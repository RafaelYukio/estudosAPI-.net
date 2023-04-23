namespace Estudos.Application.DTOs.Request
{
    public record CreateProductRequest(int Code, string Name, int Qtd, string DescriptionDetails, string CategoryName, List<string> TagNames);
}
