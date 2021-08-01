using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Models
{
    /// <summary>
    /// User of library
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// User name
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// User surname
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        /// <summary>
        /// User patronymic
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Patronymic { get; set; }

        /// <summary>
        /// User Date of Birth
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string DateofBirth { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// User books
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
    }
}
