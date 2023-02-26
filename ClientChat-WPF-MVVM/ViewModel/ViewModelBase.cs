using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.ViewModel;
public class ViewModelBase : INotifyPropertyChanged
{
    private int height;
    public int Height
    {
        get
        {
            return height;
        }
        set
        {
            height = value;
            OnPropertyChanged(nameof(Height));

        }
    }


    private int width;
    public int Width
    {
        get
        {
            return width;
        }
        set
        {
            width = value;
            OnPropertyChanged(nameof(Width));

        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public virtual void Dispose() { }
}
