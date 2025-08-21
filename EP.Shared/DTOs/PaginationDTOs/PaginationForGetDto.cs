namespace EP.Shared.DTOs.PaginationDTOs;

public class PaginationForGetDto
{
    private readonly int _maxPageSize = 50;

    private int _pageSize = 20; 

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = Math.Min(_maxPageSize, value);
    }

    public int PageId { get; set; } = 1;
}