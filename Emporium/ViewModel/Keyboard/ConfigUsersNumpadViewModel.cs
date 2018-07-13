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
    public class ConfigUsersNumpadViewModel : NumPadViewModel
    {
        public ConfigUsersNumpadViewModel()
        {
            _ServiceProxy = new DataAccess();
            SelectedUser = new User_UserLevel();
            GetUserParameter(Logger.UserId);
            MessengerInstance.Register<KeyboardMessage<UserProperty>>(this, ReceiveMessage);
            EnterCommand = new RelayCommand(ExecuteEnter);
            ControlVisible = false;
        }

        IDataAccess _ServiceProxy;
        private User_UserLevel _SelectedUser;

        public User_UserLevel SelectedUser
        {
            get
            {
                return _SelectedUser;
            }

            set
            {
                _SelectedUser = value;
                RaisePropertyChanged("SelectedUser");
                if (_SelectedUser != null)
                {
                    switch (Logger.UserPropertyToEdit)
                    {
                        case UserProperty.Name:
                            Message = SelectedUser.Name;
                            break;
                        case UserProperty.Surname:
                            Message = SelectedUser.Surname;
                            break;
                        case UserProperty.Number:
                            Message = SelectedUser.Number;
                            break;
                        case UserProperty.IDNumber:
                            Message = SelectedUser.IDNum;
                            break;
                        case UserProperty.Bank:
                            Message = SelectedUser.Bank;
                            break;
                        case UserProperty.BranchNo:
                            Message = SelectedUser.BranchNo;
                            break;
                        case UserProperty.BankNo:
                            Message = SelectedUser.BankNo;
                            break;
                        case UserProperty.Password:
                            Message = SelectedUser.Password;
                            break;
                        default:
                            break;

                    }
                    RaisePropertyChanged("Message");
                }
            }
        }

        void ReceiveMessage(KeyboardMessage<UserProperty> message)
        {
            GetUserParameter(Logger.UserId);
        }
        void GetUserParameter(int userid)
        {
            SelectedUser = _ServiceProxy.GetUserDetails(userid);

            if (SelectedUser != null)
            {
                switch (Logger.UserPropertyToEdit)
                {
                    case UserProperty.Name:
                        Message = SelectedUser.Name;
                        break;
                    case UserProperty.Surname:
                        Message = SelectedUser.Surname;
                        break;
                    case UserProperty.Number:
                        Message = SelectedUser.Number;
                        break;
                    case UserProperty.IDNumber:
                        Message = SelectedUser.IDNum;
                        break;
                    case UserProperty.Bank:
                        Message = SelectedUser.Bank;
                        break;
                    case UserProperty.BranchNo:
                        Message = SelectedUser.BranchNo;
                        break;
                    case UserProperty.BankNo:
                        Message = SelectedUser.BankNo;
                        break;
                    case UserProperty.Password:
                        Message = SelectedUser.Password;
                        break;
                    default:
                        break;
                }
                RaisePropertyChanged("Message");
            }

        }

        public RelayCommand EnterCommand { get; set; }
        void ExecuteEnter()
        {
            ViewModelLocator.RegisterViewModel(ViewModelList.Configuration);
            switch (Logger.UserPropertyToEdit)        //TODO Validate input
            {
                case UserProperty.Name:
                    SelectedUser.Name = Message;
                    break;
                case UserProperty.Surname:
                    SelectedUser.Surname = Message;
                    break;
                case UserProperty.Number:
                    SelectedUser.Number = Message;
                    break;
                case UserProperty.IDNumber:
                    if (Message.Length != 13)
                    {
                        MessageBox.Show("ID number must be 13 characters");
                    }
                    else if (IsDigitOnly(Message) == true)
                    {
                        SelectedUser.IDNum = Message;
                        _ServiceProxy.UpdateUser(SelectedUser);
                        MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.Configuration));
                        ViewModelLocator.Cleanup(ViewModelList.ConfigNumPad);
                    }
                    else
                    {
                        MessageBox.Show("ID Number must be Numeric");
                    }


                    break;
                case UserProperty.Bank:
                    SelectedUser.Bank = Message;
                    break;
                case UserProperty.BranchNo:
                    SelectedUser.BranchNo = Message;
                    break;
                case UserProperty.BankNo:
                    SelectedUser.BankNo = Message;
                    break;
                case UserProperty.Password:
                    SelectedUser.Password = Message;
                    break;
                default:
                    break;
            }


        }

        bool IsDigitOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
