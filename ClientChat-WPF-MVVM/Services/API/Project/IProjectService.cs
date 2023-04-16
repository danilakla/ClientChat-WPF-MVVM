using ClientChat_WPF_MVVM.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.Project;
internal interface IProjectService
{
    Task<ProjectModel> GetProject(int id);
    Task DeleteProject(int id);
    Task AddProject(ProjectModel projectViewModel);

    Task UpdateProject(ProjectModel projectViewModel);
}
