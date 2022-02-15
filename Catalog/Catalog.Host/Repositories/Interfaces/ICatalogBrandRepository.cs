using System;

public interface ICatalogBrandRepository
{
    Task<int?> Add(string brand);
    Task Delete(int id);
    Task<bool> Update(int id, string brand);
}
