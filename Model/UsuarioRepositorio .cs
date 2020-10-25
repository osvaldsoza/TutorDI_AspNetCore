using System;
using System.Collections.Generic;

namespace TutorDI.Model
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public List<Usuario> GetListaTodosUsuarios()
        {
            return new List<Usuario>{
                 new Usuario()
               {
                   Nome = "Jose",
                   Sobrenome="Macoratti",
                   Nascimento= new DateTime(1997,02,03),
                   NomeUsuario="macoratti"
               },
               new Usuario()
               {
                   Nome = "Miriam",
                   Sobrenome="Silveira",
                   Nascimento= new DateTime(1999,11,08),
                   NomeUsuario="miriam"
               }
            };
        }
    }
}