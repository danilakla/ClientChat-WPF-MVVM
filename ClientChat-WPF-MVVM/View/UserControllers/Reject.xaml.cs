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

namespace ClientChat_WPF_MVVM.View.UserControllers
{
    /// <summary>
    /// Логика взаимодействия для Reject.xaml
    /// </summary>
    public partial class Reject : UserControl
    {
        public Reject(string msg="Bad Request")
        {
            InitializeComponent();
            MsgError.Text = msg;

        }
    }
}
