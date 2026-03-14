using Microsoft.AspNetCore.Mvc;
using Onpe_ADO.NET.Models.Tablas;
using Onpe_ADO.NET.Models.Vistas;
using Onpe_ADO.NET.Repositorios;
using Onpe_ADO.NET.Repositorios.Implementacion.Tablas;
using Onpe_ADO.NET.Repositorios.Implementacion.Vistas;

namespace Onpe_ADO.NET.Controllers
{
    [Route("Actas")]
    public class ActasController : Controller
    {
        private readonly RepoLugares _repoL;
        public ActasController( IConfiguration configuration)
        {
            _repoL= new RepoLugares(configuration);

        }
        [HttpGet("ActUbigeo")]
        public IActionResult ActUbigeo()
        {
            return View("Actas");
        }
        [HttpGet("ActNumero")]
        public IActionResult ActNumero()
        {
            return View();
        }
        [HttpGet("GetDepartamento")]
        public async Task<IActionResult> GetDepartamento(string ambito)
        {
            var datos = await  _repoL.GetMdlDepartamentos();
            var lista = new List<MdlDepartamento>();
            foreach( var d in datos)
            {
                bool agregar = ambito == "PERU" ? d.idDepartamento<=25 : d.idDepartamento>25;
                if (agregar)
                {
                    lista.Add(new MdlDepartamento
                    {
                        idDepartamento = d.idDepartamento,
                        Detalle = d.Detalle
                    });
                }
            }
            return Json(lista);
        }
        [HttpGet("GetDistritos")]
        public async Task<IActionResult> GetDistritos(int idProvincia)
        {
            var datos = await _repoL.GetMdlDistritos(idProvincia);
            return Json(datos);
        }
        [HttpGet("GetProvincia")]
        public async Task<IActionResult> GetProvincia(int idDepartamento)
        {
            var datos = await _repoL.GetMdlProvincia(idDepartamento);
            return Json(datos);
        }

        [HttpGet("GetLocalVotacion")]
        public async Task<IActionResult> GetLocalV(int idDistrito)
        {
            var datos = await _repoL.getLocalVotacion(idDistrito);
            return Json(datos);
        }

    }
}
