using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIContagem.Controllers
{
    [Route("api/[controller]")]
    public class ContadorController : Controller
    {
        private static Contador _CONTADOR = new Contador();

        [HttpGet]
        public object Get()
        {
            lock (_CONTADOR)
            {
                _CONTADOR.Incrementar();

                return new
                {
                    _CONTADOR.ValorAtual,
                    Environment.MachineName,
                    Sistema = Environment.OSVersion.VersionString
                };
            }
        }
    }
}