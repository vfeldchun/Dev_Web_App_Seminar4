using AutoMapper;
using UserService.Models.Dto;
using UserService.Models;

namespace UserService.Repo
{
    public class UserRepository : IUserRepository
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public UserRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddUser(UserDto user)
        {
            _context.Users.Add(_mapper.Map<User>(user));
            _context.SaveChanges();
        }

        public bool Exists(string email) => _context.Users.Count(x => x.Active && x.Email == email) > 0;

        public bool Exists(Guid id)
        {
            return _context.Users.Count(x => x.Active && x.Id == id) > 0;
        }

        public IEnumerable<UserDto> ListUsers()
        {
            return _context.Users.Select(_mapper.Map<UserDto>).ToList();
        }
    }
}
