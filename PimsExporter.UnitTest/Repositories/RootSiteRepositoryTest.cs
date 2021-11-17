using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.InputRepositories;
using SharePoint.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PimsExporter.UnitTest.Repositories
{
    [TestClass]
    public class RootSiteRepositoryTest
    {
        [TestMethod]
        public void GetAllVersionsTest()
        {
            // ARRANGE
            var list = new List<AllVersion>
            {
                new AllVersion
                {
                    PimsId = "0001/0001",
                    VersionName = "MyVersion1"
                },
                new AllVersion
                {
                    PimsId = "0001/0002",
                    VersionName = "MyVersion2"
                },
                new AllVersion
                {
                    PimsId = "0002/0001",
                    VersionName = "MyVersion3"
                }
            };
            var spMock = new Mock<ISharePointAdapter>();
            spMock.Setup(sp => sp.AllVersions()).Returns(list);
            var rootRepository = new RootSiteRepository(spMock.Object);

            // ACT
            var versions = rootRepository.GetAllVersions().ToList();

            // ASSERT
            var version1 = versions[0];
            Assert.AreEqual("0001/0001", version1.PimsId);
            Assert.AreEqual("MyVersion1", version1.VersionName);
            var version2 = versions[1];
            Assert.AreEqual("0001/0002", version2.PimsId);
            Assert.AreEqual("MyVersion2", version2.VersionName);
            var version3 = versions[2];
            Assert.AreEqual("0002/0001", version3.PimsId);
            Assert.AreEqual("MyVersion3", version3.VersionName);
        }
    }
}