using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChuckNorrisJokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = @"https://api.chucknorris.io/jokes/categories";

            HttpClient client = new HttpClient();

            string json = client.GetStringAsync(url).Result;
            string[] categories = JsonConvert.DeserializeObject<string[]>(json);
            foreach (var item in categories)
            {
                cboJokeSelect.Items.Add(item);
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string url;
            if (cboJokeSelect.SelectedItem != null)
            {
                url = @"https://api.chucknorris.io/jokes/random?category=" + cboJokeSelect.SelectedItem.ToString();
                HttpClient client = new HttpClient();
                string json = client.GetStringAsync(url).Result;
                ChuckNorris joke = JsonConvert.DeserializeObject<ChuckNorris>(json);
                txtJoke.Text = joke.value;
            }
            else
            {
                url = @"https://api.chucknorris.io/jokes/random";
                HttpClient client = new HttpClient();
                string json = client.GetStringAsync(url).Result;
                ChuckNorris joke = JsonConvert.DeserializeObject<ChuckNorris>(json);
                txtJoke.Text = joke.value;
            }

            


        }
    }
}
