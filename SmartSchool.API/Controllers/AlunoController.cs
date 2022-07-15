﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
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

        private readonly SmartContext _context;
        private readonly IRepository _repo;

        public AlunoController(SmartContext context, IRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get(bool includeProfessor)
        {          

            var alunos = _repo.GetAllAlunos(includeProfessor);

            return Ok(alunos);
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id, bool includeProfessor)
        {
            
            var aluno = _repo.GetAlunoById(id, includeProfessor);

            return Ok(aluno);

        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {

            _repo.Add(aluno);

            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado!");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno não encontrado!");

            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado!");

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno não encontrado!");

            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Ok(aluno);
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
