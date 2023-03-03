using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Strore;
public class UndoRedoStoreStringSearch
{

    Stack<string> searchString=new Stack<string>();

    Stack<string> Temp = new Stack<string>();


    public string SearchString
    {
        get
        {
            if(searchString.Count == 0)
            {
                return "";
            }
            else
            {
                string searchStr = searchString.Pop();

                return searchStr;
            }
        

        }
        set {
            if (value == "" || value == null)
            {

            }
            searchString.Push(value);
        }
    }

}
