
using ByX.Model;
using ByX.Repository;
using ByX.Repository.Common;
using ByX.Service.Common;


namespace ByX.Service
{
    public class UserService :EntityService<User>, IUserService
    {

        IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
            : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public IPagedList<User> GetAllUserPaged(int pageIndex, int pageSize)
        {
            var users = _userRepository.GetAllUserPaged(pageIndex, pageSize);
            return users;
        }


        public string GetRoleByUser(User usr)
        {
          return  _userRepository.GetRoleByUser(usr);
        }


        public bool IsRegisteredUserHaveUniqueGuidAndExceedQuota(System.Guid UniqueGuid)
        {
            return _userRepository.IsRegisteredUserHaveUniqueGuidAndExceedQuota(UniqueGuid);
            
        }



        public bool IsRegisteredUser(User usrUser)
        {
            return _userRepository.IsRegisteredUser(usrUser);
        }
    }
}
