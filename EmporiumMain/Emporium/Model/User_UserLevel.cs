using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emporium.Model
{
    public class User_UserLevel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int UserLevelId { get; set; }
        public string Number { get; set; }
        public string IDNum { get; set; }
        public string Bank { get; set; }
        public string AccountType { get; set; }
        public string BranchNo { get; set; }
        public string FingerPrint { get; set; }
        public string BankNo { get; set; }
        public string FullName { get; set; }

        public string LevelName { get; set; }
    }
    public class UserTables
    {
        public int TableId { get; set; }
        public int TableNo { get; set; }
        public System.DateTime TimeStarted { get; set; }
        public decimal BillAmount { get; set; }
        public int Pax { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int UserLevelId { get; set; }
        public string Number { get; set; }
        public string IDNum { get; set; }
        public string Bank { get; set; }
        public string AccountType { get; set; }
        public string BranchNo { get; set; }
        public string FingerPrint { get; set; }
        public string BankNo { get; set; }
    }

    public class User_Timesheet
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int UserLevelId { get; set; }
        public string Number { get; set; }
        public string IDNum { get; set; }
        public string Bank { get; set; }
        public string AccountType { get; set; }
        public string BranchNo { get; set; }
        public string FingerPrint { get; set; }
        public string BankNo { get; set; }
        public string FullName { get; set; }

        public int TimesheetId { get; set; }
        public Nullable<System.DateTime> ClockIn { get; set; }
        public Nullable<System.DateTime> ClockOut { get; set; }
    }


}
