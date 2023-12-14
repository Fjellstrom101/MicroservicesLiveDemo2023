using Authorization.DataAccess.Models;
using Domain.Common.DTOs;

namespace Authorization.API.Endpoints.GetAllUsers;

public class GetAllUsersResponse
{
    public IEnumerable<User> Users { get; set; } = new List<User>();
}