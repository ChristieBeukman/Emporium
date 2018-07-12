using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Emporium.ViewModel.Keyboard
{
    public class NumPadViewModel : KeyboardBase
    {
        public NumPadViewModel()
        {
            DivideCommand = new RelayCommand(ExecuteDivide);
            MinusCommand = new RelayCommand(ExecuteMinus);
            MultiplyCommand = new RelayCommand(ExecuteMultiply);
            PlusCommand = new RelayCommand(ExecutePlus);
            OneCommand = new RelayCommand(ExecuteOne);
            TwoCommand = new RelayCommand(ExecuteTwo);
            ThreeCommand = new RelayCommand(ExecuteThree);
            FourCommand = new RelayCommand(ExecuteFour);
            FiveCommand = new RelayCommand(ExecuteFive);
            SixCommand = new RelayCommand(ExecuteSix);
            SevenCommand = new RelayCommand(ExecuteSeven);
            EightCommand = new RelayCommand(ExecuteEight);
            NineCommand = new RelayCommand(ExecuteNine);
            ZeroCommand = new RelayCommand(ExecuteZero);
            MultiplyCommand = new RelayCommand(ExecuteMultiply);
        }

        #region Commands
        public RelayCommand OneCommand { get; set; }
        public RelayCommand TwoCommand { get; set; }
        public RelayCommand ThreeCommand { get; set; }
        public RelayCommand FourCommand { get; set; }
        public RelayCommand FiveCommand { get; set; }
        public RelayCommand SixCommand { get; set; }
        public RelayCommand SevenCommand { get; set; }
        public RelayCommand EightCommand { get; set; }
        public RelayCommand NineCommand { get; set; }
        public RelayCommand ZeroCommand { get; set; }
        public RelayCommand DivideCommand { get; set; }
        public RelayCommand MinusCommand { get; set; }
        public RelayCommand MultiplyCommand { get; set; }
        public RelayCommand PlusCommand { get; set; }
        #endregion

        #region Execute
        public void ExecuteDivide()
        {
            Message = Message + "/";
        }

        public void ExecuteMinus()
        {
            Message = Message + "-";
        }

        public void ExecutePlus()
        {
            Message = Message + "+";
        }

        public void ExecuteOne()
        {
            Clickkey("1");
        }

        public void ExecuteTwo()
        {
            Clickkey("2");
        }

        public void ExecuteThree()
        {
            Clickkey("3");
        }

        public void ExecuteFour()
        {
            Clickkey("4");
        }

        public void ExecuteFive()
        {
            Clickkey("5");
        }

        public void ExecuteMultiply()
        {
            Clickkey("*");
        }

        public void ExecuteSix()
        {
            Clickkey("6");
        }

        public void ExecuteSeven()
        {
            Clickkey("7");
        }

        public void ExecuteEight()
        {
            Clickkey("8");
        }

        public void ExecuteNine()
        {
            Clickkey("9");
        }

        public void ExecuteZero()
        {
            Clickkey("0");
        }

        #endregion

        private bool _ControlVisible = true;

        public bool ControlVisible
        {
            get
            {
                return _ControlVisible;
            }

            set
            {
                _ControlVisible = value;
                RaisePropertyChanged("ControlVisible");
            }
        }


    }
}
