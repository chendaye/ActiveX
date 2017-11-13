using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyActiveX
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface Param
    {
        string Param { get; set; }
        string Zmber { get; set; }
    }
}
