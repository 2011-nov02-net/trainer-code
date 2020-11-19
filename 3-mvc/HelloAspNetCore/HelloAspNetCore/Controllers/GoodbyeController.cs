using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloAspNetCore.Controllers
{
    public class GoodbyeController
    {
        public string Goodbye()
        {
            return "goodbye";
        }
    }
}
