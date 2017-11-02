using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetify
{
    public interface IMasterViewVM
    {
        IBaseVM GetSubVM(string vmTypeName, string vmInstanceId);
        void OnSubVMDisposing(IBaseVM subVM);
        void OnSubVMCreated(IBaseVM subVM);
        void OnUnresolvedUpdate(string vmPath, string value);
    }
}
