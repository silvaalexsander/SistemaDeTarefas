using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Controllers
{
    public class UserModel
    {
        public static implicit operator UserModel?(UsuarioModel? v)
        {
            throw new NotImplementedException();
        }
    }
}