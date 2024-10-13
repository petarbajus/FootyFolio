using FootyFolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolio.Repository.Common
{
    public interface IUserRepository
    {
        Task<User> GetUserInfoAsync(Guid id);
        Task<bool> InsertUserAsync(User user);

        Task<bool> UpdateUserByIdAsync(Guid id, User user);
        Task<List<Footballer>> GetUserWishlistAsync(Guid userId);
        Task<bool> InsertFootballerIntoWishlistAsnyc(Guid userId, Footballer footaballer);


    }
}
