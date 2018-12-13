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
        #region usingPsScripts
        //List Containers
        [HttpPost]
        public DockerResponse ListContainers(DockerItem dockerItem)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.ListContainers(dockerItem.isUsingBatch)
            };
            return dockerResponse;

        }

        //List images
        [HttpPost]
        public DockerResponse ListImages(DockerItem dockerItem)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.ListImages(dockerItem.isUsingBatch)
            };
            return dockerResponse;
        }


        //   api/docker/pullimage
        [HttpPost]
        public DockerResponse PullImage(DockerItem image)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.PullImage(image.isUsingBatch, image.imageName)
            };
            return dockerResponse;
        }



        //  api/docker/runcontainer
        [HttpPost]
        public DockerResponse RunContainer(DockerItem image)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.RunContainer(image.isUsingBatch, image.imageName)
            };
            return dockerResponse;
        }


        //   api/docker/runcontainerwithport
        [HttpPost]
        public DockerResponse RunContainerWithPort(DockerItem container)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.RunContainerWithPort(container.isUsingBatch, container.imageName,container.hostPort,container.containerPort)
            };
            return dockerResponse;
        }


        //   api/docker/startcontainer
        [HttpPost]
        public DockerResponse StartContainer(DockerItem container)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.StartContainer(container.isUsingBatch, container.containerId)
            };
            return dockerResponse;
        }


        //   api/docker/stopcontainer
        [HttpPost]
        public DockerResponse StopContainer(DockerItem container)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.StopContainer(container.isUsingBatch, container.containerId)
            };
            return dockerResponse;
        }


        //   api/docker/removecontainer
        [HttpPost]
        public DockerResponse RemoveContainer(DockerItem container)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.RemoveContainer(container.isUsingBatch, container.containerId)
            };
            return dockerResponse;
        }

        //   api/docker/removeimage
        [HttpPost]
        public DockerResponse RemoveImage(DockerItem image)
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.RemoveImage(image.isUsingBatch, image.imageName)
            };
            return dockerResponse;
        }
        #endregion usingPsScripts

        //#region usingBatchScripts
        ////List Containers
        //[HttpPost]
        //public DockerResponse ListContainersBatch()
        //{
        //    var dockerResponse = new DockerResponse
        //    {
        //        output = dockerOperations.ListContainers()
        //    };
        //    return dockerResponse;

        //}

        ////List images
        //[HttpPost]
        //public DockerResponse ListImagesBatch()
        //{
        //    var dockerResponse = new DockerResponse
        //    {
        //        output = dockerOperations.ListImages()
        //    };
        //    return dockerResponse;
        //}


        ////   api/docker/pullimage
        //[HttpPost]
        //public DockerResponse PullImageBatch(DockerItem image)
        //{
        //    var dockerResponse = new DockerResponse
        //    {
        //        output = dockerOperations.PullImage(image.imageName)
        //    };
        //    return dockerResponse;
        //}



        ////  api/docker/runcontainer
        //[HttpPost]
        //public DockerResponse RunContainerBatch(DockerItem image)
        //{
        //    var dockerResponse = new DockerResponse
        //    {
        //        output = dockerOperations.RunContainer(image.imageName)
        //    };
        //    return dockerResponse;
        //}


        ////   api/docker/runcontainerwithport
        //[HttpPost]
        //public DockerResponse RunContainerWithPortBatch(DockerItem container)
        //{
        //    var dockerResponse = new DockerResponse
        //    {
        //        output = dockerOperations.RunContainerWithPort(container.imageName, container.hostPort, container.containerPort)
        //    };
        //    return dockerResponse;
        //}


        ////   api/docker/startcontainer
        //[HttpPost]
        //public DockerResponse StartContainerBatch(DockerItem container)
        //{
        //    var dockerResponse = new DockerResponse
        //    {
        //        output = dockerOperations.StartContainer(container.containerId)
        //    };
        //    return dockerResponse;
        //}


        ////   api/docker/stopcontainer
        //[HttpPost]
        //public DockerResponse StopContainerBatch(DockerItem container)
        //{
        //    var dockerResponse = new DockerResponse
        //    {
        //        output = dockerOperations.StopContainer(container.containerId)
        //    };
        //    return dockerResponse;
        //}


        ////   api/docker/removecontainer
        //[HttpPost]
        //public DockerResponse RemoveContainerBatch(DockerItem container)
        //{
        //    var dockerResponse = new DockerResponse
        //    {
        //        output = dockerOperations.RemoveContainer(container.containerId)
        //    };
        //    return dockerResponse;
        //}

        ////   api/docker/removeimage
        //[HttpPost]
        //public DockerResponse RemoveImageBatch(DockerItem image)
        //{
        //    var dockerResponse = new DockerResponse
        //    {
        //        output = dockerOperations.RemoveImage(image.imageName)
        //    };
        //    return dockerResponse;
        //}
        //#endregion usingBatchScripts

    }
    public class DockerItem
    {
        public bool isUsingBatch;
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