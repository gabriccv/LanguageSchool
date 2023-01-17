//using SR39_2021_pop2022_2.Models;
//using SR39_2021_POP2022_2.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Runtime.Remoting.Lifetime;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace SR39_2021_pop2022_2.Views
//{
//    /// <summary>
//    /// Interaction logic for LoginWindow.xaml
//    /// </summary>
//    public partial class LoginWindow : Window
//    {
//        public LoginWindow()
//        {
//            InitializeComponent();
//        }

//        private void btnCancel_Click(object sender, RoutedEventArgs e)
//        {
//            DialogResult = false;
//            Close();
//        }

//        private void btnLogin_Click(object sender, RoutedEventArgs e)
//        {
//            //using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
//            //{
//            //    conn.Open();

//            //    SqlCommand command = conn.CreateCommand();
//            //    command.CommandText = @"SELECT * FROM dbo.Users WHERE email = @email AND password = @password";
//            //    command.Parameters.Add(new SqlParameter("email",User.));

//            //    command.ExecuteNonQuery();

//            //}
//            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=database;Integrated Security=True");
//            con.Open();
//            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE email = @email AND password = @password", con);
//            cmd.Parameters.AddWithValue("@email", txtEmail);
//            cmd.Parameters.AddWithValue("@password", txtPassword);
//            SqlDataReader reader = cmd.ExecuteReader();
//            if (reader.Read())
//            {
//                // If a match is found, check the user's type and redirect them to the appropriate page
//                string userType = (string)reader["UserType"];
//                if (userType == "ADMINISTRATOR")
//                {
//                    Console.WriteLine("Welcome administrator!");
                    
//                }
//                else if (userType == "PROFESSOR")
//                {
//                    Console.WriteLine("Welcome professor!");
                    
//                }
//                else if (userType == "STUDENT")
//                {
//                    Console.WriteLine("Welcome student!");
                    
//                }
//            }
//            else
//            {
//                Console.WriteLine("Invalid email or password.");
//            }
//            reader.Close();
//            con.Close();
//        }
//    }
    
//}
