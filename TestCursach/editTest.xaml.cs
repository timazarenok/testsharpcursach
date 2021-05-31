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
using TestCursach.models;

namespace TestCursach
{
    /// <summary>
    /// Логика взаимодействия для editTest.xaml
    /// </summary>
    public partial class editTest : Window
    {
        private AddQuestion add;
        public editTest()
        {
            InitializeComponent();
            SetQuestions();
        }
        public void SetQuestions()
        {
            DataTable dt = DB.Select("select Questions.id, Questions.[name] from Questions");
            List<Test> tests = new List<Test>();
            foreach (DataRow dr in dt.Rows)
            {
                tests.Add(new Test
                {
                    ID = dr["id"].ToString(),
                    Name = dr["name"].ToString(),
                });
            }
            Questions.ItemsSource = tests;
        }

        private void Questions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Test t = (Test)Questions.SelectedItem;
            DB.QuestionID = Convert.ToInt32(t.ID);
            EditQuestion window = new EditQuestion();
            window.ID = t.ID;
            window.Name.Text = t.Name;
            window.Show();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }
        public void AddClosed(object sender, System.EventArgs e)
        {
            add = null;
            SetQuestions();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            add = new AddQuestion();
            add.Show();
            add.Closed += AddClosed;
        }
    }
}
