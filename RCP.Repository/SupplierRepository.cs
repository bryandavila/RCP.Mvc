using RCP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Repository;

public interface ISupplierRepository
{
    Task<bool> AddSupplierAsync(Supplier supplier);
    Task<Supplier> GetSupplierAsync(int id);
}

public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
{
    public async Task<Supplier> GetSupplierAsync(int id)
    {
        var suppliers = await ReadAsync();
        return suppliers.SingleOrDefault(x => x.SupplierId == id);
    }

    public async Task<bool> AddSupplierAsync(Supplier supplier)
    {
        return await CreateAsync(supplier);
    }
}
