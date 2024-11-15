using Servicio.Models;
using Servicio_Proyecto.Clases;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Servicio_Proyecto.Controllers
{
    [RoutePrefix("api/Estudiantes")]
    [EnableCors(origins: "https://localhost:44365", headers: "*", methods: "*")]
    public class EstudiantesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Estudiante estudiante)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.estudiante = estudiante;
            return _estudiante.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Estudiante estudiante)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.estudiante = estudiante;
            return _estudiante.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Estudiante estudiante)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.estudiante = estudiante;
            return _estudiante.Eliminar();
        }

        [HttpGet]
        [Route("ConsultarXDocumento")]
        public Estudiante ConsultarXDocumento(string Documento)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            return _estudiante.Consultar(Documento);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsEstudiante _estudiante = new clsEstudiante();
            return _estudiante.LlenarTabla();
        }
    }
}