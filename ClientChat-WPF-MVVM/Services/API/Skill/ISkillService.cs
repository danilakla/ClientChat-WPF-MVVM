using ClientChat_WPF_MVVM.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.Skill;
public interface ISkillService
{
    Task<SkillModel> GetSkill(int id);
    Task DeleteSkill(int id);
    Task AddSkill(SkillModel skillViewModel);

    Task UpdateSkill(SkillModel skillViewModel);
}
