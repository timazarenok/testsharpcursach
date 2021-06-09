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
using System.Windows.Shapes;

namespace TestCursach
{
    /// <summary>
    /// Логика взаимодействия для addAnswers.xaml
    /// </summary>
    public partial class addAnswers : Window
    {
        public int Count { get; set; }
        public int Amount { get; set; }
        public int QuestionID { get; set; }
        public addAnswers(int count, int id_q)
        {
            InitializeComponent();
            Count = 0;
            Amount = count;
            QuestionID = id_q;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if(Count+1 == Amount)
            {
                AdminWindow window = new AdminWindow();
                window.Show();
                Close();
            }
            if(AnswerText.Text.Length > 0)
            {
                if(DB.Command($"insert into Answers values({QuestionID}, '{AnswerText.Text}')"))
                {
                    Count += 1;
                    AnswerText.Text = "";
                    MessageBox.Show("Ответ добавлен");
                }
            }
            else
            {
                MessageBox.Show("Введите ответ");
            }
        }
    }
}
