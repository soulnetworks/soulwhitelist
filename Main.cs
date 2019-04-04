using System;
using GTANetworkAPI;
using GTANetworkMethods;


namespace whitelist
{
    public class Main : Script
    {
        public delegate void OnPlayerJoinDelegate(Player player);


            [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Client player)
        {
            var pip = NAPI.Player.GetPlayerAddress(player);


            /*
             *  This is the configuration for the IP's to be whitelisted.
             *  You will see pip.Equals and the IP's are within the
             *  equal parameter. You can copy and paste this to add
             *  more in the middle - (pip.Equals("123.45.67.89")) ||
             *  If you only want one IP it should look like this - (pip.Equals("81.136.116.0")) 
             */

            if (pip.Equals("12.345.67.89") ||
                (pip.Equals("98.76.654.32")) ||
                pip.Equals("43.21.56.789"))                
            {
                player.SendChatMessage("Welcome to our server!");
                Console.WriteLine(pip + " - Whitelisted entry to the server");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Your Not Whitelisted!", true);
                Console.WriteLine(pip + " - Denied Entry to server");
                NAPI.Player.KickPlayer(player, "Denied");
            }
        }
    }
}
