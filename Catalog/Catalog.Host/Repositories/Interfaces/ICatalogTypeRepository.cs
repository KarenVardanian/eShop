using System;

public interface ICatalogTypeRepository
{
    Task<int?> Add(string type);
    Task Delete(int id);
}
