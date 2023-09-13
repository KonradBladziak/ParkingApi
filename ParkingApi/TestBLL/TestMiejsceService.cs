using BLL.WorkServices;
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
    public class TestMiejsceService
    {
        [Fact]
        public async Task TestGetMiejsca()
        {

            Mock<IMiejsceRepository> mockMiejsceRepository = new Mock<IMiejsceRepository>();
            mockMiejsceRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Miejsce> { new Miejsce(), new Miejsce(), new Miejsce() });


            var unitOfWork = new UnitOfWork(null,null,null, mockMiejsceRepository.Object);
            var miejsceService = new MiejsceService(unitOfWork);

            Assert.Equal(3, miejsceService.GetMiejsca().Result.Count());

        }

        [Fact]
        public async Task TestDodajMiejsce()
        {

            var miejsceFakeRepo = new MiejsceFakeRepo();
            var unitOfWork = new UnitOfWork(null, null, null, miejsceFakeRepo);
            var miejsceService = new MiejsceService(unitOfWork);


            miejsceFakeRepo?.Add(new Miejsce());
            Assert.Equal(1, miejsceFakeRepo?.GetAllAsync().Result.Count());

            miejsceFakeRepo?.Add(new Miejsce());
            Assert.Equal(2, miejsceFakeRepo?.GetAllAsync().Result.Count());

            miejsceFakeRepo?.Add(new Miejsce());
            Assert.Equal(3, miejsceFakeRepo?.GetAllAsync().Result.Count());

        }

        [Fact]
        public void TestUsunMiejsce()
        {
            var miejsceFakeRepo = new MiejsceFakeRepo();
            var unitOfWork = new UnitOfWork(null, null, null, miejsceFakeRepo);
            var miejsceService = new MiejsceService(unitOfWork);

            miejsceFakeRepo?.Add(new Miejsce() { Id = 1 });
            Assert.Equal(1, miejsceFakeRepo?.GetAllAsync().Result.Count());

            miejsceFakeRepo?.Add(new Miejsce());
            Assert.Equal(2, miejsceFakeRepo?.GetAllAsync().Result.Count());

            var miejsce = new Miejsce() { Id = 1 };

            miejsceFakeRepo?.Delete(miejsce);
            Assert.Equal(1, miejsceFakeRepo?.GetAllAsync().Result.Count());
        }

        [Fact]
        public void TestUpdateMiejsce()
        {
            var miejsceFakeRepo = new MiejsceFakeRepo();
            var unitOfWork = new UnitOfWork(null, null, null, miejsceFakeRepo);
            var miejsceService = new MiejsceService(unitOfWork);

            Miejsce miejsce1 = new Miejsce()
            {
                Id = 1,
                ParkingId = 1
            };

            miejsceFakeRepo?.Add(miejsce1);
            miejsce1.ParkingId = 2;
            miejsceFakeRepo?.Update(miejsce1);

            Assert.Equal(miejsce1, miejsceFakeRepo?.GetByIdAsync(1).Result);
        }
    }
}
