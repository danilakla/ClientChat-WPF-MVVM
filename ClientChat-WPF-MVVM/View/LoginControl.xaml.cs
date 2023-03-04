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

namespace ClientChat_WPF_MVVM.View;
/// <summary>
/// Логика взаимодействия для LoginControl.xaml
/// </summary>
public partial class LoginControl : UserControl
{
    public LoginControl()
    {
        InitializeComponent();
    }


    private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            Application.Current.MainWindow.DragMove();
    }

    private void Image_MouseUp(object sender, MouseButtonEventArgs e)
    {
        Application.Current.Shutdown();
    }





    private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
    {
        txtEmail.Focus();
    }
}
