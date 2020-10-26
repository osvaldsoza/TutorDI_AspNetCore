using System.Collections.Generic;
using System.Threading.Tasks;
using TutorDI.Model;

namespace TutorDI.Repository
{
    public interface IUsuarioRepositorio
    {
         Task <List<Usuario>> GetTodosUsuariosAsync();
         Task <Usuario> GetUsuarioByIdAsync(int usuarioId);

         Task<bool> SaveChangesAsync();

         void Add<T>(T entity) where T : class;

         void Update<T>(T entity) where T : class;

         void Delete<T>(T entity) where T : class;
    }
}