﻿using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace BookViewer.Model
{
    public class Book : BindableBase, IBook
    {
        private IChapter _currentChapter;
        private IPage _currentPage;

        public IChapter CurrentChapter
        {
            get { return _currentChapter; }
            set
            {
                if (SetProperty(ref _currentChapter, value))
                {
                    // Chapterを移動した場合、そのChapterの先頭ページをカレントページに設定する
                    CurrentPage = _currentChapter.Pages.First();
                }
            }
        }

        public IPage CurrentPage
        {
            get { return _currentPage; }
            private set { SetProperty(ref _currentPage, value); }
        }

        public IList<IChapter> Chapters { get; }
        public Book()
        {
            Chapters = new List<IChapter>();
            for (int i = 0; i < 20; i++)
            {
                Chapters.Add(new Chapter(i + 1));
            }
        }

        public void Open()
        {
            CurrentChapter = Chapters.First();
            CurrentPage = CurrentChapter.Pages.First();
        }

        public void GoToNextPage()
        {
            if (CurrentPage == CurrentChapter.Pages.Last())
            {
                // 同一Chapter内の最後のページの場合
                if (CurrentChapter == Chapters.Last())
                {
                    // 最後のChapterであれば何もしない
                }
                else
                {
                    // 次のChapterの最初のページへ
                    CurrentChapter = Chapters[Chapters.IndexOf(CurrentChapter) + 1];
                    CurrentPage = CurrentChapter.Pages.First();
                }
            }
            else
            {
                // 同一Chapter内で１ページ進める
                CurrentPage = CurrentChapter.Pages[CurrentChapter.Pages.IndexOf(CurrentPage) + 1];
            }
        }

        public void GoToPreviousPage()
        {
            if (CurrentPage == CurrentChapter.Pages.First())
            {
                // 同一Chapter内の最初のページの場合
                if (CurrentChapter == Chapters.First())
                {
                    // 最初のChapterであれば何もしない
                }
                else
                {
                    // 前のChapterの最後のページへ
                    CurrentChapter = Chapters[Chapters.IndexOf(CurrentChapter) - 1];
                    CurrentPage = CurrentChapter.Pages.Last();
                }
            }
            else
            {
                // 同一Chapter内で１ページ進める
                CurrentPage = CurrentChapter.Pages[CurrentChapter.Pages.IndexOf(CurrentPage) - 1];
            }
        }
    }
}