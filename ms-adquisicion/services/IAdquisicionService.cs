using System.Text.Json;
using ms_adquisicion.model;

namespace ms_adquisicion.services
{
    public interface IAdquisicionService
    {
        Task<List<Adquisicion>> getListaAdquisiciones();
        Task<Adquisicion?> addAdquisicion(JsonElement jItem);
        Task<Adquisicion?> updAdquisicion(JsonElement jItem);
        Task<ResultVoid> delAdquisicion(int id);
        Task<Adquisicion?> getAdquisicionById(int id);
    }
}
