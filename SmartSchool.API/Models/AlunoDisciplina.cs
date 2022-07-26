using System;

namespace SmartSchool.API.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }

        public AlunoDisciplina(int alunoId, int discipliaId)
        {
            AlunoId = alunoId;           
            DisciplinaId = discipliaId;
        }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; } = null;

        public int? Nota { get; set; } = null;

        public int AlunoId { get; set; }

        public Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }

        public Disciplina Disciplina { get; set; }

    }
}
