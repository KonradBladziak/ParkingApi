using BLL;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.CodeAnalysis.Host.Mef;
using System.Diagnostics;

namespace TestProjectBLL
{
    public class UnitTestMiastaBLL
    {
        [Fact]
        public void DodajMiasta()
        {
            var MiastoFakeRepo = new MiastoRepositoryFake();
            var unitOfWork = new UnitOfWork(MiastoFakeRepo);
            var workService = new WorkService(unitOfWork);

            for (int i = 1; i <= 5; i++)
            {
                workService.DodajMiasto($"Test{i}",$"Test{i}");
            }

            var count = MiastoFakeRepo.GetMiasta().Result.Count();
            Assert.Equal(5, count);  
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
    }
}