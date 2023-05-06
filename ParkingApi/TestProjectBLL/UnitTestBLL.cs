using BLL;
using DAL.Entity;
using DAL.IRepositories;
using DAL.UnitOfWork;
using Microsoft.CodeAnalysis.Host.Mef;
using Moq;
using System.Diagnostics;

namespace TestProjectBLL
{
    public class UnitTestBLL
    {
        [Fact]
        public void DodajMiasta()
        {
            var MiastoFakeRepo = new MiastoRepositoryFake();
            var unitOfWork = new TestUnitOfWork(MiastoFakeRepo);
            var workService = new WorkService(unitOfWork);

            for (int i = 1; i <= 5; i++)
            {
                workService.DodajMiasto($"Test{i}", $"Test{i}");
            }

            var count = MiastoFakeRepo.GetMiasta().Result.Count();
            Assert.Equal(5, count);
        }

        [Fact]
        public void UsunMiasto() {
            var MiastoFakeRepo = new MiastoRepositoryFake();
            var unitOfWork = new TestUnitOfWork(MiastoFakeRepo);
            var workService = new WorkService(unitOfWork);

            workService.DodajMiasto("TestUsuwania", "TestUsuwania");
            Assert.Equal(1, MiastoFakeRepo.GetMiasta().Result.Count());

            var miasto = unitOfWork.MiastoRepository.GetMiasta().Result.FirstOrDefault(x => x.Nazwa == "TestUsuwania");

            workService.UsunMiasto(miasto.Id);
            Assert.Equal(0, MiastoFakeRepo.GetMiasta().Result.Count());
        }

        [Fact]
        public void DodajMiejsca()
        {
            var miejsceFakeRepo = new MiejsceRepositoryFake();
            var unitOfWork = new UnitOfWork(miejsceFakeRepo);
            var workService = new WorkService(unitOfWork);

            workService.DodajMiejsca(5, 1);

            var count = miejsceFakeRepo.GetMiejsca().Result.Count();
            Assert.Equal(5, count);
        }

        [Fact]
        public void DodajMiastaMock() { 
            Mock<IMiastoRepository> mockMiastoRepo = new Mock<IMiastoRepository>();
            var unitOfWork = new TestUnitOfWork(mockMiastoRepo.Object);
            var workService = new WorkService(unitOfWork);

            for (int i = 1; i <= 5; i++)
            {
                workService.DodajMiasto($"Test{i}", $"Test{i}");
            }

            Assert.Equal(5, mockMiastoRepo.Object.GetMiasta().Result.Count());
        }


        [Fact]
        public void UsunMiastoMock()
        {
            Mock<IMiastoRepository> mockMiastoRepo = new Mock<IMiastoRepository>();
            var unitOfWork = new TestUnitOfWork(mockMiastoRepo.Object);
            var workService = new WorkService(unitOfWork);

            workService.DodajMiasto("TestUsuwania", "TestUsuwania");
            Assert.Equal(1, mockMiastoRepo.Object.GetMiasta().Result.Count());

            var miasto = unitOfWork.MiastoRepository.GetMiasta().Result.FirstOrDefault(x => x.Nazwa == "TestUsuwania");

            workService.UsunMiasto(miasto.Id);
            Assert.Equal(0, mockMiastoRepo.Object.GetMiasta().Result.Count());
        }

        [Fact]
        public async Task DodajMiejscaMock()
        {
            Mock<IMiejsceRepository> mockMiejsceRepo = new Mock<IMiejsceRepository>();
            var unitOfWork = new TestUnitOfWork(mockMiejsceRepo.Object);
            var workService = new WorkService(unitOfWork);

            await workService.DodajMiejsca(5, 1);

           // var count = await unitOfWork.MiejsceRepository.GetMiejsca();
           // Assert.Equal(5, count.Count());
        }
    }
}
