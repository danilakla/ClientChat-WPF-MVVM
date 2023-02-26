using ClientChat_WPF_MVVM.Commands;
using ClientChat_WPF_MVVM.Commands.ChatCommand;
using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.ChatModels;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using ClientChat_WPF_MVVM.View;
using ClientChat_WPF_MVVM.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

public class ChatViewModel : ViewModelBase
{
    public int Count { get; set; } = 2;

    public List<UserProfileModel> Users { get; set; } = new List<UserProfileModel>() { new UserProfileModel {  Id=3,
                    profileImage="https://i.imgur.com/ABwifID.gif",
                    Email="1email",
                    Name="kulibn name"}, new UserProfileModel {
                     Id=4,
                    profileImage="https://i.imgur.com/ABwifID.gif",
                    Email="2email",
                    Name="renat name"}, };


    private bool _changeUser;

    public bool ChangeUser
    {
        get { return _changeUser; }
        set
        {
            _changeUser = value;
            OnPropertyChanged(nameof(ChangeUser));
        }
    }

    private bool _isView;

    public bool IsView
    {
        get { return _isView; }
        set
        {
            _isView = value;
            OnPropertyChanged(nameof(IsView));
        }
    }



    private UserProfileModel _user;

    public UserProfileModel User
    {
        get { return _user; }
        set
        {
            _user = value;
            OnPropertyChanged(nameof(User));
        }
    }
    private string _text;

    public string Text
    {
        get { return _text; }
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }



    private string _name;

    public string NName
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged(nameof(NName));
        }
    }



    private string _findFriend;

    public string FindFriend
    {
        get { return _findFriend; }
        set
        {
            _findFriend = value;
            setNewFriendList(_findFriend);
            OnPropertyChanged(nameof(FindFriend));
        }
    }
    private void setNewFriendList(string fr)
    {

        if (fr == "")
        {
            FindConversations.Clear();
            foreach (var item in Conversations)
            {
                FindConversations.Add(item);
            }
        }
        else
        {
            var newList = Conversations.Where(e => e.FriendProfile.Name.Contains(fr)).ToList();
            FindConversations.Clear();
            foreach (var item in newList)
            {
                FindConversations.Add(item);
            }
        }



    }




    private string _img;

    public string NImga
    {
        get { return _img; }
        set
        {
            _img = value;
            OnPropertyChanged(nameof(NImga));
        }
    }

    private string _message;

    public string Message
    {
        get { return _message; }
        set
        {
            _message = value;
            OnPropertyChanged(nameof(Message));
        }
    }




    private string _test;

    public string Test
    {
        get { return _test; }
        set
        {
            _test = value;
            OnPropertyChanged(nameof(Test));
        }
    }


    private ConversationModel _selectedConversation;

    public ConversationModel SelectedConversation
    {
        get { return _selectedConversation; }
        set
        {
            IsView = true;
            ChangeUser = false;
            _selectedConversation = value;
            OnPropertyChanged(nameof(SelectedConversation));
        }
    }



    private ObservableCollection<MessageModel> _messagesForSelectedConversation;

    public ObservableCollection<MessageModel> MessagesForSelectedConversation
    {
        get { return _messagesForSelectedConversation; }
        set { _messagesForSelectedConversation = value; }
    }

    private ObservableCollection<ConversationModel> _conversations;

    public ObservableCollection<ConversationModel> Conversations
    {
        get { return _conversations; }
        set { _conversations = value; }
    }


    private ObservableCollection<ConversationModel> _Findconversations = new ObservableCollection<ConversationModel>();

    public ObservableCollection<ConversationModel> FindConversations
    {
        get { return _Findconversations; }
        set { _Findconversations = value; }
    }
    public ICommand SendCommand { get; }

    public ICommand DeleteUserCommand { get; }


    public ICommand LoadDataCommand { get; }
    public ICommand OpenModalDialogCommand { get; }
    public ICommand AddFriendCommand { get; }
    public ICommand UpDataUserDataCommand { get; }



    public ICommand ChangeUserCommand { get; }

    public ChatViewModel(UserStoreServices userStoreServices,
        NavigationWindowService<ChatView> navigationWindowService)
    {

        MessagesForSelectedConversation = new();
        Test = "test cje";
        ChangeUserCommand = new ChangeUserCommand(this);
        SendCommand = new SendMessageCommand(this);
        UpDataUserDataCommand = new UpDataUserDataCommand(this);
        DeleteUserCommand = new DeleteUserCommand(this);
        OpenModalDialogCommand = new OpenModalDialogCommand(navigationWindowService);
        AddFriendCommand = new AddFriendCommand(this);
        LoadDataCommand = new LoadedCommand(this, userStoreServices);
        LoadDataCommand.Execute(null);
        FindFriend = "";

    }
}