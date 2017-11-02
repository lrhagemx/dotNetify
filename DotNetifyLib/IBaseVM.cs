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
        
        ConcurrentDictionary<string, object> ChangedProperties { get; }

        
    }

    public interface IIgnoreProperties
    {
        List<string> IgnoredProperties { get; }
    }
}
