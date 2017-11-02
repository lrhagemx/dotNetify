using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Disposables;
using DotNetify;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.Reactive.Linq;

namespace ViewModels
{
    /// <summary>
    /// This view model demonstrates the two-way data binding between this server-side view model and the browser view.
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class HelloWorldVM : ReactiveObject, IBaseVM, IDisposable
    {
        CompositeDisposable disposables;
        private ConcurrentDictionary<string, object> _changedProperties = new ConcurrentDictionary<string, object>();

        [Ignore]
        public ConcurrentDictionary<string, object> ChangedProperties => _changedProperties;

        /// <summary>
        /// Constructor.
        /// </summary>
        public HelloWorldVM()
        {
            disposables = new CompositeDisposable();

            Changed
                .Select(e => e.PropertyName)
                .Where(propertyName => propertyName != nameof(ChangedProperties))
                .Subscribe(propertyName => ChangedProperties[propertyName] = GetType().GetProperty(propertyName).GetValue(this))
                .DisposeWith(disposables);

            FirstName = "Hello";
            LastName = "World";

            this.WhenAnyValue(vm => vm.FirstName, vm => vm.LastName, (firstName, lastName) => FirstName + " " + LastName)
                .ToPropertyEx(this, vm => vm.FullName)
                .DisposeWith(disposables);
        }


        [Reactive] public string FirstName { get; set; }

        [Reactive] public string LastName { get; set; }

        public extern string FullName { [ObservableAsProperty]get; }


        public void Dispose()
            => disposables?.Dispose();
    }
}
