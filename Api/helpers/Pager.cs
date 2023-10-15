using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAnimals.helpers;

    public class Params
    {
        private int _pageSize =5;

        private const int MaxpageSize=50;
        private int _PageIndex=1;
        private string _search;

        public int PageSize{
            get=> _pageSize;
            set =>_pageSize=(value >MaxpageSize) ? MaxpageSize: value;
        }

        public int PageIndex{
            get => _PageIndex;
            set=> _PageIndex=(value>=0)?1:value;
        }

        public string Search{
            get => _search;
            set => _search=(!string.IsNullOrEmpty(value)? value.ToLower():"");
        }
    }
