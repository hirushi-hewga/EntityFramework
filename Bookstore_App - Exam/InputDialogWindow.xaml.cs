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
    /// Interaction logic for InputDialogWindow.xaml
    /// </summary>
    public partial class InputDialogWindow : Window
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public InputDialogWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            FirstName = FirstNameTextBox.Text;
            LastName = LastNameTextBox.Text;
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
