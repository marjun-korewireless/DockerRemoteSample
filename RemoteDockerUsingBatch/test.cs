using System;
using DockerAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDockerUsingBatch
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Pulling image " + txtImageName.Text;
            DockerOperations dockerOperations = new DockerOperations();
            string[] Result = dockerOperations.PullImage(txtImageName.Text);
            lblOutput.Text = Result[0];
            lblOutput.Text += Result[1];
        }

        private void btnRunImage_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Running container using " + txtImageToRun.Text;
            DockerOperations dockerOperations = new DockerOperations();
            string[] result = null;
            if (txtContPort.Text == "" || txtHostPort.Text == "")
            {
                string imageName = txtImageToRun.Text;
                result = dockerOperations.RunContainer(imageName);
            }
            else
            {
                int hostPort = Convert.ToInt32(txtHostPort.Text);
                int containerPort = Convert.ToInt32(txtContPort.Text);
                string imageName = txtImageToRun.Text;
                result = dockerOperations.RunContainer(imageName, hostPort, containerPort);
            }
            lblOutput.Text = result[0] + result[1];
            txtImageToRun.Text = null;
            txtContPort.Text = null;
            txtHostPort.Text = null;
        }

        private void btnListContainers_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "listing Containers";
            DockerOperations dockerOperations = new DockerOperations();
            string[] result = dockerOperations.ListContainers();
            lblOutput.Text = result[0] + result[1];
        }

        private void btnListImages_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Listing Images";
            DockerOperations dockerOperations = new DockerOperations();
            string[] result = dockerOperations.ListImages();
            lblOutput.Text = result[0] + result[1];
        }

        private void btnStartContainer_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Starting container";
            DockerOperations dockerOperations = new DockerOperations();
            string[] result = dockerOperations.StartContainer(txtStartContainerId.Text);
            lblOutput.Text = result[0] + result[1];
        }

        private void btnStopContainer_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "Loading...";
            lblOutputHeader.Text = "Stopping container";
            DockerOperations dockerOperations = new DockerOperations();
            string[] result = dockerOperations.StopContainer(txtStopContainerId.Text);
            lblOutput.Text = result[0] + result[1];
        }
    }
}
