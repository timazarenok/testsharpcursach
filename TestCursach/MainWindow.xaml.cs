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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestCursach.models;

namespace TestCursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetTests();
        }

        public void SetTests()
        {
            DataTable dt = DB.Select("select Tests.id, Tests.[name], Professions.[name] as profession from Tests join Professions on Professions.id = Tests.id_p");
            List<Test> tests = new List<Test>();
            foreach(DataRow dr in dt.Rows)
            {
                tests.Add(new Test { 
                    ID = dr["id"].ToString(), 
                    Name = dr["name"].ToString(), 
                    Profession = dr["profession"].ToString() 
                });
            }
            Tests.ItemsSource = tests;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        private void Tests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Test t = (Test)Tests.SelectedItem;
            DB.TestID = Convert.ToInt32(t.ID);
            TestWindow window = new TestWindow();
            window.Show();
            Close();
        }
    }
}
