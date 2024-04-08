using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Product_Orders_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            productOrderListView.ItemsSource = getProductAndOrderData ( (App.Current as App).ConnectionString );
        }

        public ObservableCollection<ProductOrderData> getProductAndOrderData(string connectionString)
        {
            const string getProductOrderDataQuery = "SELECT storeAddress, productName, productType, orderDate, productPrice, orderQuantity, (productPrice * orderQuantity) AS orderAmt, orderTaxAmount, ((productPrice * orderQuantity) + orderTaxAmount) AS totalBillAmt FROM Orders INNER JOIN Products ON Orders.productId = Products.productId INNER JOIN Stores ON Stores.storeId = Orders.storeId INNER JOIN ProductTypes ON ProductTypes.productTypeId = Products.productTypeId ORDER BY totalBillAmt DESC";

            var productOrderList = new ObservableCollection<ProductOrderData>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = getProductOrderDataQuery;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var productOrderData = new ProductOrderData();

                                    productOrderData.storeAddress = reader.GetString(0);
                                    productOrderData.productName = reader.GetString(1);
                                    productOrderData.productType = reader.GetString(2);
                                    productOrderData.orderDate = reader.GetDateTime(3);
                                    productOrderData.productPrice = reader.GetDecimal(4);
                                    productOrderData.orderQuantity = reader.GetInt32(5);
                                    productOrderData.orderAmt = reader.GetDecimal(6);
                                    productOrderData.orderTaxAmount = reader.GetDecimal(7);
                                    productOrderData.totalBillAmt = reader.GetDecimal(8);

                                    productOrderList.Add( productOrderData );
                                }
                            }
                        }
                    }
                }
                return productOrderList;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine($"Exception: {eSql.Message}");
            }
            return null;
        }
    }
}
