namespace EmployeeManagement.ViewModels
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
