using RNX.Mediator;

namespace Application.Features.Job.Commands.CreateJobCategory
{
    public class CreateJobCategoryCommand : IRequest
    {
        public int CategoryId { get; set; }
        public int JobId { get; set; }
    }
}
