using Authorization.DataAccess.Models;
using Domain.Common.Interfaces.DataAccess;

namespace Authorization.DataAccess;

public interface IAuthorizationRepository : IGenericRepository<User, int>
{
    
}