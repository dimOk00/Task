using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIAutomationClientsideProviders;

namespace TreeViewMVVMBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int textBoxX;
        int textBoxY;
        AutomationElement automation;
        //int mouseX;
        //int mouseY;
        //string controlName;
        //string controlValue;
        //string controlRole;
        //MyControl myControl;

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
        //private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        //private const uint MOUSEEVENTF_LEFTUP = 0x04;
        //private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        //private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        //void sendMouseClick(Point p)
        //{
        //    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Convert.ToUInt32(p.X), Convert.ToUInt32(p.Y), 0, new UIntPtr(0));
        //}

        public MainWindow()
        {
            InitializeComponent();
            textBoxX = 0;
            textBoxY = 0;
            automation = AutomationElement.FromPoint(new Point(textBoxX, textBoxY));
        }

        private void AddControlButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(automation.Current.Name.ToString());
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        private void HighlightButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
           
        }

        private void HierarchicalDataTemplate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void xTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(xTextBox.Text, out textBoxX);
            automation = AutomationElement.FromPoint(new Point(textBoxX, textBoxY));
            SetCursorPos(textBoxX, textBoxY);
        }

        private void yTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(yTextBox.Text, out textBoxY);
            automation = AutomationElement.FromPoint(new Point(textBoxX, textBoxY));
            SetCursorPos(textBoxX, textBoxY);
        }

    }
}
