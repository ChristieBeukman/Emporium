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
    public class ConfigUsersKeyboardViewModel : KeyPadViewModel
    {
        public ConfigUsersKeyboardViewModel()
        {
            _ServiceProxy = new DataAccess();
            SelectedUser = new User_UserLevel();
            GetUserParameter(Logger.UserId);
            MessengerInstance.Register<KeyboardMessage<UserProperty>>(this, ReceiveMessage);
            EnterCommand = new RelayCommand(ExecuteEnter);
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
                    if (Message == "Please Enter Name")
                    {
                        MessageBox.Show("Name cannot be Empty");
                        
                    }
                    else
                    {
                        SelectedUser.Name = Message;
                        LoadConfiguration();
                    }
                    
                    break;
                case UserProperty.Surname:
                    if (Message == "Please Enter Surname")
                    {
                        MessageBox.Show("Surname cannot be Empty");

                    }
                    else
                    {
                        SelectedUser.Surname = Message;
                        LoadConfiguration();
                    }
                    
                    break;
                case UserProperty.Number:
                    if (IsDigitOnly(Message) == true)
                    {
                        SelectedUser.Number = Message;
                        LoadConfiguration();
                    }
                    else
                    {
                        MessageBox.Show("Number must be Numeric");
                    }
                    break;
                case UserProperty.IDNumber:
                    if (IsDigitOnly(Message) == true)
                    {
                        SelectedUser.IDNum = Message;
                        LoadConfiguration();
                    }


                    break;
                case UserProperty.Bank:
                    SelectedUser.Bank = Message;
                    LoadConfiguration();
                    break;
                case UserProperty.BranchNo:

                    if (IsDigitOnly(Message) == true)
                    {
                        SelectedUser.BranchNo = Message;
                        LoadConfiguration();
                    }
                    else
                    {
                        MessageBox.Show("Number must be Numeric");
                    }

                    break;
                case UserProperty.BankNo:
                    if (IsDigitOnly(Message) == true)
                    {
                        SelectedUser.BankNo = Message;
                        LoadConfiguration();
                    }
                    else
                    {
                        MessageBox.Show("Number must be Numeric");
                    }

                    break;
                case UserProperty.Password:
                    if (IsDigitOnly(Message) == true)
                    {
                        SelectedUser.Password = Message;
                        LoadConfiguration();
                    }
                    else
                    {
                        MessageBox.Show("Number must be Numeric");
                    }

                    break;
                default:
                    break;
            }


        }

        void LoadConfiguration()
        {
            _ServiceProxy.UpdateUser(SelectedUser);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.Configuration));
            ViewModelLocator.Cleanup(ViewModelList.ConfigKeyboard);
        }


    }
}
