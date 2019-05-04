using System.ComponentModel.DataAnnotations;

namespace AspnetcoreVue.Models
{
    /// <summary>
    /// TodoItem
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// TodoItem.Id
        /// </summary>
        /// <value></value>
        public long TodoItemId { get; set; }

        /// <summary>
        /// TodoItem.Name
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// TodoItem.IsComplete
        /// </summary>
        /// <value></value>
        [Required]
        public bool IsComplete { get; set; }

        /// <summary>
        /// User
        /// </summary>
        /// <value></value>
        public User User { get; set; }
    }
}