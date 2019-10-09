using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ch07.RoutedCommands
{
    class OpenImageFileCommand : ICommand
    {
        ImageData _data;
        public OpenImageFileCommand(ImageData data)
        {
            _data = data;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Image Files | *.jpg;*.png;*.bmp;*.gif"
            };
            if (dlg.ShowDialog() == true)
            {
                _data.ImagePath = dlg.FileName;
                
            }
        }
    }
}
