using UserService.Models.Dto;

namespace UserService.Repo
{
    public interface IUserRepository
    {
        public void AddUser(UserDto user);
        public IEnumerable<UserDto> ListUsers();
        public bool Exists(string email);
        public bool Exists(Guid id);
    }
}
