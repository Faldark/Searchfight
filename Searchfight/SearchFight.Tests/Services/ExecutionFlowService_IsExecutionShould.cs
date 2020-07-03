using NUnit.Framework;
using Searchfight.Services;
using Searchfight.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SearchFight.Tests.Services
{
    [TestFixture]
    public class ExecutionFlowService_IsExecutionShould
    {
        private IExecutionFlowService _executionFlowService;

        [SetUp]
        public void SetUp()
        {
            _executionFlowService = new ExecutionFlowService(new ResultsAggregatorService(), new SearchEnginesService(), new ResultsOutputService());
        }

        [Test]
        public void Run_InputEmpty_ShouldThrowArgumentException()
        {
            var input = new List<string>();

            Assert.ThrowsAsync<ArgumentException>(() => _executionFlowService.Run(input));
        }

        [Test]
        public void Run_Input1Element_ShouldThrowArgumentException()
        {
            var input = new List<string>() {"java"};

            Assert.ThrowsAsync<ArgumentException>(() => _executionFlowService.Run(input));
        }

        [Test]
        public void Run_InputOk_ShouldNotThrowExceptionException()
        {
            var input = new List<string>() { "java", ".net" };

            Assert.DoesNotThrowAsync(() => _executionFlowService.Run(input));
        }
    }
}
