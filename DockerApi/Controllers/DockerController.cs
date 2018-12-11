using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DockerAccess;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace DockerApi.Controllers
{
    public class DockerController : ApiController
    {
        DockerOperations dockerOperations = new DockerOperations();

        //List Containers
        [HttpPost]
        public DockerResponse ListContainers()
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.ListContainers()
            };
            return dockerResponse;

        }

        //List images
        [HttpPost]
        public DockerResponse ListImages()
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.ListImages()
            };
            return dockerResponse;
        }


        //   api/docker/pullimage
        [HttpPost]
        public DockerResponse PullImage(DockerItem image)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.PullImage(image.imageName)
            };
            return dockerResponse;
        }



        //  api/docker/runcontainer
        [HttpPost]
        public DockerResponse RunContainer(DockerItem image)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.RunContainer(image.imageName)
            };
            return dockerResponse;
        }


        //   api/docker/runcontainerwithport
        [HttpPost]
        public DockerResponse RunContainerWithPort(DockerItem container)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.RunContainerWithPort(container.imageName,container.hostPort,container.containerPort)
            };
            return dockerResponse;
        }


        //   api/docker/startcontainer
        [HttpPost]
        public DockerResponse StartContainer(DockerItem container)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.StartContainer(container.containerId)
            };
            return dockerResponse;
        }


        //   api/docker/stopcontainer
        [HttpPost]
        public DockerResponse StopContainer(DockerItem container)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.StopContainer(container.containerId)
            };
            return dockerResponse;
        }


        //   api/docker/removecontainer
        [HttpPost]
        public DockerResponse RemoveContainer(DockerItem container)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.RemoveContainer(container.containerId)
            };
            return dockerResponse;
        }

        //   api/docker/removeimage
        [HttpPost]
        public DockerResponse RemoveImage(DockerItem image)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.RemoveImage(image.imageName)
            };
            return dockerResponse;
        }



        //[HttpGet]
        //public string Get(int id)
        //{
        //    return "Working";
        //}
    }
    public class DockerItem
    {
        public string imageName;
        public string containerName;
        public string containerId;
        public int hostPort;
        public int containerPort;
    }
    public class DockerResponse
    {
        public IEnumerable<string> output;
    }
}