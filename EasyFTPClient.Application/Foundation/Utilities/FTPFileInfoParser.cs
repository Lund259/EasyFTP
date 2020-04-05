using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity;
using EasyFTPClient.Application.Foundation.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EasyFTPClient.Application.Foundation.Utilities
{
    public partial class FTPFileInfoParser : IFTPFileInfoParser
    {
        public IList<IFTPFileInfo> ParseStringData(IEnumerable<string> dataListings)
        {
            IList<IFTPFileInfo> result = new List<IFTPFileInfo>();

            foreach (var dataListing in dataListings)
            {
                var dataFormat = GetDataFormat(dataListing);
                IFTPFileInfo newFTPFileInfo = dataFormat switch
                {
                    DataFormat.DosWindows => ParseDosString(dataListing),
                    DataFormat.Nix => ParseNixString(dataListing),
                    _ => throw new NotImplementedException($"A parser for {dataFormat} format has not been implemented")
                };

                result.Add(newFTPFileInfo);
            }

            return result;
        }

        public DataFormat GetDataFormat(string dataListing)
        {
            DataFormat dataFormat;

            var nixRegexPattern = @"^([\w-]+)\s+(\d+)\s+(\w+)\s+(\w+)\s+(\d+)\s+(\w+\s+\d+\s+\d+|\w+\s+\d+\s+\d+:\d+)\s+(.+)$";
            var dosRegexPattern = @"^(\d+-\d+-\d+\s+\d+:\d+(?:AM|PM))\s+(<DIR>|\d+)\s+(.+)$";

            if(Regex.IsMatch(dataListing, nixRegexPattern))
            {
                dataFormat = DataFormat.Nix;
            }
            else if(Regex.IsMatch(dataListing, dosRegexPattern))
            {
                dataFormat = DataFormat.DosWindows;
            }
            else
            {
                throw new NotImplementedException("The datalisting format is unknown and cannot be parsed");
            }

            return dataFormat;
        }

        public IFTPFileInfo ParseNixString(string dataListing)
        {
            throw new NotImplementedException();
        }

        public IFTPFileInfo ParseDosString(string dataListing)
        {
            throw new NotImplementedException();
        }
    }
}
