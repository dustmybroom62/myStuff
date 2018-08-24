using System;
using System.Threading.Tasks;

namespace TapPatterns
{
    class Program
    {
/*        
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            var manager = new TapPatternManager();
            manager.Launch();
            Console.ReadLine();
        }
*/
        static async Task Main(string[] args)
        {
            Console.WriteLine("start");
            var manager = new TapPatternManager();
            await manager.LaunchAsync();
            Console.ReadLine();
        }

    }
}
