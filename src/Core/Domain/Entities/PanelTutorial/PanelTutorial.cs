namespace Domain.Entities.PanelTutorial
{
    public class PanelTutorial : BaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string CoverName { get; set; } = null!;
        public string VideoName { get; set; } = null!;

        public int Sort { get; set; }
    }
}
