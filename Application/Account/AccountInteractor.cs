using ThinkCraft.Application.Account.Repositories;

namespace ThinkCraft.Application.Account
{
    public class AccountInteractor : IAccountInteractor
    {
        private readonly IUserRepository _userRepository;

        public AccountInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Message()
        {
            var user = _userRepository.Find("Force Database Communication");
            return "RAWR";
        }
    }
}