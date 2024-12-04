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

namespace Bookstore_App___Exam
{
    /// <summary>
    /// Interaction logic for InputDialogWindow2.xaml
    /// </summary>
    public partial class InputDialogWindow2 : Window
    {
        public string Content { get; private set; }
        public InputDialogWindow2(string label_content)
        {
            InitializeComponent();
            TextBlock_.Content = label_content;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Content = TextBox_.Text;
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
