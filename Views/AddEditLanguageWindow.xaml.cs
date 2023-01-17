using SR39_2021_pop2022_2.Models;
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

namespace SR39_2021_pop2022_2.Views
{
    public partial class AddEditLanguageWindow : Window
    {
        private Language language;
        private ILanguageService languageService = new LanguageService();
        private bool isAddMode;

        public AddEditLanguageWindow(Language language)
        {
            InitializeComponent();
            this.language = language.Clone() as Language;

            DataContext = this.language;

            isAddMode = false;
            //txtId.IsReadOnly = true;

        }

        public AddEditLanguageWindow()
        {
            InitializeComponent();


            language = new Language
            {

                IsDeleted = false,
            };

            isAddMode = true;
            DataContext = language;
        }

        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //if (language.IsValid)
            //{
                if (isAddMode)
                {

                    languageService.Add(language);
                }
                else
                {
                    languageService.Update(language.Id, language);
                }

                DialogResult = true;
                Close();
            //}

        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }



    }
}
