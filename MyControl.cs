using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationClientsideProviders;

namespace TreeViewMVVMBinding
{
    public class MyControl : ViewModelBase
    {
        private string name;
        private string role;
        private string value;

        public MyControl()
        {

        }

        public MyControl(string name, string role, string value)
        {
            Name = name;
            Role = role;
            Value = value;
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

        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged("Role");
            }
        }

        public string Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        
    }
}
