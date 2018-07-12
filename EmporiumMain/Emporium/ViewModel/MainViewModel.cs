using GalaSoft.MvvmLight;
using Emporium.Messenger;
using Emporium.ViewModel.Configuration;
using Emporium.ViewModel.Keyboard;
using Emporium.ViewModel.Table;

namespace Emporium.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //Startup VM
            CurrentViewModel = MainViewModel.configurationViewModel;                                                                

            // Register the messenger to listen for ViewmodelControl messages
            MessengerInstance.Register<ViewModelControlMessage<ViewModelList>>(this, ReceiveViewModelControlMessage);       
        }

        #region CurrentViewModel

        private ViewModelBase _CurrentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _CurrentViewModel;
            }

            set
            {
                _CurrentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        /// <summary>
        /// Registration of VM's for the CurrentViewmodel
        /// </summary>
        private static readonly ConfigurationViewModel configurationViewModel = new ConfigurationViewModel();
        private static readonly KeyboardBase keyboardViewModel = new KeyboardBase();
        private static readonly LoginViewModel loginViewModel = new LoginViewModel();
        private static readonly TableViewModel tableViewModel = new TableViewModel();
        private static readonly KeyPadViewModel keyPadViewModel = new KeyPadViewModel();
        private static readonly NumPadViewModel numPadViewModel = new NumPadViewModel();
        private static readonly ConfigUsersKeyboardViewModel configUsersKeyboardViewModel = new ConfigUsersKeyboardViewModel();
        private static readonly ConfigUsersNumpadViewModel configUsersNumpadViewModel = new ConfigUsersNumpadViewModel();
        //private static readonly PasswordResetNumPadViewModel passwordResetNumPadViewModel = new PasswordResetNumPadViewModel();
        #endregion

        #region Messenger

        /// <summary>
        /// Revieves a message stating which vm should be viewed
        /// </summary>
        /// <param name="message"></param>
        void ReceiveViewModelControlMessage(ViewModelControlMessage<ViewModelList> message)
        {
            ViewModelList vm = new ViewModelList();
            vm = message.ActivateViewModel;
            switch (vm)
            {
                case ViewModelList.Login:
                    CurrentViewModel = MainViewModel.loginViewModel;
                    break;
                case ViewModelList.Table:
                    CurrentViewModel = MainViewModel.tableViewModel;
                    break;
                case ViewModelList.Configuration:
                    CurrentViewModel = MainViewModel.configurationViewModel;
                    break;
                case ViewModelList.Keyboard:
                    CurrentViewModel = MainViewModel.keyboardViewModel;
                    break;
                case ViewModelList.KeyPad:
                    CurrentViewModel = MainViewModel.keyPadViewModel;
                    break;
                case ViewModelList.NumPad:
                    CurrentViewModel = MainViewModel.numPadViewModel;
                    break;
                case ViewModelList.ConfigKeyboard:
                    CurrentViewModel = MainViewModel.configUsersKeyboardViewModel;
                    break;
                case ViewModelList.ConfigNumPad:
                    CurrentViewModel = MainViewModel.configUsersNumpadViewModel;
                    break;
                case ViewModelList.PasswordReset:
                 //  CurrentViewModel = MainViewModel.passwordResetNumPadViewModel;
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}