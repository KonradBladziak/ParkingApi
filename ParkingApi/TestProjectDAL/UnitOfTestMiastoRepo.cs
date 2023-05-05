using DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace TestProjectDAL
{
    public class UnitOfTestMiastoRepo
    {
        [Fact]
        public void TestGetMiasta()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("Testowa")
                .Options;
        }
    }
}