namespace Oprim.Application.Dtos.PageableParams;

public class PageableParam
{
    public int Page { get; set; } = 1;
    public int TotalPage { get; set; } = 0;
    public int PageSize { get; set; } = 25;
    public string? Search { get; set; } = string.Empty;
}