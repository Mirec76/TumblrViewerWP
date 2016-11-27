using System.Text.RegularExpressions;
using Tumblr.Contracts.Services;

namespace Tumblr.Services
{
    public class TumblrDataValidationService : ITumblrDataValidationService
    {
        private string DEMO_USER_NAME = "demo";

        public bool IsUserNameAcceptable(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (!r.IsMatch(name))
                return false;

            return true;
        }

        public string DemoUserName
        {
            get { return DEMO_USER_NAME; }
        }
    }
}
