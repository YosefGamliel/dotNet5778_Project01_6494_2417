using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for REMOVENANNY.xaml
    /// </summary>
    public partial class REMOVENANNY : Window
    {
        static string API_KEY = ConfigurationSettings.AppSettings.Get("googleApiKey");
        public REMOVENANNY()
        {
            InitializeComponent();
        }
        

        public static List<string> GetPlaceAutoComplete(string str)
        {
            List<string> result = new List<string>();
            GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest request = new GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest();
            request.ApiKey = API_KEY;
            request.Input = str;

            var response = GoogleMaps.PlaceAutocomplete.Query(request);

            foreach (var item in response.Results)
            {
                result.Add(item.Description);
            }

            return result;
        }
    }
}
