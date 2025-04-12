using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_CurrencyDisplay_App
{
    public class CurrencyData : INotifyPropertyChanged
    {
        // Map the Variables according to DB Output
        public string fromCurrencyCode { get; set; }
        public string fromCurrencyCodeStr { get; set; }
        public string toCurrencyCode { get; set; }
        public string toCurrencyCodeStr { get; set; }
        public decimal maxAverageRate { get; set; }
        public decimal maxEndOfDayRate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
