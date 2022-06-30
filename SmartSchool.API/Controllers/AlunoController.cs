using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        public List<Aluno> Alunos = new List<Aluno>()
        {

            new Aluno ()
            {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "1133333333"
            },

            new Aluno ()
            {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "1134444444"
            },

            new Aluno ()
            {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Maria",
                Telefone = "1137777777"
            }

        };

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // GET api/<AlunoController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {

            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("Aluno não encontrado!");

            return Ok(aluno);

        }

        // GET api/<AlunoController>/5
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {

            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if (aluno == null) return BadRequest("Aluno não encontrado!");

            return Ok(aluno);

        }
       
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
          
            return Ok(aluno);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

            return Ok(aluno);

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            return Ok(aluno);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok();

        }
    }
}
