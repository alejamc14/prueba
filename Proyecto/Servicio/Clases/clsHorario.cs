
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AcademiaSistemas.Clases
{
    public class clsHorario
    {
        AcademiaSistemasEntities academiaSistemasEntities = new AcademiaSistemasEntities();

        public Horario horario { get; set; }

        public string Insertar()
        {
            try
            {
                academiaSistemasEntities.Horarios.Add(horario);
                academiaSistemasEntities.SaveChanges();
                return "Se grabo el Horario con exito";
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
                academiaSistemasEntities.Horarios.AddOrUpdate(horario);
                academiaSistemasEntities.SaveChanges();
                return $"Se actualizaron los datos del Horario {horario.Id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            Horario _horario = Consultar(horario.Id);
            academiaSistemasEntities.Horarios.Remove(_horario);
            academiaSistemasEntities.SaveChanges();
            return $"Se eliminó el horario {horario.Id}";
        }
        public Horario Consultar(int Id)
        {
            return academiaSistemasEntities.Horarios.FirstOrDefault(c => c.Id == Id);
        }
        public IQueryable LlenarTabla()
        {
            return from H in academiaSistemasEntities.Horarios
                   select new
                   {
                       Id = H.Id,
                       DiaSemana = H.DiaSemana, 
                       HoraInicio = H.HoraInicio,
                       HoraFin = H.HoraFin,
                       IdCurso= H.IdCurso,
                       IdAula= H.IdAula
                   };
        }


    }
}