using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectDAL
{
    public class UnitTestUnitOfWork
    {
        [Fact]
        public void TestUnitOfWork()
        {
            var miastoRepo = new MiastoRepoDummy();

            var unitOfWork = new UnitOfWork(miastoRepo);

            Assert.Same(miastoRepo, unitOfWork.MiastoRepository);
        }
    }
}
