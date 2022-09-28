using Backend.Uckam.data;
using Backend.Uckam.Entities;

namespace Backend.Uckam.Repositories;

public class UserRepository : GenericRepository<User>, IUSerRepository
{
    public UserRepository(AppDbContext context) : base(context) { }
}