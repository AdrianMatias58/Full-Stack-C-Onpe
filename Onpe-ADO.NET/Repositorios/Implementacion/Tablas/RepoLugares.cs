using Microsoft.Data.SqlClient;
using Onpe_ADO.NET.Models.Tablas;
using Onpe_ADO.NET.Models.Vistas;
using System.Data;

namespace Onpe_ADO.NET.Repositorios.Implementacion.Tablas
{
    public class RepoLugares
    {
        private readonly String _CadenaSql = "";
        public RepoLugares(IConfiguration configuration)
        {
            _CadenaSql = configuration.GetConnectionString("cadenaSQL");
        }
        public async Task<List<MdlDepartamento>> GetMdlDepartamentos()
        {
            List<MdlDepartamento> _Lista = new List<MdlDepartamento>();
            using (var conexion = new SqlConnection(_CadenaSql))
            {
                await conexion.OpenAsync();
                SqlCommand sql = new SqlCommand("usp_getDepartamentos", conexion);
                sql.CommandType = CommandType.StoredProcedure;
                using (var rd = await sql.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        _Lista.Add(new MdlDepartamento
                        {
                            idDepartamento = Convert.ToInt32(rd["idDepartamento"]),
                            Detalle = rd["Detalle"].ToString().Trim()
                        });
                    }
                }

            }
            return _Lista;
        }

        public async Task<List<MdlDistrito>> GetMdlDistritos(int idProvincia)
        {
            List<MdlDistrito> _Lista = new List<MdlDistrito>();
            using (var conexion = new SqlConnection(_CadenaSql))
            {
                await conexion.OpenAsync();
                SqlCommand sql = new SqlCommand("usp_getDistritos", conexion);
                sql.Parameters.AddWithValue("@idProvincia", idProvincia);
                sql.CommandType = CommandType.StoredProcedure;
                using (var rd = await sql.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        _Lista.Add(new MdlDistrito
                        {
                            idDistrito = Convert.ToInt32(rd["idDistrito"]),
                            Detalle = rd["Detalle"].ToString().Trim()
                        });
                    }
                }

            }
            return _Lista;
        }

        public async Task<List<MdlProvincia>> GetMdlProvincia(int idDepartamento)
        {
            List<MdlProvincia> _Lista = new List<MdlProvincia>();
            using (var conexion = new SqlConnection(_CadenaSql))
            {
                await conexion.OpenAsync();
                SqlCommand sql = new SqlCommand("usp_getProvincias", conexion);
                sql.Parameters.AddWithValue("@idDepartamento", idDepartamento);
                sql.CommandType = CommandType.StoredProcedure;
                using (var rd = await sql.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        _Lista.Add(new MdlProvincia
                        {
                            idProvincia = Convert.ToInt32(rd["idProvincia"]),
                            Detalle = rd["Detalle"].ToString().Trim()
                        });
                    }
                }

            }
            return _Lista;
        }

        public async Task<List<MdlLocal>> getLocalVotacion(int idDistrito)
        {
            List<MdlLocal> _Lista = new List<MdlLocal>();
            using (var conexion = new SqlConnection(_CadenaSql))
            {
                await conexion.OpenAsync();
                SqlCommand sql = new SqlCommand("usp_getLocalesVotacion", conexion);
                sql.Parameters.AddWithValue("@idDistrito", idDistrito);
                sql.CommandType = CommandType.StoredProcedure;
                using (var rd = await sql.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        _Lista.Add(new MdlLocal
                        {
                            idLocalVotacion = Convert.ToInt32(rd["idLocalVotacion"]),
                            RazonSocial = rd["RazonSocial"].ToString()
                        });
                    }
                }
            }
            return _Lista;
        }
    }
}
