using TestMVCControllers;
using PresentationLayer.Controllers;
using Moq;
using BLL;
using DAL.Entity;

namespace TestAPIControllers
{
    public class TestMiastaAPIController
    {
        [Fact]
        public void TestDodajMiasto() {
            ParkingBLLMock parkingBLLMock = new ParkingBLLMock();
            MiastoController miastoController = new MiastoController(parkingBLLMock);
            miastoController.DodajMiasto("Test1", "Test1");

            Assert.Equal(2, parkingBLLMock.miasta.Count());
        }


        [Fact]
        public void TestUsunMiasto() {
            ParkingBLLMock parkingBLLMock = new ParkingBLLMock();
            MiastoController miastoController = new MiastoController(parkingBLLMock);

            Miasto miasto = parkingBLLMock.miasta.Find(x => x.Nazwa == "Test2");

            miastoController.UsunMiasto(miasto.Id);

            Assert.Equal(1, parkingBLLMock.miasta.Count());

        }
    }
}
