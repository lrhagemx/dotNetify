using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetify
{
    public interface IDisposableVM : IDisposable
    {
        event EventHandler Disposed;
    }
}
