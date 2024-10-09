namespace Domain.Entities.UploadedFile
{
    public class UploadedFile
    {
        #region (Fields)
        public int Id { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public UploadedFileType FileType { get; set; }
        #endregion
    }
}