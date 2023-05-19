using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WpfApp2.Commands;

namespace WpfApp2.ViewModels
{
    public class NotifyViewModel : ViewModelBase
    {
        public ICommand NotifyCommand { get; set; }

        public NotifyViewModel(NotifyIcon notifyIcon) {
            NotifyCommand = new NotifyCommand(notifyIcon);
        }
    }
}
