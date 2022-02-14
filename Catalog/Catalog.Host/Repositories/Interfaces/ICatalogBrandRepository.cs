using System;

public interface ICatalogBrandRepository
{
    Task<int?> Add(string brand);
    Task Delete(int id);
}
