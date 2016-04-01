using System;
using System.IO;
using System.IO.Pipes;

namespace GameServer
{
    class GameServer
    {
        static void Main(string[] args)
        {
            var server = new NamedPipeServerStream("The Game", PipeDirection.InOut);
            bool isRunning = true;
            StreamReader sr = new StreamReader(server);
            StreamWriter sw = new StreamWriter(server);
            do
            {
                Console.WriteLine("Waiting...");
                server.WaitForConnection();
                sw.WriteLine("Waiting");
                sw.Flush();

                server.WaitForPipeDrain();
                string test = sr.ReadLine();
                Console.WriteLine(test);
                isRunning = false;
            } while (isRunning);
        }
    }
}
