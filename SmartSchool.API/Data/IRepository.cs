using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {

        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool SaveChanges();

        Aluno[] GetAllAlunos(bool includeProfessor);

        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor);

        Aluno GetAlunoById(int alunoId, bool includeProfessor);

        Professor[] GetAllProfessores(bool includeAluno);

        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeProfessor);

        Professor GetProfessorById(int professorId, bool includeProfessor);

    }
}
