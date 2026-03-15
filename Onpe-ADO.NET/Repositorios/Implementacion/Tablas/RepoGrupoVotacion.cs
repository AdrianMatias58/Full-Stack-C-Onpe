using Microsoft.Data.SqlClient;
using Onpe_ADO.NET.Models.Tablas;
using System.Collections;
using System.Data;

namespace Onpe_ADO.NET.Repositorios.Implementacion.Tablas
{
    public class RepoGrupoVotacion
    {
        private readonly String _CadenaSql = "";
        public RepoGrupoVotacion(IConfiguration configuration)
        {
            _CadenaSql = configuration.GetConnectionString("cadenaSQL");
        }
        public async Task<List<MdlGrupoVotacion>> GetMdlGrupoByLocal(int idLocacion) 
        {
            List<MdlGrupoVotacion> _Lista = new List<MdlGrupoVotacion>();
            using (var conexion = new SqlConnection(_CadenaSql)) { 
                await conexion.OpenAsync();
                SqlCommand sql = new SqlCommand("usp_getGruposVotacion", conexion);
                sql.Parameters.AddWithValue("@idLocalVotacion", idLocacion);
                sql.CommandType = CommandType.StoredProcedure;
                using (var rd = await sql.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        _Lista.Add(new MdlGrupoVotacion
                        {
                            idGrupoVotacion = rd["idGrupoVotacion"].ToString(),
                        });
                    }
                }
            }
            return _Lista;
        }

        public async Task<MdlGrupoVotacion> GetMdlGrupo(string idGrupo)
        {
            MdlGrupoVotacion modelo = null;
            using (var conexion = new SqlConnection(_CadenaSql))
            {
                await conexion.OpenAsync();
                SqlCommand sql = new SqlCommand("usp_getGrupoVotacion", conexion);
                sql.Parameters.AddWithValue("@idGrupoVotacion", idGrupo);
                sql.CommandType = CommandType.StoredProcedure;
                using (var rd = await sql.ExecuteReaderAsync())
                {
                    if (await rd.ReadAsync())
                    {
                        modelo = new MdlGrupoVotacion
                        {
                            Departamento = rd["Departamento"].ToString(),
                            Provincia = rd["Provincia"].ToString(),
                            Distrito = rd["Distrito"].ToString(),
                            RazonSocial = rd["RazonSocial"].ToString(),
                            Direccion = rd["Direccion"].ToString(),
                            nCopia = rd["nCopia"].ToString(),
                            idEstadoActa = Convert.ToInt32(rd["idEstadoActa"]),
                            ElectoresHabiles = Convert.ToInt32(rd["ElectoresHabiles"]),
                            TotalVotantes = Convert.ToInt32(rd["TotalVotantes"]),
                            P1 = Convert.ToInt32(rd["P1"]),
                            P2 = Convert.ToInt32(rd["P2"]),
                            VotosBlancos = Convert.ToInt32(rd["VotosBlancos"]),
                            VotosNulos = Convert.ToInt32(rd["VotosNulos"]),
                            VotosImpugnados = Convert.ToInt32(rd["VotosImpugnados"]),
                            idGrupoVotacion = rd["idGrupoVotacion"].ToString(),
                        };
                    }
                }
            }
            return modelo;
        }
    }
}
