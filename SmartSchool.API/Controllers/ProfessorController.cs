using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;
using System.Collections.Generic;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repo;

        public ProfessorController( IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }


        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {

            var professores = _repo.GetAllProfessores(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));

        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var professor = _repo.GetProfessorById(id, false);

            return Ok(_mapper.Map<ProfessorDto>(professor));

        }

        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {

            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não cadastrado!");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _mapper.Map(model, professor);

            _repo.Update(professor);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado!");

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor model)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _mapper.Map(model, professor);

            _repo.Update(professor);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado!");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _repo.Delete(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não deletado!");

        }

    }
}
