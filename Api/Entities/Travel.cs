using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Travel
    {
        private const string MSG_REQUIRED = "{0} is required";

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = MSG_REQUIRED)]
        [MaxLength(100)]
        public string Destiny { get; set; }

        [Required(ErrorMessage = MSG_REQUIRED)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = MSG_REQUIRED)]
        public DateTime DateRegister { get; set; }
    }
}
