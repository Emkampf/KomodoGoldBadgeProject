using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeContent
    {
        public int BadgeID { get; set; }
        public ADoor DoorName { get; set; }



        public BadgeContent() { }

        public BadgeContent(int badgeId, ADoor doorName)
        {
            BadgeID = badgeId;
            DoorName = doorName;
        }

        
    }

    public enum ADoor
    {
       
        

        
        
    }
}
