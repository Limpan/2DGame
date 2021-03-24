using System;

namespace RunnerGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new RunnerGame())
                game.Run();
        }
    }
}
