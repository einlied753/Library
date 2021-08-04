using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Models
{
    /// <summary>
    /// Lended book for user
    /// </summary>
    public class LendedBook : BaseEntity
    {
        [Required]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        /// <summary>
        /// Lending date and time with format: yyyy-MM-ddTHH:mm:ss.fffzzz (for example: 2021-01-01T16:01:12.257+04:00)
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\d)|3[01])T([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9]).([0-9][0-9][0-9])\[-+]([0][0-9]|[1][0-2]))$",
         ErrorMessage = "LendingDateTime is not valid.")]
        public DateTimeOffset LendingDateTime { get; set; }

    }
}
