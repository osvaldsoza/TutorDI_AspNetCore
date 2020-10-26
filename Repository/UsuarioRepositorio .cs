using System.Collections.Generic;
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
            _usuarioContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<Usuario>> GetTodosUsuariosAsync()
        {
            IQueryable<Usuario> query = _usuarioContext.Usuarios;

            query = query.OrderBy(u => u.Nome);

            return await query.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id){
           IQueryable<Usuario> query = _usuarioContext.Usuarios;

           query = query.Where(u => u.UsuarioId == id);

           return await query.FirstOrDefaultAsync();
        }

        public void Add<T>(T entity) where T : class
        {
            _usuarioContext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
           _usuarioContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _usuarioContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _usuarioContext.SaveChangesAsync() > 0;
        }
    }
}