using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinPads
{
    public partial class PinPads : Form
    {
        Bank[] Banks;
        OleDbConnection connection;
        bool errorDB = false;
        public PinPads()
        {
            InitializeComponent();
            connection = new OleDbConnection();
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Data\\pinpads.mdb;Persist Security Info=True";
            try
            {
                connection.Open();
            } 
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных");
                errorDB = true;
            }
        }

        public void FillData()
        {
            Banks[0] = new Bank();
            Banks[0].Set(1, "VTB24");
            Banks[1] = new Bank();
            Banks[1].Set(2, "Sberbank");
        }

        private void PinPads_Shown(object sender, EventArgs e)
        {
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM bank";
            int number = (int)command.ExecuteScalar();
            Text = number.ToString();
        }
    }
}
