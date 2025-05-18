namespace ViewModels.QueriesResponseViewModel.Payments;

public class PaymentVerificationResponseViewModel
{
    public string? PaymentAmount { get; set; }
    public string? PaymentReferenceId { get; set; }
    public string? PaymentStatusCode { get; set; }
    public string? PaymentStatusMessage { get; set; }
}