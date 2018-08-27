using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TreeViewMVVMBinding
{
    public class MainWindowViewModel : ViewModelBase
    {
        static int controlINdex = 1;

        ObservableCollection<Group> groups;

        public MainWindowViewModel()
        {
            Groups = new ObservableCollection<Group>()
            {
                new Group("Group 1", new ObservableCollection<MyControl>
                {
                    new MyControl("Control 1", "Role 1", "Value 1")
                })
            };
        }

        public ObservableCollection<Group> Groups
        {
            get
            {
                return groups;
            }
            set
            {
                groups = value;
                OnPropertyChanged("Groups");
            }
        }

        private RelayCommand addGroupCommand;
        public RelayCommand AddGroupCommand
        {
            get
            {
                return addGroupCommand ??
                    (addGroupCommand = new RelayCommand(obj =>
                    {
                        int groupsCount = Groups.Count;
                        Group group = new Group($"Group {++groupsCount}");
                        Groups.Add(group);
                    }));
            }
        }

        private RelayCommand addControlCommand;
        public RelayCommand AddControlCommand
        {
            get
            {
                return addControlCommand ??
                    (addControlCommand = new RelayCommand(obj =>
                    {
                        Group selectedGroup = obj as Group;
                        if (selectedGroup != null)
                        {
                            if(selectedGroup.MyControls == null)
                            {
                                selectedGroup.MyControls = new ObservableCollection<MyControl>();
                            }
                            selectedGroup.MyControls.Add(new MyControl($"Control {++controlINdex}", $"Role  {controlINdex}", $"Value  {controlINdex}"));
                        }
                    }));
            }
        }

        private RelayCommand removeGroupControl;
        public RelayCommand RemoveGroupControl
        {
            get
            {
                return removeGroupControl ??
                    (removeGroupControl = new RelayCommand(obj =>
                    {
                        if (obj is Group)
                        {
                            groups.Remove(obj as Group);
                        }
                        else if (obj is MyControl)
                        {
                            MyControl control = obj as MyControl;
                            foreach (var group in Groups)
                            {
                                if (group.MyControls.Contains(control))
                                {
                                    group.MyControls.Remove(control);
                                    return;
                                }

                            }
                        }
                    }));
            }
        }

        private RelayCommand highlight;
        public RelayCommand Highlight
        {
            get
            {
                return highlight ??
                    (highlight = new RelayCommand(obj =>
                    {
                        

                    }));
            }
        }
    }
}
