using ClientChat_WPF_MVVM.Commands;
using ClientChat_WPF_MVVM.Commands.ChatCommand;
using ClientChat_WPF_MVVM.Commands.UndoRedoCommand;
using ClientChat_WPF_MVVM.Commands.UtilCommand;
using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.ChatModels;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using ClientChat_WPF_MVVM.Services.API.ChatHub;
using ClientChat_WPF_MVVM.Services.JsonSerialization;
using ClientChat_WPF_MVVM.Services.LoggerService;
using ClientChat_WPF_MVVM.Services.TokentServices;
using ClientChat_WPF_MVVM.Strore;
using ClientChat_WPF_MVVM.View;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;

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


    private bool _isSetStyle=false;

    public bool IsSetStyle
    {
        get { return _isSetStyle; }
        set
        {
            _isSetStyle = value;
            OnPropertyChanged(nameof(IsSetStyle));
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
    public ICommand GetMessage { get; }

    public ICommand OpenModalDialogCommand { get; }
    public ICommand AddFriendCommand { get; }
    public ICommand UpDataUserDataCommand { get; }
    public ICommand CommandToBindTo { get; }


    public ICommand UndoCommand { get; }
    public ICommand RedoCommand { get; }


    public ICommand ChangeUserCommand { get; }

    public ChatViewModel(UserStoreServices userStoreServices,
        NavigationWindowService<ChatView> navigationWindowService,
        Logger logger,
        UndoRedoStoreStringSearch undoRedoStringSearch ,
        ChatView chatView, TokenServieces tokenServieces)
    {

        
        MessagesForSelectedConversation = new();    
        var dd = tokenServieces.GetToken();
        ConnectionToChat.Connection = new HubConnectionBuilder()
        .WithUrl("https://localhost:7161/chathub", option =>
        {
            option.AccessTokenProvider = () => Task.FromResult(tokenServieces.GetToken().AccToken);

        })
        .WithAutomaticReconnect()
        .Build();




        ChangeUserCommand = new ChangeUserCommand(this);
        SendCommand = new SendMessageCommand(this,chatView);
        UpDataUserDataCommand = new UpDataUserDataCommand(this);
        DeleteUserCommand = new DeleteUserCommand(this);
        OpenModalDialogCommand = new OpenModalDialogCommand(navigationWindowService);
        AddFriendCommand = new AddFriendCommand(this);
        LoadDataCommand = new LoadedCommand(this, userStoreServices);
        GetMessage=new GetMessageCommand(this,chatView);
        CommandToBindTo = new LoggerCommand(logger, chatView,this);
        UndoCommand = new UndoCommand(this, undoRedoStringSearch);
        RedoCommand = new RedoCommand(this, undoRedoStringSearch);

        GetMessage.Execute(null);

        LoadDataCommand.Execute(null);
        
        FindFriend = "";




    }



}