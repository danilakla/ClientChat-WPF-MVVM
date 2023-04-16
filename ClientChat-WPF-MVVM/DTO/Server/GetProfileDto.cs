using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.DTO.Server;
public class GetProfileDTO
{


    public string Description { get; set; } = "Empty";
    public int UserId { get; set; }
    public byte[] Photo { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public string UniversityName { get; set; }
    public byte[] BackgroundProfile { get; set; }

    public List<GetProjectDto> Projects { get; set; }
    public List<GetSkillDto> Skills { get; set; }
}
