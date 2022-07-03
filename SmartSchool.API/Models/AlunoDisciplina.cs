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

        public int AlunoId { get; set; }

        public Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }

        public Disciplina Disciplina { get; set; }

    }
}
