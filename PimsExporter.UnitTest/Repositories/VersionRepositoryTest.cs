using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.InputRepositories;
using SharePoint.Interfaces;
using System.Collections.Generic;

namespace PimsExporter.UnitTest.Repositories
{
    [TestClass]
    public class VersionRepositoryTest
    {
        [TestMethod]
        public void GetVersionRecordTest()
        {
            // ARRANGE
            var list = new List<VersionHeader>
            {
                new VersionHeader
                {
                    VersionName = "Version 1",
                    VersionManager = new User("Alice", "alice@mycompany.com"),
                    PimsId = "0001/0001",
                    ActiveStatus = false
                },
                new VersionHeader
                {
                    VersionName = "Version 2",
                    VersionManager = new User("Bob", "bob@mycompany.com"),
                    PimsId = "0001/0002",
                    ActiveStatus = true
                },
                new VersionHeader
                {
                    VersionName = "Version 3",
                    VersionManager = new User("Claire", "claire@mycompany.com"),
                    PimsId = "0002/0001",
                    ActiveStatus = true
                }
            };

            var spMock1 = new Mock<ISharePointAdapter>();
            spMock1.Setup(sp => sp.ProductVersion()).Returns(list[0]);
            var versionRepository1 = new VersionRepository(spMock1.Object);

            var spMock2 = new Mock<ISharePointAdapter>();
            spMock2.Setup(sp => sp.ProductVersion()).Returns(list[1]);
            var versionRepository2 = new VersionRepository(spMock2.Object);

            var spMock3 = new Mock<ISharePointAdapter>();
            spMock3.Setup(sp => sp.ProductVersion()).Returns(list[2]);
            var versionRepository3 = new VersionRepository(spMock3.Object);

            // ACT
            var version1 = versionRepository1.GetHeader();
            var version2 = versionRepository2.GetHeader();
            var version3 = versionRepository3.GetHeader();

            // ASSERT
            Assert.AreEqual("Version 1", version1.VersionName);
            Assert.AreEqual("Alice", version1.VersionManager.Name);
            Assert.AreEqual("alice@mycompany.com", version1.VersionManager.Email);
            Assert.AreEqual("0001/0001", version1.PimsId);

            Assert.AreEqual("Version 2", version2.VersionName);
            Assert.AreEqual("Bob", version2.VersionManager.Name);
            Assert.AreEqual("bob@mycompany.com", version2.VersionManager.Email);
            Assert.AreEqual("0001/0002", version2.PimsId);

            Assert.AreEqual("Version 3", version3.VersionName);
            Assert.AreEqual("Claire", version3.VersionManager.Name);
            Assert.AreEqual("claire@mycompany.com", version3.VersionManager.Email);
            Assert.AreEqual("0002/0001", version3.PimsId);
        }
    }
}