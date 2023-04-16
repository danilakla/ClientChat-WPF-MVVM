using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Models.Profile;
public class ProjectModel
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string NameUsingTech { get; set; }
    public List<string> urltech { get; set; }

}
