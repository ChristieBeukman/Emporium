using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emporium.Messenger
{
    /// <summary>
    /// List of USer Properties
    /// </summary>
    public enum UserProperty
    {
        Name = 1,
        Surname,
        Number,
        IDNumber,
        Bank,
        BranchNo,
        BankNo,
        Password
    }

    /// <summary>
    /// List of Viewmodels
    /// </summary>
    public enum ViewModelList
    {
        Login,
        Table,
        Configuration,
        Keyboard,
        KeyPad,
        NumPad,
        ConfigKeyboard,
        ConfigNumPad,
        PasswordReset,
        ClockIn,
    }

    /// <summary>
    /// Transfer control between VM
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ViewModelControlMessage<T>
    {
        public ViewModelList ActivateViewModel { get; set; }

        public ViewModelControlMessage(ViewModelList activateViewModel)
        {
            this.ActivateViewModel = activateViewModel;
        }
    }

    /// <summary>
    /// Message between VM and Keyboard
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class KeyboardMessage<T>
    {
        public UserProperty Property { get; set; }

        public KeyboardMessage(UserProperty property)
        {
            this.Property = property;
        }
    }

    public static class Logger
    {
        //Pass the UserID betweem VM
        public static int UserId { get; set; }

        //States which property is being edited
        public static UserProperty UserPropertyToEdit { get; set; }                

    }
}
