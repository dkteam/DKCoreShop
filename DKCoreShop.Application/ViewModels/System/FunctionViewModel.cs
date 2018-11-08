using DKCoreShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Application.ViewModels.System
{
    public class FunctionViewModel
    {
        public string Id { set; get; }

        public string Name { set; get; }

        public string URL { set; get; }

        public string ParentId { set; get; }

        public string IconCss { get; set; }

        public int SortOrder { set; get; }

        public Status Status { set; get; }
    }
}
