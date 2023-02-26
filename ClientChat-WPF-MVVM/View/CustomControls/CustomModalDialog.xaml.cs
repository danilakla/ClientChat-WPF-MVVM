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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientChat_WPF_MVVM.View.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для CustomModalDialog.xaml
    /// </summary>
    public partial class CustomModalDialog : UserControl
    {
        public CustomModalDialog()
        {
            InitializeComponent();
        }
        private void Rectangle_MouseDown(object sender, MouseEventArgs e)
        {
            this.Visibility= Visibility.Collapsed;
        }
    }
}
