using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emporium.Model;

namespace Emporium.Services
{
	public interface IDataAccess
	{
		User VerifyLogin(string password);
        User VerifyLogin(int userid, string password);
        ObservableCollection<User> GetAllUSers();               //TODO Change later for clocked in users
		User_UserLevel GetUserDetails(int userId);
		ObservableCollection<User_UserLevel> GetUserDetails();
		void UpdateUser(User_UserLevel e);
        void ClockInUser(Timesheet t);
        void ClockOutUser(Timesheet t);
        ObservableCollection<Timesheet> GetTimesheets();
        ObservableCollection<User_Timesheet> GetClockedInWaitors();
        ObservableCollection<eUserLevel> GetUserLevels();
	}
    public class DataAccess : IDataAccess
    {
        EmporiumEntities _Context;

        public DataAccess()
        {
            _Context = new EmporiumEntities();
        }

        public void ClockInUser(Timesheet t)
        {
            _Context.Timesheets.Add(t);
            _Context.SaveChanges();
        }

        public void ClockOutUser(Timesheet t)
        {
            _Context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public ObservableCollection<User> GetAllUSers()
        {
            ObservableCollection<User> us = new ObservableCollection<User>();

            var Query = from u in _Context.Users
                        select u;

            foreach (var item in Query)
            {
                us.Add(item);
            }

            return us;
        }

        public ObservableCollection<User_Timesheet> GetClockedInWaitors()
        {
            ObservableCollection<User_Timesheet> time = new ObservableCollection<User_Timesheet>();
            DateTime day = new DateTime(2018, 07, 07);
            var Query = (from u in _Context.Users
                         join t in _Context.Timesheets
                         on u.UserId equals t.UserId
                         where t.ClockOut != day
                         select new User_Timesheet
                         {
                             UserId = u.UserId,
                             Name = u.Name,
                             Surname = u.Surname,
                             FullName = u.Name + " " + u.Surname,
                             ClockIn = t.ClockIn,
                             ClockOut = t.ClockOut

                         }).ToList();
            foreach (var item in Query)
            {
                time.Add(item);
            }

            return time;
        }

        public ObservableCollection<Timesheet> GetTimesheets()
        {
            ObservableCollection<Timesheet> tom = new ObservableCollection<Timesheet>();

            var Query = from t in _Context.Timesheets
                        select t;

            return tom;
        }

        public User_UserLevel GetUserDetails(int userId)
        {
            var Query = (from u in _Context.Users
                         join l in _Context.eUserLevels
                         on u.UserLevelId equals l.UserLevelId
                         where u.UserId == userId
                         select new User_UserLevel
                         {
                             AccountType = u.AccountType,
                             Bank = u.Bank,
                             BankNo = u.BankNo,
                             BranchNo = u.BranchNo,
                             FingerPrint = u.FingerPrint,
                             IDNum = u.IDNum,
                             LevelName = l.Name,
                             Name = u.Name,
                             Number = u.Number,
                             Password = u.Password,
                             Surname = u.Surname,
                             UserId = u.UserId,
                             FullName = u.Name + " " + u.Surname,
                             UserLevelId = u.UserLevelId
                         }).SingleOrDefault();
            return Query;
        }

        public ObservableCollection<User_UserLevel> GetUserDetails()
        {
            ObservableCollection<User_UserLevel> us = new ObservableCollection<User_UserLevel>();
            var Query = (from u in _Context.Users
                         join l in _Context.eUserLevels
                         on u.UserLevelId equals l.UserLevelId
                         select new User_UserLevel
                         {
                             AccountType = u.AccountType,
                             Bank = u.Bank,
                             BankNo = u.BankNo,
                             BranchNo = u.BranchNo,
                             FingerPrint = u.FingerPrint,
                             IDNum = u.IDNum,
                             LevelName = l.Name,
                             Name = u.Name,
                             Number = u.Number,
                             Password = u.Password,
                             Surname = u.Surname,
                             UserId = u.UserId,
                             UserLevelId = u.UserLevelId
                         }).ToList();
            foreach (var item in Query)
            {
                us.Add(item);
            }

            return us;
        }

        public ObservableCollection<eUserLevel> GetUserLevels()
        {
            ObservableCollection<eUserLevel> us = new ObservableCollection<eUserLevel>();

            var Query = (from u in _Context.eUserLevels
                        where u.UserLevelId >  2
                        select u).ToList();

            foreach (var item in Query)
            {
                us.Add(item);
            }

            return us;
        }

        public void UpdateUser(User_UserLevel e)
        {
            User u = new User();
            u.UserId = e.UserId;
            u.UserLevelId = e.UserLevelId;
            u.Surname = e.Surname;
            u.Password = e.Password;
            u.Number = e.Number;
            u.Name = e.Name;
            u.IDNum = e.IDNum;
            u.Bank = e.Bank;
            u.AccountType = e.AccountType;
            u.BankNo = e.BankNo;
            u.UserLevelId = e.UserLevelId;
            u.BranchNo = e.BranchNo;

            _Context.Entry(u).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public User VerifyLogin(string password)
        {
            var Query = (from u in _Context.Users
                         where u.Password == password
                         select u).SingleOrDefault();
            return Query;
        }

        public User VerifyLogin(int userid, string password)
        {
            var Query = (from u in _Context.Users
                         where u.Password == password && u.UserId == userid
                         select u).SingleOrDefault();
            return Query;
        }
    }

}
