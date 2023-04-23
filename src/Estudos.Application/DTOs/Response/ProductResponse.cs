namespace Estudos.Application.DTOs.Response
{
    public record ProductResponse(Guid Id, int Code, string Name, int Qtd, string Description, string Category, IEnumerable<string> Tags);
}
