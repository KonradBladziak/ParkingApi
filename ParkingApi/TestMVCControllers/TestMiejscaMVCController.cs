using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Moq;
using PresentationLayer.Controllers;

namespace TestMVCControllers
{
    public class TestMiejscaMVCController
    {
        [Fact]
        public void TestDodajMiejsca()
        {
            ParkingBLLMock parkingBLLMock = new ParkingBLLMock();
            MiejscaMVCController miejscaMVCController = new MiejscaMVCController(parkingBLLMock);
            var result = miejscaMVCController.DodajMiejsca(5, 1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Null(viewResult.Model);
            Assert.Equal(5, parkingBLLMock.IleMiejscDodano);
        }

        [Fact]
        public void TestDodajMiejscaInwalidzkie()
        {
            ParkingBLLMock parkingBLLMock = new ParkingBLLMock();
            MiejscaMVCController miejscaMVCController = new MiejscaMVCController(parkingBLLMock);
            var result = miejscaMVCController.DodajMiejscaInwalidzkie(5, 1, 2);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Null(viewResult.Model);
            Assert.Equal(5, parkingBLLMock.IleMiejscDodano);
        }

        [Fact]
        public void TestDodajMiejscaMoq()
        {
            Mock<IWorkService> miejscaBLLMock = new Mock<IWorkService>();
            MiejscaMVCController miejscaMVCController = new MiejscaMVCController(miejscaBLLMock.Object);
            var result = miejscaMVCController.DodajMiejsca(5, 1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Null(viewResult.Model);

            miejscaBLLMock.Verify(m => m.DodajMiejsca(5, 1));
        }

        [Fact]
        public void TestDodajMiejscaInwalidzkieMoq()
        {
            Mock<IWorkService> miejscaBLLMock = new Mock<IWorkService>();
            MiejscaMVCController miejscaMVCController = new MiejscaMVCController(miejscaBLLMock.Object);
            var result = miejscaMVCController.DodajMiejscaInwalidzkie(5, 1, 2);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Null(viewResult.Model);

            miejscaBLLMock.Verify(m => m.DodajMiejscaInwalidzkie(5, 1, 2));
        }
    }
}