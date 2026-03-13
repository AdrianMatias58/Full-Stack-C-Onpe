namespace Onpe_ADO.NET.Models.Tablas
{
    public class MdlLocal
    {
        public int idLocalVotacion { get; set; }
        public int idDistrito{ get; set; }
        public MdlDistrito refDistrito { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
    }
}
