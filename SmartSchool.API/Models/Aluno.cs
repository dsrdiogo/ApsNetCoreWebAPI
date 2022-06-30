using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Aluno
    {

        public Aluno() { }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Telefone { get; set; }

        public IEnumerable<AlunoDisciplina> AluniDisciplinas { get; set; }

        public Aluno(int id, string nome, string sobrenome, string telefone)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
        }
        
    }
}
