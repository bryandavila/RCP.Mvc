using APW.Architecture;
using PAW.Architecture.Providers;
using RCP.Data.Entities;

namespace RCP.MVC.Services;

public interface ISupplierService
{
    Task<Supplier> GetSupplierFromServiceAsync(int id);
}

public class SupplierService : ISupplierService
{
    private readonly IRestProvider _restProvider;

    public SupplierService(IRestProvider restProvider)
    {
        _restProvider = restProvider;
    }

    public async Task<Supplier> GetSupplierFromServiceAsync(int id)
    {
        var data = await _restProvider.GetAsync($"https://localhost:7177/SupplierApi/{id}", null);
        var result = JsonProvider.DeserializeSimple<Supplier>(data);
        return result;
    }

}
