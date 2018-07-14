using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Emporium.ViewModel.Keyboard;
using Emporium.Messenger;
using Emporium.Model;
using Emporium.Services;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Emporium.ViewModel.Configuration
{
    public class ConfigurationViewModel : ViewModelBase
    {

        public ConfigurationViewModel()
        {
            _ServiceProxy = new DataAccess();
            Users = new ObservableCollection<User_UserLevel>();
            SelectedUser = new User_UserLevel();
            Userlevels = new ObservableCollection<eUserLevel>();
            SelectedUserLevel = new eUserLevel();

            GetUsers();
            GetUserLevels();
            DisplayNameKeyboard = new RelayCommand(ExecuteNameKeyboard);
            DisplaySurnameKeyboard = new RelayCommand(ExecuteSurnameKeyboard);
            DisplayNumberKeyboard = new RelayCommand(ExecuteNumberKeyboard);
            DisplayBankKeyboard = new RelayCommand(ExecuteBankKeyboard);
            DisplayBankNumberKeyboard = new RelayCommand(ExecuteBankNumberKeyboard);
            DisplayBranchNoKeyboard = new RelayCommand(ExecuteIdBranchNoKeyboard);
            DisplayIDNumberKeyboard = new RelayCommand(ExecuteIdNumKeyboard);
            DisplayPasswordResetNumpad = new RelayCommand(ExecutePasswordResetNumPad);
            EditUSerLevelCommand = new RelayCommand(ExecuteEditUserLevel);
            UserLevelSelectionChangedCommand = new RelayCommand(ExecuteUserLevelSelectionChanged);
            AddBlankUserCommand = new RelayCommand(ExecuteAddUser);
        }
        IDataAccess _ServiceProxy;
        private ObservableCollection<User_UserLevel> _Users;
        private User_UserLevel _SelectedUser;
        private bool _VisibleControl = true;
        private bool _InvisibleControl = false;
        private ObservableCollection<eUserLevel> _Userlevels;
        private eUserLevel _SelectedUserLevel;

        public ObservableCollection<User_UserLevel> Users
        {
            get
            {
                return _Users;
            }

            set
            {
                _Users = value;
                RaisePropertyChanged("Users");
            }
        }

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
            }
        }

        void GetUsers()
        {
            Users.Clear();
            foreach (var item in _ServiceProxy.GetUserDetails())
            {
                Users.Add(item);
            }
        }

        public RelayCommand DisplayNameKeyboard { get; set; }
        public RelayCommand DisplaySurnameKeyboard { get; set; }
        public RelayCommand DisplayNumberKeyboard { get; set; }
        public RelayCommand DisplayBankKeyboard { get; set; }
        public RelayCommand DisplayIDNumberKeyboard { get; set; }
        public RelayCommand DisplayBankNumberKeyboard { get; set; }
        public RelayCommand DisplayBranchNoKeyboard { get; set; }
        public RelayCommand DisplayPasswordResetNumpad { get; set; }
        public RelayCommand EditUSerLevelCommand { get; set; }
        public RelayCommand UserLevelSelectionChangedCommand { get; set; }
        public RelayCommand AddBlankUserCommand { get; set; }

        public bool VisibleControl
        {
            get
            {
                return _VisibleControl;
            }

            set
            {
                _VisibleControl = value;
                RaisePropertyChanged("VisibleControl");
            }
        }

        public bool InvisibleControl
        {
            get
            {
                return _InvisibleControl;
            }

            set
            {
                _InvisibleControl = value;
                RaisePropertyChanged("InvisibleControl");
            }
        }

        public ObservableCollection<eUserLevel> Userlevels
        {
            get
            {
                return _Userlevels;
            }

            set
            {
                _Userlevels = value;
                RaisePropertyChanged("Userlevels");
            }
        }

        public eUserLevel SelectedUserLevel
        {
            get
            {
                return _SelectedUserLevel;
            }

            set
            {
                _SelectedUserLevel = value;
                RaisePropertyChanged("SelectedUserLevel");
            }
        }

        void GetUserLevels()
        {
            Userlevels.Clear();
            foreach (var item in _ServiceProxy.GetUserLevels())
            {
                Userlevels.Add(item); //TODO restrict the list
            }
        }

        void ExecuteNameKeyboard()
        {
            Logger.UserId = SelectedUser.UserId;
            Logger.UserPropertyToEdit = UserProperty.Name;
            ViewModelLocator.RegisterViewModel(ViewModelList.ConfigKeyboard);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.ConfigKeyboard));
            MessengerInstance.Send<KeyboardMessage<UserProperty>>(new KeyboardMessage<UserProperty>(UserProperty.Name));
            ViewModelLocator.Cleanup(ViewModelList.Configuration);
        }

        void ExecuteSurnameKeyboard()
        {
            Logger.UserId = SelectedUser.UserId;
            Logger.UserPropertyToEdit = UserProperty.Surname;
            ViewModelLocator.RegisterViewModel(ViewModelList.ConfigKeyboard);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.ConfigKeyboard));
            MessengerInstance.Send<KeyboardMessage<UserProperty>>(new KeyboardMessage<UserProperty>(UserProperty.Surname));
            ViewModelLocator.Cleanup(ViewModelList.Configuration);
        }

        void ExecuteNumberKeyboard()
        {
            Logger.UserId = SelectedUser.UserId;
            Logger.UserPropertyToEdit = UserProperty.Number;
            ViewModelLocator.RegisterViewModel(ViewModelList.ConfigKeyboard);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.ConfigKeyboard));
            MessengerInstance.Send<KeyboardMessage<UserProperty>>(new KeyboardMessage<UserProperty>(UserProperty.Number));
            ViewModelLocator.Cleanup(ViewModelList.Configuration);
        }

        void ExecuteIdNumKeyboard()
        {
            Logger.UserId = SelectedUser.UserId;
            Logger.UserPropertyToEdit = UserProperty.IDNumber;
            ViewModelLocator.RegisterViewModel(ViewModelList.ConfigNumPad);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.ConfigNumPad));
            MessengerInstance.Send<KeyboardMessage<UserProperty>>(new KeyboardMessage<UserProperty>(UserProperty.IDNumber));
            ViewModelLocator.Cleanup(ViewModelList.Configuration);
        }

        void ExecuteBankKeyboard()
        {
            Logger.UserId = SelectedUser.UserId;
            Logger.UserPropertyToEdit = UserProperty.Bank;
            ViewModelLocator.RegisterViewModel(ViewModelList.ConfigKeyboard);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.ConfigKeyboard));
            MessengerInstance.Send<KeyboardMessage<UserProperty>>(new KeyboardMessage<UserProperty>(UserProperty.Bank));
            ViewModelLocator.Cleanup(ViewModelList.Configuration);
        }

        void ExecuteBankNumberKeyboard()
        {
            Logger.UserId = SelectedUser.UserId;
            Logger.UserPropertyToEdit = UserProperty.BankNo;
            ViewModelLocator.RegisterViewModel(ViewModelList.ConfigKeyboard);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.ConfigKeyboard));
            MessengerInstance.Send<KeyboardMessage<UserProperty>>(new KeyboardMessage<UserProperty>(UserProperty.BankNo));
            ViewModelLocator.Cleanup(ViewModelList.Configuration);
        }

        void ExecuteIdBranchNoKeyboard()
        {
            Logger.UserId = SelectedUser.UserId;
            Logger.UserPropertyToEdit = UserProperty.BranchNo;
            ViewModelLocator.RegisterViewModel(ViewModelList.ConfigKeyboard);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.ConfigKeyboard));
            MessengerInstance.Send<KeyboardMessage<UserProperty>>(new KeyboardMessage<UserProperty>(UserProperty.BranchNo));
            ViewModelLocator.Cleanup(ViewModelList.Configuration);
        }

        void ExecutePasswordResetNumPad()
        {
            Logger.UserId = SelectedUser.UserId;
            Logger.UserPropertyToEdit = UserProperty.Password;
            ViewModelLocator.RegisterViewModel(ViewModelList.PasswordReset);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.PasswordReset));
            MessengerInstance.Send<KeyboardMessage<UserProperty>>(new KeyboardMessage<UserProperty>(UserProperty.Password));
            ViewModelLocator.Cleanup(ViewModelList.Configuration);
        }

        void ExecuteEditUserLevel()
        {
            if (SelectedUser.UserLevelId > 2)
            {
                VisibleControl = false;
                InvisibleControl = true; 
            }
            else
            {
                MessageBox.Show("Cannot change the user level");
            }
        }

        void ExecuteUserLevelSelectionChanged()
        {
            
            var Result = MessageBox.Show("Accept the new Position? Note: You will have to login again for changes to take effect", "Save Changes", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            switch (Result)
            {
                
                case MessageBoxResult.Cancel:
                    VisibleControl = true;
                    InvisibleControl = false;
                    break;
                case MessageBoxResult.Yes:
                    SelectedUser.UserLevelId = SelectedUserLevel.UserLevelId;
                    _ServiceProxy.UpdateUser(SelectedUser);
                    GetUsers();
                    VisibleControl = true;
                    InvisibleControl = false;
                    ViewModelLocator.RegisterViewModel(ViewModelList.Table);
                    MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.Login));
                    ViewModelLocator.Cleanup(ViewModelList.Configuration);
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    break;
            }
         
        }

        void ExecuteAddUser()
        {
            UserClockinStatu status = new UserClockinStatu();
            _ServiceProxy.AddBlankUser();
            SelectedUser =  _ServiceProxy.GetUserDetails("Please Enter Name", "Please Enter Surname");
            Logger.UserId = SelectedUser.UserId;
            Logger.UserPropertyToEdit = UserProperty.Name;
            status.UserId = SelectedUser.UserId;
            status.Status = 0;
            _ServiceProxy.AddClockInStatus(status);
            ViewModelLocator.RegisterViewModel(ViewModelList.ConfigKeyboard);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.ConfigKeyboard));
            MessengerInstance.Send<KeyboardMessage<UserProperty>>(new KeyboardMessage<UserProperty>(UserProperty.Name));
            ViewModelLocator.Cleanup(ViewModelList.Configuration);
        }

        private string fullpath;
        private BitmapImage NewImage;

        void UploadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select Image";
            op.Filter = "Images |*.jpg;*.jpeg;*.png";
            if (op.ShowDialog() == true)
            {
                string file = op.FileName;
                System.IO.File.Copy(file, @"\\Resources\" + file);
                NewImage = new BitmapImage(new Uri(op.FileName));
            }
        }

    }
}
