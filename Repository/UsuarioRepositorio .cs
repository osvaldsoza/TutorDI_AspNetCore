using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorDI.Model;

namespace TutorDI.Repository
{
   
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly UsuarioContext _usuarioContext;

        public UsuarioRepositorio (UsuarioContext usuarioContext)
        {
            _usuarioContext = usuarioContext;
        }
        public async Task<Usuario[]> GetTodosUsuariosAsync()
        {
            IQueryable<Usuario> query = _usuarioContext.Usuarios;

            query = query.OrderBy(u => u.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id){
           IQueryable<Usuario> query = _usuarioContext.Usuarios;

           query = query.Where(u => u.UsuarioId == id);

           return await query.FirstOrDefaultAsync();
        }
    }
}