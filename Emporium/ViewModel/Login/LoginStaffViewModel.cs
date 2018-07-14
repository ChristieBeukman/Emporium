using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using Emporium.Messenger;
using Emporium.ViewModel.Keyboard;
using Emporium.Services;
using Emporium.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;

namespace Emporium.ViewModel.Login
{
    public class LoginStaffViewModel : NumPadViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LoginStaffViewModel()
        {
            _ServiceProxy = new DataAccess();

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

            ClockedInStaff = new ObservableCollection<User_ClockInStatus>();
            SelectedClockedInStaffMember = new User_ClockInStatus();
            GetClockedInStaff();
            EnterCommand = new RelayCommand(ExecuteVerifyLogin);
            SelectionChangedCommand = new RelayCommand(ExecuteSelectionChanged);
            ClockInCommand = new RelayCommand(ExecuteClockIn);
            CancelClockInCommand = new RelayCommand(ExecuteCancelClockIn);
        }

        IDataAccess _ServiceProxy;
        private string _Output = string.Empty;
        private bool _EnableNumPad = false;
        private ObservableCollection<User_ClockInStatus> _ClockedInStaff;
        private User_ClockInStatus _SelectedClockedInStaffMember;
        private User _Credentials;
        private bool _EnableClockIn;
        private bool _EnableClockInControl = true;
        /// <summary>
        /// The text that will be displayed while logging in
        /// </summary>
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

        /// <summary>
        /// Only Enables the numpad once a user has been selected
        /// </summary>
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

        /// <summary>
        /// list of all the staff that are clocked in that can login
        /// </summary>
        public ObservableCollection<User_ClockInStatus> ClockedInStaff
        {
            get
            {
                return _ClockedInStaff;
            }

            set
            {
                _ClockedInStaff = value;
                RaisePropertyChanged("ClockedInStaff");
            }
        }

        /// <summary>
        /// The selected staff memeber of the Clocked in staff collection
        /// </summary>
        public User_ClockInStatus SelectedClockedInStaffMember
        {
            get
            {
                return _SelectedClockedInStaffMember;
            }

            set
            {
                _SelectedClockedInStaffMember = value;
                RaisePropertyChanged("SelectedClockedInStaffMember");
            }
        }

        /// <summary>
        /// User Credentials to be verified
        /// </summary>
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
        /// Enabled the EnterCommand method will load the ClockinViewModel
        /// Disabled the EnterCommand method will login the Clocked in User
        /// </summary>
        public bool EnableClockIn
        {
            get
            {
                return _EnableClockIn;
            }

            set
            {
                _EnableClockIn = value;
                RaisePropertyChanged("EnableClockIn");
            }
        }

        public RelayCommand SelectionChangedCommand { get; set; }

        /// <summary>
        /// Enables the Login Numpad
        /// </summary>
        public void ExecuteSelectionChanged()
        {
            EnableNumPad = true;
        }

        /// <summary>
        /// Fills the ClockedInStaff collection
        /// </summary>
        void GetClockedInStaff()
        {
            ClockedInStaff.Clear();
            foreach (var item in _ServiceProxy.GetUserClockInStatus(1))
            {
                ClockedInStaff.Add(item);
            }
        }

        /// <summary>
        /// Fills the collection with all the users with manager previlages
        /// </summary>
        void GetManagers()
        {
            ClockedInStaff.Clear();
            foreach (var item in _ServiceProxy.GetManagers())
            {
                ClockedInStaff.Add(item);
            }
        }

        public RelayCommand EnterCommand { get; set; }


        /// <summary>
        /// Queries the database with the userId and password parameters for login
        /// </summary>
        void ExecuteVerifyLogin()
        {
            Credentials = _ServiceProxy.VerifyLogin(SelectedClockedInStaffMember.UserId, Message);
            if (Credentials!= null)
            {

                if (EnableClockIn == false)
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
                    ViewModelLocator.RegisterViewModel(ViewModelList.ClockIn);
                    Logger.UserId = Credentials.UserId;
                    Message = string.Empty;
                    Output = string.Empty;
                    EnableClockIn = false;
                    MessengerInstance.Send<ViewModelControlMessage<ViewModelList>>(new ViewModelControlMessage<ViewModelList>(ViewModelList.ClockIn));
                    ViewModelLocator.Cleanup(ViewModelList.Login);

                }

            }
            else
            {
                MessageBox.Show("Incorrect Password");
                Message = string.Empty;
                Output = string.Empty;
            }
        }

        public RelayCommand ClockInCommand { get; set; }

        public bool EnableClockInControl
        {
            get
            {
                return _EnableClockInControl;
            }

            set
            {
                _EnableClockInControl = value;
                RaisePropertyChanged("EnableClockInControl");
            }
        }

        /// <summary>
        /// Enables the managers to login for clocking
        /// </summary>
        void ExecuteClockIn()
        {
            EnableClockIn = true;
            EnableClockInControl = false;
            GetManagers();
        }

        public RelayCommand CancelClockInCommand { get; set; }



        /// <summary>
        /// Cancel the Clockin process
        /// </summary>
        void ExecuteCancelClockIn()
        {
            EnableClockIn = false;
            EnableClockInControl = true;
            GetClockedInStaff();
        }

        #region Numpad
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
        #endregion

    }
}
