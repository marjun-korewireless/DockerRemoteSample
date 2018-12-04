using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace DockerAccess
{
    public class DockerOperations
    {
        //list containers
        public string[] ListContainers()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\dockerListContainers.bat");//@"..\..\DockerAccess\
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }

        //list images
        public string[] ListImages()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\dockerListImages.bat");
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }
        //pull an image
        public string[] PullImage(string imageName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\dockerPull.bat", imageName);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }

        //run a container from an image without port mapping
        public string[] RunContainer(string imageName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\dockerRun.bat", imageName);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }

        //run a container froman image with port mapping
        public string[] RunContainer(string imageName, int hostPort, int containerPort)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\dockerRun.bat", imageName + " " + hostPort + " " + containerPort);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result,result[1].Result };
        }


        //Remove a container forcefully
        public string[] RemoveContainer(string containerId)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\dockerRemoveContainer.bat", containerId);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }



        //Start a container
        public string[] StartContainer(string containerId)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\dockerStartContainer.bat", containerId);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }
        public string[] StopContainer(string containerId)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\dockerStopContainer.bat", containerId);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }
        //sub-funcion to create a process and start it up
        Task<string>[] CreateProcess(ProcessStartInfo processInfo)
        {
            Task<string> output = null;
            Task<string> error = null;
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            var process = Process.Start(processInfo);
            //process.Start();
            process.WaitForExit(1);
            output = process.StandardOutput.ReadToEndAsync(); //Text in command line
            error = process.StandardError.ReadToEndAsync();   //error
            return new Task<string>[] { output, error };
        }
    }
}
