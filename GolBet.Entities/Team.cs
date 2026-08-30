using GolBet.Entities.common1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolBet.Entities
{
    public class Team : common1.AuditableEntity

    {

        [Required, MaxLength(80)]

        public string Name { get; set; } = null!;



        [Required, MaxLength(60)]

        public string City { get; set; } = null!;



        [MaxLength(300)]

        public string? CrestUrl { get; set; }

    }
}
