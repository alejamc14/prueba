using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Http.Cors;
using Servicio.Models;


namespace Servicio_Proyecto.Clases
{
    public class clsEstudiante
    {
        AcademiaSistemasEntities dbAcademia = new AcademiaSistemasEntities();

        public Estudiante estudiante { get; set; }

        public string Insertar()
        {
            try
            {
                dbAcademia.Estudiantes.Add(estudiante);
                dbAcademia.SaveChanges();
                return "Se grabó el estudiante " + estudiante.Nombre + " " + estudiante.Apellido;
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Estudiante _estudiante = Consultar(estudiante.Documento);
                if (_estudiante != null)
                {
                    dbAcademia.Estudiantes.AddOrUpdate(estudiante);
                    dbAcademia.SaveChanges();
                    return "Se actualizaron los datos del estudiante con documento: " + estudiante.Documento;
                }
                else
                {
                    return "El documento del estudiante no existe en la base de datos.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                Estudiante _estudiante = Consultar(estudiante.Documento);
                if (_estudiante != null)
                {
                    dbAcademia.Estudiantes.Remove(_estudiante);
                    dbAcademia.SaveChanges();
                    return "Se eliminó el estudiante: " + estudiante.Nombre + " " + estudiante.Apellido;
                }
                else
                {
                    return "El cliente no existe en la base de datos.";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Estudiante Consultar(string Documento)
        {
            return dbAcademia.Estudiantes.FirstOrDefault(e => e.Documento == Documento);
        }

        public IQueryable LlenarTabla()
        {
            return from E in dbAcademia.Set<Estudiante>()
                   orderby E.Nombre
                   select new
                   {
                       Documento = E.Documento,
                       Nombre = E.Nombre,
                       Apellido = E.Apellido,
                       FechaNacimiento = E.FechaNacimiento,
                       Telefono = E.Telefono,
                       Direccion = E.Direccion,
                       Correo = E.Correo
                   };
        }
    }
}