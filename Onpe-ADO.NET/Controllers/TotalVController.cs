using Microsoft.AspNetCore.Mvc;
using Onpe_ADO.NET.Models.Vistas;
using Onpe_ADO.NET.Repositorios;
using Onpe_ADO.NET.Repositorios.Implementacion.Vistas;

namespace Onpe_ADO.NET.Controllers
{
    [Route("TotalV")]
    public class TotalVController : Controller
    {
        private readonly IGenerico<MdlTotalVotos> _totalV;
        private readonly RepoListaVotantes _repoListaV;

        public TotalVController(IGenerico<MdlTotalVotos> totalV,IConfiguration configuration )
        {
            _totalV = totalV;
            _repoListaV = new RepoListaVotantes(configuration);

        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View("participacion");
        }
        [HttpGet("VistaDepartamentoV")]
        public IActionResult VistaDepartamentoV()
        {
            return View("VDepartamento");
        }
        [HttpGet("VistaProvinciaV")]
        public IActionResult VistaProvinciaV()
        {
            return View("VProvincia");
        }
        [HttpGet("VistaDistritroV")]
        public IActionResult VistaDistritroV()
        {
            return View("VistaDistritro");
        }
        [HttpGet("GetTotalVProvincia")]
        public async Task<IActionResult> GetTotalVProvincia(string provincia)
        {
            try
            {
                var Datos = await _repoListaV.ListaVotosProvincia(provincia);
                return Json(Datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = ex.Message,
                    detalle = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }

        }
        [HttpGet("GetTotalVDepartamento")]
        public async Task<IActionResult> GetTotalVDepartamento(string Departamento) {
            try
            {
                var Datos = await _repoListaV.ListaVotosDepartamento(Departamento);
                return Json(Datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = ex.Message,
                    detalle = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }

        }
        [HttpGet("GetTotalVotos")]
        public async Task<IActionResult> GetTotalVotos()
        {
            try
            {
                var Datos = await _totalV.Lista();
                return Json(Datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = ex.Message,
                    detalle = ex.InnerException?.Message,  
                    stackTrace = ex.StackTrace
                });
            }
        }
        [HttpGet("GetVotosPeru")]
        public async Task<IActionResult> GetVotosPeru()
        {
            try
            {
                var Datos = await _repoListaV.ListaVotosPeru();
                return PartialView("_TablaVotosPeru",Datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = ex.Message,
                    detalle = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
        [HttpGet("GetVotosExtranjero")]
        public async Task<IActionResult> GetVotosExtranjero()
        {
            try
            {
                var Datos = await _repoListaV.ListaVotosExtranjero();
                return PartialView("_TablaVotosPeru", Datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = ex.Message,
                    detalle = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
        
        [HttpGet("GetVotosExtranjeroJson")]
        public async Task<IActionResult> GetVotosExtranjeroJson()
        {
            try
            {
                var Datos = await _repoListaV.ListaVotosExtranjero();
                return Json(Datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = ex.Message,
                    detalle = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
        [HttpGet("GetVotosPeruJson")]
        public async Task<IActionResult> GetVotosPeruJson()
        {
            try
            {
                var Datos = await _repoListaV.ListaVotosPeru();
                return Json(Datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = ex.Message,
                    detalle = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
    }
}
