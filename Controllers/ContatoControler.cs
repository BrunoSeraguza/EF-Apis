using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Entities;
using ModuloAPI.Context;

namespace ModuloAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class ContatoControler: ControllerBase
    {
        private readonly Agenda _context;

        public ContatoControler(Agenda context)
        {
            context = _context;

        }
        [HttpPost]
        public IActionResult Create(Contato contato )
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);



        }
        [HttpGet("{Id}")]
        public IActionResult ObterportaId(int Id)
        {
            
            var contato = _context.Contatos.Find(Id);
            

            if(contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }
        [HttpPut("{Id}")]

        public IActionResult Atualizar(int id , Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);
            if(contatoBanco == null)
            {
                return NotFound();

            }
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;
            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();
            return Ok(contatoBanco);

        }
        [HttpDelete]

        public IActionResult Deletar(int Id)
        {
            var contatoBanco = _context.Contatos.Find(Id);
            if(contatoBanco == null)
            {
                return NotFound();

            }
            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();

        }
    }
}