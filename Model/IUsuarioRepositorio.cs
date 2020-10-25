using System.Collections.Generic;

namespace TutorDI.Model
{
    public interface IUsuarioRepositorio
    {
         List<Usuario> GetListaTodosUsuarios();
    }
}