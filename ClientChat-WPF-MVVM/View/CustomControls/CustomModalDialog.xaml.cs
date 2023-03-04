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
        public static readonly DependencyProperty nameOfFriend =
    DependencyProperty.Register("AddFriend", typeof(string), typeof(BindablePasswordBox),
           new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, MockBlocked, NameFriendsValueCallback, false, UpdateSourceTrigger.PropertyChanged), NameFriendsCallback);
        private bool _isChanging;

        private static object NameFriendsValueCallback(DependencyObject d, object baseValue)
        {
            if (baseValue is string)
            {
                string password = baseValue as string;


                return password.Trim();

            }
            return "";
        }

        private static void MockBlocked(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomModalDialog dialog)
            {
                dialog.UpdateText();
            }
        }
        public string Text
        {
            get { return (string)GetValue(nameOfFriend); }
            set { SetValue(nameOfFriend, value); }
        }
        private static bool NameFriendsCallback(object value)
        {


            if (value is string)
            {
                value = (value as string).Trim();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void UpdateText()
        {

            Content.Text = Text;
            
        }

     
        public CustomModalDialog()
        {
            InitializeComponent();
        }
        private void Rectangle_MouseDown(object sender, MouseEventArgs e)
        {
            this.Visibility= Visibility.Collapsed;
        }

 
     

        private void Content_TextChanged(object sender, TextChangedEventArgs e)
        {
   _isChanging = true;
            Text = Content.Text;
            _isChanging = false;
        }
    }
}
