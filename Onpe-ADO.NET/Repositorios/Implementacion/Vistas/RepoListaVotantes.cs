using Microsoft.Data.SqlClient;
using Onpe_ADO.NET.Models.Vistas;
using System.Collections.Concurrent;
using System.Data;

namespace Onpe_ADO.NET.Repositorios.Implementacion.Vistas
{
    public class RepoListaVotantes
    {
        private readonly String _CadenaSql = "";
        public RepoListaVotantes(IConfiguration configuration)
        {
            _CadenaSql = configuration.GetConnectionString("cadenaSQL");
        }
        public async Task<List<MdlListaVotantes>> ListaVotosPeru()
        {
            List<MdlListaVotantes> _Lista= new List<MdlListaVotantes>();
            using (var conexion = new SqlConnection(_CadenaSql))
            {
                await conexion.OpenAsync();
                SqlCommand sql = new SqlCommand("usp_getVotosPeru", conexion);
                sql.CommandType = CommandType.StoredProcedure;
                using (var rd = await sql.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        _Lista.Add(new MdlListaVotantes
                        {
                            idDepartamento = Convert.ToInt32(rd["id"]),
                            Departamento = rd["DPD"].ToString().Trim(),
                            TV = Convert.ToInt32(rd["TV"]),
                            PTV = rd["PTV"].ToString().Trim(),
                            TA = Convert.ToInt32(rd["TA"]),
                            PTA = rd["PTA"].ToString().Trim(),
                            EH = Convert.ToInt32(rd["EH"])
                        });
                    }
                }
            }

            return _Lista;
        }
    
        public async Task<List<MdlListaVotantes>> ListaVotosExtranjero()
        {
            List<MdlListaVotantes> _Lista = new List<MdlListaVotantes>();
            using (var conexion = new SqlConnection(_CadenaSql))
            {
                await conexion.OpenAsync();
                SqlCommand sql = new SqlCommand("usp_getVotosExtranjero", conexion);
                sql.CommandType = CommandType.StoredProcedure;
                using (var rd = await sql.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        _Lista.Add(new MdlListaVotantes
                        {
                            idDepartamento = Convert.ToInt32(rd["id"]),
                            Departamento = rd["DPD"].ToString().Trim(),
                            TV = Convert.ToInt32(rd["TV"]),
                            PTV = rd["PTV"].ToString().Trim(),
                            TA = Convert.ToInt32(rd["TA"]),
                            PTA = rd["PTA"].ToString().Trim(),
                            EH = Convert.ToInt32(rd["EH"])
                        });
                    }
                }
            }
            return _Lista;
        }
    }
}
