namespace Domain.Entities.MessageBox
{
    public class MessageBox : Entity
    {
        public string Description { get; set; } = null!;
        public bool IsRead { get; set; }
        public MessageBoxType Type { get; set; }


        public int JobId { get; set; }
        public Job.Job Job { get; set; }
    }
}
