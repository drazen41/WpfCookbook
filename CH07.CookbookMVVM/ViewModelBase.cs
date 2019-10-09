using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07.CookbookMVVM
{
    public abstract class ViewModelBase : ObservableObject 
    { }
    public abstract class ViewModelBase<TModel> : ViewModelBase
    {
        TModel _model;
        public TModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value, () => Model); }
        }
    }
}
