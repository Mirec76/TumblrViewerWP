using Windows.Networking.Connectivity;

namespace Tumblr.Common
{
    public class Network
    {
        public static bool IsConnectedToInternet()
        {
            var internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();

            if (internetConnectionProfile == null)
                return false;

            var level = internetConnectionProfile.GetNetworkConnectivityLevel();

            return level == NetworkConnectivityLevel.InternetAccess;
        }

        public static bool IsConnected { get { return NetworkInformation.GetInternetConnectionProfile() != null; } }
    }
}