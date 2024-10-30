namespace ViewModels.QueriesResponseViewModel.Tag
{
    public class TagViewModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }   

        public string UniqueName { get; set; } 

        public string IconPicture { get; set; } 

        public string IconHtmlCode { get; set; } 

        public bool Status { get; set; }

        public TagType Type { get; set; }
    }
}
