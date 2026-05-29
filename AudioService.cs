using System.Media;

namespace CyberBotWPF
{
    public class AudioService
    {
        public static void PlayGreeting()
        {
            try
            {
                SoundPlayer player =
                    new SoundPlayer("Assets/greetings.wav");

                player.Play();
            }
            catch
            {
            }
        }
    }
}