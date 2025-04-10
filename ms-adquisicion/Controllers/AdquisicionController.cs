using Microsoft.AspNetCore.Mvc;
using ms_adquisicion.model;
using ms_adquisicion.services; // Namespace de tu interfaz IAdquisicionService
using System.Text.Json;
using ms_adquisicion.services;
namespace ms_adquisicion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdquisicionController : ControllerBase
    {
        private readonly ILogger<AdquisicionController> _logger;
        private readonly IAdquisicionService _service;

        // Constructor inyecta el servicio y logger
        public AdquisicionController(ILogger<AdquisicionController> logger, IAdquisicionService service)
        {
            _logger = logger;
            _service = service;
        }

        // Obtener lista de adquisiciones
        [HttpGet]
        [Route("adquisiciones")]
        public async Task<List<Adquisicion>> GetListaAdquisiciones()
        {
            _logger.LogInformation("Obteniendo lista de adquisiciones");
            return await _service.getListaAdquisiciones();
        }

        // Obtener una adquisición por ID
        [HttpGet]
        [Route("adquisicion/{id}")]
        public async Task<Adquisicion?> GetAdquisicionById(int id)
        {
            _logger.LogInformation("Obteniendo adquisición por ID: {0}", id);
            return await _service.getAdquisicionById(id);
        }

        // Crear una nueva adquisición
        [HttpPost]
        [Route("adquisicion")]
        public async Task<Adquisicion?> AddAdquisicion([FromBody] JsonElement item)
        {
            _logger.LogInformation("Creando nueva adquisición");
            return await _service.addAdquisicion(item);
        }

        // Actualizar una adquisición existente
        [HttpPut]
        [Route("adquisicion")]
        public async Task<Adquisicion?> UpdateAdquisicion([FromBody] JsonElement item)
        {
            _logger.LogInformation("Actualizando adquisición");
            return await _service.updAdquisicion(item);
        }

        // Eliminar una adquisición por ID
        [HttpDelete]
        [Route("adquisicion/{id}")]
        public async Task<ResultVoid> DeleteAdquisicion(int id)
        {
            _logger.LogInformation("Eliminando adquisición con ID: {0}", id);
            return await _service.delAdquisicion(id);
        }
    }
}
