using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepo
        //hold all of our CRUD
    {           //Key for dictionary=badgeID and value will be list of door names
        public Dictionary<int, ADoor> _badgeContents = new Dictionary<int, ADoor>();

        //Create
        public void AddContent(BadgeContent content)
        {
            _badgeContents.Add(content);
        }

        //Read
        public Dictionary<int, ADoor> GetContentList()

        //Update

        //Delete

    }
}
