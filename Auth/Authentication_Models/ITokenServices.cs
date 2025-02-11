using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_Entity.Models;

namespace Auth.Authentication_Models
{
    public interface ITokenServices
    {
       Task<string> GeneretorToken(User user);
    }
}
