using System;
using efconsole.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efconsole.Entity
{
    public class Student : EntityBase
    {
        [MaxLength(50)]
        public string Firstname { get; set; }

        [MaxLength(50)]
        public string Lastname { get; set; }

        [MinAge(18)]
        public DateTimeOffset Birthdate { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone ]
        public string Phone { get; set; }

        [ForeignKey("Teachers")]
        public Guid MentorId { get; set; }
    }
}