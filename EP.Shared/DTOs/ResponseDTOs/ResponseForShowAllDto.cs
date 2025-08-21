namespace EP.Shared.DTOs.ResponseDTOs;

public class ResponseForShowAllDto<T>
{
    public IEnumerable<T> Data { get; set; } = new List<T>();

    public MetaDataDto Meta { get; set; } = new MetaDataDto();
}