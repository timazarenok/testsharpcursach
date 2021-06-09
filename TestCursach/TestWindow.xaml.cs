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
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public List<Question> questions = new List<Question>();
        public int Count;
        public TestWindow()
        {
            InitializeComponent();
            Count = 0;
            SetTestQuestions();
            DeletePreviousAnsers();
            SetAnswers();
        }
        public void DeletePreviousAnsers()
        {
            if(DB.Command($"delete from Question_Answers where id_u = {DB.UserID}"))
            {
                MessageBox.Show("Старт");
            }
        }
        private void SetAnswers()
        {
            DataTable dt = DB.Select($"select * from Answers where id_q={questions[Count].ID}");
            List<Answer> answers = new List<Answer>();
            foreach(DataRow dr in dt.Rows)
            {
                answers.Add(new Answer { ID = dr["id"].ToString(), AnswerText = dr["value"].ToString() });
            }
            Answers.ItemsSource = answers;
        }
        public void SetTestQuestions()
        {
            DataTable dt = DB.Select($"select * from Questions where id_t = {DB.TestID}");
            questions = new List<Question>();
            foreach (DataRow dr in dt.Rows)
            {
                questions.Add(new Question { ID = dr["id"].ToString(), Value= dr["name"].ToString() });
            }
            Question.Text = questions[Count].Value;
        }

        public void ChangeQuestion()
        {
            Question.Text = questions[Count].Value;
            SetAnswers();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void Answers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Answer answer = (Answer)Answers.SelectedItem;
            if (DB.Command($"insert into Question_Answers values ({questions[Count].ID}, {answer.ID}, {DB.UserID})"))
            {
                MessageBox.Show("Ответ принят");
                Count += 1;
                if (Count == questions.Count)
                {
                    ResultWindow result = new ResultWindow();
                    result.Show();
                }
                else
                {
                    ChangeQuestion();
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
