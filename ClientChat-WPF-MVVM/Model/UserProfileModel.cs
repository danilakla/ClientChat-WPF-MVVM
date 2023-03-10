using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClientChat_WPF_MVVM.Model;
public class UserProfileModel:INotifyPropertyChanged

{
    public int Id { get; set; }
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    private string _name=string.Empty;

    public string Token { get; set; }= string.Empty;

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }


    private string _primag=string.Empty;

    public string profileImage
    {
        get { return _primag; }
        set
        {
            _primag = value;
            OnPropertyChanged(nameof(profileImage));
        }
    }



    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}






