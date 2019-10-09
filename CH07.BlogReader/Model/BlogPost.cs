using CH07.CookbookMVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07.BlogReader
{
    class BlogPost : ObservableObject
    {
        string _title;
        string _text;
        DateTime _when;
        ObservableCollection<BlogComment> _comments = new ObservableCollection<BlogComment>();

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value, () => Text); }
        }
        public DateTime When
        {
            get { return _when; }
            set { SetProperty(ref _when, value, () => When); }
        }
        public IList<BlogComment> Comments
        {
            get { return _comments; }
        }
    }
}
