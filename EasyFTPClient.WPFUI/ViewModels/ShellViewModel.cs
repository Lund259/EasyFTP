using Caliburn.Micro;
using EasyFTPClient.Application.Acquaintance;
using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Fascade.Factories;
using EasyFTPClient.Application.Fascade.Interfaces;
using EasyFTPClient.WPFUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EasyFTPClient.WPFUI.ViewModels
{
    public class ShellViewModel : Screen
    {
        private BindableCollection<IContentFileInfo> contentFiles;

        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public BindableCollection<IContentFileInfo> ContentFiles 
        { 
            get => contentFiles;
            set
            {
                contentFiles = value;
                NotifyOfPropertyChange(() => ContentFiles);
            }
        }


        public void ConnectButton()
        {
            IConnectionProvider connection = new Connection(new Uri(Url), Username, Password);
            IContentFascade contentFascade = new FascadeFactory().CreateContentFascade(Application.Fascade.Entity.ConnectionType.Ftp, connection);

            ContentFiles = new BindableCollection<IContentFileInfo>(contentFascade.GetContentFileInfo(""));
        }
    }
}
