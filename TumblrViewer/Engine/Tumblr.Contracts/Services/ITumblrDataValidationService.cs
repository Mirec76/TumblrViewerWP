namespace Tumblr.Contracts.Services
{
    public interface ITumblrDataValidationService
    {
        bool IsUserNameAcceptable(string name);
        string DemoUserName { get; }
    }
}
