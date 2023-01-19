using Microsoft.VisualBasic.ApplicationServices;
using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Services;
using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using User = SR39_2021_POP2022_2.Models.User;

namespace SR39_2021_pop2022_2.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private User user;
        private IUserService userService = new UserService();
        string s = "";
        private List<User> users = new List<User>();
        private User _loggUser;
        private EUserType _loggUserType;

        public LoginWindow()
        {
            InitializeComponent();
        }

        //public User login(string email, string password)
        //{
        //    users = userService.GetActiveUsers();
        //    if (email != null && password != null)
        //    {
        //        foreach (User user in users)
        //        {
        //            if (user.Password == password && user.Email == email)
        //            {
        //                Console.WriteLine("OVDE");
        //                //return user;
        //            }
        //        }
        //    }
        //    return null;
        //}

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {

                string commandtext = $"select * from dbo.Users where Email='{email}' and Password='{password}'";
                SqlCommand command = new SqlCommand(commandtext, conn);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    reader.Read();
                    int Id = (int)reader["Id"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    EUserType userType = (EUserType)Enum.Parse(typeof(EUserType), reader["UserType"] as string);

                    _loggUser = new User
                    {
                        Id = Id,
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        UserType = userType
                     };


                    _loggUserType = userType;

                    this.Hide();

                     var welcomeWindow = new WelcomeWindow(_loggUser, _loggUserType);
                     welcomeWindow.OpenWindows();
                     welcomeWindow.Show();
                     //var showStudentWindow = new ShowStudentsWindow(_loggUser);
                     //var showprofessorwindow = new ShowProfessorsWindow(_loggUser);
                }
                else
                {

                    MessageBox.Show("invalid email or password. please try again.");
                }

                reader.Close();
                conn.Close();

            }

















            //if (txtEmail.Text == s || txtPassword.Text == s)
            //{
            //    MessageBox.Show("Polje ne sme da bude prazno");
            //}
            //else
            //{
            //    user = login(txtEmail.Text, txtPassword.Text);
            //    if (user != null)
            //    {
            //        Data.Instance.LoggedInUser = user;
            //        MainWindow mainWindow = new MainWindow();
            //        //MessageBox.Show(user.FirstName);
            //        //mainWindow.ShowDialog();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Korisnik ne postoji");
            //    }
            //}

        }
    }
    //    //using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
    //    //{
    //    //    conn.Open();

    //    //    SqlCommand command = conn.CreateCommand();
    //    //    command.CommandText = @"SELECT * FROM dbo.Users WHERE email = @email AND password = @password";
    //    //    command.Parameters.Add(new SqlParameter("email",User.));

    //    //    command.ExecuteNonQuery();

    //    //}
    //    SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=database;Integrated Security=True");
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE email = @email AND password = @password", con);
    //    cmd.Parameters.AddWithValue("@email", txtEmail);
    //    cmd.Parameters.AddWithValue("@password", txtPassword);
    //    SqlDataReader reader = cmd.ExecuteReader();
    //    if (reader.Read())
    //    {
    //        // If a match is found, check the user's type and redirect them to the appropriate page
    //        string userType = (string)reader["UserType"];
    //        if (userType == "ADMINISTRATOR")
    //        {
    //            Console.WriteLine("Welcome administrator!");

    //        }
    //        else if (userType == "PROFESSOR")
    //        {
    //            Console.WriteLine("Welcome professor!");

    //        }
    //        else if (userType == "STUDENT")
    //        {
    //            Console.WriteLine("Welcome student!");

    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Invalid email or password.");
    //    }
    //    reader.Close();
    //    con.Close();
    //}
}


