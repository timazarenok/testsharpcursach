using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        }

        public string ID { get; set; }
        private void Score_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if(Name.Text.Length > 0 && Score.Text.Length > 0)
            {
                if (DB.Command($"update Questions set [name] = '{Name.Text}', score = '{Score.Text}' where id={ID}"))
                {
                    Close();
                }
            }
            else
            {
                if (Name.Text.Length > 0)
                {
                    if (DB.Command($"update Questions set [name] = '{Name.Text}' where id={ID}"))
                    {
                        Close();
                    }
                }
                if (Score.Text.Length > 0)
                {
                    if (DB.Command($"update Questions set score = '{Score.Text}' where id={ID}"))
                    {
                        Close();
                    }
                }
            } 
        }
    }
}
