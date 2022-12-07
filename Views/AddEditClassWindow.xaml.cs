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

    public partial class AddEditClassWindow : Window
    {
        private Class @class;
        private IClassService classService = new ClassService();
        private bool isAddMode;

        public AddEditClassWindow(Class @class)
        {
            InitializeComponent();
            this.@class = @class.Clone() as Class;

            DataContext = @class;
            isAddMode = false;

        }

        public AddEditClassWindow()
        {
            InitializeComponent();

            @class = new Class
            {

                IsDeleted = false
            };



            isAddMode = true;
            DataContext = @class;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (@class.IsValid)
            {
                if (isAddMode)
                {
                    classService.Add(@class);
                }
                else
                {
                    classService.Update(@class.Id, @class);
                }

                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
