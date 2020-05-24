using Caliburn.Micro;
using EasyFTPClient.WPFUI.Models;
using System.Threading;
using System.Threading.Tasks;

namespace EasyFTPClient.WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>
    {
        public Page[] Pages { get; set; }

        private Page _currentPage;

        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                NotifyOfPropertyChange(() => CurrentPage);
                LoadView();
            }
        }

        public ShellViewModel()
        {
            Pages = new Page[]
            {
                new Page("Remote Files", new FtpFilesViewModel())
            };
            CurrentPage = Pages[0];
        }

        public void LoadView()
        {
            ActivateItemAsync(CurrentPage.Screen, CancellationToken.None);
        }
    }
}
