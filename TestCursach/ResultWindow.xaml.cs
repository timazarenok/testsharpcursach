using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow()
        {
            InitializeComponent();
            DataTable dt = DB.Select($"select Count([Answers].[value]) as Result, Professions.[name] from Answers " +
                $"join Questions on Questions.id = Answers.id_q " +
                $"join Professions on Professions.id = Questions.id_p " +
                $"where Answers.id_u = {DB.UserID} " +
                $"group by Professions.[name] ");
            List<Answer> answers = new List<Answer>();
            foreach (DataRow dr in dt.Rows)
            {
                answers.Add(new Answer { Result = Convert.ToDouble(dr["Result"]), Profession = dr["name"].ToString() });
            }
            Results.ItemsSource = answers;
        }
    }
}
