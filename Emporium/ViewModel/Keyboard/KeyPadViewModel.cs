using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;


namespace Emporium.ViewModel.Keyboard
{
    public class KeyPadViewModel : NumPadViewModel
    {
        public KeyPadViewModel()
        {
            ExclamationCommand = new RelayCommand(ExecuteExclamation);
            Acommand = new RelayCommand(ExecuteAcommand);
            Bcommand = new RelayCommand(ExecuteBcommand);
            Ccommand = new RelayCommand(ExecuteCcommand);
            Dcommand = new RelayCommand(ExecuteDcommand);
            Ecommand = new RelayCommand(ExecuteEcommand);
            Fcommand = new RelayCommand(ExecuteFcommand);
            Gcommand = new RelayCommand(ExecuteGcommand);
            Hcommand = new RelayCommand(ExecuteHcommand);
            Icommand = new RelayCommand(ExecuteIcommand);
            Jcommand = new RelayCommand(ExecuteJcommand);
            Kcommand = new RelayCommand(ExecuteKcommand);
            Lcommand = new RelayCommand(ExecuteLcommand);
            Mcommand = new RelayCommand(ExecuteMcommand);
            Ncommand = new RelayCommand(ExecuteNcommand);
            Ocommand = new RelayCommand(ExecuteOcommand);
            Pcommand = new RelayCommand(ExecutePcommand);
            Qcommand = new RelayCommand(ExecuteQcommand);
            Rcommand = new RelayCommand(ExecuteRcommand);
            Scommand = new RelayCommand(ExecuteScommand);
            Tcommand = new RelayCommand(ExecuteTcommand);
            UCommand = new RelayCommand(ExecuteUcommand);
            Vcommand = new RelayCommand(ExecuteVcommand);
            Wcommand = new RelayCommand(ExecuteWcommand);
            Xcommand = new RelayCommand(ExecuteXcommand);
            Ycommand = new RelayCommand(ExecuteYcommand);
            Zcommand = new RelayCommand(ExecuteZcommand);
            SpaceCommand = new RelayCommand(ExecuteSPacecommand);
            ColonCommand = new RelayCommand(ExecuteColonCommand);
            PointCOmmmand = new RelayCommand(ExecutePointCommand);
            QuestionCommand = new RelayCommand(ExecuteQuestionCommand);
            CapsCommand = new RelayCommand(ExecuteCapsCommand);

        }


        #region Alphabet Properties

        private bool caps = false;
        private string _Akey = "a";
        private string _Bkey = "b";
        private string _Ckey = "c";
        private string _Dkey = "d";
        private string _Ekey = "e";
        private string _Fkey = "f";
        private string _Gkey = "g";
        private string _Hkey = "h";
        private string _Ikey = "i";
        private string _Jkey = "j";
        private string _Kkey = "k";
        private string _Lkey = "l";
        private string _Mkey = "m";
        private string _Nkey = "n";
        private string _Okey = "o";
        private string _Pkey = "p";
        private string _Qkey = "q";
        private string _Rkey = "r";
        private string _Skey = "s";
        private string _Tkey = "t";
        private string _Vkey = "v";
        private string _Ukey = "u";
        private string _Wkey = "w";
        private string _Xkey = "x";
        private string _Ykey = "y";
        private string _Zkey = "z";

        public string Akey
        {
            get
            {
                return _Akey;
            }

            set
            {
                _Akey = value;
                RaisePropertyChanged("Akey");
            }
        }

        public string Bkey
        {
            get
            {
                return _Bkey;
            }

            set
            {
                _Bkey = value;
                RaisePropertyChanged("Bkey");
            }
        }

        public string Ckey
        {
            get
            {
                return _Ckey;
            }

            set
            {
                _Ckey = value;
                RaisePropertyChanged("Ckey");
            }
        }

        public string Dkey
        {
            get
            {
                return _Dkey;
            }

            set
            {
                _Dkey = value;
                RaisePropertyChanged("Dkey");
            }
        }

        public string Ekey
        {
            get
            {
                return _Ekey;
            }

            set
            {
                _Ekey = value;
                RaisePropertyChanged("Ekey");
            }
        }

        public string Fkey
        {
            get
            {
                return _Fkey;
            }

            set
            {
                _Fkey = value;
                RaisePropertyChanged("Fkey");
            }
        }

        public string Gkey
        {
            get
            {
                return _Gkey;
            }

            set
            {
                _Gkey = value;
                RaisePropertyChanged("Gkey");
            }
        }

        public string Hkey
        {
            get
            {
                return _Hkey;
            }

            set
            {
                _Hkey = value;
                RaisePropertyChanged("Hkey");
            }
        }

        public string Ikey
        {
            get
            {
                return _Ikey;
            }

            set
            {
                _Ikey = value;
                RaisePropertyChanged("Ikey");
            }
        }

        public string Jkey
        {
            get
            {
                return _Jkey;
            }

            set
            {
                _Jkey = value;
                RaisePropertyChanged("Jkey");
            }
        }

        public string Kkey
        {
            get
            {
                return _Kkey;
            }

            set
            {
                _Kkey = value;
                RaisePropertyChanged("Kkey");
            }
        }

        public string Lkey
        {
            get
            {
                return _Lkey;
            }

            set
            {
                _Lkey = value;
                RaisePropertyChanged("Lkey");
            }
        }

        public string Mkey
        {
            get
            {
                return _Mkey;
            }

            set
            {
                _Mkey = value;
                RaisePropertyChanged("Mkey");
            }
        }

        public string Nkey
        {
            get
            {
                return _Nkey;
            }

            set
            {
                _Nkey = value;
                RaisePropertyChanged("Nkey");
            }
        }

        public string Okey
        {
            get
            {
                return _Okey;
            }

            set
            {
                _Okey = value;
                RaisePropertyChanged("Okey");
            }
        }

        public string Pkey
        {
            get
            {
                return _Pkey;
            }

            set
            {
                _Pkey = value;
                RaisePropertyChanged("Pkey");
            }
        }

        public string Qkey
        {
            get
            {
                return _Qkey;

            }

            set
            {
                _Qkey = value;
                RaisePropertyChanged("Qkey");
            }
        }

        public string Rkey
        {
            get
            {
                return _Rkey;
            }

            set
            {
                _Rkey = value;
                RaisePropertyChanged("Rkey");
            }
        }

        public string Skey
        {
            get
            {
                return _Skey;
            }

            set
            {
                _Skey = value;
                RaisePropertyChanged("Skey");
            }
        }

        public string Tkey
        {
            get
            {
                return _Tkey;
            }

            set
            {
                _Tkey = value;
                RaisePropertyChanged("Tkey");
            }
        }

        public string Vkey
        {
            get
            {
                return _Vkey;

            }

            set
            {
                _Vkey = value;
                RaisePropertyChanged("Vkey");
            }
        }

        public string Ukey
        {
            get
            {
                return _Ukey;

            }

            set
            {
                _Ukey = value;
                RaisePropertyChanged("Ukey");
            }
        }

        public string Wkey
        {
            get
            {
                return _Wkey;
            }

            set
            {
                _Wkey = value;
                RaisePropertyChanged("Wkey");
            }
        }

        public string Xkey
        {
            get
            {
                return _Xkey;
            }

            set
            {
                _Xkey = value;
                RaisePropertyChanged("Xkey");
            }
        }

        public string Ykey
        {
            get
            {
                return _Ykey;
            }

            set
            {
                _Ykey = value;
                RaisePropertyChanged("Ykey");
            }
        }

        public string Zkey
        {
            get
            {
                return _Zkey;
            }

            set
            {
                _Zkey = value;
                RaisePropertyChanged("Zkey");
            }
        }
        #endregion

        #region Alphabet Commands
        public RelayCommand ExclamationCommand { get; set; }
        public RelayCommand CapsCommand { get; set; }
        public RelayCommand Acommand { get; set; }
        public RelayCommand Bcommand { get; set; }
        public RelayCommand Ccommand { get; set; }
        public RelayCommand Dcommand { get; set; }
        public RelayCommand Ecommand { get; set; }
        public RelayCommand Fcommand { get; set; }
        public RelayCommand Gcommand { get; set; }
        public RelayCommand Hcommand { get; set; }
        public RelayCommand Icommand { get; set; }
        public RelayCommand Jcommand { get; set; }
        public RelayCommand Kcommand { get; set; }
        public RelayCommand Lcommand { get; set; }
        public RelayCommand Mcommand { get; set; }
        public RelayCommand Ncommand { get; set; }
        public RelayCommand Ocommand { get; set; }
        public RelayCommand Pcommand { get; set; }
        public RelayCommand Qcommand { get; set; }
        public RelayCommand Rcommand { get; set; }
        public RelayCommand Scommand { get; set; }
        public RelayCommand Tcommand { get; set; }
        public RelayCommand Vcommand { get; set; }
        public RelayCommand UCommand { get; set; }
        public RelayCommand Wcommand { get; set; }
        public RelayCommand Xcommand { get; set; }
        public RelayCommand Ycommand { get; set; }
        public RelayCommand Zcommand { get; set; }
        public RelayCommand SpaceCommand { get; set; }
        public RelayCommand ColonCommand { get; set; }
        public RelayCommand QuestionCommand { get; set; }
        public RelayCommand PointCOmmmand { get; set; }



        #endregion

        #region Alphabet Execute Methods
        public void ExecuteExclamation()
        {
            Message = Message + "!";
        }

        private void ExecuteCapsCommand()
        {
            if (caps == false)
            {
                caps = true;
                CapsEnabled = true;
                CapsDisabled = false;

                Akey = Akey.ToUpper();
                Bkey = Bkey.ToUpper();
                Ckey = Ckey.ToUpper();
                Dkey = Dkey.ToUpper();
                Ekey = Ekey.ToUpper();
                Fkey = Fkey.ToUpper();
                Gkey = Gkey.ToUpper();
                Hkey = Hkey.ToUpper();
                Ikey = Ikey.ToUpper();
                Jkey = Jkey.ToUpper();
                Kkey = Kkey.ToUpper();
                Lkey = Lkey.ToUpper();
                Mkey = Mkey.ToUpper();
                Nkey = Nkey.ToUpper();
                Okey = Okey.ToUpper();
                Pkey = Pkey.ToUpper();
                Qkey = Qkey.ToUpper();
                Rkey = Rkey.ToUpper();
                Skey = Skey.ToUpper();
                Tkey = Tkey.ToUpper();
                Vkey = Vkey.ToUpper();
                Ukey = Ukey.ToUpper();
                Wkey = Wkey.ToUpper();
                Xkey = Xkey.ToUpper();
                Ykey = Ykey.ToUpper();
                Zkey = Zkey.ToUpper();
            }
            else
            {
                caps = false;
                CapsEnabled = false;
                CapsDisabled = true;
                Akey = Akey.ToLower();
                Bkey = Bkey.ToLower();
                Ckey = Ckey.ToLower();
                Dkey = Dkey.ToLower();
                Ekey = Ekey.ToLower();
                Fkey = Fkey.ToLower();
                Gkey = Gkey.ToLower();
                Hkey = Hkey.ToLower();
                Ikey = Ikey.ToLower();
                Jkey = Jkey.ToLower();
                Kkey = Kkey.ToLower();
                Lkey = Lkey.ToLower();
                Mkey = Mkey.ToLower();
                Nkey = Nkey.ToLower();
                Okey = Okey.ToLower();
                Pkey = Pkey.ToLower();
                Qkey = Qkey.ToLower();
                Rkey = Rkey.ToLower();
                Skey = Skey.ToLower();
                Tkey = Tkey.ToLower();
                Vkey = Vkey.ToLower();
                Ukey = Ukey.ToLower();
                Wkey = Wkey.ToLower();
                Xkey = Xkey.ToLower();
                Ykey = Ykey.ToLower();
                Zkey = Zkey.ToLower();
            }
        }

        private void ExecuteAcommand()
        {
            Clickkey(Akey);
        }

        private void ExecuteBcommand()
        {
            Clickkey(Bkey);
            RaisePropertyChanged("Message");
        }

        private void ExecuteCcommand()
        {
            Clickkey(Ckey);

        }

        private void ExecuteDcommand()
        {
            Clickkey(Dkey);

        }

        private void ExecuteEcommand()
        {
            Clickkey(Ekey);

        }

        private void ExecuteFcommand()
        {
            Clickkey(Fkey);

        }

        private void ExecuteGcommand()
        {
            Clickkey(Gkey);

        }

        private void ExecuteHcommand()
        {
            Clickkey(Hkey);

        }

        private void ExecuteIcommand()
        {
            Clickkey(Ikey);

        }

        private void ExecuteJcommand()
        {
            Clickkey(Jkey);

        }

        private void ExecuteKcommand()
        {
            Clickkey(Kkey);

        }

        private void ExecuteLcommand()
        {
            Clickkey(Lkey);

        }

        private void ExecuteMcommand()
        {
            Clickkey(Mkey);

        }

        private void ExecuteNcommand()
        {
            Clickkey(Nkey);

        }

        private void ExecuteOcommand()
        {
            Clickkey(Okey);

        }

        private void ExecutePcommand()
        {
            Clickkey(Pkey);

        }

        private void ExecuteQcommand()
        {
            Clickkey(Qkey);

        }

        private void ExecuteRcommand()
        {
            Clickkey(Rkey);

        }

        private void ExecuteScommand()
        {
            Clickkey(Skey);

        }

        private void ExecuteTcommand()
        {
            Clickkey(Tkey);

        }

        private void ExecuteVcommand()
        {
            Clickkey(Vkey);

        }

        private void ExecuteUcommand()
        {
            Clickkey(Ukey);

        }

        private void ExecuteWcommand()
        {
            Clickkey(Wkey);

        }

        private void ExecuteXcommand()
        {
            Clickkey(Xkey);

        }

        private void ExecuteYcommand()
        {
            Clickkey(Ykey);

        }

        private void ExecuteZcommand()
        {
            Clickkey(Zkey);

        }

        private void ExecuteSPacecommand()
        {
            Message = Message + " ";
        }

        private void ExecuteColonCommand()
        {
            Message = Message + ";";
        }

        private void ExecuteQuestionCommand()
        {
            Message = Message + "?";
        }

        private void ExecutePointCommand()
        {
            Message = Message + ".";
        }
        #endregion

        public bool IsDigitOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }


    }
}
