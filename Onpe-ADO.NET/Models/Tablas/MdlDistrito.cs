namespace Onpe_ADO.NET.Models.Tablas
{
    public class MdlDistrito
    {
        public int idDistrito { get; set; }
        public int idProvincia { get; set; }
        public MdlProvincia refProvincia{ get; set; }
        public string Detalle { get; set; }
    }
}
