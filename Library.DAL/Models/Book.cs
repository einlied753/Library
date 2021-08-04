using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Library.DAL.Enums;

namespace Library.DAL.Models
{
    /// <summary>
    /// Books of library
    /// </summary>
    public class Book : BaseEntity
    {
        /// <summary>
        /// Book name
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Book's author name
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        /// <summary>
        /// Book's genre
        /// </summary>
        [Required]
        public Genre Genre { get; set; }
    }
}
