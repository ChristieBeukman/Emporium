using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Emporium.Messenger;
using Emporium.Model;
using Emporium.Services;
using Emporium.ViewModel;

namespace Emporium.ViewModel.Table
{
    public class TableViewModel : ViewModelBase
    {
        public TableViewModel()
        {
            _ServiceProxy = new DataAccess();
            UserCredentials = new User();
            AllUserTables = new ObservableCollection<UserTables>();
            SelectedUserTable = new UserTables();

           GetUserCredentials();
            SignOutCommand = new RelayCommand(ExecuteSignOut);
            DisplayConfigurationCommand = new RelayCommand(ExecuteDisplayCOnfiguration);
        }

        IDataAccess _ServiceProxy;
        private User _UserCredentials;
        private string _UserFullName;
        private bool _ManagementAccess = true;
        private string _AccessName;
        private ObservableCollection<UserTables> _AllUserTables;
        private UserTables _SelectedUserTable;

        /// <summary>
        /// Get the user credentials that was passed on from the loginvm
        /// </summary>
        public User UserCredentials
        {
            get
            {
                return _UserCredentials;
            }

            set
            {
                _UserCredentials = value;
                RaisePropertyChanged("UserCredentials");
            }
        }

        
        public string UserFullName
        {
            get
            {
                return _UserFullName;
            }

            set
            {
                _UserFullName = value;
                RaisePropertyChanged("UserFullName");
            }
        }

        /// <summary>
        /// Determines if the user will see management controls
        /// </summary>
        public bool ManagementAccess
        {
            get
            {
                return _ManagementAccess;
            }

            set
            {
                _ManagementAccess = value;
                RaisePropertyChanged("ManagementAccess");
            }
        }

        public string AccessName
        {
            get
            {
                return _AccessName;
            }

            set
            {
                _AccessName = value;
                RaisePropertyChanged("AccessName");
            }
        }

        /// <summary>
        /// list of all the tables the user has 
        /// or in management case all the open tables
        /// </summary>
        public ObservableCollection<UserTables> AllUserTables
        {
            get
            {
                return _AllUserTables;
            }

            set
            {
                _AllUserTables = value;
                RaisePropertyChanged("AllUserTables");
            }
        }

        /// <summary>
        /// Selected table 
        /// </summary>
        public UserTables SelectedUserTable
        {
            get
            {
                return _SelectedUserTable;
            }

            set
            {
                _SelectedUserTable = value;
                RaisePropertyChanged("SelectedUserTable");
            }
        }

        /// <summary>
        /// Gets the user parameters passed on from the loginvm and loads the correct table paramaeters
        /// </summary>
        void GetUserCredentials()
        {
            UserCredentials = _ServiceProxy.VerifyLogin(Logger.UserId);
            if (UserCredentials != null)
            {
                UserFullName = UserCredentials.Name + " " + UserCredentials.Surname;
                RaisePropertyChanged("UserFullName");
                AccessName = _ServiceProxy.GetLevel(UserCredentials.UserLevelId);
                RaisePropertyChanged("AccessName");
                if (UserCredentials.UserLevelId < 4)
                {
                    ManagementAccess = true; foreach (var item in _ServiceProxy.GetUserTables())
                    {
                        AllUserTables.Add(item);
                    }
                }
                else
                {
                    ManagementAccess = false;
                    foreach (var item in _ServiceProxy.GetUserTables(UserCredentials.UserId))
                    {
                        AllUserTables.Add(item);
                    }

                }
            }
            GetUserTables();
        }

        void GetUserTables()
        {
            AllUserTables.Clear();
            if (ManagementAccess == true)
            {
                foreach (var item in _ServiceProxy.GetUserTables())
                {
                    AllUserTables.Add(item);
                }
            }
            else
            {
                foreach (var item in _ServiceProxy.GetUserTables(UserCredentials.UserId))
                {
                    AllUserTables.Add(item);
                }
            }
        }

        public RelayCommand SignOutCommand { get; set; }

        void ExecuteSignOut()
        {
            ViewModelLocator.RegisterViewModel(ViewModelList.Login);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.Login));
            ViewModelLocator.Cleanup(ViewModelList.Table);
        }

        public RelayCommand DisplayConfigurationCommand { get; set; }

        void ExecuteDisplayCOnfiguration()
        {
            ViewModelLocator.RegisterViewModel(ViewModelList.Configuration);
            MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.Configuration));
            ViewModelLocator.Cleanup(ViewModelList.Table);
        }
    }
}
