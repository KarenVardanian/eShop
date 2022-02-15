using System;

public interface ICatalogBrandService
{
    Task<int?> AddAsync(string brand);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, string brand);
}
