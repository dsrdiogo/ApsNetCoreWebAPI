using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            this._context = context;
        }


        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {

            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);

            if (professor == null) return BadRequest("Professor não encontrado!");

            return Ok(professor);

        }

        // GET api/<ProfessorController>/5
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {

            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));

            if (professor == null) return BadRequest("Professor não encontrado!");

            return Ok(professor);

        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {

            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();

        }

    }
}
