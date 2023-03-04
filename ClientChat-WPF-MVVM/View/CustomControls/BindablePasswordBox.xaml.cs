using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace ClientChat_WPF_MVVM.View.CustomControls;
/// <summary>
/// Логика взаимодействия для BindablePasswordBox.xaml
/// </summary>
public partial class BindablePasswordBox : UserControl
{
    private bool _isPasswordChanging;

    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PasswordPropertyChanged, PasswordCoerceValueCallback, false, UpdateSourceTrigger.PropertyChanged), PassworVakueCallback);

    private static object PasswordCoerceValueCallback(DependencyObject d, object baseValue)
    {

        if (baseValue is string)
        {
           string password=baseValue as string;


            return password.Trim();

        }
        return "";
    }

    private static bool PassworVakueCallback(object value)
    {

        if (value is string)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is BindablePasswordBox passwordBox)
        {
            passwordBox.UpdatePassword();
        }
    }

    public string Password
    {
        get { return (string)GetValue(PasswordProperty); }
        set { SetValue(PasswordProperty, value); }
    }

    public BindablePasswordBox()
    {
        InitializeComponent();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        _isPasswordChanging = true;
        Password = passwordBox.Password;
        _isPasswordChanging = false;
    }

    private void UpdatePassword()
    {
        if (!_isPasswordChanging)
        {
            passwordBox.Password = Password;
        }
    }
}