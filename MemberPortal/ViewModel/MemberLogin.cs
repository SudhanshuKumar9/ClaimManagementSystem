using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemberPortal.ViewModel
{
    public class MemberLogin
    {
        [Required(ErrorMessage ="Username can't be empty!")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password can't be empty!")]
        public string Password { get; set; }
    }
}
