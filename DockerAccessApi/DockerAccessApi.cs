using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockerAccess;
using System.Net.Http;
using System.Web.Http;

namespace DockerAccessApi
{
    public class DockerAccessApi
    {
        DockerOperations dockerOperations = new DockerOperations();

        [HttpPost]
        public DockerResponse PullImage(Image image)
        {
            var imageName = image.imageName;
           
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.PullImage(imageName)
            };
            return dockerResponse;
        }

        [HttpPost]
        public DockerResponse ListImages()
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.ListImages()
            };
            return dockerResponse;
        }

        [HttpPost]
        public DockerResponse ListContainers()
        {
            var dockerResponse = new DockerResponse
            {
                output = dockerOperations.ListContainers()
            };
            return dockerResponse;      
        }


    }
    public class Image
    {
        public string imageName; 
    }
    public class DockerResponse
    {
        public string[] output; 
    }    
}
