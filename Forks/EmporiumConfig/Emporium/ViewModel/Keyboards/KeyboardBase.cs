using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emporium.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Emporium.ViewModel.Keyboards
{
    public class KeyboardBase : ViewModelBase
    {

        public KeyboardBase()
        {
            BackspaceCommand = new RelayCommand(ExecuteBackspace);
        }

        private string _Message;
        private bool _CapsEnabled = false;
        private bool _CapsDisabled = true;

        public bool CapsEnabled
        {
            get
            {
                return _CapsEnabled;
            }

            set
            {
                _CapsEnabled = value;
                RaisePropertyChanged("CapsEnabled");
            }
        }

        public bool CapsDisabled
        {
            get
            {
                return _CapsDisabled;
            }

            set
            {
                _CapsDisabled = value;
                RaisePropertyChanged("CapsDisabled");
            }
        }

        public string Message
        {
            get
            {
                return _Message;
            }

            set
            {
                _Message = value;
                RaisePropertyChanged("Message");
            }
        }

        public void Clickkey(string key)
        {
            Message = Message + key;
            RaisePropertyChanged("Message");
        }

        public RelayCommand BackspaceCommand { get; set; }
        void ExecuteBackspace()
        {
            if (Message != null)
            {
                if (Message.Length != 0)
                {
                    Message = Message.Remove(Message.Length - 1);
                }
            }
        }
    }
}
