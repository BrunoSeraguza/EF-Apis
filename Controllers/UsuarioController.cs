using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController: ControllerBase
    {
        [HttpGet("DataHoraAtual")]
        public IActionResult ObterdataHora()
        {
           
            var obj = new
            {
                data = DateTime.Now.ToLongDateString(),
                hora = DateTime.Now.ToLongTimeString()
            };
            return Ok(obj);
        }

        [HttpGet("Apresentar/{nome}")]
        public IActionResult Apresentar(string nome )
        {
            var mensagem = $"Olá {nome} Seja bem vindo!";
            return Ok(new {mensagem});
        }
        
    }
}