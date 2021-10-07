using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepo
    {
        public Dictionary<string, List<string>> _badgeContent = new Dictionary<string, List<string>>();
        private List<BadgeContent> badgeContents = new List<BadgeContent>();
        //Create
        public bool AddContent(BadgeContent badgeId)
        {
            int startingCount = badgeContents.Count;
            badgeContents.Add(badgeId);

            bool wasAdded = (_badgeContent.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public Dictionary<string, List<string>> GetContent()
        {
            return _badgeContent;
        }
        //Update
        public bool UpdateExistingContent(string badgeId, BadgeContent content)
        {
            BadgeContent oldContent = GetContentById(badgeId);
            if (oldContent != null)
            {
                oldContent.BadgeId = content.BadgeId;
                oldContent.DoorNames = content.DoorNames;

                return true;
            }
            else
            {
                return false;
            }

        }
        //Helper 
        public BadgeContent GetContentById(string badgeId)
        {
            BadgeContent badgeContent = new BadgeContent(badgeId, _badgeContent[badgeId]);

            /*   foreach (BadgeContent content in _badgeContent)*/

            if (badgeContent != null)
            {
                return badgeContent; 
            }
          /*  {
                return content;
            }*/

            return null;
        }
        /*        //Delete
                public void DeleteContent()
                {
                    BadgeContent content = GetContent(int, ADoor);
                        if(content == null)
                        {
                        return false;
                        }

                    int initialCount = _badgeContents.Count;
                    _badgeContents.Remove(content);

                    if (initialCount > _badgeContents.Count)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }*/
        //Build Helper method to find specific badge 
    }
}
