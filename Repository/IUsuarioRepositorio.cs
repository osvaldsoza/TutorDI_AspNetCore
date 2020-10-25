using System.Collections.Generic;
using System.Threading.Tasks;
using TutorDI.Model;

namespace TutorDI.Repository
{
    public interface IUsuarioRepositorio
    {
         Task <Usuario[]> GetTodosUsuariosAsync();
         Task <Usuario> GetUsuarioByIdAsync(int id);
    }
}