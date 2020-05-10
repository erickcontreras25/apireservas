using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string nombreUsuario { get; set; }

        [Column(TypeName = "decimal")]
        public int edad { get; set; }

        [Column(TypeName = "bit")]
        public bool isAdmin { get; set; }

        public List<EquipoUser> equipoUser { get; set; }
    }
}
