using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenuRepository
{
    public class CafeMenuRepo
    {
        public readonly List<CafeContent> _listOfCafeContent = new List<CafeContent>();

        //Create
        public bool CreateNewMenuContent(CafeContent cafeContent)
        {
            int startingCount = _listOfCafeContent.Count;
            _listOfCafeContent.Add(cafeContent);

            bool wasAdded = (_listOfCafeContent.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<CafeContent> GetCafeContents()
        {
            return _listOfCafeContent;
        }

        //Delete
        public bool DeleteCafeContent(string menu)
        {
            CafeContent cafeContent = GetContentByMenu(menu);
            if (cafeContent == null)
            {
                return false;
            }

            int initialCount = _listOfCafeContent.Count;
            _listOfCafeContent.Remove(cafeContent);

            if (initialCount > _listOfCafeContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method

        public CafeContent GetContentByMenu(string menu)
        {
            foreach (CafeContent cafeContent in _listOfCafeContent)
            {
                if (cafeContent.Menu == menu)
                {
                    return cafeContent;
                }
            }

            return null;
        }
    }
}
