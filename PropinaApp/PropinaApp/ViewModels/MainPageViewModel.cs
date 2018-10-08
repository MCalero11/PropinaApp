using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PropinaApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Properties
        private double _total;

        public double Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(); }
        }

        private double _propina;

        public double Propina
        {
            get { return _propina; }
            set { _propina = value; OnPropertyChanged(); }
        }

        private int _personas;

        public int Personas
        {
            get { return _personas; }
            set { _personas = value; OnPropertyChanged(); }
        }

        private double _valPropina;

        public double ValPropina
        {
            get { return _valPropina; }
            set { _valPropina = value; OnPropertyChanged(); }
        }

        private double _valTotal;

        public double ValTotal
        {
            get { return _valTotal; }
            set { _valTotal = value; OnPropertyChanged(); }
        }

        private double _propinaPorPersona;

        public double PropinaPorPersona
        {
            get { return _propinaPorPersona; }
            set { _propinaPorPersona = value; OnPropertyChanged(); }
        }

        private double _totalPorPersona;

        public double TotalPorPersona
        {
            get { return _totalPorPersona; }
            set { _totalPorPersona = value; OnPropertyChanged(); }
        }
        

        #endregion
        #region Binding
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Commands
        public ICommand CalcularCommand { get; set; }
        public ICommand LimpiarCommand { get; set; }
        #endregion

        public MainPageViewModel()
        {
            CalcularCommand = new Command(Calcular);
            LimpiarCommand = new Command(Limpiar);
        }

        private void Calcular()
        {
            if (Total == 0 || Propina == 0 || Personas == 0)
            {
                App.Current.MainPage.DisplayAlert("¡Alerta!","Los campos no deben estar vacios","OK");
                return;
            }

            ValPropina = Total * (Propina / 100);
            ValTotal = Total + ValPropina;
            PropinaPorPersona = ValPropina / Personas;
            TotalPorPersona = ValTotal / Personas;
        }
        private void Limpiar()
        {
            Total             = 0;
            Propina           = 0;
            Personas          = 0;
            ValPropina        = 0;
            ValTotal          = 0;
            PropinaPorPersona = 0;
            TotalPorPersona   = 0;
        }
    }
}
