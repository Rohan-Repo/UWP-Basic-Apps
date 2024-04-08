using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Product_Orders_App
{
    public class ProductOrderData : INotifyPropertyChanged
    {
        public string storeAddress { get; set; }

        public string productName { get; set; }

        public string productType { get; set; }

        public DateTime orderDate { get; set; }

        public String orderDateStr { get { return orderDate.ToString("yyyy/MM/dd"); } }

        public decimal productPrice { get; set; }

        public int orderQuantity { get; set; }

        public decimal orderAmt { get; set; }

        public decimal orderTaxAmount { get; set; }

        public decimal totalBillAmt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
