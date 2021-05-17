using System;
using System.Collections.Generic;
using System.Data;
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

namespace TestCursach
{
    /// <summary>
    /// Логика взаимодействия для EditQuestion.xaml
    /// </summary>
    public partial class EditQuestion : Window
    {
        public EditQuestion()
        {
            InitializeComponent();
            SetProfessions();
        }

        public string ID { get; set; }
        public void SetProfessions()
        {
            DataTable dt = DB.Select("select * from Professions");
            List<string> professions = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                professions.Add(dr["name"].ToString());
            }
            Professions.ItemsSource = professions;
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            int id_p = DB.GetId($"select * from Professions where [name]='{Professions.SelectedItem}'");
            if (DB.Command($"update Questions set [name] = '{Name.Text}', id_p = {id_p} where id={ID}"))
            {
                Close();
            }
        }
    }
}
