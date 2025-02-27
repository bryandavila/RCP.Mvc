using Microsoft.AspNetCore.Mvc;
using RCP.Business;
using RCP.Data.Entities;

namespace RCP.API.Controllers;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// 
/// </remarks>
/// <param name="ProductController"></param>
[ApiController]
[Route("[controller]")]
public class SupplierApiController
{
    private readonly ISupplierBusiness _business;

    public SupplierApiController(ISupplierBusiness business)
    {
        _business = business;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}", Name = "GetSupplier")]
    public async Task<Supplier> Get(int id)
    {
        return await _business.GetSupplierAsync(id);
    }

    /// <summary>
	/// 
	/// </summary>
	/// <param name="supplier"></param>
	/// <returns></returns>
    [HttpPost("save", Name = "SaveSupplier")]
    public async Task<Supplier> Save([FromBody] Supplier supplier)
    {
        return await _business.AddSupplierAsync(supplier);
    }
}
