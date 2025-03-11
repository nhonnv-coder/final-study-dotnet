using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;
using FinalMvcNet.Services.TestSuites;

namespace FinalMvcNet.Controllers
{
    public class TestSuiteController : Controller
    {
        private readonly ITestSuiteService _testSuiteService;
        private readonly IMapper _mapper;

        public TestSuiteController(ITestSuiteService testSuiteService, IMapper mapper)
        {
            _testSuiteService = testSuiteService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var testSuites = await _testSuiteService.GetAllAsync();
            var viewModel = _mapper.Map<List<TestSuiteViewModel>>(testSuites);
            return View(viewModel);
        }

        public IActionResult Create() => View(new TestSuiteViewModel());

        [HttpPost]
        public async Task<IActionResult> Create(TestSuiteViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var testSuite = _mapper.Map<TestSuite>(model);
            await _testSuiteService.AddAsync(testSuite);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var testSuite = await _testSuiteService.GetByIdAsync(id);
            if (testSuite == null) return NotFound();

            var viewModel = _mapper.Map<TestSuiteViewModel>(testSuite);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TestSuiteViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var testSuite = _mapper.Map<TestSuite>(model);
            await _testSuiteService.UpdateAsync(testSuite);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _testSuiteService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
