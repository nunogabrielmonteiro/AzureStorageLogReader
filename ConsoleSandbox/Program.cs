using AzureStorageLogReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Library.GetEvents("Endpoint=sb://duplicatedmessageseh.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=1tT8sRAvJLdk3NzVeIjjrZ/MoptNot8/fQspEr0gjA8=", "testeh");

            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
    }
}
