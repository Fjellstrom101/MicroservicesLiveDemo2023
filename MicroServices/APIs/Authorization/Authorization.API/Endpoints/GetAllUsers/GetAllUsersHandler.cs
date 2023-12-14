using Authorization.DataAccess;
using FastEndpoints;

namespace Authorization.API.Endpoints.GetAllUsers;

public class GetAllUsersHandler(IAuthorizationRepository repository) : Endpoint<GetAllUsersRequest, GetAllUsersResponse>
{
    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await repository.GetAllAsync();
        await SendAsync(
            new GetAllUsersResponse()
            {
                Users = users
            },
            cancellation: cancellationToken);
    }
}