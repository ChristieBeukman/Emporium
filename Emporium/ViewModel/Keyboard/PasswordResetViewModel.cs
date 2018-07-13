using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Emporium.Messenger;
using Emporium.Model;
using Emporium.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Emporium.ViewModel.Keyboard
{
    public class PasswordResetViewModel : LoginViewModel
    {
        public PasswordResetViewModel()
        {
            ResetUserPassword = new User_UserLevel();
            _ServiceProxy = new DataAccess();
            PasswordResetCommand = new RelayCommand(ExecuteResetPassword);
        }

        IDataAccess _ServiceProxy;
        private string _FirstInput;
        private string _SecondInput;
        private User_UserLevel _ResetUserPassword;

        public string FirstInput
        {
            get
            {
                return _FirstInput;
            }

            set
            {
                _FirstInput = value;
                RaisePropertyChanged("FirstInput");
            }
        }

        public string SecondInput
        {
            get
            {
                return _SecondInput;
            }

            set
            {
                _SecondInput = value;
                RaisePropertyChanged("SecondInput");
            }
        }

        public User_UserLevel ResetUserPassword
        {
            get
            {
                return _ResetUserPassword;
            }

            set
            {
                _ResetUserPassword = value;
                RaisePropertyChanged("ResetUserPassword");
            }
        }

        public RelayCommand PasswordResetCommand { get; set; }

        void ExecuteResetPassword()
        {
            if (Message.Length < 5)
            {
                MessageBox.Show("Password must be at least 5 characters long");
                Message = string.Empty;
                Output = string.Empty;
            }
            else 
            {
                if (FirstInput == null)
                {
                    FirstInput = Message;
                    MessageBox.Show("Re enter password");
                    Message = string.Empty;
                    Output = string.Empty;
                }
                else
                {
                    SecondInput = Message;
                    if (FirstInput == SecondInput)
                    {
                        ResetUserPassword = _ServiceProxy.GetUserDetails(Logger.UserId);
                        ResetUserPassword.Password = FirstInput;
                        _ServiceProxy.UpdateUser(ResetUserPassword);
                        MessageBox.Show("Updated");
                        ViewModelLocator.RegisterViewModel(ViewModelList.Configuration);
                        MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.Configuration));
                        ViewModelLocator.Cleanup(ViewModelList.PasswordReset);
                    }
                    else
                    {
                        MessageBox.Show("Passwords does not match");
                        FirstInput = string.Empty;
                        SecondInput = string.Empty;
                        Message = string.Empty;
                        Output = string.Empty;
                    }
                }
            }
             
        }
    }
}
