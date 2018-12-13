using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;

namespace DockerAccess
{
    public class DockerOperations
    {
        #region usingPsOrBatch
        private static string userName = @"userName";        //Enter username here
        private static string password = "Password";         //Enter password here
        private static string computerName = "ipAddress/computerName"; //Enter Ip Address or Computer Name

        //List Containers
        public IEnumerable<string> ListContainers(bool IsUsingBatch)
        {
            IEnumerable<string> output = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (IsUsingBatch)
            {
                var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerListContainers.bat");
                Task<string>[] result = CreateProcess(processInfo);
                output = new string[] { result[0].Result, result[1].Result };
            }
            else
            {
                path = Path.Combine(path, @"..\DockerAccess\PsScripts\dockerListContainers.ps1");
                var ps = PowerShell.Create();
                ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
                ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
                ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
                ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
                ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
                ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {1} -Credential $Credential;", computerName, path));
                var results = ps.Invoke();

                if (ps.Streams.Error.Count != 0)
                {
                    output = from result in ps.Streams.Error
                             select result.ToString();

                }
                else
                {
                    output = from result in results
                             select result.BaseObject.ToString();
                }
            }
            return output;
        }

        //List Images
        public IEnumerable<string> ListImages(bool isUsingBatch)
        {
            IEnumerable<string> output = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (isUsingBatch)
            {
                var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerListImages.bat");
                Task<string>[] result = CreateProcess(processInfo);
                output = new string[] { result[0].Result, result[1].Result };
            }
            else
            {
                path = Path.Combine(path, @"..\DockerAccess\PsScripts\dockerListImages.ps1");
                var ps = PowerShell.Create();
                ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
                ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
                ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
                ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
                ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
                ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {1} -Credential $Credential;", computerName, path));
                var results = ps.Invoke();

                if (ps.Streams.Error.Count != 0)
                {
                    output = from result in ps.Streams.Error
                             select result.ToString();

                }
                else
                {
                    output = from result in results
                             select result.BaseObject.ToString();
                }
            }
            return output;
        }

        //Pull an Image
        public IEnumerable<string> PullImage(bool isUsingBatch, string image)
        {
            //string source = @"E:\dockerListContainers.bat";
            //string dest = @"\\192.168.64.183\d$\dockerListContainers.bat";
            //ps.AddScript(string.Format(@"net use \\192.168.64.183\d$ /user:""{0}"" ""{1}""", userName, password));
            //ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -force -value 192.168.64.183"));
            //ps.AddScript(string.Format(
            //    @"$WebClient = New-Object System.Net.WebClient;" +
            //    @"$WebClient.UploadFile(""{0}"",""{1}"");", dest, source));

            //****Important:powershell remoting must be enabled in the remote machine
            IEnumerable<string> output = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (isUsingBatch)
            {
                var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerPull.bat", image);
                Task<string>[] result = CreateProcess(processInfo);
                output = new string[] { result[0].Result, result[1].Result };
            }
            else
            {
                
                path = Path.Combine(path, @"..\DockerAccess\PsScripts\dockerPull.ps1");
                var ps = PowerShell.Create();
                ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
                ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
                ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
                ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
                ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
                ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {2}" +
                                            " -ArgumentList {1} -Credential $Credential;", computerName, image, path));
                var results = ps.Invoke();

                if (ps.Streams.Error.Count != 0)
                {
                    output = from result in ps.Streams.Error
                             select result.ToString();

                }
                else
                {
                    output = from result in results
                             select result.BaseObject.ToString();
                }
            }
            // result[2].BaseObject.ToString();
            //foreach(var item in result)
            //{
            //    output = item.BaseObject.ToString();
            //}
            return output;
        }

        //Run Container without port mapping
        public IEnumerable<string> RunContainer(bool isUsingBatch, string image)
        {
            IEnumerable<string> output = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (isUsingBatch)
            {
                var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerRun.bat", image);
                Task<string>[] result = CreateProcess(processInfo);
                output = new string[] { result[0].Result, result[1].Result };
            }
            else
            {
                path = Path.Combine(path, @"..\DockerAccess\PsScripts\dockerRun.ps1");
                var ps = PowerShell.Create();
                ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
                ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
                ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
                ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
                ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
                ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {1}" +
                                            " -ArgumentList {2} -Credential $Credential;", computerName, path, image));
                var results = ps.Invoke();

                if (ps.Streams.Error.Count != 0)
                {
                    output = from result in ps.Streams.Error
                             select result.ToString();

                }
                else
                {
                    output = from result in results
                             select result.BaseObject.ToString();
                }
            }
            return output;
        }

        //Run a container with port mapping
        public IEnumerable<string> RunContainerWithPort(bool isUsingBatch, string image,int hostPort, int containerPort)
        {
            IEnumerable<string> output = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (isUsingBatch)
            {
                var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerRun.bat", image + " " + hostPort + " " + containerPort);
                Task<string>[] result = CreateProcess(processInfo);
                output = new string[] { result[0].Result, result[1].Result };
            }
            else
            {
                path = Path.Combine(path, @"..\DockerAccess\PsScripts\dockerRunWithPort.ps1");
                var ps = PowerShell.Create();
                ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
                ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
                ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
                ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
                ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
                ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {1}" +
                                            " -ArgumentList {2} -Credential $Credential;", computerName, path, image, hostPort, containerPort));
                var results = ps.Invoke();

                if (ps.Streams.Error.Count != 0)
                {
                    output = from result in ps.Streams.Error
                             select result.ToString();

                }
                else
                {
                    output = from result in results
                             select result.BaseObject.ToString();
                }
            }
            return output;
        }

        //Remove a container
        public IEnumerable<string> RemoveContainer(bool isUsingBatch, string container)
        {
            IEnumerable<string> output = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (isUsingBatch)
            {
                var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerRemoveContainer.bat", container);
                Task<string>[] result = CreateProcess(processInfo);
                output = new string[] { result[0].Result, result[1].Result };
            }
            else
            {
                path = Path.Combine(path, @"..\DockerAccess\PsScripts\dockerRemoveContainer.ps1");
                var ps = PowerShell.Create();
                ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
                ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
                ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
                ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
                ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
                ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {1}" +
                                            " -ArgumentList {2} -Credential $Credential;", computerName, path, container));
                var results = ps.Invoke();

                if (ps.Streams.Error.Count != 0)
                {
                    output = from result in ps.Streams.Error
                             select result.ToString();

                }
                else
                {
                    output = from result in results
                             select result.BaseObject.ToString();
                }
            }
            return output;
        }

        //Remove an image
        public IEnumerable<string> RemoveImage(bool isUsingBatch, string image)
        {
            IEnumerable<string> output = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (isUsingBatch)
            {
                var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerRemoveImage.bat", image);
                Task<string>[] result = CreateProcess(processInfo);
                output = new string[] { result[0].Result, result[1].Result };
            }
            else
            {
                path = Path.Combine(path, @"..\DockerAccess\PsScripts\dockerRemoveImage.ps1");
                var ps = PowerShell.Create();
                ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
                ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
                ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
                ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
                ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
                ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {1}" +
                                            " -ArgumentList {2} -Credential $Credential;", computerName, path, image));
                var results = ps.Invoke();

                if (ps.Streams.Error.Count != 0)
                {
                    output = from result in ps.Streams.Error
                             select result.ToString();

                }
                else
                {
                    output = from result in results
                             select result.BaseObject.ToString();
                }
            }
            return output;
        }

        //Start a stopped container
        public IEnumerable<string> StartContainer(bool isUsingBatch, string container)
        {
            IEnumerable<string> output = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (isUsingBatch)
            {
                var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerStartContainer.bat", container);
                Task<string>[] result = CreateProcess(processInfo);
                output = new string[] { result[0].Result, result[1].Result };
            }
            else
            {
                path = Path.Combine(path, @"..\DockerAccess\PsScripts\dockerStartContainer.ps1");
                var ps = PowerShell.Create();
                ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
                ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
                ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
                ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
                ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
                ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {1}" +
                                            " -ArgumentList {2} -Credential $Credential;", computerName, path, container));
                var results = ps.Invoke();

                if (ps.Streams.Error.Count != 0)
                {
                    output = from result in ps.Streams.Error
                             select result.ToString();

                }
                else
                {
                    output = from result in results
                             select result.BaseObject.ToString();
                }
            }
            return output;
        }

        //Start a stopped container
        public IEnumerable<string> StopContainer(bool isUsingBatch, string container)
        {
            IEnumerable<string> output = new List<string>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (isUsingBatch)
            {
                var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerStopContainer.bat", container);
                Task<string>[] result = CreateProcess(processInfo);
                output = new string[] { result[0].Result, result[1].Result };
            }
            else
            {
                path = Path.Combine(path, @"..\DockerAccess\PsScripts\dockerStopContainer.ps1");
                var ps = PowerShell.Create();
                ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
                ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
                ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
                ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
                ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
                ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {1}" +
                                            " -ArgumentList {2} -Credential $Credential;", computerName, path, container));
                var results = ps.Invoke();

                if (ps.Streams.Error.Count != 0)
                {
                    output = from result in ps.Streams.Error
                             select result.ToString();

                }
                else
                {
                    output = from result in results
                             select result.BaseObject.ToString();
                }
            }
            return output;
        }
        
        #endregion usingPsOrBatch

        #region usingBatch

        #region ListContainers
        //list containers
        public string[] rListContainers()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerListContainers.bat");
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }

        #endregion ListContainers

        #region ListImages
        //list images
        public string[] rListImages()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerListImages.bat");
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }
        #endregion ListImages

        #region PullImage
        //pull an image
        public string[] rPullImage(string imageName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerPull.bat", imageName);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }
        #endregion PullImage

        #region RunContainer
        //run a container from an image without port mapping
        public string[] rRunContainer(string imageName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerRun.bat", imageName);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }
        #endregion RunContainer

        #region RunContainerWithport
        //run a container froman image with port mapping
        public string[] rRunContainer(string imageName, int hostPort, int containerPort)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerRun.bat", imageName + " " + hostPort + " " + containerPort);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result,result[1].Result };
        }

        #endregion RunContainerWithport

        #region RemoveContainer
        //Remove a container forcefully
        public string[] rRemoveContainer(string containerId)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerRemoveContainer.bat", containerId);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }
        #endregion RemoveContainer

        #region RemoveImage
        //Remove an image forcefully
        public string[] rRemoveImage(string imageName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerRemoveImage.bat", imageName);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }

        #endregion RemoveImage

        #region StartContainer
        //Start a container
        public string[] rStartContainer(string containerId)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerStartContainer.bat", containerId);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }
        #endregion StartContainer

        #region StopContainer
        public string[] rStopContainer(string containerId)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var processInfo = new ProcessStartInfo(path + @"..\DockerAccess\BatchScripts\dockerStopContainer.bat", containerId);
            Task<string>[] result = CreateProcess(processInfo);
            return new string[] { result[0].Result, result[1].Result };
        }
        #endregion StopContainer

        #region Subfunction

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

        #endregion Subfunction

        #endregion usingBatch
    }
}
