using RCP.Data.Entities;
using RCP.Repository;

namespace RCP.Business;

public interface ISupplierBusiness
{
    Task<Supplier> AddSupplierAsync(Supplier supplier);
    Task<Supplier> GetSupplierAsync(int id);
}

public class SupplierBusiness : ISupplierBusiness
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierBusiness(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<Supplier> GetSupplierAsync(int id)
    {
        var supplier = await _supplierRepository.GetSupplierAsync(id);
        supplier.Country = "Costa Rica";
        supplier.Phone = string.Empty;

        if (supplier.City == "Alajuela")
        {
            //haga tanto
        }
        else if (supplier.City == "San Jose")
        {
            // haga lo otro
        }
        return supplier;
    }

    public async Task<Supplier> AddSupplierAsync(Supplier supplier)
    {
        supplier.LastModified = DateTime.UtcNow;
        supplier.ModifiedBy = "Admin";

        var result = await _supplierRepository.AddSupplierAsync(supplier);
        if (!result) throw new Exception("Error al intentar guardar el Supplier");

        return await _supplierRepository.GetSupplierAsync(supplier.SupplierId);
    }
}
