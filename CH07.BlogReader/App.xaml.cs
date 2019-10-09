using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CH07.BlogReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // create some dummy blogs
            var blogs = new ObservableCollection<Blog>
            {
                new Blog
                {
                    Blogger = new Blogger
                    {
                        Name = "Bart Simpson",
                        Email = "bart@springfield.com",
                        Picture = GetResourceStream(new Uri("/Images/Icon-user.png",UriKind.Relative)).Stream
                    },
                    BlogTitle = "Bart's adventures",
                    Posts =
                    {
                        new BlogPost
                        {
                            When = new DateTime(2000,8,12),
                            Title = "Post 1",
                            Text = "This is the first post of Bart",
                            Comments =
                            {
                                new BlogComment
                                {
                                    Name = "Homer S.",
                                    Text = "Why you little ...",
                                    When = new DateTime(2000,8,13)
                                }
                            }
                        },
                        new BlogPost
                        {
                            When = new DateTime(2002,8,12),
                            Title = "Post 2",
                            Text = "This is the second post of Bart",
                            Comments =
                            {
                                new BlogComment
                                {
                                    Name = "Lisa S.",
                                    Text = "Come on Bart!",
                                    When = new DateTime(2002,8,13)
                                },
                                new BlogComment
                                {
                                    Name = "Maggie S.",
                                    Text = "Whhhhhaaaaa!",
                                    When = DateTime.Now
                                }
                            }
                        }
                    }
                }
            };
            var vm = new MainVM(blogs);
            var win = new MainWindow
            {
                DataContext = vm
            };
            win.Show();
        }
    }
}