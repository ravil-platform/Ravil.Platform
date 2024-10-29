using RNX.Mediator;

namespace Application.Features.Job.Commands.UpdateJobCategory
{
    public class UpdateJobCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int JobId { get; set; }
    }
}
