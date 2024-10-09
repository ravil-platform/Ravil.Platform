namespace Domain.Entities.Complaint;
public class Complaint : BaseEntity
{
    #region (Fields)
    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string Subject { get; set; } = null!;

    public string ComplaintText { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public bool IsReadByAdmin { get; set; }
    #endregion
}

