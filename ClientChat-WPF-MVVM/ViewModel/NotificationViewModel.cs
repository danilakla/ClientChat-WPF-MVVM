using ClientChat_WPF_MVVM.Commands;
using ClientChat_WPF_MVVM.Commands.NotificationCommand;
using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.Services.API.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel;
public class NotificationViewModel:ViewModelBase
{
    private object _notificationBar;

    public object NotificationBar
    {
        get { return _notificationBar; }
        set { _notificationBar = value;
            OnPropertyChanged("NotificationBar");
        }
    }

    private object _selectedNotification;

    public object SelectedNotification
    {
        get { return _selectedNotification; }
        set
        {
            _selectedNotification = value;
            OnPropertyChanged("SelectedNotification");
        }
    }

    private List<Notification>  _notifications;

    public List<Notification> Notifications
    {
        get { return _notifications; }
        set { _notifications = value;
            OnPropertyChanged("Notifications");
        }
    }


    private Notification _selectedNotifications;

    public Notification SelectedNotitfication
    {
        get { return _selectedNotifications; }
        set
        {
            _selectedNotifications = value;
            OnPropertyChanged("SelectedNotitfication");
        }
    }


    public NotificationViewModel(NotificationBarViewModel notificationBarViewModel,
        SelectedNotificationViewModel  selectedNotificationViewModel,
        StartRoomViewModel startRoomViewModel,
        INotificationService notificationService,
        IFriendService friendService

        )
    {
        SelectedNotification= startRoomViewModel;
        NotificationBar= notificationBarViewModel;
        this.DeleteNotificationCommand = new DeleteNotificationCommand(notificationService, this, startRoomViewModel);
        this.GetNotifications = new GetNotificationsCommand(this, notificationService);
        ToSelectedNotification = new ToSelectedNotificationCommand(selectedNotificationViewModel,this);
        AcceptNotificationCommand=new AcceptNotificationCommand(this.DeleteNotificationCommand, friendService);
        GetNotifications.Execute(null);

    }
    
    public ICommand ToSelectedNotification { get; set; }
    public ICommand AcceptNotificationCommand { get; set; }

    public ICommand DeleteNotificationCommand{ get; set; }
    public ICommand GetNotifications { get; set; }

}
