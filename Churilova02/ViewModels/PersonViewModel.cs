    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using Churilova02.Models;
    using Churilova02.Properties;
    using Churilova02.Tools;
    using Churilova02.Tools.Managers;

    namespace Churilova02.ViewModels
    {
        class PersonViewModel : INotifyPropertyChanged, ILoaderOwner
        {
            #region Fields
            private readonly Person _person = new Person();
            #endregion


            #region Commands
            private RelayCommand<object> _proceedCommand;
            #endregion


            #region Properties
            public string Name
            {
                get { return _person.Name; }
                set { _person.Name = value; }
            }

            public string Surname
            {
                get { return _person.Surname; }
                set { _person.Surname = value; }
            }

            public string Email
            {
                get { return _person.Email; }
                set { _person.Email = value; }
            }

            
            public DateTime BirthDate
            {
                get { return _person.BirthDate; }
                set { _person.BirthDate = value; }
            }

            public string BirthDateStr
            {
                get { return _person.BirthDate != DateTime.MinValue ? _person.BirthDate.ToShortDateString() : " "; }
            }

            public string SunSign
            {
                get { return _person.SunSign; }
              
            }

            public string ChineseSign
            {
                get { return _person.ChineseSign; }
            }

            public bool? IsAdult
            {
                get { return _person.IsAdult; }
            }

            public bool? IsBirthday
            {
                get { return _person.IsBirthday; }
            }
            #endregion


            #region Commands

            public RelayCommand<object> ProceedCommand
            {
                get
                {
                    return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(Proceed, o => CanExecuteCommand()));
                }
            }

            #endregion

            private bool CanExecuteCommand()
            {
                return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Surname) && !String.IsNullOrWhiteSpace(Email) && (BirthDate!= DateTime.MinValue);
            }
        

           
            private void Proceed()
            {
                if ((DateTime.Today.Year - _person.BirthDate.Year) > 135)
                {
                    MessageBox.Show("Error! You are too old!");
                }
                else if (_person.BirthDate.CompareTo(DateTime.Today) > 0)
                {
                    MessageBox.Show("Error! You don't exist yet!");
                }

                else {
                    if (_person.BirthDate.Month.CompareTo(DateTime.Today.Month) == 0 && _person.BirthDate.Day.CompareTo(DateTime.Today.Day) == 0)
                {
                    MessageBox.Show("Happy Birthday! Enjoy your special day!");
                }

                    _person.CalculateSunSign();
                    _person.CalculateChineseSign();
                    _person.CalculateIsAdult();
                    _person.CalculateIsBirthday();


                    OnPropertyChanged("Name");
                    OnPropertyChanged("Surname");
                    OnPropertyChanged("Email");
                    OnPropertyChanged("BirthDateStr");
                    OnPropertyChanged("SunSign");
                    OnPropertyChanged("ChineseSign");
                    OnPropertyChanged("IsAdult");
                    OnPropertyChanged("IsBirthday");

                    Thread.Sleep(1000);

                }

            
                
            }

         
            

            private async void Proceed(object obj)
            {
                LoaderManager.Instance.ShowLoader();
                await Task.Run(() => Proceed());
                LoaderManager.Instance.HideLoader();
            }




            public event PropertyChangedEventHandler PropertyChanged;
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }


            #region Fields
            private Visibility _loaderVisibility = Visibility.Hidden;
            private bool _isControlEnabled = true;
            #endregion


            #region Properties
            public Visibility LoaderVisibility
            {
                get { return _loaderVisibility; }
                set
                {
                    _loaderVisibility = value;
                    OnPropertyChanged();
                }
            }
            public bool IsControlEnabled
            {
                get { return _isControlEnabled; }
                set
                {
                    _isControlEnabled = value;
                    OnPropertyChanged();
                }
            }
            #endregion

            internal PersonViewModel()
            {
                LoaderManager.Instance.Initialize(this);
            }
        }
    }
