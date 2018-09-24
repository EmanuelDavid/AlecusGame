using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlecusGame.Controllers
{
    public class ChessController : Controller
    {
        [HttpGet]
        public char Index()
        {
            return 'X';
        }
    }
}