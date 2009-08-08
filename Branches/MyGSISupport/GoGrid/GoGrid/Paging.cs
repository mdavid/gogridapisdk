using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class Paging : IModifier
    {
        public Paging(int pageSize, int pageIndex)
        {
            pageSize.ThrowIfLessThanZero("pageSize");
            this.PageSize = pageSize;

            pageIndex.ThrowIfLessThanZero("pageIndex");
            this.PageIndex = pageIndex;
        }

        public static Paging None
        {
            get
            {
                Paging paging = new Paging(0, 0);
                return paging;
            }
        }

        public static Paging Of(int pageSize, int pageIndex)
        {
            Paging paging = new Paging(pageSize, pageIndex);
            return paging;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public void Apply(Dictionary<string, string> parameters, Connection connection)
        {
            if (this.PageIndex == 0 || this.PageSize == 0) return;

            parameters.Add("num_items", this.PageSize.ToString());
            parameters.Add("page", this.PageIndex.ToString());
        }
    }
}
