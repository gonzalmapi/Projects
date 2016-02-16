using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airliners.net.Models
{
    interface RepoFoto
    {
        IEnumerable<AddFoto> GetPhotos();
        AddFoto GetPhotoByPhotographer(string name);
        //void InsertPhoto(UserModel user);
        //void DeletePhoto(int userId);
        //void UpdatePhoto(UserModel user);
    }
}
