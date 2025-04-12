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

namespace UWP_CurrencyDisplay_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            currencyListView.ItemsSource =
                populateCurrencyData(
                    (App.Current as App).ConnectionString
                );
        }

        public ObservableCollection<CurrencyData> populateCurrencyData(string connectionString)
        {
            // Create SQL QueryString variable
            const string getCurrencyDataQuery =
                "SELECT DISTINCT FromCurrencyCode, 'US Dollars' AS fromCurrencyStr, ToCurrencyCode, Name AS toCurrencyStr, AverageRate, EndOfDayRate FROM Sales.Currency INNER JOIN Sales.CurrencyRate ON Sales.Currency.CurrencyCode = Sales.CurrencyRate.ToCurrencyCode WHERE AverageRate = ( SELECT MAX(AverageRate) FROM Sales.CurrencyRate WHERE Sales.CurrencyRate.ToCurrencyCode = Sales.Currency.CurrencyCode ) AND EndOfDayRate = ( SELECT MAX(EndOfDayRate) FROM Sales.CurrencyRate WHERE Sales.CurrencyRate.ToCurrencyCode = Sales.Currency.CurrencyCode ) ORDER BY AverageRate DESC";

            // Create A list to hold our CurrencyData
            var currencyList = new ObservableCollection<CurrencyData>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            // Set the appropriate SQL QueryString variable
                            cmd.CommandText = getCurrencyDataQuery;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Create Individual CurrencyData Objects
                                    var currencyData = new CurrencyData();

                                    currencyData.fromCurrencyCode =
                                        reader.GetString(0); 
                                    currencyData.fromCurrencyCodeStr =
                                        reader.GetString(1); 
                                    currencyData.toCurrencyCode =
                                        reader.GetString(2);
                                    currencyData.toCurrencyCodeStr =
                                        reader.GetString(3);
                                    currencyData.maxAverageRate = 
                                        reader.GetDecimal(4);
                                    currencyData.maxEndOfDayRate =
                                        reader.GetDecimal(5);

                                    // Add the object to the list
                                    currencyList.Add(currencyData);
                                }
                            }
                        }
                    }
                }
                return currencyList;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine($"Exception: {eSql.Message}");
            }
            return null;
        }
    }
}
