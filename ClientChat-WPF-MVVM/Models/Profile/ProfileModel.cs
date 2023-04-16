using ClientChat_WPF_MVVM.DTO.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Models.Profile;
public class ProfileModel
{
    public UserDataModel  UserDataModel { get; set; }

    public UpdateProfileModel  UpdateProfileModel{ get; set; }

    public List<GetSkillDto>  SkillModels { get; set; }
    public List<GetProjectDto>  ProjectModels { get; set; }
    public SkillModel AddNewSkill { get; set; }
    public ProjectModel AddNewProject { get; set; }

}
