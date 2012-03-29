using System;
using System.Windows.Forms;
using System.Threading;

namespace FindingPrincess
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using(Game1 _game = new Game1())
            {
                _game.Run();
            }
        }
    }
#endif
}

