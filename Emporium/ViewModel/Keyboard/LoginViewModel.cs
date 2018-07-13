using Emporium.Messenger;
using Emporium.Model;
using Emporium.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emporium.ViewModel.Keyboard
{
    public class LoginViewModel : NumPadViewModel
    {
        public LoginViewModel()
        {
            _ServiceProxy = new DataAccess();
            Credentials = new User();

            OneCommand = new RelayCommand(PassOne);
            TwoCommand = new RelayCommand(PassTwo);
            ThreeCommand = new RelayCommand(PassThree);
            FourCommand = new RelayCommand(PassFour);
            FiveCommand = new RelayCommand(PassFive);
            SixCommand = new RelayCommand(PassSix);
            SevenCommand = new RelayCommand(PassSeven);
            EightCommand = new RelayCommand(PassEight);
            NineCommand = new RelayCommand(PassNine);
            ZeroCommand = new RelayCommand(PassZero);
            EnterCommand = new RelayCommand(ExecuteVerifyLogin);
            Users = new ObservableCollection<User>();
            GetUsers();
            SelectionChangedCommand = new RelayCommand(ExecuteSelectionChanged);
            ClockedIn = new ObservableCollection<User_Timesheet>();
            GetClockedInPersonel();

            GetClockedInCommand = new RelayCommand(GetClockedInPersonel);
            GetClockedOutCommand = new RelayCommand(GetClockedOutPersonel);
            SelectedClockedIn = new User_Timesheet();
        }

        IDataAccess _ServiceProxy;
        private string _Output = string.Empty;
        private int Count;

        public string Output
        {
            get
            {
                return _Output;
            }

            set
            {
                _Output = value;
                RaisePropertyChanged("Output");
            }
        }


        void PassOne()
        {
            ExecuteOne();
            Output = Output + "*";
            RaisePropertyChanged("Output");
        }

        void PassTwo()
        {
            ExecuteTwo();
            Output = Output + "*";
        }

        void PassThree()
        {
            ExecuteThree();
            Output = Output + "*";
        }

        void PassFour()
        {
            ExecuteFour();
            Output = Output + "*";
        }

        void PassFive()
        {
            ExecuteFive();
            Output = Output + "*";
        }

        void PassSix()
        {
            ExecuteSix();
            Output = Output + "*";
        }

        void PassSeven()
        {
            ExecuteSeven();
            Output = Output + "*";
        }

        void PassEight()
        {
            ExecuteEight();
            Output = Output + "*";
        }

        void PassNine()
        {
            ExecuteNine();
            Output = Output + "*";
        }

        void PassZero()
        {
            ExecuteZero();
            Output = Output + "*";
        }

        void ValidatePassInput()
        {
            if (Message.Length < 4 || Message.Length > 7)
            {
                MessageBox.Show("Please Enter a Password between 4 and 6 characters");
            }
            else
            {
                //TODO validate password doesnt exist
            }
        }

        void ResetPassword()
        {
            Message = string.Empty;
            Output = string.Empty;
        }

        #region Login
        private User _Credentials;
        private ObservableCollection<User> _Users;
        private bool _EnableNumPad = false;

        public User Credentials
        {
            get
            {
                return _Credentials;
            }

            set
            {
                _Credentials = value;
                RaisePropertyChanged("Credentials");
            }
        }

        /// <summary>
        /// Verify the Password from database
        /// </summary>
        void ExecuteVerifyLogin()
        {
            Credentials = _ServiceProxy.VerifyLogin(SelectedClockedIn.UserId, Message);

            if (Credentials != null)
            {
                ViewModelLocator.RegisterViewModel(ViewModelList.Table);
                Logger.UserId = Credentials.UserId;
                Message = string.Empty;
                Output = string.Empty;
                MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.Table));
                ViewModelLocator.Cleanup(ViewModelList.Login);
            }
            else
            {
                MessageBox.Show("Incorrect Password");
                Message = null;
                Output = null;
                EnableNumPad = false;
            }
        }

        public RelayCommand EnterCommand { get; set; }
        public RelayCommand SelectionChangedCommand { get; set; }

        public ObservableCollection<User> Users
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

        public bool EnableNumPad
        {
            get
            {
                return _EnableNumPad;
            }

            set
            {
                _EnableNumPad = value;
                RaisePropertyChanged("EnableNumPad");
            }
        }


        void GetUsers()
        {
            Users.Clear();
            foreach (var item in _ServiceProxy.GetAllUSers())
            {
                Users.Add(item);
            }
        }

        void ExecuteSelectionChanged()
        {
            EnableNumPad = true;
        }
        #endregion

        private ObservableCollection<User_Timesheet> _ClockedIn;
        public ObservableCollection<User_Timesheet> ClockedIn
        {
            get
            {
                return _ClockedIn;
            }

            set
            {
                _ClockedIn = value;
                RaisePropertyChanged("ClockedIn");
            }
        }
        private User_Timesheet _SelectedClockedIn;
        private bool _clockedInToggle = true;
        private string _ClockedInOutText = "Clocked In Personel";

        public RelayCommand GetClockedInCommand { get; set; }
        public RelayCommand GetClockedOutCommand { get; set; }

        public bool ClockedInToggle
        {
            get
            {
                return _clockedInToggle;
            }

            set
            {
                _clockedInToggle = value;
                RaisePropertyChanged("ClockedInToggle");
            }
        }

        public string ClockedInOutText
        {
            get
            {
                return _ClockedInOutText;
            }

            set
            {
                _ClockedInOutText = value;
                RaisePropertyChanged("ClockedInOutText");
            }
        }

        public User_Timesheet SelectedClockedIn
        {
            get
            {
                return _SelectedClockedIn;
            }

            set
            {
                _SelectedClockedIn = value;
                RaisePropertyChanged("SelectedClockedIn");
            }
        }

        void GetClockedInPersonel()
        {
            if (ClockedInToggle == true)
            {
                ClockedIn.Clear();
                foreach (var item in _ServiceProxy.GetClockedInWaitors(1))
                {
                    ClockedIn.Add(item);
                }
                ClockedInToggle = false;
                ClockedInOutText = "Clocked In Personel";
            }
            else
            {
                ClockedIn.Clear();
                foreach (var item in _ServiceProxy.GetClockedInWaitors(0))
                {
                    ClockedIn.Add(item);
                }
                ClockedInToggle = true;
                ClockedInOutText = "Clocked Out Personel";
            }
        }

        void GetClockedOutPersonel()
        {
            ClockedIn.Clear();
            foreach (var item in _ServiceProxy.GetClockedInWaitors(0))
            {
                ClockedIn.Add(item);
            }
        }


    }
}
