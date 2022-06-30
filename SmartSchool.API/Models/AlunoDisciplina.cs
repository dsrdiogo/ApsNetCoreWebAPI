namespace SmartSchool.API.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }

        public AlunoDisciplina(int alunoId, int discipliaId)
        {
            AlunoId = alunoId;           
            DiscipliaId = discipliaId;
        }

        public int AlunoId { get; set; }

        public Aluno Aluno { get; set; }

        public int DiscipliaId { get; set; }

        public Disciplina Disciplina { get; set; }

    }
}
