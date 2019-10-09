using CH07.CookbookMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CH07.BlogReader
{
    class BlogPostVM : ViewModelBase<BlogPost>
    {
        public string Title
        {
            get { return Model.Title; }
            set
            {
                Model.Title = value;
                OnPropertyChanged("IsPostOK");
            }
        }
        public string Text
        {
            get { return Model.Text; }
            set
            {
                Model.Text = value;
                OnPropertyChanged("IsPostOK");
            }
        }
        public bool IsPostOK
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Model.Title) &&
                !string.IsNullOrWhiteSpace(Model.Text);
            }
        }
        ICommand _newCommentCommand;
        public ICommand NewCommentCommand
        {
            get
            {
                return _newCommentCommand ?? (_newCommentCommand =
                new RelayCommand(() =>
                {
                    var comment = new BlogComment();
                    var dlg = new NewCommentWindow
                    {
                        DataContext = new BlogCommentVM { Model = comment }
                    };
                    if (dlg.ShowDialog() == true)
                    {
                        comment.When = DateTime.Now;
                        Model.Comments.Add(comment);
                    }
                }));
            }
        }
    }
}
