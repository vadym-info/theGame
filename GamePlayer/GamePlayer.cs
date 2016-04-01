using System.IO;
using System.IO.Pipes;

namespace GamePlayer
{
    class GamePlayer
    {
        static void Main(string[] args)
        {
            var player = new NamedPipeClientStream(".", "The Game", PipeDirection.InOut);
            StreamReader sr = new StreamReader(player);
            StreamWriter sw = new StreamWriter(player);
            player.Connect(100);

            string handshake = sr.ReadLine();
            if (handshake == "Waiting")
            {
                sw.WriteLine("Test Message");
                sw.Flush();
                player.Close();
            }
        }
    }
}
