using System;

namespace DKCoreShop.Utilities.Dtos
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { set; get; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)RowCount / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
            set
            {
                PageCount = value;
            }
        }

        public int PageSize { set; get; }
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {
            get
            {
                return (CurrentPage - 1) * PageSize + 1;
            }
        }

        public int LastRowOnPage
        {
            get
            {
                return Math.Min(CurrentPage * PageSize, RowCount);
            }
        }
    }
}