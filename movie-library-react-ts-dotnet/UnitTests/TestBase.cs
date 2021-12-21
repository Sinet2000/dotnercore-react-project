using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace UnitTests
{
    public abstract class TestBase
    {
        protected TestDataModels testDataModels;

        public TestBase()
        {
            testDataModels = new TestDataModels();
        }

        protected DataContext GetDataContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new DataContext(options);
        }
    }
}
