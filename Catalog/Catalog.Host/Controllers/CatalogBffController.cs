using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly IOptions<CatalogConfig> _config;
    private readonly ApplicationDbContext _applictionDbContetx;
    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        IOptions<CatalogConfig> config,
        ApplicationDbContext applicationDb)
    {
        _logger = logger;
        _catalogService = catalogService;
        _config = config;
        _applictionDbContetx = applicationDb;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult GetBrands()
    {
        _logger.LogInformation($"User Id {User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value}");
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult GetById(int id)
    {
       var result = _applictionDbContetx.CatalogItems.FirstOrDefaultAsync(x => x.Id == id);
       _logger.LogInformation($"User Id {result.Id}");
       return Ok();
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult GetByBrand(string brand)
    {
        var result = _applictionDbContetx.CatalogItems.Include(x => x.CatalogBrand.Brand == brand).FirstAsync();
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult GetByType(string type)
    {
        var result = _applictionDbContetx.CatalogItems.Include(x => x.CatalogType.Type == type).FirstAsync();
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult GetTypes(string brand)
    {
        var result = _applictionDbContetx.CatalogItems.Select(x => x.CatalogType).ToListAsync();
        return Ok();
    }
}