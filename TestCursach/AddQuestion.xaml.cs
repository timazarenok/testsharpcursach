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
    /// Логика взаимодействия для AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        public int Amount;
        public int IDTest;
        public AddQuestion()
        {
            InitializeComponent();
            IDTest = DB.GetId("select top 1 * from Tests order by id desc");
        }

        public void ResetInputs()
        {
            Name.Text = "";
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if(Amount >= 0)
            {
                if(DB.Command($"insert into Questions values({IDTest}, '{Name.Text}')"))
                {
                    Amount -= 1;
                    if (Amount == 0)
                    {
                        AdminWindow admin = new AdminWindow();
                        admin.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"Следующий вопрос, осталось всего: {Amount}");
                        ResetInputs();
                    }
                }
            }
        }
    }
}
