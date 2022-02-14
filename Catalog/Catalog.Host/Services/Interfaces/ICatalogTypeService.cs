using System;

public interface ICatalogTypeService
{
    Task<int?> AddAsync(string type);
    Task DeleteAsync(int id);
}
