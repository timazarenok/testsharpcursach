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
        }

        public void SetTestQuestions()
        {
            MessageBox.Show(DB.TestID + "");
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
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if(DB.Command($"insert into Answers values ({questions[Count].ID}, {DB.UserID}, 1)"))
            {
                MessageBox.Show("Ответ принят");
                Count += 1;
                if (Count == questions.Count)
                {
                    MessageBox.Show("Тест окончен, результаты можно посмотреть позже");
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

        private void No_Click(object sender, RoutedEventArgs e)
        {
            if (DB.Command($"insert into Answers values ({questions[Count].ID}, {DB.UserID}, 0)"))
            {
                MessageBox.Show("Ответ принят");
                Count += 1;
                if (Count == questions.Count)
                {
                    MessageBox.Show("Тест окончен, результаты можно посмотреть позже");
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

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
