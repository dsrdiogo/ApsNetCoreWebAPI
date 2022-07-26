﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {          

            var alunos = _repo.GetAllAlunos(true);          

            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(_mapper.Map<AlunoDto>(aluno));

        }

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {

            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);

            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não cadastrado!");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não atualizado!");

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não atualizado!");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado!");

            _repo.Delete(aluno);

            if (_repo.SaveChanges())
            {
                return Ok("Aluno deletado!");
            }

            return BadRequest("Aluno não deletado!");

        }
    }
}
