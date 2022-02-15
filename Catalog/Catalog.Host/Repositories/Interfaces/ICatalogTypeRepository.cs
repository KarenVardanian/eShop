using System;

public interface ICatalogTypeRepository
{
    Task<int?> Add(string type);
    Task Delete(int id);
    Task<int?> Update(int id, string type);
}
