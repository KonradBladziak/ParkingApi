using BLL.WorkServices;
using DAL.DataContext;
using DAL.Entity;
using DAL.IRepository;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class TestMiastoService
    {
        [Fact]
        public async Task DodajMiasta()
        {
            DatabaseContext db = new DatabaseContext();

            var miastoFakeRepo = new MiastoFakeRepo(db);
            var unitOfWork = new UnitOfWork(miastoFakeRepo);
            var workService = new MiastoService(unitOfWork);

            for (int i = 10000; i <= 10005; i++)
            {
                Miasto miasto = new Miasto() { Id = i, Nazwa = $"{"Test" + i}", Wojewodztwo = $"{"Test" + i}" };
                await workService.AddMiasto(miasto);
            }

            var count = miastoFakeRepo.GetAllAsync().Result.Count();
            Assert.Equal(5, count);
        }

        [Fact]
        public async Task UsunMiasto()
        {
            DatabaseContext db = new DatabaseContext();

            var miastoFakeRepo = new MiastoFakeRepo(db);
            var unitOfWork = new UnitOfWork(miastoFakeRepo);
            var workService = new MiastoService(unitOfWork);

            Miasto miasto = new Miasto() { Id = 1 };

            await workService.AddMiasto(miasto);

            Assert.Equal(1, miastoFakeRepo.GetAllAsync().Result.Count());

            var miastoDel = unitOfWork.MiastoRepository.GetAllAsync().Result.FirstOrDefault(x => x.Id == 1);

            await workService.DeleteMiasto(miasto);

            Assert.Equal(0, miastoFakeRepo.GetAllAsync().Result.Count());
        }
    }
}
