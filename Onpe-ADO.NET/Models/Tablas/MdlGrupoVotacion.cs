namespace Onpe_ADO.NET.Models.Tablas
{
    public class MdlGrupoVotacion
    {
        public int idLocalVotacion { get; set; }
        public MdlLocal refLocal { get; set; }
        public string idGrupoVotacion { get; set; }
        public string nCopia { get; set; }
        public int idEstadoActa { get; set; }
        public int? ElectoresHabiles { get; set; }
        public int? TotalVotantes { get; set; }
        public int? P1 { get; set; }
        public int? P2 { get; set; }
        public int? VotosBlancos { get; set; }
        public int? VotosNulos { get; set; }
        public int? VotosImpugnados { get; set; }
    }
}
