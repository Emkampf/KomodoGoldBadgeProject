using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Department_Repository
{
    public class ClaimsRepo
    {   
        public Queue<ClaimsContent> _getClaimsContents = new Queue<ClaimsContent>();

        //Add
        public bool AddClaimContent(ClaimsContent claimsContent)
        {
            int startCount = _getClaimsContents.Count;
            _getClaimsContents.Enqueue(claimsContent);

            bool wasAdded = (_getClaimsContents.Count> startCount) ? true : false;
            return wasAdded;
        }

        //READ
        public Queue<ClaimsContent> GetClaimsContents()
        {
            return _getClaimsContents;
        }
   

    }
}

