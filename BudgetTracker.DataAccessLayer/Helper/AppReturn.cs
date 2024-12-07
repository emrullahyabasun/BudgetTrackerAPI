namespace BudgetTracker.DataAccessLayer.Helper
{
    public class AppReturn
    {
        public AppReturn()
        {

        }
        public AppReturn(bool isSuccess, string message)
        {
            isSuccess = this.IsSuccess;
            message = this.Message ?? string.Empty;

        }

        public AppReturn(bool isSuccess, int id, string message)
        {
            id = this.Id;
            isSuccess = this.IsSuccess;
            message = this.Message ?? string.Empty;

        }

        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }
}
