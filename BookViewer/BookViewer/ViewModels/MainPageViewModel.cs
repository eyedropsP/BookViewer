using System.Windows.Input;
using BookViewer.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace BookViewer.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public ICommand OpenCommand { get; }
        public MainPageViewModel(IBook book)
        {
            OpenCommand = new DelegateCommand(() => book.Open());
        }
    }
}
