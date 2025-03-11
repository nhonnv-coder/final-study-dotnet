using AutoMapper;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;
using FinalMvcNet.Services.Projects;
using FinalMvcNet.Services.Sprints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalMvcNet.Controllers
{
    public class SprintsController : Controller
    {
        private readonly ISprintService _sprintService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public SprintsController(
            ISprintService sprintService,
            IProjectService projectService,
            IMapper mapper
        )
        {
            _sprintService = sprintService;
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var sprints = await _sprintService.GetAllAsync();
            return View(sprints);
        }

        public async Task<IActionResult> Create()
        {
            var sprintViewModel = new SprintViewModel();
            var projects = await _projectService.GetAllAsync();
            sprintViewModel.ProjectOptions = projects
                .Select(project => new SelectListItem
                {
                    Text = project.Name,
                    Value = project.Id.ToString(),
                })
                .ToList();

            return View(sprintViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SprintViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var projects = await _projectService.GetAllAsync();
                model.ProjectOptions = projects
                    .Select(project => new SelectListItem
                    {
                        Text = project.Name,
                        Value = project.Id.ToString(),
                    })
                    .ToList();
                return View(model);
            }

            await _sprintService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _sprintService.GetByIdAsync(id);
            model.Project = _mapper.Map<Project>(await _projectService.GetProjectByIdAsync(model.ProjectId));
            return View(_mapper.Map<SprintViewModel>(model));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SprintViewModel model)
        {
            await _sprintService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _sprintService.GetByIdAsync(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sprintService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
