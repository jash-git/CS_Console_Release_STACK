using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Release_STACK
{
    //C# 手動釋放記憶體實驗
    //https://docs.microsoft.com/zh-tw/dotnet/api/system.gc.collect?redirectedfrom=MSDN&view=netframework-4.8#overloads
    //https://blog.csdn.net/lastBeachhead/article/details/3379230

    class MyGCCollectClass
    {
        private const int maxGarbage = 1000;
        static void pause()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            int count = 0;
            Console.WriteLine("count={0}", count++);
            Console.WriteLine("Memory used before collection:       {0:N0}",
                              GC.GetTotalMemory(false));
            // Put some objects in memory.
            MyGCCollectClass.MakeSomeGarbage();

            Console.WriteLine("count={0}", count++);
            Console.WriteLine("Memory used after collection:       {0:N0}",
                              GC.GetTotalMemory(false));

            // Collect all generations of memory.
            GC.Collect();
            Console.WriteLine("count={0}", count++);
            Console.WriteLine("Memory used after full collection:   {0:N0}",
                              GC.GetTotalMemory(false));
            Console.WriteLine("count={0}", count++);
            pause();
        }

        static void MakeSomeGarbage()
        {
            Version vt;

            // Create objects and release them to fill up memory with unused objects.
            for (int i = 0; i < maxGarbage; i++)
            {
                vt = new Version();
            }
        }
    }
}
