using TareasLibrary.Models;
using TodoList.Data;
using TodoList.Interface;

namespace TodoList.Repository
{
    public class TareaRepository : ITarea
    {
        private readonly ApplicationDbContext dbContext;

        public TareaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateTarea(Tarea tarea)
        {
            dbContext.Add(tarea);
            return Save();
        }

        public bool DeleteTarea(Tarea tarea)
        {
            dbContext.Remove(tarea);
            return Save();
        }

        public bool ExistTarea(int idTarea)
        {
            return dbContext.Tareas.Any(x => x.Id == idTarea);
        }

        public Tarea GetTarea(int idTarea)
        {
            return dbContext.Tareas.Where(x => x.Id == idTarea).FirstOrDefault();
        }

        public ICollection<Tarea> GetTareas()
        {
            return dbContext.Tareas.ToList();
        }

        public bool Save()
        {
           var saved = dbContext.SaveChanges();
           return saved > 0 ? true : false;
        }

        public bool UpdateTarea(Tarea tarea)
        {
            dbContext.Update(tarea);
            return Save();
        }
    }
}
