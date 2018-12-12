## Running docker commands on a remote host using powershell scripting
To control a docker engine in a remote machine, powershell scripting can be used. This solution contains powershell scripts to run on a remote machine, but certain configurations are need to be set in the remote machine.
1. The UserName, Password and computer name of the remote machine must be known.
2. Powershell remoting must be enabled in the remote machine. Follow the steps below,
	- Open powershell Administrator mode in remote machine
	- Run command 'Enable-PSRemoting -Force'

Now, the environment is set to run powershell scripts in remote machine.

### Running powershell scripts remotely
Once the above steps are completed this project successfully run powershell scripts on the host machine on a remote machine. The key part of the code to achieve this is below, 

    1. var ps = PowerShell.Create();
    2. ps.AddScript(string.Format(@"set-item wsman:localhost\client\trustedhosts -value ""{0}"" -Force", computerName));
    3. ps.AddScript(string.Format(@"$pword = ConvertTo-SecureString -String {0} -AsPlainText -Force;", password));
    4. ps.AddScript(string.Format(@"$user = ""{0}"";", userName));
    5. ps.AddScript(string.Format(@"$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $pword;"));
    6. ps.AddScript(string.Format(@"Set-ExecutionPolicy -ExecutionPolicy Bypass;"));
    7. ps.AddScript(string.Format(@"Invoke-Command -ComputerName {0} -filepath {1} -Credential $Credential;", computerName, path));
    8. var results = ps.Invoke();
Let's see what happens in each line of this code.
-	Line1 : This will create a new instance of powershell class contained in 'System.Management.Automation' library. This class is used to run powershell scripts on remote machine.
-	Line2 : AddScript method add a script to powershell instance. The script added here will add the remote machine to trusted hosts list.  
-	Line3 : Here we can set remote machine password
-	Line4 : Here we can set remote user name
-	Line5 : This script generates a credential object using username and password set in the last two steps
-	Line6 : This line set the execution policy. Setting Execution policy to 'Bypass' enables us to run unsigned scripts on remote machine
-	Line7 : This line runs the specified script in the remote machine using credentials object created in preceding steps. This is the major part of running powershell scripts on remote machine.
-	Line8 : Actual execution of scripts added in preceding steps happens here. Invoke() method initiates running of each script added using Addscript() method and returns the result or errors occurred while running the scripts.

NB: Variables like userName, Password and ComputerName are set before this code.
