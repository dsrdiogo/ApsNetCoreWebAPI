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
        private readonly IRepository _repo;

        public ProfessorController(SmartContext context, IRepository repo)
        {
            _context = context;
            _repo = repo;
        }


        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get(bool includeAluno)
        {

            var professores = _repo.GetAllProfessores(includeAluno);

            return Ok(professores);

        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id, bool includeAluno)
        {

            var professor = _repo.GetProfessorById(id, includeAluno);

            return Ok(professor);

        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {

            _repo.Add(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado!");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado!");

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado!");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _context.Remove(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não deletado!");

        }

    }
}
