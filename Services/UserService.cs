using Dotz.Data;
using Dotz.Exceptions;
using Dotz.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dotz.Services
{
    public class UserService
    {
        public async Task<User> GetUserById(int id, DataContext context)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(x => x.Id == id && x.Enabled == true);

            if (user is null)
                throw new CustomException("Usuário não encontrado");

            return user;
        }
    }
}
