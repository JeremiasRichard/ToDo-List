using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}