using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Sueldo4030349

{
    //Le pongo ? para que no me aparezca un 0 en los entrys y labels 
    partial class AumentoViewModel: INotifyPropertyChanged
    {
        public decimal? _s;
        public decimal? nuevoSueldo;

        public AumentoViewModel()
        {
            CalcularSueldoCommand = new Command(CalcularSueldo);
        }
        public decimal? S
        {            
                get => _s;
                set
            {
                    if (_s != value)
                    {
                        _s = value;
                        OnPropertyChanged();
                        CalcularSueldo();
                    }
                }
            
        }

        
        public decimal? NuevoSueldo
        {
            get => nuevoSueldo;
            private set
            {
                nuevoSueldo = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcularSueldoCommand { get; }

        private void CalcularSueldo()
        {
            if (S < 1000)
            {
                NuevoSueldo = S * 1.15m;
            }
            else
            {
                NuevoSueldo = S * 1.12m;
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
