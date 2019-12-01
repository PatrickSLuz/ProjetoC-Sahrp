using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AgenteLogado : IdentityUser
    {
        public static Agente Autenticado { get; set; }
    }
}
