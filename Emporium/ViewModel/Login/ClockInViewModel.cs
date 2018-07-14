using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ClockInViewModel : LoginStaffViewModel
    {
        public ClockInViewModel()
        {
            _ServiceProxy = new DataAccess();
            GetClockedInStaff();
            UserToClockIn = new Timesheet();
            ClockinStaffCommand = new RelayCommand(ExecuteClockInStaff);
        }
        IDataAccess _ServiceProxy;
        private Timesheet _UserToClockIn;

        public Timesheet UserToClockIn
        {
            get
            {
                return _UserToClockIn;
            }

            set
            {
                _UserToClockIn = value;
                RaisePropertyChanged("UserToClockIn");
            }
        }

        void GetClockedInStaff()
        {
            ClockedInStaff.Clear();
            foreach (var item in _ServiceProxy.GetUserClockInStatus(0))
            {
                ClockedInStaff.Add(item);
            }
        }

        public RelayCommand ClockinStaffCommand { get; set; }

        void ExecuteClockInStaff()
        {
            Credentials = _ServiceProxy.VerifyLogin(SelectedClockedInStaffMember.UserId, Message);
            if (Credentials != null)
            {
                UserToClockIn.UserId = Credentials.UserId;
                SelectedClockedInStaffMember.Status = 1;
                _ServiceProxy.UpdateClockInStatus(SelectedClockedInStaffMember);
                DateTime time = DateTime.Now;
                UserToClockIn.ClockIn = time;
                _ServiceProxy.ClockInUser(UserToClockIn);
                MessageBox.Show("Clocked in at " + time.ToString());
                GetClockedInStaff();
                Message = string.Empty;
                Output = string.Empty;
            }
            else
            {
                MessageBox.Show("Incorrect Password");
                Message = string.Empty;
                Output = string.Empty;
            }
        }

    }
}
