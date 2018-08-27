using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewMVVMBinding
{
    public class Group : ViewModelBase
    {
        private string name;
        private ObservableCollection<MyControl> myControls;

        public Group()
        {

        }

        public Group(string name, ObservableCollection<MyControl> myControls = null)
        {
            Name = name;
            MyControls = myControls;
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<MyControl> MyControls
        {
            get { return myControls; }
            set
            {
                myControls = value;
                OnPropertyChanged("MyControls");
            }
        }
    }
}
