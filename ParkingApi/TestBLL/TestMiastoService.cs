using BLL.WorkServices;
using DAL.DataContext;
using DAL.Entity;
using DAL.IRepository;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class TestMiastoService
    {
        [Fact]
        public async Task TestGetMiasta()
        {

            Mock<IMiastoRepository> mockMiastoRepository = new Mock<IMiastoRepository>();
            mockMiastoRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Miasto> { new Miasto(), new Miasto(), new Miasto() });


            var unitOfWork = new UnitOfWork(null, mockMiastoRepository.Object);
            var miastoService = new MiastoService(unitOfWork);

            Assert.Equal(3, miastoService.GetMiasta().Result.Count());

        }

        [Fact]
        public async Task TestDodajMiasto()
        {

            var miastoRepo = new MiastoFakeRepo();
            var unitOfWork = new UnitOfWork(null, miastoRepo);
            var miastoService = new MiastoService(unitOfWork);

            miastoRepo?.Add(new Miasto());
            Assert.Equal(1, miastoRepo?.GetAllAsync().Result.Count());

            miastoRepo?.Add(new Miasto());
            Assert.Equal(2, miastoRepo?.GetAllAsync().Result.Count());

            miastoRepo?.Add(new Miasto());
            Assert.Equal(3, miastoRepo?.GetAllAsync().Result.Count());

        }

        [Fact]
        public void TestUsunMiasto()
        {
            var miastoRepo = new MiastoFakeRepo();
            var unitOfWork = new UnitOfWork(null, miastoRepo);
            var miastoService = new MiastoService(unitOfWork);

            miastoRepo?.Add(new Miasto() { Id = 1 });
            Assert.Equal(1, miastoRepo?.GetAllAsync().Result.Count());

            miastoRepo?.Add(new Miasto());
            Assert.Equal(2, miastoRepo?.GetAllAsync().Result.Count());

            var miasto = new Miasto() { Id = 1 };

            miastoRepo?.Delete(miasto);
            Assert.Equal(1, miastoRepo?.GetAllAsync().Result.Count());
        }

        [Fact]
        public void TestUpdateMiasto()
        {
            var miastoRepo = new MiastoFakeRepo();
            var unitOfWork = new UnitOfWork(null, miastoRepo);
            var miastoService = new MiastoService(unitOfWork);

            Miasto katowice = new Miasto()
            {
                Id = 1,
                Nazwa = "Katowice",
                Wojewodztwo = "Małopolskie",
                Parkingi = new Collection<Parking> { }
            };

            miastoRepo?.Add(katowice);
            katowice.Wojewodztwo = "Śląskie";
            miastoRepo?.Update(katowice);

            Assert.Equal(katowice, miastoRepo?.GetByIdAsync(1).Result);
        }
    }
}
