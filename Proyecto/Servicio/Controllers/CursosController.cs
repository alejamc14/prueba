﻿using Servicio.Clases;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicio.Controllers
{
    [EnableCors(origins: "https://localhost:44365", headers: "*", methods: "*")]
    [RoutePrefix("api/Cursos")]
    public class CursosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXCodigo")]
        public Curso ConsultarXCodigo(int Codigo)
        {
            clsCurso curso = new clsCurso();
            return curso.Consultar(Codigo);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsCurso curso = new clsCurso();
            return curso.llenarTabla();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Curso Curso)
        {
            clsCurso curso = new clsCurso();
            curso.curso = Curso;
            return curso.Insertar();

        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Curso Curso)
        {
            clsCurso curso = new clsCurso();
            curso.curso = Curso;
            return curso.Actualizar();

        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Curso Curso)
        {
            clsCurso curso = new clsCurso();
            curso.curso = Curso;
            return curso.Eliminar();
        }
    }
}