using CH07.BlogReader;
using CH07.CookbookMVVM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CH07.BlogReader
{
    class BloggerVM : ViewModelBase<Blogger>
    {
        public ImageSource Picture
        {
            get
            {
                if (Model.Picture == null)
                    return new BitmapImage(new Uri("Images/Icon-user.png", UriKind.Relative));
                var bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = Model.Picture;
                bmp.EndInit();
                return bmp;
            }
        }
        ICommand _sendEmailCommand;
        public ICommand SendEmailCommand
        {
            get
            {
                return _sendEmailCommand ?? (_sendEmailCommand = new RelayCommand<string>(email => Process.Start("mailto:" + email)));
            }
        }
    }
}
