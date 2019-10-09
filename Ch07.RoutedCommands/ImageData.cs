using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ch07.RoutedCommands
{
    class ImageData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public string ImagePath { get; private set; }
        //public ImageData(string path)
        //{
        //    ImagePath = path;
        //}
        double _zoom = 1.0;
        string _imagePath;
        ICommand _openImageFileCommand, _zoomCommand;
        public ImageData()
        {
            _openImageFileCommand = new OpenImageFileCommand(this);
            _zoomCommand = new ZoomCommand(this);
        }
        public ICommand OpenImageFileCommand
        {
            get { return _openImageFileCommand; }
        }
        public ICommand ZoomCommand
        {
            get { return _zoomCommand; }
        }

        public double Zoom
        {
            get { return _zoom; }
            set
            { _zoom = value;
                OnPropertyChanged("Zoom");
            }
        }
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            var pc = PropertyChanged;
            if (pc != null)
                pc(this, new PropertyChangedEventArgs(name));
        }
    }
}
