﻿using System;
using Catalog.Host.Data;
using Catalog.Host.Repositories;

public class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogTypeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public Task<int?> Add(string type)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
        var p = _dbContext.CatalogItems.Include(x => x.Id == id);
        var item = _dbContext.Remove(p);
        await _dbContext.SaveChangesAsync();
     }

    public async Task<int?> Update(int id, string type)
    {
        var catalogType = await _dbContext.CatalogTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (catalogType is not null)
        {
            catalogType.Type = type;
            await _dbContext.SaveChangesAsync();
            return catalogType.Id;
        }
        else
        {
            return 0;
        }
    }
}