using Hycite.DTOs;
using Hycite.Models;

namespace Hycite.Mappers;

public static class Mappers
{
    public static UserActivityDTO ToUserActivityDTO(this UserActivity userActivity)
    {
        return new UserActivityDTO
        {
            ActivityDate = userActivity.ActivityDate,
            ProspectSourceId = userActivity.ProspectSourceId,
            Appointment = userActivity.Appointment,
            Demonstration = userActivity.Demonstration,
            Sale = userActivity.Sale
        };
    }
}