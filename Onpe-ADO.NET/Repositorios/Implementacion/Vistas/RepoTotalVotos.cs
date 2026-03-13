using Onpe_ADO.NET.Models;
using Onpe_ADO.NET.Models.Vistas;
using Onpe_ADO.NET.Repositorios;
using System.Data;
using Microsoft.Data.SqlClient;
namespace Onpe_ADO.NET.Repositorios.Implementacion.Vistas
{
    public class RepoTotalVotos: IGenerico<MdlTotalVotos>
    {
        private readonly String _CadenaSql = "";
        public RepoTotalVotos (IConfiguration configuration)
        {
            _CadenaSql = configuration.GetConnectionString("cadenaSQL");
        }

        public async Task<List<MdlTotalVotos>> Lista()
        {
            List<MdlTotalVotos> _LisTotalVotantes= new List<MdlTotalVotos>();
            using(var conexion = new SqlConnection(_CadenaSql))
            {
                 await conexion.OpenAsync();
                SqlCommand sql = new SqlCommand("SELECT * FROM vTotalVotos", conexion);
                sql.CommandType = CommandType.Text;
                using(var rd = await sql.ExecuteReaderAsync())
                {
                    while(await rd.ReadAsync()) {
                        _LisTotalVotantes.Add(new MdlTotalVotos
                        {
                            TotalAsistentes = Convert.ToInt32(rd["TotalAsistentes"]),
                            PorcentajeTotalAsistentes = rd["PorcentajeTotalAsistentes"].ToString(),
                            TotalAusentes = Convert.ToInt32(rd["TotalAusentes"]),
                            PorcentajeTotalAusentes = rd["PorcentajeTotalAusentes"].ToString(),
                            ElectoresHabiles = Convert.ToInt32(rd["ElectoresHabiles"])
                        });
                    }
                } 
            }
            return _LisTotalVotantes;
        }
    }
}
