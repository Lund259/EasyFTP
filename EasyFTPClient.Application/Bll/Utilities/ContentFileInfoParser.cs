using EasyFTPClient.Application.Acquaintance;
using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Bll.Utilities.Interfaces;
using EasyFTPClient.Application.Foundation.Entity;
using EasyFTPClient.Application.Foundation.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EasyFTPClient.Bll.Foundation.Utilities
{
    public class ContentFileInfoParser : IContentFileInfoParser
    {
        private const string nixRegexPattern = @"^([d-])([\w-]+)\s+(\d+)\s+(\w+)\s+(\w+)\s+(\d+)\s+(\w+\s+\d+\s+\d+|\w+\s+\d+\s+\d+:\d+)\s+(.+)$";
        private const string dosRegexPattern = @"^(\d+-\d+-\d+\s+\d+:\d+(?:AM|PM))\s+(<DIR>|\d+)\s+(.+)$";

        private static readonly Regex nixRegex = new Regex(nixRegexPattern);
        private static readonly Regex dosRegex = new Regex(dosRegexPattern);
        private static readonly IFormatProvider culture = CultureInfo.InvariantCulture;

        public IList<IContentFileInfo> ParseStringData(IEnumerable<string> dataListings)
        {
            IList<IContentFileInfo> result = new List<IContentFileInfo>();

            foreach (var dataListing in dataListings)
            {
                var dataFormat = GetDataFormat(dataListing);
                IContentFileInfo newFtpFileInfo = dataFormat switch
                {
                    DataFormat.DosWindows => ParseDosString(dataListing),
                    DataFormat.Nix => ParseNixString(dataListing),
                    _ => throw new NotImplementedException($"A parser for {dataFormat} format has not been implemented")
                };

                result.Add(newFtpFileInfo);
            }

            return result;
        }

        public DataFormat GetDataFormat(string dataListing)
        {
            if (string.IsNullOrWhiteSpace(dataListing))
            {
                throw new ArgumentException("dataListing cannot be null, empty or whitespace", nameof(dataListing));
            }

            DataFormat dataFormat;

            if(nixRegex.IsMatch(dataListing))
            {
                dataFormat = DataFormat.Nix;
            }
            else if(dosRegex.IsMatch(dataListing))
            {
                dataFormat = DataFormat.DosWindows;
            }
            else
            {
                throw new NotImplementedException("The datalisting format is unknown and cannot be parsed");
            }

            return dataFormat;
        }

        public IContentFileInfo ParseNixString(string dataListing)
        {
            if (string.IsNullOrWhiteSpace(dataListing))
            {
                throw new ArgumentException("dataListing cannot be null, empty or whitespace", nameof(dataListing));
            }

            string[] hourMinFormats =
                new[] { "MMM dd HH:mm", "MMM dd H:mm", "MMM d HH:mm", "MMM d H:mm" };
            string[] yearFormats =
                new[] { "MMM dd yyyy", "MMM d yyyy" };

            Match match = nixRegex.Match(dataListing);

            string filePermissions = match.Groups[2].Value;
            int inode = int.Parse(match.Groups[3].Value);
            string owner = match.Groups[4].Value;
            string group = match.Groups[5].Value;
            bool isDirectory = string.Equals(match.Groups[1].Value, "d", StringComparison.InvariantCultureIgnoreCase);
            long fileSize = long.Parse(match.Groups[6].Value);
            string fileName = match.Groups[8].Value;

            DateTime lastModified;
            string sanitizedString = Regex.Replace(match.Groups[7].Value, @"\s+", " "); //Ensure maximum of 1 whitespace in between letters/digits
            if (sanitizedString.IndexOf(':') >= 0)
            {
                lastModified = DateTime.ParseExact(sanitizedString, hourMinFormats, culture, DateTimeStyles.None);
            }
            else
            {
                lastModified = DateTime.ParseExact(sanitizedString, yearFormats, culture, DateTimeStyles.None);
            }

            return new FtpFileInfo(isDirectory, fileSize, lastModified, fileName);
        }

        public IContentFileInfo ParseDosString(string dataListing)
        {
            if (string.IsNullOrWhiteSpace(dataListing))
            {
                throw new ArgumentException("dataListing cannot be null, empty or whitespace", nameof(dataListing));
            }

            Match match = dosRegex.Match(dataListing);

            DateTime lastModified = DateTime.ParseExact(match.Groups[1].Value, "MM-dd-yy  hh:mmtt", culture, DateTimeStyles.None);
            long fileSize = (match.Groups[2].Value != "<DIR>") ? long.Parse(match.Groups[2].Value) : 0;
            string fileName = match.Groups[3].Value;
            bool isDirectory = string.Equals(match.Groups[2].Value, "<DIR>", StringComparison.InvariantCultureIgnoreCase);

            return new FtpFileInfo(isDirectory, fileSize, lastModified, fileName);
        }
    }
}
