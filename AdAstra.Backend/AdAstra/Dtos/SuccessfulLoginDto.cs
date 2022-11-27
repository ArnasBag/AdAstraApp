using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAstra.Dtos
{
    public class SuccessfulLoginDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
