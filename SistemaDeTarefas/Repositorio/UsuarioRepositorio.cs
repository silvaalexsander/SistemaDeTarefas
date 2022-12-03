using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorio.Interfaces;

namespace SistemaDeTarefas.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaDeTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(t => t.id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.OrderByDescending(x => x.id).ToListAsync();
        }
        public async Task<List<UsuarioModel>> Adicionar(UsuarioModel usuario)
        {
           await _dbContext.Usuarios.AddAsync(usuario);
           await _dbContext.SaveChangesAsync();
           return await BuscarTodosUsuarios();

        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel user = await BuscarPorId(id);
            if(user == null)
            {
                throw new Exception($"Usuario para o id {id} não foi encontrado no banco de dados");
            }
            user.Nome = usuario.Nome;
            user.Email = usuario.Email;

            _dbContext.Usuarios.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel user = await BuscarPorId(id);
            if(user == null)
            {
                throw new Exception($"Usuario com o id {id} não foi encontrado no banco de dados");
            }
            _dbContext.Usuarios.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

       

        
    }
}
