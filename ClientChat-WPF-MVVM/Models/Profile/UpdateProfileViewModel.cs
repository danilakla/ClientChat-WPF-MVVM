using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Models.Profile;
public class UpdateProfileModel
{
    public IFormFile Icon { get; set; }
    public IFormFile Bg { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Description { get; set; } = "Empty";
    public string UniversityName { get; set; }

}
