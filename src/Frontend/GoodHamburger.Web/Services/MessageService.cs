namespace GoodHamburger.Web.Services
{
    public class MessageService
    {
        public string Message { get; private set; } = string.Empty;
        public bool IsError { get; private set; }
        public bool Show { get; private set; }

        public event Action OnChange;

        public void ShowMessage(string message, bool isError = false)
        {
            Message = message;
            IsError = isError;
            Show = true;
            NotifyStateChanged();

            Task.Delay(5000).ContinueWith(_ => { Show = false; NotifyStateChanged(); });
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
