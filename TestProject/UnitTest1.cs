using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class ProjectTests
    {

        [Test, Order(1)]
        public async Task Backend_Test_Method_GetProjectById_In_ProjectService_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Services.ProjectService";

            Type serviceType = assembly.GetType(serviceName);

            // Get the GetProjectById method
            MethodInfo getProjectByIdMethod = serviceType.GetMethod("GetProjectById");

            if (getProjectByIdMethod != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(2)]
        public async Task Backend_Test_Method_GetAllProjects_In_ProjectService_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Services.ProjectService";

            Type serviceType = assembly.GetType(serviceName);

            // Get the GetAllProjects method
            MethodInfo method = serviceType.GetMethod("GetAllProjects");

            if (method != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(3)]
        public async Task Backend_Test_Method_AddProject_In_ProjectService_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Services.ProjectService";

            Type serviceType = assembly.GetType(serviceName);

            // Get the AddProject method
            MethodInfo method = serviceType.GetMethod("AddProject");

            if (method != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(4)]
        public async Task Backend_Test_Method_UpdateProject_In_ProjectService_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Services.ProjectService";

            Type serviceType = assembly.GetType(serviceName);

            // Get the UpdateProject method
            MethodInfo method = serviceType.GetMethod("UpdateProject");

            if (method != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(5)]
        public async Task Backend_Test_Method_DeleteProject_In_ProjectService_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Services.ProjectService";

            Type serviceType = assembly.GetType(serviceName);

            // Get the DeleteProject method
            MethodInfo method = serviceType.GetMethod("DeleteProject");

            if (method != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(6)]
        public async Task Backend_Test_Method_GetAllProjects_In_ProjectController_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Controllers.ProjectController";

            Type serviceType = assembly.GetType(serviceName);

            // Get the GetAllProjects method
            MethodInfo method = serviceType.GetMethod("GetAllProjects");

            if (method != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(7)]
        public async Task Backend_Test_Method_GetProjectById_In_ProjectController_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Controllers.ProjectController";

            Type serviceType = assembly.GetType(serviceName);

            // Get the GetProjectById method
            MethodInfo method = serviceType.GetMethod("GetProjectById");

            if (method != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(8)]
        public async Task Backend_Test_Method_AddProject_In_ProjectController_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Controllers.ProjectController";

            Type serviceType = assembly.GetType(serviceName);

            // Get the AddProject method
            MethodInfo method = serviceType.GetMethod("AddProject");

            if (method != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(9)]
        public async Task Backend_Test_Method_UpdateProject_In_ProjectController_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Controllers.ProjectController";

            Type serviceType = assembly.GetType(serviceName);

            // Get the UpdateProject method
            MethodInfo method = serviceType.GetMethod("UpdateProject");

            if (method != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(10)]
        public async Task Backend_Test_Method_DeleteProject_In_ProjectController_Exists()
        {
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Controllers.ProjectController";

            Type serviceType = assembly.GetType(serviceName);

            // Get the DeleteProject method
            MethodInfo method = serviceType.GetMethod("DeleteProject");

            if (method != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    
     [Test, Order(11)]
public async Task Backend_Test_Method_Login_In_AuthenticationController_Exists()
{
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Controllers.AuthenticationController";

            Type serviceType = assembly.GetType(serviceName);

            // Get the GetCourseById method
            MethodInfo Method = serviceType.GetMethod("Login");

            if (Method != null)
            {
                Assert.Pass();

            }
            else
            {
                Assert.Fail();
            }
}
    

 [Test, Order(12)]
public async Task Backend_Test_Method_Register_In_AuthenticationController_Exists()
{
            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Controllers.AuthenticationController";

            Type serviceType = assembly.GetType(serviceName);

            // Get the GetCourseById method
            MethodInfo Method = serviceType.GetMethod("Register");

            if (Method != null)
            {
                Assert.Pass();

            }
            else
            {
                Assert.Fail();
            }
}
    
    
    }
}
