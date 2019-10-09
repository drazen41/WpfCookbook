using CH07.CookbookMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CH07.BlogReader
{
    class BlogVM : ViewModelBase<Blog>
    {
        public BloggerVM Blogger
        {
            get { return new BloggerVM { Model = Model.Blogger }; }
        }
        ICommand _newPostCommand;
        public ICommand NewPostCommand
        {
            get
            {
                return _newPostCommand ?? (_newPostCommand =
                new RelayCommand(() =>
                {
                    var post = new BlogPostVM
                    {
                        Model = new BlogPost()
                    };
                    var dlg = new NewPostWindow
                    {
                        DataContext = post
                    };
                    if (dlg.ShowDialog() == true)
                    {
                        post.Model.When = DateTime.Now;
                        Model.Posts.Add(post.Model);
                        OnPropertyChanged("Posts");
                    }
                }));
            }
        }
        public IEnumerable<BlogPostVM> Posts
        {
            get
            {
                return Model.Posts.Select(post =>
                new BlogPostVM { Model = post });
            }
        }
    }
}
