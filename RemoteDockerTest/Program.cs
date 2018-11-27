﻿using System;
using System.Collections.Generic;


namespace RemoteDockerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DockerAccess dockerAccess = new DockerAccess();
            dynamic n = 0;

            do
            {
                Console.WriteLine("1.List images\n" +
                    "2.List Containers\n" +
                    "3.Start a container\n" +
                    "4.Stop a container");
                n =Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        dockerAccess.ListImages();
                        break;
                    case 2:
                        dockerAccess.ListContainers();
                        break;
                    case 3:
                        dockerAccess.StartContainer("955e3716d1e3");
                        break;
                    case 4:
                        dockerAccess.StopContainer("955e3716d1e3");
                        break;

                    default:n = 0;
                        break;
                }
            } while (n != 0);
            //Listing Containers
            //dockerAccess.ListContainers();
            //Listing images
            //dockerAccess.ListImages();

            //Starting a container
            //dockerAccess.StartContainer("a356ceb66460");
            Console.ReadKey();
        }
    }
}