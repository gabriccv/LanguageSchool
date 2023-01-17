using SR39_2021_POP2022_2.Models;
using SR39_2021_pop2022_2.Services;
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
using SR39_2021_pop2022_2.Models;

namespace SR39_2021_pop2022_2.Views
{
    public partial class ShowLanguagesWindow : Window
    {
        private LanguageService languageService = new LanguageService();


        public enum State { ADMINISTRATION, DOWNLOADING };
        State state;
        public Language SelectedLanguage = null;

        public ShowLanguagesWindow(State state = State.ADMINISTRATION)
        {
            InitializeComponent();
            this.state = state;

            if (state == State.DOWNLOADING)
            {
                miAddLanguage.Visibility = Visibility.Collapsed;
                miUpdateLanguage.Visibility = Visibility.Collapsed;
                miDeleteLanguage.Visibility = Visibility.Collapsed;
            }
            else
            {
                miPickLanguage.Visibility = Visibility.Hidden;
            }

            //dgAddresses.ItemsSource = Data.Instance.Addresses;
            dgLanguages.ItemsSource = languageService.GetAll();

            dgLanguages.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        public ShowLanguagesWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void miPickLanguageb_Click(object sender, RoutedEventArgs e)
        {
            SelectedLanguage = dgLanguages.SelectedItem as Language;
            this.DialogResult = true;
            this.Close();
        }

        private void miAddLanguage_Click(object sender, RoutedEventArgs e)
        {
            var addEditLanguageWindow = new AddEditLanguageWindow();

            var successeful = addEditLanguageWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }

        private void miUpdateLanguage_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgLanguages.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var languages = languageService.GetAll();

                var addEditLanguageWindow = new AddEditLanguageWindow(languages[selectedIndex]);

                var successeful = addEditLanguageWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miDeleteLanguage_Click(object sender, RoutedEventArgs e)
        {
            var selectedLanguage = dgLanguages.SelectedItem as Language;

            if (selectedLanguage != null)
            {
                languageService.Delete(selectedLanguage.Id);
                RefreshDataGrid();
            }
        }


        private void RefreshDataGrid()
        {
            List<Language> languages = languageService.GetAll().Select(p => p).ToList();
            dgLanguages.ItemsSource = languages;
        }

        private void dgLanguages_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Error" || e.PropertyName == "IsValid")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void miPickLanguage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
