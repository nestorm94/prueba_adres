using Microsoft.EntityFrameworkCore;
using ms_adquisicion.database;
using ms_adquisicion.model;
using System.Globalization;
using System.Text.Json;
using ms_adquisicion.Exceptions;

namespace ms_adquisicion.services;

    // Clase que implementa los métodos definidos en la interfaz IAdquisicionService
    public class AdquisicionService : IAdquisicionService

    {
        // Contexto de base de datos para acceder a la tabla de Adquisiciones
        private readonly DBAdquisicionContext _context;
        
        // Logger para registrar eventos durante la ejecución
        private readonly ILogger<AdquisicionService> _logger;

        // Fecha de referencia para el 1 de enero de 1900
        private readonly DateTime milNovecientos = DateTime.ParseExact("1900-01-01", "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);

        // Constructor que inyecta las dependencias: configuración, logger y contexto de base de datos
        public AdquisicionService(IConfiguration config, ILogger<AdquisicionService> logger, DBAdquisicionContext context)
        {
            // Se asegura de que las dependencias no sean nulas
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            // Log de inicio
            this._logger.LogInformation("Inicio AdquisicionService {0}", milNovecientos);
            
            
        }

        // Método para obtener la lista de todas las adquisiciones
        public async Task<List<Adquisicion>> getListaAdquisiciones()
        {
            // Devuelve todas las adquisiciones de la base de datos
            return await this._context.Adquisiciones.ToListAsync();
        }

        // Método para agregar una nueva adquisición
        public async Task<Adquisicion?> addAdquisicion(JsonElement jItem)
        {
            try
            {
                // Deserializa el Json recibido en un objeto Adquisicion
                Adquisicion? item = jItem.Deserialize<Adquisicion>();
                
                // Si el objeto no se puede deserializar, se retorna null
                if (item == null)
                    return null;

                // Verifica si ya existe una adquisición con el mismo Presupuesto
                if (await this._context.Adquisiciones.AnyAsync(a => a.Presupuesto == item.Presupuesto))
                    throw new AppException("Ya existe la adquisición con ese Presupuesto.");

                // Añade la nueva adquisición a la base de datos y guarda los cambios
                Adquisicion xItem = this._context.Adquisiciones.Add(item).Entity;
                await this._context.SaveChangesAsync();
                
                return xItem;
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lanza una excepción personalizada con el mensaje de error
                throw new AppException("Error al crear la adquisición: " + ex.Message);
            }
        }

        // Método para actualizar una adquisición existente
        public async Task<Adquisicion?> updAdquisicion(JsonElement jItem)
        {
            try
            {
                // Deserializa el Json recibido en un objeto Adquisicion
                Adquisicion? item = jItem.Deserialize<Adquisicion>();
                
                // Si el objeto no se puede deserializar, se retorna null
                if (item == null)
                    return null;

                // Verifica si ya existe otra adquisición con el mismo nombre (excluyendo la actual)
                if (await this._context.Adquisiciones.AnyAsync(a => a.Id != item.Id && a.Presupuesto == item.Presupuesto))
                    throw new AppException("""Ya existe otra adquisición con ese Presupuesto.""");

                // Actualiza la adquisición en la base de datos y guarda los cambios
                Adquisicion xItem = this._context.Adquisiciones.Update(item).Entity;
            global::System.Object value = await this._context.SaveChangesAsync();
                
                return xItem;
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lanza una excepción personalizada con el mensaje de error
                throw new AppException("Error al actualizar la adquisición: " + ex.Message);
            }
        }

        // Método para eliminar una adquisición por su ID
        public async Task<ResultVoid> delAdquisicion(int Id)
        {
            try
            {
                // Elimina la adquisición de la base de datos usando su ID
                int deleteds = await this._context.Adquisiciones.Where(a => a.Id == Id).ExecuteDeleteAsync();
                
                // Devuelve un objeto que describe la operación realizada
                return new ResultVoid { operation = $"Eliminar Adquisición {Id}", description = $"Se eliminaron {deleteds} registros." };
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lanza una excepción personalizada con el mensaje de error
                throw new AppException("Error al eliminar la adquisición: " + ex.Message);
            }
        }

        // Método para obtener una adquisición por su ID
        public async Task<Adquisicion?> getAdquisicionById(int Id)
        {
            // Devuelve la adquisición con el ID especificado o null si no se encuentra
            return await this._context.Adquisiciones.FirstOrDefaultAsync(a => a.Id == Id);
        }
    }

