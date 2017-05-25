using System;
using System.Collections.Generic;
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

namespace musiclibrary2017
{
    /// <summary>
    /// Логика взаимодействия для NewSingerWindow.xaml
    /// </summary>
    public partial class NewSingerWindow : Window
    {
        public NewSingerWindow(List<Country> countries)
        {
            InitializeComponent();

            comboBoxCountries.ItemsSource = countries;
        }

        Singer _newSinger;

        public Singer NewSinger
        {
            get
            {
                return _newSinger;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int year;
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Необходимо ввести имя");
                textBoxName.Focus();
                return;
            }
            if (!int.TryParse(textBoxYear.Text, out year))
            {
                MessageBox.Show("Некорректно написан год создания");
                textBoxYear.Focus();
                return;
            }
            if (year < 1900 || year > 2017)
            {
                MessageBox.Show("Год создания должен быть от 1900 до 2017 включительно");
                textBoxYear.Focus();
                return;
            }

            if (comboBoxCountries.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать страну");
                comboBoxCountries.Focus();
                return;
            }

            _newSinger = new Singer(textBoxName.Text, year);
            _newSinger.Country = comboBoxCountries.SelectedItem as Country;
            // Close current window
            DialogResult = true;
        }
    }
}
