using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeContent
    {
        public string BadgeId { get; set; }
        public List<string> DoorNames { get; set; } 

        public BadgeContent() { }
        public BadgeContent(string badgeId, List<string> doorNames)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;
        }
    }
}
