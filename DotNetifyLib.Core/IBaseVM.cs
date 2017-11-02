using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetify
{
    public interface IBaseVM : INotifyPropertyChanged
    {
        List<string> IgnoredProperties { get; }
        ConcurrentDictionary<string, object> ChangedProperties { get; }

        void OnUnresolvedUpdate(string vmPath, string value);
    }
}
