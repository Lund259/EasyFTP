using EasyFTPClient.Application.Acquaintance;
using EasyFTPClient.Application.Foundation.Entity;
using EasyFTPClient.Application.Foundation.Factories;
using EasyFTPClient.Application.Foundation.Utilities.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EasyFTPClient.Application.Test.UnitTests.Foundation
{
    [TestFixture]
    public class FtpFileInfoParserTests
    {
        IFtpFileInfoParser FtpFileInfoParser;

        [SetUp]
        public void Setup()
        {
            FtpFileInfoParser = new UtilityFactory().CreateFtpFileInfoParser();
        }

        [TestCase("08-10-11  12:02PM       <DIR>          Version2", DataFormat.DosWindows)]
        [TestCase("06-25-09  02:41PM            144700153 image34.gif", DataFormat.DosWindows)]
        [TestCase("06-25-09  02:51PM            144700153 updates.txt", DataFormat.DosWindows)]
        [TestCase("11-04-10  02:45PM            144700214 digger-54.tif", DataFormat.DosWindows)]
        [TestCase("d--x--x--x    2 ftp      ftp          4096 Mar 07  2002 bin", DataFormat.Nix)]
        [TestCase("-rw-r--r--    1 ftp      ftp        659450 Jun 15 05:07 TEST.TXT", DataFormat.Nix)]
        [TestCase("-rw-r--r--    1 ftp      ftp      101786380 Sep 08  2008 TEST03-05.TXT", DataFormat.Nix)]
        [TestCase("drwxrwxr-x    2 ftp      ftp          4096 May 06 12:24 dropoff", DataFormat.Nix)]
        public void GetDataFormat_ReturnCorrectFormat(string dataListing, DataFormat dataFormat)
        {
            //Arrange

            var expected = dataFormat;
            //Act
            var actual = FtpFileInfoParser.GetDataFormat(dataListing);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("      ")]
        [TestCase("")]
        [TestCase(null)]
        public void GetDataFormat_NullEmptyWhitespaceData_ThrowException(string dataListing)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => FtpFileInfoParser.GetDataFormat(dataListing));
        }

        [TestCase("      ")]
        [TestCase("")]
        [TestCase(null)]
        public void ParseNixString_NullEmptyWhitespaceData_ThrowException(string dataListing)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => FtpFileInfoParser.ParseNixString(dataListing));
        }

        [TestCase("d--x--x--x    2 ftp      ftp          4096 Mar 07  2002 bin", true, 4096, "bin", 0, 0, 07, 3, 2002)]
        [TestCase("-rw-r--r--    1 ftp ftp        659450 Jun 15 05:07 TEST.TXT", false, 659450, "TEST.TXT", 7, 5, 15, 6, 0)]
        [TestCase("-rw-r--r--    1 ftp ftp      101786380 Sep 08  2008 TEST03-05.TXT", false, 101786380, "TEST03-05.TXT", 0, 0, 8, 9, 2008)]
        [TestCase("drwxrwxr-x    2 ftp ftp          4096 May 06 12:24 dropoff", true, 4096, "dropoff", 24, 12, 6, 5, 0)]
        public void ParseNixString_ReturnCorrectFTPFileInfo(string dataListing, bool isDirectory, long fileSize, string fileName, int minute, int hour, int day, int month, int year)
        {
            //Arrange
            if (year == 0)
                year = DateTime.Now.Year;

            var lastModified = new DateTime(year, month, day, hour, minute, 0);
            var expected = new ContentFileInfo(isDirectory, fileSize, lastModified, fileName);

            //Act
            var actual = FtpFileInfoParser.ParseNixString(dataListing);

            //Assert
            Assert.AreEqual(expected.IsDirectory, actual.IsDirectory);
            Assert.AreEqual(expected.FileSize, actual.FileSize);
            Assert.AreEqual(expected.LastModifiedDate, actual.LastModifiedDate);
            Assert.AreEqual(expected.FileName, actual.FileName);
        }

        [TestCase("      ")]
        [TestCase("")]
        [TestCase(null)]
        public void ParseDosString_NullEmptyWhitespaceData_ThrowException(string dataListing)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => FtpFileInfoParser.ParseDosString(dataListing));
        }

        [TestCase("08-10-11  12:02PM       <DIR>          Version2", true, 0, "Version2", 2, 12, 10, 8, 2011)]
        [TestCase("06-25-09  02:41PM            144700153 image34.gif", false, 144700153, "image34.gif", 41, 14, 25, 6, 2009)]
        [TestCase("06-25-09  02:51PM            144700153 updates.txt", false, 144700153, "updates.txt", 51, 14, 25, 6, 2009)]
        [TestCase("11-04-10  02:45PM            144700214 digger.tif", false, 144700214, "digger.tif", 45, 14, 4, 11, 2010)]
        public void ParseDosString_ReturnCorrectFTPFileInfo(string dataListing, bool isDirectory, long fileSize, string fileName, int minute, int hour, int day, int month, int year)
        {
            //Arrange
            if (year == 0)
                year = DateTime.Now.Year;

            var lastModified = new DateTime(year, month, day, hour, minute, 0);
            var expected = new ContentFileInfo(isDirectory, fileSize, lastModified, fileName);

            //Act
            var actual = FtpFileInfoParser.ParseDosString(dataListing);

            //Assert
            Assert.AreEqual(expected.IsDirectory, actual.IsDirectory);
            Assert.AreEqual(expected.FileSize, actual.FileSize);
            Assert.AreEqual(expected.LastModifiedDate, actual.LastModifiedDate);
            Assert.AreEqual(expected.FileName, actual.FileName);
        }

    }
}
