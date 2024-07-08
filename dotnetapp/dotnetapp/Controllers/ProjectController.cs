using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;
        private readonly BlobService _blobService;

        public ProjectController(ProjectService projectService, BlobService blobService)
        {
            _projectService = projectService;
            _blobService = blobService;
        }
        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<Project>> GetProjectById(int projectId)
        {
            var project = await _projectService.GetProjectById(projectId);

            if (project == null)
                return NotFound(new { message = "Project not found" });

            return Ok(project);
        }

        // [HttpPost]
        // public async Task<ActionResult> AddProject([FromBody] Project project)
        // {
        //     try
        //     {
        //         await _projectService.AddProject(project);
        //         return Ok(new { message = "Project added successfully" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, new { message = ex.Message });
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromForm] ProjectInputModel inputModel)
        {
            if (inputModel.CoverImage == null || inputModel.CoverImage.Length == 0)
                return BadRequest(new { message = "Cover image file is empty." });

            // Validate file type
            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
            var fileExtension = Path.GetExtension(inputModel.CoverImage.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(fileExtension) || !allowedExtensions.Contains(fileExtension))
            {
                return BadRequest(new { message = "Invalid file type. Only PNG, JPG, and JPEG files are allowed." });
            }

            // Upload the file to blob storage and get the URL
            var blobResponse = await _blobService.UploadAsync1(inputModel.CoverImage);

            // Create a new course object with the URL of the uploaded file
            var project = new Project
            {
                ProjectTitle = inputModel.ProjectTitle,
                ProjectDescription = inputModel.ProjectDescription,
                StartDate = inputModel.StartDate,
                EndDate = inputModel.EndDate,
                FrontEndTechStack = inputModel.FrontEndTechStack,
                BackendTechStack = inputModel.BackendTechStack,
                Database = inputModel.Database,
                CoverImage = blobResponse.Uri,
                Status = inputModel.Status
            };

            var success = await _projectService.AddProject(project);
            if (success)
                return Ok(new { message = "Project added successfully" });
            else
                return StatusCode(500, new { message = "Failed to add project" });
        }

        // [HttpPut("{projectId}")]
        // public async Task<ActionResult> UpdateProject(int projectId, [FromBody] Project project)
        // {
        //     try
        //     {
        //         var success = await _projectService.UpdateProject(projectId, project);

        //         if (success)
        //             return Ok(new { message = "Project updated successfully" });
        //         else
        //             return NotFound(new { message = "Project not found" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, new { message = ex.Message });
        //     }
        // }

        [HttpPut("{projectId}")]
        public async Task<ActionResult> UpdateProject(int projectId, [FromForm] ProjectInputModel inputModel)
        {
            try
            {
                // Fetch the existing course to update
                var existingProject = await _projectService.GetProjectById(projectId);
                if (existingProject == null)
                {
                    return NotFound(new { message = "Cannot find any project" });
                }

                // Validate file type if a new cover image is provided
                if (inputModel.CoverImage != null && inputModel.CoverImage.Length > 0)
                {
                    var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
                    var fileExtension = Path.GetExtension(inputModel.CoverImage.FileName).ToLowerInvariant();

                    if (string.IsNullOrEmpty(fileExtension) || !allowedExtensions.Contains(fileExtension))
                    {
                        return BadRequest(new { message = "Invalid file type. Only PNG, JPG, and JPEG files are allowed." });
                    }

                    // Upload the new file to blob storage and get the URL
                    var blobResponse = await _blobService.UploadAsync1(inputModel.CoverImage);
                    existingProject.CoverImage = blobResponse.Uri;
                }

                // Update course properties
                existingProject.ProjectTitle = inputModel.ProjectTitle;
                existingProject.ProjectDescription = inputModel.ProjectDescription;
                existingProject.StartDate = inputModel.StartDate;
                existingProject.EndDate = inputModel.EndDate;
                existingProject.FrontEndTechStack = inputModel.FrontEndTechStack;
                existingProject.BackendTechStack = inputModel.BackendTechStack;
                existingProject.Database = inputModel.Database;
                existingProject.Status = inputModel.Status;

                var success = await _projectService.UpdateProject(projectId, existingProject);

                if (success)
                    return Ok(new { message = "Project updated successfully" });
                else
                    return NotFound(new { message = "Cannot find any project" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult> DeleteProject(int projectId)
        {
            try
            {
                var success = await _projectService.DeleteProject(projectId);

                if (success)
                    return Ok(new { message = "Project deleted successfully" });
                else
                    return NotFound(new { message = "Project not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
