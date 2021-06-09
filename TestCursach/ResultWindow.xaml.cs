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
            DataTable dt = DB.Select($"select * from Question_Answers " +
                $"join Questions on Questions.id = Question_Answers.id_q " +
                $"join Answers on Answers.id = Question_Answers.id_a " +
                $"where id_u = { DB.UserID} ");
            List<Answer> answers = new List<Answer>();
            int final_score = 0;
            foreach (DataRow dr in dt.Rows)
            {
                int score = 0;
                if(Convert.ToInt32(dr["id_a"].ToString()) % 2 == 0)
                {
                    score = Convert.ToInt32(dr["score"]);
                }
                else
                {
                    score = 0;
                }
                answers.Add(new Answer 
                {
                    AnswerText = dr["value"].ToString(),
                    Score = score.ToString()
                });
                final_score += score;
            }
            Score.Content = "Общий счет: " + final_score;
            Results.ItemsSource = answers;
        }
    }
}
