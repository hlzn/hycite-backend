namespace Hycite.APIModels;

public class SaveUserActivityAPIModels
{
    public class Request
    {
        public required DateTime ActivityDate { get; set; }
        public int? ProspectSourceId { get; set; }
        public bool Appointment { get; set; } = false;
        public bool Demonstration { get; set; } = false;
        public decimal Sale { get; set; } = 0.00m;
    }

    public class Response : BaseAPIModels<DTOs.UserActivityDTO>.Response
    {
    }
}

public class GetUserActivityAPIModels
{
    public class Request
    {
        public int Id { get; set; }
    }

    public class Response : BaseAPIModels<DTOs.UserActivityDTO>.Response
    {
    }
}

public class UpdateUserActivityAPIModels
{
    public class Request
    {
        public int Id { get; set; }
        public required DateTime ActivityDate { get; set; }
        public int? ProspectSourceId { get; set; }
        public bool Appointment { get; set; } = false;
        public bool Demonstration { get; set; } = false;
        public decimal Sale { get; set; } = 0.00m;
    }

    public class Response : BaseAPIModels<DTOs.UserActivityDTO>.Response
    {
    }
}