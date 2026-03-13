namespace Onpe_ADO.NET.Models.Tablas
{
    public class MdlProvincia
    {
        public int idProvincia { get; set; }
        public int idDepartamento { get; set; }
        public MdlDepartamento refDepartamento{ get; set; }
        public string Detalle { get; set; }
    }
}
