using System.ComponentModel.DataAnnotations;

namespace ToDoExercice.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsComplete { get; set; }

    }
}
