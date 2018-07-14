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
        User VerifyLogin(int userid);
        ObservableCollection<User> GetAllUSers();               //TODO Change later for clocked in users
		User_UserLevel GetUserDetails(int userId);
		ObservableCollection<User_UserLevel> GetUserDetails();
        User_UserLevel GetUserDetails(string Name, string Surname);
        void UpdateUser(User_UserLevel e);
        void AddBlankUser();
        void ClockInUser(Timesheet t);
        void ClockOutUser(Timesheet t);
        ObservableCollection<Timesheet> GetTimesheets();
        ObservableCollection<User_ClockInStatus> GetUserClockInStatus(int status);
        void UpdateClockInStatus(User_ClockInStatus s);
        void AddClockInStatus(UserClockinStatu s);
        ObservableCollection<User_ClockInStatus> GetManagers();
        ObservableCollection<eUserLevel> GetUserLevels();
        string GetLevel(int levelId);
        ObservableCollection<UserTables> GetUserTables();
        ObservableCollection<UserTables> GetUserTables(int userid);
        //void Add(test t);
        //test sele();

    }
    public class DataAccess : IDataAccess
    {
        EmporiumEntities _Context;

        public DataAccess()
        {
            _Context = new EmporiumEntities();
        }

        public void AddBlankUser()
        {
            User u = new User();
            
            u.UserLevelId = 4;
            u.Surname = "Please Enter Surname";
            u.Password = "0000";
            u.Number = string.Empty;
            u.Name = "Please Enter Name";
            u.IDNum = string.Empty;
            u.Bank = string.Empty;
            u.AccountType = string.Empty;
            u.BankNo = string.Empty;
            u.BranchNo = string.Empty;

            _Context.Users.Add(u);
            _Context.SaveChanges();

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
            u.BranchNo = e.BranchNo;
            u.Image = e.Image;

            _Context.Entry(u).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
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

        //public ObservableCollection<User_Timesheet> GetClockedInStaff(int i)
        //{
        //    ObservableCollection<User_Timesheet> time = new ObservableCollection<User_Timesheet>();

        //    var Query = (from u in _Context.Users
        //                 join t in _Context.Timesheets
        //                 on u.UserId equals t.UserId
        //                 join l in _Context.eUserLevels
        //                 on u.UserLevelId equals l.UserLevelId
        //                 where t.IsClockedIn == i
        //                 select new User_Timesheet
        //                 {
        //                     UserId = u.UserId,
        //                     Name = u.Name,
        //                     Surname = u.Surname,
        //                     FullName = u.Name + " " + u.Surname,
        //                     ClockIn = t.ClockIn,
        //                     ClockOut = t.ClockOut,
        //                     Image = u.Image,
        //                     LevelName = l.Name
                             

        //                 }).ToList();
        //    foreach (var item in Query)
        //    {
        //        time.Add(item);
        //    }

        //    return time;
        //}

        public ObservableCollection<Timesheet> GetTimesheets()
        {
            ObservableCollection<Timesheet> tom = new ObservableCollection<Timesheet>();

            var Query = from t in _Context.Timesheets
                        select t;

            return tom;
        }

        //public ObservableCollection<User_Timesheet> GetManagers()
        //{

        //}

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
                             UserLevelId = u.UserLevelId,
                             Image = u.Image
                         }).ToList();
            foreach (var item in Query)
            {
                us.Add(item);
            }

            return us;
        }

        public User_UserLevel GetUserDetails(string Name, string Surname)
        {
            var Query = (from u in _Context.Users
                         join l in _Context.eUserLevels
                         on u.UserLevelId equals l.UserLevelId
                         where u.Name == Name && u.Surname == u.Surname
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

        public User VerifyLogin(int userid)
        {
            var Query = (from u in _Context.Users
                        where u.UserId == userid
                        select u).SingleOrDefault();
            return Query;
        }

        public ObservableCollection<User_ClockInStatus> GetUserClockInStatus(int status)
        {
            ObservableCollection<User_ClockInStatus> us = new ObservableCollection<User_ClockInStatus>();

            var Query = (from u in _Context.Users
                         join s in _Context.UserClockinStatus
                         on u.UserId equals s.UserId
                         join l in _Context.eUserLevels
                         on u.UserLevelId equals l.UserLevelId
                         where s.Status == status
                         select new User_ClockInStatus
                         {
                             UserId = u.UserId,
                             Name = u.Name,
                             Surname = u.Surname,
                             FullName = u.Name + " " + u.Surname,
                             Status = s.Status,
                             StatusId = s.StatusId,
                             LevelName = l.Name,
                             Image = u.Image,
                             Password = u.Password
                         }).ToList();

            foreach (var item in Query)
            {
                us.Add(item);
            }

            return us;
        }

        public ObservableCollection<User_ClockInStatus> GetManagers()
        {
            ObservableCollection<User_ClockInStatus> time = new ObservableCollection<User_ClockInStatus>();

            var Query = (from u in _Context.Users
                         join t in _Context.UserClockinStatus
                         on u.UserId equals t.UserId
                         join l in _Context.eUserLevels
                         on u.UserLevelId equals l.UserLevelId
                         where u.UserLevelId < 4
                         select new User_ClockInStatus
                         {
                             UserId = u.UserId,
                             Name = u.Name,
                             Surname = u.Surname,
                             FullName = u.Name + " " + u.Surname,
                             Image = u.Image,
                             LevelName = l.Name,
                             Password = u.Password


                         }).ToList();
            foreach (var item in Query)
            {
                time.Add(item);
            }

            return time;
        }

        public void UpdateClockInStatus(User_ClockInStatus s)
        {
            UserClockinStatu st = new UserClockinStatu();
            st.Status = s.Status;
            st.UserId = s.UserId;
            st.StatusId = s.StatusId;
            _Context.Entry(st).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public string GetLevel(int levelId)
        {
            var Query = (from u in _Context.eUserLevels
                         where u.UserLevelId == levelId
                         select u.Name).SingleOrDefault();
            return Query;
        }

        public ObservableCollection<UserTables> GetUserTables()
        {
            ObservableCollection<UserTables> us = new ObservableCollection<UserTables>();

            var Query = (from u in _Context.Users
                         join t in _Context.Tables
                         on u.UserId equals t.UserId
                         select new UserTables
                         {
                             UserId = u.UserId,
                             Name = u.Name,
                             Surname = u.Surname,
                             BillAmount = t.BillAmount,
                             Pax = t.Pax,
                             TableId = t.TableId,
                             TableNo = t.TableNo,
                             TimeStarted = t.TimeStarted
                         }).ToList();

            foreach (var item in Query)
            {
                us.Add(item);
            }

            return us;
        }

        public ObservableCollection<UserTables> GetUserTables(int userid)
        {
            ObservableCollection<UserTables> us = new ObservableCollection<UserTables>();

            var Query = (from u in _Context.Users
                         join t in _Context.Tables
                         on u.UserId equals t.UserId
                         where u.UserId == userid
                         select new UserTables
                         {
                             UserId = u.UserId,
                             Name = u.Name,
                             Surname = u.Surname,
                             BillAmount = t.BillAmount,
                             Pax = t.Pax,
                             TableId = t.TableId,
                             TableNo = t.TableNo,
                             TimeStarted = t.TimeStarted
                         }).ToList();

            foreach (var item in Query)
            {
                us.Add(item);
            }
            return us;
        }

        public void AddClockInStatus(UserClockinStatu s)
        {
            _Context.UserClockinStatus.Add(s);
            _Context.SaveChanges();
        }

        //public void Add(test t)
        //{
        //    _Context.tests.Add(t);
        //    _Context.SaveChanges();
        //}

        //public test sele()
        //{
        //    var Query = (from u in _Context.tests
        //                where u.Id == 1
        //                select u).SingleOrDefault();
        //    return Query;
        //}
    }

}
