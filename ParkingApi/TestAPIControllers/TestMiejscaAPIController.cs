using TestMVCControllers;
using PresentationLayer.Controllers;
using Moq;
using BLL;

namespace TestAPIControllers
{
    public class TestMiejscaAPIController
    {
        [Fact]
        public void TestDodajMiejsca()
        {
            ParkingBLLMock parkingBLLMock = new ParkingBLLMock();
            MiejscaController miejscaAPIController = new MiejscaController(parkingBLLMock);
            var result = miejscaAPIController.DodajMiejsca(5, 1);


            Assert.Equal(5, parkingBLLMock.IleMiejscDodano);
        }

        [Fact]
        public void TestDodajMiejscaInwalidzkie()
        {
            ParkingBLLMock parkingBLLMock = new ParkingBLLMock();
            MiejscaController miejscaAPIController = new MiejscaController(parkingBLLMock);
            var result = miejscaAPIController.DodajMiejscaInwalidzkie(5, 1, 2);


            Assert.Equal(5, parkingBLLMock.IleMiejscDodano);
        }

        [Fact]
        public void TestDodajMiejscaMoq()
        {
            Mock<IWorkService> miejscaBLLMock = new Mock<IWorkService>();
            MiejscaController miejscaAPIController = new MiejscaController(miejscaBLLMock.Object);
            var result = miejscaAPIController.DodajMiejsca(5, 1);

            miejscaBLLMock.Verify(m => m.DodajMiejsca(5, 1));
        }

        [Fact]
        public void TestDodajMiejscaInwalidzkieMoq()
        {
            Mock<IWorkService> miejscaBLLMock = new Mock<IWorkService>();
            MiejscaController miejscaAPIController = new MiejscaController(miejscaBLLMock.Object);
            var result = miejscaAPIController.DodajMiejscaInwalidzkie(5, 1, 2);

            miejscaBLLMock.Verify(m => m.DodajMiejscaInwalidzkie(5, 1, 2));
        }
    }
}