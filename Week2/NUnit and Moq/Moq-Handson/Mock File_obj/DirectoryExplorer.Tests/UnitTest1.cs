using NUnit.Framework;
using MagicFilesLib;
using Moq;
using System.Collections.Generic;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";
        private Mock<IDirectoryExplorer> _mockDirectoryExplorer;

        [OneTimeSetUp]
        public void Init()
        {
            _mockDirectoryExplorer = new Mock<IDirectoryExplorer>();
            _mockDirectoryExplorer
                .Setup(x => x.GetFiles(It.IsAny<string>()))
                .Returns(new List<string> { _file1, _file2 });
        }

        [TestCase("C:\\Test")]
        public void GetFiles_ReturnsExpectedFiles(string path)
        {
            // Act
            var files = _mockDirectoryExplorer.Object.GetFiles(path);

            // Assert
            NUnit.Framework.Assert.That(files, Is.Not.Null);
            NUnit.Framework.Assert.That(files.Count, Is.EqualTo(2));
            NUnit.Framework.Assert.That(files, Does.Contain(_file1));
        }
    }
}
