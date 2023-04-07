using TodoList.Models;

namespace TodoList.Interface
{
    public interface ITarea
    {
        ICollection<Tarea> GetTareas();
        Tarea GetTarea(int idTarea);
        bool CreateTarea(Tarea tarea);
        bool DeleteTarea(Tarea tarea);
        bool ExistTarea(int idTarea);
        bool UpdateTarea(Tarea tarea);
        bool Save();
    }
}
