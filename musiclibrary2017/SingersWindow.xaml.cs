using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace musiclibrary2017
{
    /// <summary>
    /// Логика взаимодействия для SingersWindow.xaml
    /// </summary>
    public partial class SingersWindow : Window
    {
        const string FileName = "singers.txt";
        List<Singer> _singers = new List<Singer>();
        List<Country> _countries = new List<Country>();
        public SingersWindow()
        {
            InitializeComponent();

            // Загружаем данные из файла
            LoadData();
        }

        private void RefreshListBox()
        {
            listBoxSingers.ItemsSource = null;
            listBoxSingers.ItemsSource = _singers;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewSingerWindow(_countries);
            if (window.ShowDialog().Value)
            {

                _singers.Add(window.NewSinger);

                SaveData();
                RefreshListBox();
            }
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxSingers.SelectedIndex != -1)
            {
                _singers.RemoveAt(listBoxSingers.SelectedIndex);
                SaveData();
                RefreshListBox();
            }
        }

        private void listBoxSingers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index = -1, we set IsEnabled to false
            buttonRemove.IsEnabled = listBoxSingers.SelectedIndex != -1;
        }

        private void SaveData()
        {
            using (var sw = new StreamWriter(FileName))
            {
                foreach (var lect in _singers)
                {
                    sw.WriteLine($"{lect.Name}:{lect.Year}:{lect.Country.Name}:{lect.Country.School}");
                }
            }
        }

        private void LoadData()
        {
            try
            {
                _singers = new List<Singer>();
                _countries = new List<Country>();

                using (var sr = new StreamReader(FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var parts = line.Split(':');
                        if (parts.Length == 4)
                        {

                            int i = 0;
                            while (i < _countries.Count && _countries[i].Name != parts[2])
                                i++;
                            Country f;
                            if (i < _countries.Count)
                                f = _countries[i];  // Use existing faculty
                            else
                            {
                                // Create a new faculty and add it to the list
                                f = new Country(parts[2], parts[3]);
                                _countries.Add(f);
                            }

                            var Singer = new Singer(parts[0], int.Parse(parts[1]));
                            Singer.Country = f;
                            _singers.Add(Singer);
                        }
                    }


                }
            }
            catch (FileNotFoundException)
            {
                // Файла с данными нет, создаем один факультет по умолчанию, чтобы можно было
                // выбирать его при добавлении преподавателей
                _countries.Add(new Country("United States of America", "Rap"));
            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }
            RefreshListBox();
        }
    }
}
