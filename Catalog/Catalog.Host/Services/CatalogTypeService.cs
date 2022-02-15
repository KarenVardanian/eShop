using System;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;

    public CatalogTypeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
    }

    public async Task<int?> AddAsync(string type)
    {
        return await ExecuteSafeAsync(() => _catalogTypeRepository.Add(type));
    }

    public async Task DeleteAsync(int id)
    {
        await ExecuteSafeAsync(() => _catalogTypeRepository.Delete(id));
    }

    public async Task<int?> UpdateAsyncUpdate(int id, string type)
    {
        return await ExecuteSafeAsync(() => _catalogTypeRepository.Update(id, type));
    }
}
