using Hycite.APIModels;
using FastEndpoints;
using Hycite.Repositories;
using Hycite.Models;
using Hycite.Mappers;

namespace Hycite.Endpoints;

public class SaveUserActivityEndpoint : Endpoint<SaveUserActivityAPIModels.Request, SaveUserActivityAPIModels.Response>
{
    private readonly IUserActivityRepository _userActivityRepository;

    public SaveUserActivityEndpoint(IUserActivityRepository userActivityRepository, 
                                    IUserSecurityRepository userSecurityRepository,
                                    IHttpContextAccessor httpContextAccessor)
    {
        _userActivityRepository = userActivityRepository;
    }

    public override void Configure()
    {
        
        Post("api/useractivity");
    }

    public override async Task HandleAsync(SaveUserActivityAPIModels.Request request, CancellationToken cancellationToken)
    {
        var userActivity = new UserActivity
        {
            ActivityDate = request.ActivityDate,
            ProspectSourceId = request.ProspectSourceId ?? 0,
            Appointment = request.Appointment,
            Demonstration = request.Demonstration,
            Sale = request.Sale,
            CreatedBy = 0 // _httpContextAccessor.HttpContext.User.Claims["Id"].ToInt() //TODO: Decide how to handle this
        };

        await _userActivityRepository.AddAsync(userActivity);

        
        await SendAsync(Response);
    }
}

public class GetUserActivityEndpoint : EndpointWithoutRequest<GetUserActivityAPIModels.Response>
{
    private readonly IUserActivityRepository _userActivityRepository;

    public GetUserActivityEndpoint(IUserActivityRepository userActivityRepository)
    {
        _userActivityRepository = userActivityRepository;
    }

    public override void Configure()
    {
        Get("api/useractivity/{id}");
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var activityId = Route<int>("id");
        var userActivity = await _userActivityRepository.GetByIdAsync(activityId);
        Response = new GetUserActivityAPIModels.Response
        {
            Success = true,
            Data = userActivity.ToUserActivityDTO()
        };
    }
}

public class UpdateUserActivityEndpoint : Endpoint<UpdateUserActivityAPIModels.Request, UpdateUserActivityAPIModels.Response>
{
    private readonly IUserActivityRepository _userActivityRepository;

    public UpdateUserActivityEndpoint(IUserActivityRepository userActivityRepository)
    {
        _userActivityRepository = userActivityRepository;
    }

    public override void Configure()
    {
        Put("api/useractivity");
    }

    public override async Task HandleAsync(UpdateUserActivityAPIModels.Request request, CancellationToken cancellationToken)
    {
        var userActivity = await _userActivityRepository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException();
        userActivity.ActivityDate = request.ActivityDate;
        userActivity.ProspectSourceId = request.ProspectSourceId ?? 0;
        userActivity.Appointment = request.Appointment;
        userActivity.Demonstration = request.Demonstration;
        userActivity.Sale = request.Sale;

        await _userActivityRepository.UpdateAsync(userActivity);

        Response = new UpdateUserActivityAPIModels.Response
        {
            Success = true,
            Data = userActivity.ToUserActivityDTO()
        };
    }
}

public class DeleteUserActivityEndpoint : EndpointWithoutRequest<BaseAPIModel.Response>
{
    private readonly IUserActivityRepository _userActivityRepository;

    public DeleteUserActivityEndpoint(IUserActivityRepository userActivityRepository)
    {
        _userActivityRepository = userActivityRepository;
    }

    public override void Configure()
    {
        Delete("api/useractivity/{id}");
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        try 
        {
            var activityId = Route<int>("id");
            var activity = await _userActivityRepository.GetByIdAsync(activityId) ?? throw new KeyNotFoundException();
            await _userActivityRepository.DeleteAsync(activity);
            Response = new BaseAPIModel.Response
            {
                Success = true
            };
        }
        catch (Exception ex)
        {
            Response = new BaseAPIModel.Response
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}