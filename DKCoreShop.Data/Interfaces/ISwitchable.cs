using DKCoreShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
