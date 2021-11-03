using System;
using efconsole.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace efconsole.Entity
{
    public class Teacher : EntityBase
    {
        [MaxLength(50)]
        public string Firstname { get; set; }

        [MaxLength(50)]
        public string Lastname { get; set; }

        [MinAge(25)]
        public DateTimeOffset Birthdate { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone ]
        public string Phone { get; set; }
        public List<Student> Students { get; set; } =  new List<Student>();
    }
}