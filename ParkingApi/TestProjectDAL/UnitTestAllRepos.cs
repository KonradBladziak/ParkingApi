using DAL.DataContext;
using DAL.Entity;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace TestProjectDAL
{
    public class UnitTestAllRepos
    {
        [Fact]
        public async Task TestGetMiasta()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Testowa")
                .Options;
            var databaseContext = new DatabaseContext(options);
            MiastoRepository miastoRepository = new MiastoRepository(databaseContext);

            
            Assert.Empty(await miastoRepository.GetMiasta());
            await miastoRepository.InsertMiasto(new DAL.Entity.Miasto { Id = 1, Nazwa = "Test", Wojewodztwo = "Testowe" });
            await miastoRepository.Save();

            var listaMiast = await miastoRepository.GetMiasta();

            Assert.Equal(1, listaMiast.Count());
        }

        [Fact]
        public async Task TestGetParkingi()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Testowa")
                .Options;
            var databaseContext = new DatabaseContext(options);
            ParkingRepository parkingRepository = new ParkingRepository(databaseContext);


            Assert.Empty(await parkingRepository.GetParkingi());
            await parkingRepository.InsertParking(new DAL.Entity.Parking { Id = 1, Nazwa = "Test", Adres = "Test", IdMiasta = 1 });
            await parkingRepository.Save();

            var listaParkingow = await parkingRepository.GetParkingi();

            Assert.Equal(1, listaParkingow.Count());
        }

        [Fact]
        public async Task TestGetMiejsca()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Testowa")
                .Options;
            var databaseContext = new DatabaseContext(options);
            MiejsceRepository miejsceRepository = new MiejsceRepository(databaseContext);


            Assert.Empty(await miejsceRepository.GetMiejsca());
            await miejsceRepository.InsertMiejsce(new DAL.Entity.Miejsce { Id = 1, ParkingId = 1, MiejsceInwalidzkieId = 1 });
            await miejsceRepository.Save();

            var listaMiejsc= await miejsceRepository.GetMiejsca();

            Assert.Equal(1, listaMiejsc.Count());
        }

        [Fact]
        public async Task TestGetInwalidzkie()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Testowa")
                .Options;
            var databaseContext = new DatabaseContext(options);
            InwalidzkieRepository inwalidzkieRepository = new InwalidzkieRepository(databaseContext);


            Assert.Empty(await inwalidzkieRepository.GetMiejscaInwalidzkie());
            await inwalidzkieRepository.InsertMiejsceInwalidzkie(new DAL.Entity.MiejsceInwalidzkie { Id = 1, RozmiarMiejsca = 2 });
            await inwalidzkieRepository.Save();

            var listaMiejsc = await inwalidzkieRepository.GetMiejscaInwalidzkie();

            Assert.Equal(1, listaMiejsc.Count());
        }

        [Fact]
        public async Task TestGetOpiekunowie()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Testowa")
                .Options;
            var databaseContext = new DatabaseContext(options);
            OpiekunRepository opienkunRepository = new OpiekunRepository(databaseContext);


            Assert.Empty(await opienkunRepository.GetOpiekunowie());
            await opienkunRepository.InsertOpiekun(new DAL.Entity.Opiekun { Id = 1, Imie = "Test", Nazwisko = "Test" });
            await opienkunRepository.Save();

            var listaOpiekunow = await opienkunRepository.GetOpiekunowie();

            Assert.Equal(1, listaOpiekunow.Count());
        }

        [Fact]
        public async Task TestGetRezerwacje()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Testowa")
                .Options;
            var databaseContext = new DatabaseContext(options);
            RezerwacjaRepository rezerwacjaRepository = new RezerwacjaRepository(databaseContext);


            Assert.Empty(await rezerwacjaRepository.GetRezerwacje());
            await rezerwacjaRepository.InsertRezerwacja(new DAL.Entity.Rezerwacja { Id = 1, Od = new DateTime(2023, 7, 12, 14, 0, 0), 
                Do = new DateTime(2023, 7, 12, 14, 0, 0), IdMiejsca = 1, Imie = "Test", Nazwisko = "Test" });
            await rezerwacjaRepository.Save();

            var listaRezerwacjii = await rezerwacjaRepository.GetRezerwacje();

            Assert.Equal(1, listaRezerwacjii.Count());
        }
    }
}