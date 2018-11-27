## Running docker commands on a remote host programically
'docker.dotnet' is a Nuget package allows you to interact with Docker Remote API endpoints in .NET applications. This document is about how to use that library to interact with a host docker



### Steps to follow

 1. Open .Net application project in Visual Studio.
 2. Add Nuget package named 'docker.dotnet' to the project.
3. Add '*using Docker.Dotnet*' and '*using Docker.Dotnet.Models*' assembly references in code

#### To Initialize a client :
	using Docker.DotNet;
	DockerClient client = new DockerClientConfiguration(
		new Uri("<Your_url>:<port_number>"))
     .CreateClient(); 

This will connect to a remote docker in 'Your_url'.
	
##### To connect to local Docker for windows daemon :
	using Docker.DotNet;
	DockerClient client = new DockerClientConfiguration(
	new Uri("tcp://localhost:2375") )
     .CreateClient();
This will connect to our local docker daemon
### Examples
#### To List all images :
	IList<ImagesListResponse> images = await client.Images.ListImagesAsync(new ImagesListParameters());
            foreach(var image in images)
            {
                Console.WriteLine("{0,-10}:{1}", image.ID,image.RepoTags[0]);
            }
  The output will be list of all images with Image ID and Image tag
   #### To List all containers
	   IList <ContainerListResponse> containers = await client.Containers.ListContainersAsync(new ContainersListParameters()
            {
                Limit=50
            });
            foreach (var container in containers)
            {
                Console.WriteLine("{0}:{1,-22}:{2}",container.ID,container.Names[0],container.State);
            }
