using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Tests.Repositories
{
    public class TestModelMock
    {
    }

    [TestFixture]
    public class GenericRepositroryTests
    {
        [Test]
        public void Constructor_NullDB_ShouldThrow()
        {
            var dbMock = new Mock<ICodeWarfaresDbContext>();

            Assert.Throws<ArgumentException>(() => new GenericRepository<TestModelMock>(null));
        }

        [Test]
        public void Constructor_ShouldCallSet_ShouldThrow()
        {
            var dbMock = new Mock<ICodeWarfaresDbContext>();

            var repository = new GenericRepository<TestModelMock>(dbMock.Object);

            dbMock.Verify(x => x.Set<TestModelMock>(), Times.Once());
        }

        [Test]
        public void MethodAll_ShouldCall()
        {
            var dbMock = new Mock<ICodeWarfaresDbContext>();


            var repository = new GenericRepository<TestModelMock>(dbMock.Object);

            Assert.Throws<ArgumentNullException>(() => repository.All());
        }

        [Test]
        public void GetById_ShouldCall()
        {
            var dbMock = new Mock<ICodeWarfaresDbContext>();


            var repository = new GenericRepository<TestModelMock>(dbMock.Object);

            Assert.Throws<NullReferenceException>(() => repository.GetById(2));
        }

        [Test]
        public void SaveChanges_ShouldCall()
        {
            var dbMock = new Mock<ICodeWarfaresDbContext>();


            var repository = new GenericRepository<TestModelMock>(dbMock.Object);

            repository.SaveChanges();

            dbMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public void Dispose_ShouldCall()
        {
            var dbMock = new Mock<ICodeWarfaresDbContext>();


            var repository = new GenericRepository<TestModelMock>(dbMock.Object);

            repository.Dispose();

            dbMock.Verify(x => x.Dispose(), Times.Once());
        }
    }
}
