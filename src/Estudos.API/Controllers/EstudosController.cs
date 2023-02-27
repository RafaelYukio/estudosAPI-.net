using Estudos.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net;
using System.Runtime.CompilerServices;
using static Estudos.API.Controllers.EstudosController;

namespace Estudos.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class EstudosController : Controller
    {
        // Injetando configurations para obter dados do appsettings.json
        // https://stackoverflow.com/questions/73402112/how-to-access-a-value-from-appsettings-json-in-asp-net-core-6-controller
        // https://stackoverflow.com/questions/31453495/how-to-read-appsettings-values-from-a-json-file-in-asp-net-core/67292524#67292524

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EstudosController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        // Infos úteis

        // https://pt.stackoverflow.com/questions/270818/asp-net-web-api-from-uri-e-from-body-quando-utilizar
        // Por padrão, o framework vai mapear quase todos objetos como um JSON que venha no corpo da requisição (DateTime, Guid, são exemplos de objetos que ele vai tentar pegar da URI)
        // e todo tipo simples/primitivo como um valor que vai vim na URI da requisição. Logo, se você deseja fazer o inverso, você precisa especificar de onde esta vindo a requisição

        // Teste de retorno com query
        [HttpGet("teste-query")]
        public IActionResult TesteQuery(string query)
        {
            return Ok("A query inserida é: " + query);
        }

        // Teste de retorno com rota
        [HttpGet("teste-rota/{rota}")]
        public IActionResult TesteRota(string rota)
        {
            return Ok("A rota inserida é: " + rota);
        }

        // Teste de requisição com objeto no body
        // https://stackoverflow.com/questions/43421126/how-to-use-httpclient-to-send-content-in-body-of-get-request
        // Please read the caveats at the end of this answer as to why HTTP GET requests with bodies are, in general, not advised.
        public class ObjetoTeste
        {
            public int Number { get; set; }
            public string String { get; set; }
        }

        [HttpPost("teste-objeto")]
        public IActionResult TesteObjeto(ObjetoTeste objetoTeste)
        {
            return Ok("Objecto recebido, Número = " + objetoTeste.Number + ", String: " + objetoTeste.String);
        }

        // Teste de requisição com variável no header
        // Extrair variável do header da requisição:
        // https://code-maze.com/how-to-extract-custom-header-in-asp-net-core-web-api/
        // Enviar variável no header:
        // https://code-maze.com/aspnetcore-add-custom-headers/

        [HttpGet("teste-header")]
        public IActionResult TesteHeader()
        {
            //Request.Headers.TryGetValue("TesteHeader", out StringValues headerValue);
            string response = Request.Headers["TesteHeader"].ToString();
            return Ok(response);
        }

        // Teste de CRUD em memória
        public class Product
        {
            public int Code { get; set; }
            public string Name { get; set; }
            public int Qtd { get; set; }
        }

        // O static mantém a classe a cada requisição API e fica global
        public static class ProductRepository
        {
            public static List<Product> Products { get; set; } = new();

            public static void Init(IConfiguration configurations)
            {
                Products = configurations.GetSection("ProductsTest").Get<List<Product>>();
            }

            public static void Add(Product product)
            {
                if (product is not null)
                {
                    Products.Add(product);
                }
            }

            public static void AddRange(List<Product> products)
            {
                    Products.AddRange(products);
            }

            public static Product GetByCode(int code)
            {
                return Products.FirstOrDefault(product => product.Code == code);
            }

            public static void Remove(int code)
            {
                Products.Remove(GetByCode(code));
            }

        }

        [HttpPost("crud/post")]
        public IActionResult CRUDPost(Product product)
        {
            ProductRepository.Add(product);
            //return Ok(ProductRepository.Products.FirstOrDefault(productRep => productRep.Code == product.Code));

            // Resposta do endpoint é o product.Code (segundo parâmetro) e no header a URI para obter este produto criado (primeiro parâmetro)
            return Created($"/crud/get-by-code-rota/{product.Code}", product.Code);
        }

        [HttpPost("crud/post-range")]
        public IActionResult CRUDPostRange(List<Product> products)
        {
            ProductRepository.AddRange(products);
            return Created($"/crud/get-all/", products.Select(product => product.Code).ToList());
        }

        [HttpGet("crud/get-all")]
        public IActionResult CRUDGetAll()
        {
            return Ok(ProductRepository.Products);
        }

        [HttpGet("crud/get-by-code-query")]
        public IActionResult CRUDGetByCodeQuery(int code)
        {
            Product product = ProductRepository.GetByCode(code);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpGet("crud/get-by-code-rota/{code}")]
        public IActionResult CRUDGetByCodeRota(int code)
        {
            Product product = ProductRepository.GetByCode(code);
            return product is null ? NotFound() : Ok(product);
        }

        // Ver sobre classe Delta para patches
        // https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnet.odata.delta?view=odata-aspnetcore-7.0
        // Com JsonPatchDocument:
        // https://www.coderschmoder.com/implement-http-patch-in-asp-net-using-jsonpatch/
        // Diferença entre PUT e Patch:
        // https://stackoverflow.com/questions/28459418/use-of-put-vs-patch-methods-in-rest-api-real-life-scenarios

        // Método estático (Extension Methods) para ser acessado em qualquer parte
        // https://balta.io/blog/csharp-extension-methods
        // Teste "With extension method" para atualizar dados do objeto (não recomendado desta forma, apenas para entendimento):

        [HttpPatch("crud/patch/{code}")]
        public IActionResult CRUDGPatch(int code, Product product)
        {
            Product productRep = ProductRepository.GetByCode(code);
            productRep.With(p =>
            {
                p.Name = product.Name;
                p.Qtd = product.Qtd;
            });
            return Ok(ProductRepository.GetByCode(code));
        }

        [HttpDelete("crud/delete/{code}")]
        public IActionResult CRUDGDelete(int code)
        {
            Product productRep = ProductRepository.GetByCode(code);
            ProductRepository.Remove(code);
            return NoContent();
        }

        [HttpGet("configurations")]
        public IActionResult Configurations()
        {
            return Ok(_configuration.AsEnumerable());
            //return Ok(_configuration.GetSection("ProductsTest").Get<List<Product>>());
            //return Ok(_configuration.GetValue<String>("ProductsTest:0:Code"));
        }

        [HttpGet("environment")]
        public IActionResult Environment()
        {
            return Ok($"Environment: {_webHostEnvironment.EnvironmentName}");
        }


    }
}
