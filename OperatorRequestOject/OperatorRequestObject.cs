using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorRequestOject
{
    [Serializable]
    public class OperatorRequestObject
    {
        string shortCode;

        public string ShortCode
        {
            get
            {
                return shortCode;
            }

            set
            {
                shortCode = value;
            }
        }
    }
}
