using ClientChat_WPF_MVVM.Services.LoggerService;
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
/// Логика взаимодействия для RegistrationControl.xaml
/// </summary>
public partial class RegistrationControl : UserControl
{
    public RegistrationControl()
    {
        InitializeComponent();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            Application.Current.MainWindow.DragMove();
    }

    private void Image_MouseUp(object sender, MouseButtonEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Control_MouseDown(object sender, MouseEventArgs e) {

        new Logger().EventLogger(sender.ToString() + " " + " " + e.Source.ToString());
    }



    private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
    {
        txtEmail.Focus();
    }

    private void txtEmail_MouseEnter(object sender, MouseEventArgs e)
    {
        new Logger().EventLogger(sender.ToString() + " " + " " + e.Source.ToString());

    }

    private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        new Logger().EventLogger(sender.ToString() + " " + " " + e.Source.ToString());

    }
}
