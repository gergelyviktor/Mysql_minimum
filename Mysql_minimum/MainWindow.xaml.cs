using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mysql_minimum {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        MySqlConnection kapcs = new MySqlConnection("server = server.fh2.hu;database = v2labgwj_12b; uid = v2labgwj_12b; password = '4W56FNhfKJfeZVhGwasG';");
        public MainWindow() {
            InitializeComponent();
        }

        private void megnyit() {
            try {
                kapcs.Open();
                //MessageBox.Show("db kapcsolódva");
            }
            catch (Exception) {

                MessageBox.Show("db hiba");
            }
        }

        private void lezar() {
            kapcs.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            megnyit();
            // le kell kérdezni, hogy  az beírt névvel és jelszóval létezik-e user
            var sql = $"select * from user where nev = '{txtNev.Text}' and jelszo = '{txtJelszo.Password}'";
            var lekerdezes = new MySqlCommand(sql, kapcs).ExecuteReader();
            if (lekerdezes.Read()) {
                MessageBox.Show("sikeres bejelentkezés");
            }
            else {
                MessageBox.Show("sikertelen bejelentkezés");
            }
            lezar();
        }

    }
}
