using System;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

public class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogBrandRepository> _logger;
    public CatalogBrandRepository(
	    IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
	    ILogger<CatalogBrandRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> Add(string brand)
    {
        var item1 = new CatalogBrand
        {
            Brand = brand,
        };
        var item = await _dbContext.AddAsync(item1);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task Delete(int id)
    {
        var p = _dbContext.CatalogBrands.Include(x => x.Id == id);
        var item = _dbContext.Remove(p);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Update(int id, string brand)
    {
        var brands = await _dbContext.CatalogBrands.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        if (brands is not null)
        {
            brands.Brand = brand;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }
}
