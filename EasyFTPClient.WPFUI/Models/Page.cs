using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.WPFUI.Models
{
    public class Page
    {
        public string Name { get; set; }
        public Screen Screen { get; set; }

        public Page(string name, Screen screen)
        {
            Name = name;
            Screen = screen;
        }
    }
}
