using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>.
    public partial class Menu : Window
    {
        searchControl cSearchControl;
     string dbConnectionString = @"Data Source=hospital.sqlite;Version=3;";

    
        public Menu()
        {
           InitializeComponent();
           cSearchControl = new searchControl();
           cSearchControl.Name = "SearchName";
           cSearchControl.Height = 200;
           cSearchControl.Width = 300;
           cSearchControl.HorizontalAlignment = HorizontalAlignment.Left;
           cSearchControl.VerticalAlignment = VerticalAlignment.Top;
           MenuGrid.Children.Add(cSearchControl);
            
        }
       
        
        
        private void enterDataBase(object sender, RoutedEventArgs e)
        {
            addPatient addP = (addPatient)e.OriginalSource;
            SQLiteConnection con = new SQLiteConnection(dbConnectionString);
            try
            {
                con.Open();
                string Query = "insert into patientinfo (fname,lname,address,dob,ssn,phone,gender,veteran) values('" 
                    + addP.fname_txt.Text + "','" 
                    + addP.lname_txt.Text + "','"
                    + addP.address_txt.Text + "','"
                    + addP.dob_txt.Text + "','"
                    + addP.ssn_txt.Password + "','"
                    + addP.phone_txt.Text + "','"
                    + addP.gender_combo.Text + "','"
                    + addP.veteran_combo.Text + "')";
                SQLiteCommand cmd = new SQLiteCommand(Query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("SAVED!");
                addP.fname_txt.Text = "";
                addP.lname_txt.Text = "";
                addP.address_txt.Text = "";
                addP.dob_txt.Text = "";
                addP.ssn_txt.Password = "";
                addP.phone_txt.Text = "";
                addP.gender_combo.Text = "";
                addP.veteran_combo.Text = "";
                con.Close();
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Close();
            this.Close();
        }

    

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            MenuGrid.Children.Remove(cSearchControl);

        }

    

    
        
    }

        }

      /*  private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            this.Hide();
            win3.ShowDialog();
        }*/
    
