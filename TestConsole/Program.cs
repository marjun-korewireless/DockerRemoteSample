using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockerAccess;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DockerOperations dockerOperations = new DockerOperations();
            IEnumerable<string> output;//=dockerOperations.UploadFile();
            output = dockerOperations.PullImage("mgarjun/calculator-consoleapp");
            foreach(var item in output)
            {
                Console.WriteLine("{0}\n", item);
            }
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
