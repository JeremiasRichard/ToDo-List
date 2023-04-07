using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasLibrary.Models;
using TareasLibrary.Models;

namespace TareasLibrary
{
    internal class TareaService : ITareaService
    {
        public bool CreateTarea(Tarea tarea)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTarea(Tarea tarea)
        {
            throw new NotImplementedException();
        }

        public bool ExistTarea(int idTarea)
        {
            throw new NotImplementedException();
        }

        public Tarea GetTarea(int idTarea)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tarea> GetTareas()
        {
            var tareas = _tarea.GetTareas();
            return Ok(tareas);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateTarea(Tarea tarea)
        {
            throw new NotImplementedException();
        }
    }
}
