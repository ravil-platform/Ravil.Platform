namespace Application.Features.Job.Queries.GetContactRequests;

public class GetContactRequestsQuery : IRequest<ContactRequestViewModel>
{
    public int JobId { get; set; }
    public DateRange? DateRange { get; set; } = Enums.DateRange.WeeklyDays;
}