using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RemoteDockerUsingBatch
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }
        HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:61090/")
        };
        DockerResponse dockerResponse = new DockerResponse();

        private async void btnPull_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Pulling image " + txtImageName.Text;

            DockerItem image = new DockerItem()
            {
                imageName = txtImageName.Text
            };
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync("api/docker/pullimage", image);
            response.EnsureSuccessStatusCode();

            dockerResponse = JsonConvert.DeserializeObject<DockerResponse>(response.Content.ReadAsStringAsync().Result);
            lblOutput.Text = dockerResponse.output[0] + dockerResponse.output[1];
        }

        private async void btnRunImage_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Running container using " + txtImageToRun.Text;
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            DockerItem container = new DockerItem()
            {
                imageName = txtImageToRun.Text
            };
            HttpResponseMessage response;

            if (txtContPort.Text == "" || txtHostPort.Text == "")
            {
                response = await client.PostAsJsonAsync("api/docker/runcontainer", container);
            }
            else
            {
                container.hostPort = Convert.ToInt32(txtHostPort.Text);
                container.containerPort = Convert.ToInt32(txtContPort.Text);
                response = await client.PostAsJsonAsync("api/docker/runcontainerwithport", container);
            }
            response.EnsureSuccessStatusCode();
            dockerResponse = JsonConvert.DeserializeObject<DockerResponse>(response.Content.ReadAsStringAsync().Result);
            lblOutput.Text = dockerResponse.output[0] + dockerResponse.output[1];

            txtImageToRun.Text = null;
            txtContPort.Text = null;
            txtHostPort.Text = null;
        }

        private async void btnListContainers_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "listing Containers";

            DockerItem container = new DockerItem();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync("api/docker/listcontainers", container);
            response.EnsureSuccessStatusCode();

            dockerResponse = JsonConvert.DeserializeObject<DockerResponse>(response.Content.ReadAsStringAsync().Result);
            lblOutput.Text = dockerResponse.output[0]+dockerResponse.output[1];
        }

        private async void btnListImages_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Listing Images";

            DockerItem image = new DockerItem();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync("api/docker/listimages", image);
            response.EnsureSuccessStatusCode();

            dockerResponse = JsonConvert.DeserializeObject<DockerResponse>(response.Content.ReadAsStringAsync().Result);
            lblOutput.Text = dockerResponse.output[0] + dockerResponse.output[1];
        }

        private async void btnStartContainer_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Starting container";

            DockerItem container = new DockerItem()
            {
                containerId=txtStartContainerId.Text
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync("api/docker/startcontainer", container);
            response.EnsureSuccessStatusCode();

            dockerResponse = JsonConvert.DeserializeObject<DockerResponse>(response.Content.ReadAsStringAsync().Result);
            lblOutput.Text = dockerResponse.output[0] + dockerResponse.output[1];
        }

        private async void btnStopContainer_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Stopping container";

            DockerItem container = new DockerItem()
            {
                containerId = txtStopContainerId.Text
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync("api/docker/stopcontainer", container);
            response.EnsureSuccessStatusCode();

            dockerResponse = JsonConvert.DeserializeObject<DockerResponse>(response.Content.ReadAsStringAsync().Result);
            lblOutput.Text = dockerResponse.output[0] + dockerResponse.output[1];
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private async void btnRemoveContainer_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Removing container";

            DockerItem container = new DockerItem()
            {
                containerId = txtRemoveContainerId.Text
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync("api/docker/removecontainer", container);
            response.EnsureSuccessStatusCode();

            dockerResponse = JsonConvert.DeserializeObject<DockerResponse>(response.Content.ReadAsStringAsync().Result);
            lblOutput.Text = dockerResponse.output[0] + dockerResponse.output[1];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Removing Image ";
            DockerItem image = new DockerItem()
            {
                imageName = txtRemoveImage.Text
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync("api/docker/removeimage",image);
            response.EnsureSuccessStatusCode();

            dockerResponse = JsonConvert.DeserializeObject<DockerResponse>(response.Content.ReadAsStringAsync().Result);
            lblOutput.Text = dockerResponse.output[0] + dockerResponse.output[1];

        }
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
        public string[] output;
    }
}
