using System;

namespace TutorDI.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }

        public string NomeUsuario { get; set; }
    }
}