using Microsoft.AspNetCore.Mvc;

namespace ViewModels.QueriesResponseViewModel.User
{
    public class RegisterUserResponseViewModel
    {
        public Guid Id { get; set; }

        public string? PhoneNumber { get; set; }

        public JsonResult Jwt { get; set; }
    }
}
