using System;
using Prism.Mvvm;
using BookViewer.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace BookViewer.ViewModels
{
    public class TextPageViewModel : BindableBase
    {
        public ReadOnlyReactiveProperty<IPage> CurrentPage { get; }
        public ReactiveCommand GoNextCommand { get; }
        public ReactiveCommand GoBackCommand { get; }
        public TextPageViewModel(IBook book)
        {
            var book1 = book;
            CurrentPage = book1.ObserveProperty(b => b.CurrentPage).ToReadOnlyReactiveProperty();
            GoNextCommand = book1.ObserveProperty(b => b.HasNext).ToReactiveCommand();
            GoNextCommand.Subscribe(_ => book1.GoNext());
            GoBackCommand = book1.ObserveProperty(b => b.HasPrevious).ToReactiveCommand();
            GoBackCommand.Subscribe(_ => book1.GoBack());
        }
    }
}
