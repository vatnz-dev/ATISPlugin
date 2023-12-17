using GeoVR.Connection;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using vatsys;

namespace ATISPlugin
{
    public class AFV
    {
        private readonly ApiServerConnection apiServerConnection;
        internal static string VoiceServer { get; set; } = "https://voice1.vatsim.uk";
        public bool Broadcasting { get; set; }  

        public AFV() 
        {
            apiServerConnection = new ApiServerConnection(VoiceServer);
        }

        public async Task AddOrUpdateBot(byte[] audio, string callsign, uint frequency, double lat, double lon, bool timeCheck, double duration)
        {
            if (!apiServerConnection.Authenticated)
            {
                var password = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(Plugin.Settings.Password), Encoding.UTF8.GetBytes(Plugin.Settings.Entropy), DataProtectionScope.CurrentUser));
                await apiServerConnection.Connect(Plugin.Settings.CID, password, "vatSys 1.0.0");
            }


            var addBotRequestDto = BotClient.AddBotRequest(audio, frequency, lat, lon, 100.0);

            var interval = timeCheck ? TimeSpan.FromMilliseconds(duration + 60000.0) : TimeSpan.Zero;

            if (interval != TimeSpan.Zero) addBotRequestDto.Interval = interval;

            await apiServerConnection.AddOrUpdateBot(callsign, addBotRequestDto).AwaitTimeout(15000);

            Broadcasting = true;
        }

        public async Task RemoveBot(string callsign)
        {
            if (!Broadcasting) return;

            await apiServerConnection.RemoveBot(callsign).AwaitTimeout(5000);

            Broadcasting = false;
        }
    }
}
