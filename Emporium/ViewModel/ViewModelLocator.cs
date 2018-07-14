/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Emporium"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Emporium.ViewModel.Configuration;
using Emporium.ViewModel.Keyboard;
using Emporium.ViewModel.Table;
using Emporium.ViewModel.Login;
using Emporium.Messenger;

namespace Emporium.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ConfigurationViewModel>();
            SimpleIoc.Default.Register<KeyboardBase>();
            SimpleIoc.Default.Register<NumPadViewModel>();
            SimpleIoc.Default.Register<KeyPadViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<NumPadViewModel>();
            SimpleIoc.Default.Register<KeyPadViewModel>();
          //  SimpleIoc.Default.Register<TableViewModel>();
            SimpleIoc.Default.Register<ConfigUsersKeyboardViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginStaffViewModel>();
        }
        public LoginViewModel loginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public ConfigurationViewModel configurationViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConfigurationViewModel>();
            }
        }

        public KeyboardBase keyboardBaseViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<KeyboardBase>();
            }
        }

        public NumPadViewModel numPadViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NumPadViewModel>();
            }
        }

        public KeyPadViewModel keyPadViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<KeyPadViewModel>();
            }
        }

        public TableViewModel tableViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableViewModel>();
            }
        }

        public ConfigUsersKeyboardViewModel configUsersKeyboardViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConfigUsersKeyboardViewModel>();
            }
        }

        public ConfigUsersNumpadViewModel configUsersNumpadViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConfigUsersNumpadViewModel>();
            }
        }

        public PasswordResetViewModel passwordResetViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PasswordResetViewModel>();
            }
        }

        public LoginStaffViewModel loginStaffViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginStaffViewModel>();
            }
        }

        public ClockInViewModel clockInViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ClockInViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        /// <summary>
        /// Dispose ViewModels
        /// </summary>
        /// <param name="dispose"></param>
        public static void Cleanup(ViewModelList dispose)
        {
            // TODO Clear the ViewModels
            switch (dispose)
            {
                case ViewModelList.Login:
                    //if (SimpleIoc.Default.IsRegistered<LoginViewModel>())
                    //{
                    //    SimpleIoc.Default.Unregister<LoginViewModel>();
                    //}
                    if (SimpleIoc.Default.IsRegistered<LoginStaffViewModel>())
                    {
                        SimpleIoc.Default.Unregister<LoginStaffViewModel>();
                    }
                    break;
                case ViewModelList.Table:
                    if (SimpleIoc.Default.IsRegistered<TableViewModel>())
                    {
                        SimpleIoc.Default.Unregister<TableViewModel>();
                    }
                    break;
                case ViewModelList.Configuration:
                    if (SimpleIoc.Default.IsRegistered<ConfigurationViewModel>())
                    {
                        SimpleIoc.Default.Unregister<ConfigurationViewModel>();
                    }
                    break;
                case ViewModelList.Keyboard:
                    if (SimpleIoc.Default.IsRegistered<KeyboardBase>())
                    {
                        SimpleIoc.Default.Unregister<KeyboardBase>();
                    }
                    break;
                case ViewModelList.KeyPad:
                    if (SimpleIoc.Default.IsRegistered<KeyPadViewModel>())
                    {
                        SimpleIoc.Default.Unregister<KeyPadViewModel>();
                    }
                    break;
                case ViewModelList.NumPad:
                    if (SimpleIoc.Default.IsRegistered<NumPadViewModel>())
                    {
                        SimpleIoc.Default.Unregister<NumPadViewModel>();
                    }
                    break;
                case ViewModelList.ConfigKeyboard:
                    if (SimpleIoc.Default.IsRegistered<ConfigUsersKeyboardViewModel>())
                    {
                        SimpleIoc.Default.Unregister<ConfigUsersKeyboardViewModel>();
                    }
                    break;
                case ViewModelList.ConfigNumPad:
                    if (SimpleIoc.Default.IsRegistered<ConfigUsersNumpadViewModel>())
                    {
                        SimpleIoc.Default.Unregister<ConfigUsersNumpadViewModel>();
                    }
                    break;
                case ViewModelList.PasswordReset:
                    //if (SimpleIoc.Default.IsRegistered<PasswordResetNumPadViewModel>())
                    //{
                    //    SimpleIoc.Default.Unregister<PasswordResetNumPadViewModel>();
                    //}
                    break;
                case ViewModelList.ClockIn:
                    if (SimpleIoc.Default.IsRegistered<ClockInViewModel>())
                    {
                        SimpleIoc.Default.Unregister<ClockInViewModel>();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// RegisterViewModels
        /// </summary>
        /// <param name="register"></param>
        public static void RegisterViewModel(ViewModelList register)
        {
            switch (register)
            {
                case ViewModelList.Login:
                    //if (SimpleIoc.Default.IsRegistered<LoginViewModel>() == false)
                    //{
                    //    SimpleIoc.Default.Register<LoginViewModel>();
                    //}
                    if (SimpleIoc.Default.IsRegistered<LoginStaffViewModel>() == false)
                    {
                        SimpleIoc.Default.Register<LoginStaffViewModel>();
                    }
                    break;
                case ViewModelList.Table:
                    if (SimpleIoc.Default.IsRegistered<TableViewModel>() == false)
                    {
                        SimpleIoc.Default.Register<TableViewModel>();
                    }
                    break;
                case ViewModelList.Configuration:
                    if (SimpleIoc.Default.IsRegistered<ConfigurationViewModel>() == false)
                    {
                        SimpleIoc.Default.Register<ConfigurationViewModel>();
                    }
                    break;
                case ViewModelList.Keyboard:
                    if (SimpleIoc.Default.IsRegistered<KeyboardBase>() == false)
                    {
                        SimpleIoc.Default.Register<KeyboardBase>();
                    }
                    break;
                case ViewModelList.KeyPad:
                    if (SimpleIoc.Default.IsRegistered<KeyPadViewModel>() == false)
                    {
                        SimpleIoc.Default.Register<KeyPadViewModel>();
                    }
                    break;
                case ViewModelList.NumPad:
                    if (SimpleIoc.Default.IsRegistered<NumPadViewModel>() == false)
                    {
                        SimpleIoc.Default.Register<NumPadViewModel>();
                    }
                    break;
                case ViewModelList.ConfigKeyboard:
                    if (SimpleIoc.Default.IsRegistered<ConfigUsersKeyboardViewModel>() == false)
                    {
                        SimpleIoc.Default.Register<ConfigUsersKeyboardViewModel>();
                    }
                    break;
                case ViewModelList.ConfigNumPad:
                    if (SimpleIoc.Default.IsRegistered<ConfigUsersNumpadViewModel>() == false)
                    {
                        SimpleIoc.Default.Register<ConfigUsersNumpadViewModel>();
                    }
                    break;
                case ViewModelList.PasswordReset:
                    if (SimpleIoc.Default.IsRegistered<PasswordResetViewModel>() == false)
                    {
                        SimpleIoc.Default.Register<PasswordResetViewModel>();
                    }
                    break;
                case ViewModelList.ClockIn:
                    if (SimpleIoc.Default.IsRegistered<ClockInViewModel>() == false)
                    {
                        SimpleIoc.Default.Register<ClockInViewModel>();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}