using System;
using System.Collections.Generic;
using System.Text;
using Docker.DotNet.Models;
using Docker.DotNet;
using System.Collections;
using System.IO;
using System.Threading;

namespace RemoteDockerTest
{
    class DockerAccess
    {
        DockerClient client = new DockerClientConfiguration(
        new Uri("http://localhost:2375"))
        .CreateClient();
        //DockerClient client = new DockerClientConfiguration(new Uri("tcp://localhost:2375")).CreateClient();
        public async void ListContainers()
        {
            int count = 0;
            IList <ContainerListResponse> containers = await client.Containers.ListContainersAsync(new ContainersListParameters() {All=true });
            foreach (var container in containers)
            {
                Console.WriteLine(++count + ":{0}:{1,-22}:{2}",container.ID,container.Names[0],container.State);
            }
        }
        public async void ListImages()
        {
            int count = 0;
            IList<ImagesListResponse> images = await client.Images.ListImagesAsync(new ImagesListParameters());
            foreach(var image in images)
            {
                Console.WriteLine(++count + ":{0,-10}:{1}", image.ID,image.RepoTags[0]);
            }
        }

        public async void StopContainer(string containerId)
        {
            try {
            var stopped = await client.Containers.StopContainerAsync(
            containerId,
            new ContainerStopParameters
            {
                 WaitBeforeKillSeconds = 30
            },
            CancellationToken.None);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void StartContainer(string containerId)
        {
            client.Containers.StartContainerAsync(containerId, null);
        }
        public async void RunContainer(string image)
        {
            CreateContainerResponse response = await client.Containers.CreateContainerAsync(new CreateContainerParameters() {
                Image=image
            });
            Console.WriteLine(response.ID);
        }
    }
}
