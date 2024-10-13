using FootyFolio.Model;
using FootyFolio.Repository;
using FootyFolio.Repository.Common;
using FootyFolio.Service.Common;

namespace FootyFolioLogic.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUserInfoAsync(Guid id)
        {
            return await _userRepository.GetUserInfoAsync(id);
        }

        public async Task<List<Footballer>> GetUserWishlistAsync(Guid userId)
        {
            return await _userRepository.GetUserWishlistAsync(userId);
        }

        public async Task<bool> InsertFootballerIntoWishlistAsnyc(Guid userId, Footballer footaballer)
        {
            return await _userRepository.InsertFootballerIntoWishlistAsnyc(userId, footaballer);
        }

        public async Task<bool> InsertUserAsync(User user)
        {
            return await _userRepository.InsertUserAsync(user);
        }

        public async Task<bool> UpdateUserByIdAsync(Guid id, User user)
        {
            return await _userRepository.UpdateUserByIdAsync(id, user);
        }
    }
}
