using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBiotechTest.Dtos
{
    public class ContactQueryDto : ContactDto
    {
        private int _maxItemsPerPage;
        public int maxItemsPerPage
        {
            get
            {
                return _maxItemsPerPage;
            }
            set
            {
                if (value == 0)
                    _maxItemsPerPage = 10;
                else
                    _maxItemsPerPage = value;
            }
        }
        public int skipPage { get; set; }
    }
}
