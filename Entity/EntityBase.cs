using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace efconsole.Entity
{
    public class EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public long ClusterId { get; set; }
    }
}