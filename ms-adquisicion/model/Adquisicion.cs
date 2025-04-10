using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_adquisicion.model
{
    [Table("Adquisicion")]
    [Serializable]
    public class Adquisicion
    {
        // Constructor que inicializa propiedades con valores por defecto
        public Adquisicion()
        {
            Presupuesto = 0;
            Unidad = string.Empty;
            TipoBienServicio = string.Empty;
            Cantidad = 0;
            ValorUnitario = 0;
            ValorTotal = 0;
            FechaAdquisicion = DateTime.Now;
            Proveedor = string.Empty;
            Documentacion = string.Empty;
        }

        [Key]
        [Column("Adquisicion_Id")]
        public int Id { get; set; }

        [Column("Presupuesto")]
        public decimal Presupuesto { get; set; }

        [Column("Unidad")]
        public string Unidad { get; set; }

        [Column("Tipo_Bien_Servicio")]
        public string TipoBienServicio { get; set; }

        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [Column("Valor_Unitario")]
        public decimal ValorUnitario { get; set; }

        [Column("Valor_Total")]
        public decimal ValorTotal { get; set; }

        [Column("Fecha_Adquisicion")]
        public DateTime FechaAdquisicion { get; set; }

        [Column("Proveedor")]
        public string Proveedor { get; set; }

        [Column("Documentacion")]
        public string Documentacion { get; set; }
    }
}
