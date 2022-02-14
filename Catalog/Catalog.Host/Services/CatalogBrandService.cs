using System;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;

public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;

    public CatalogBrandService(
	    IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
	    ILogger<BaseDataService<ApplicationDbContext>> logger,
	    ICatalogBrandRepository catalogBrandRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
    }

    public Task<int?> AddAsync(string brand)
    {
         return ExecuteSafeAsync(() => _catalogBrandRepository.Add(brand));
    }

    public async Task DeleteAsync(int id)
    {
        await ExecuteSafeAsync(() => _catalogBrandRepository.Delete(id));
    }
}
