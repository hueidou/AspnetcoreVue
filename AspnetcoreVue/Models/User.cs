using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspnetcoreVue.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// User.UserId
        /// </summary>
        /// <value></value>
        public long UserId { get; set; }

        /// <summary>
        /// User.UserName
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        /// <summary>
        /// Todos
        /// </summary>
        /// <value></value>
        List<TodoItem> Todos { get; set; }
    }
}