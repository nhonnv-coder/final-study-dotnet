using FinalMvcNet.Data.Entities;

namespace FinalMvcNet.Data;

public static class DatabaseSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        // Seed Projects
        if (!context.Projects.Any())
        {
            var projects = new[]
            {
                new Project { Name = "Project A" },
                new Project { Name = "Project B" },
            };
            context.Projects.AddRange(projects);
            context.SaveChanges();
        }

        // Seed Sprints
        if (!context.Sprints.Any())
        {
            var sprints = new[]
            {
                new Sprint { Name = "Sprint 1", ProjectId = 1 },
                new Sprint { Name = "Sprint 2", ProjectId = 1 },
                new Sprint { Name = "Sprint 1", ProjectId = 2 },
            };
            context.Sprints.AddRange(sprints);
            context.SaveChanges();
        }

        // Seed TestSuites
        if (!context.TestSuites.Any())
        {
            var testSuites = new[]
            {
                new TestSuite { Name = "Login Tests", SprintId = 1 },
                new TestSuite { Name = "User Management Tests", SprintId = 1 },
                new TestSuite { Name = "Checkout Process Tests", SprintId = 2 },
                new TestSuite { Name = "Payment Gateway Tests", SprintId = 2 },
                new TestSuite { Name = "Search Functionality Tests", SprintId = 3 },
            };
            context.TestSuites.AddRange(testSuites);
            context.SaveChanges();
        }

        // Seed TestCases
        if (!context.TestCases.Any())
        {
            var testCases = new[]
            {
                new TestCase { Description = "Test Login Functionality", TestSuiteId = 1 },
                new TestCase { Description = "Test User Registration", TestSuiteId = 2 },
                new TestCase { Description = "Test Checkout Flow", TestSuiteId = 3 },
            };
            context.TestCases.AddRange(testCases);
            context.SaveChanges();
        }

        // Seed TestRuns
        if (!context.TestRuns.Any())
        {
            var testRuns = new[]
            {
                new TestRun
                {
                    TestCaseId = 1,
                    Status = TestRunStatus.Pass,
                    RunDate = DateTime.Now,
                },
                new TestRun
                {
                    TestCaseId = 2,
                    Status = TestRunStatus.Fail,
                    RunDate = DateTime.Now,
                },
                new TestRun
                {
                    TestCaseId = 3,
                    Status = TestRunStatus.Warning,
                    RunDate = DateTime.Now,
                },
            };
            context.TestRuns.AddRange(testRuns);
            context.SaveChanges();
        }

        // Seed Evidence
        if (!context.Evidences.Any())
        {
            var evidences = new[]
            {
                new Evidence { TestRunId = 1, FilePath = "uploads/evidence/evidence1.png" },
                new Evidence { TestRunId = 2, FilePath = "uploads/evidence/evidence1.png" },
                new Evidence { TestRunId = 3, FilePath = "uploads/evidence/evidence1.png" },
            };
            context.Evidences.AddRange(evidences);
            context.SaveChanges();
        }
    }
}
