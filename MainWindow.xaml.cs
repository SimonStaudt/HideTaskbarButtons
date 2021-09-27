using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HideTaskbarButtons;
using static WinDlls;

namespace HideTaskbarButtons
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum TaskbarButtonsAndAreas
        {
            StartBtn,
            SearchBtn,
            CortanaBtn,
            TaskviewBtn,
            ContactsBtn,
            NewsBtn,
            TrayBtn,


        }

        public MainWindow()
        {
            InitializeComponent();
            //Title = Application.Current.MainWindow.GetType().Assembly.ReflectionOnly.ToString(); // Sets the Title of this Window to the Project (Assembly) Name
            //Title = Application.ProductName;
            Title = Application.ResourceAssembly.GetName().Name;
            UpdateContentTextOf_btnShowHidePrimaryTaskbar(); // Updates the button to say the opposite of the visibility of the primary taskbar (e.g. if primary taskbar visible - button text Hide Primary Taskbar)
        }


        private void btnShowHidePrimaryTaskbar_Click(object sender, RoutedEventArgs e)
        {
            IntPtr taskbarWindow = FindWindow("Shell_TrayWnd", "");

            if (IsWindowVisible(taskbarWindow))
            {
                ShowWindow(taskbarWindow, 0);
                btnShowHidePrimaryTaskbar.Content = "Show Primary Taskbar";
            }
            else
            {
                ShowWindow(taskbarWindow, 1);
                btnShowHidePrimaryTaskbar.Content = "Hide Primary Taskbar";
            }
        }

        void UpdateContentTextOf_btnShowHidePrimaryTaskbar()
        {
            IntPtr taskbarWindow = FindWindow("Shell_TrayWnd", "");

            if (!IsWindowVisible(taskbarWindow))
            {
                btnShowHidePrimaryTaskbar.Content = "Show Primary Taskbar";
            }
            else
            {
                btnShowHidePrimaryTaskbar.Content = "Hide Primary Taskbar";
            }
        }

        private void ShowPrimaryStartBtn(object sender, RoutedEventArgs e)
        {
            IntPtr primarytaskbarWindow = FindWindow("Shell_TrayWnd", "");
            IntPtr startBtn = FindWindowEx(primarytaskbarWindow, IntPtr.Zero, "Start", "Start");
            ShowWindow(startBtn, 0);
        }
        private void HidePrimaryStartBtn(object sender, RoutedEventArgs e)
        {
            IntPtr primarytaskbarWindow = FindWindow("Shell_TrayWnd", "");
            IntPtr startBtn = FindWindowEx(primarytaskbarWindow, IntPtr.Zero, "Start", "Start");
            ShowWindow(startBtn, 1);
        }


        void ShowHideTaskbarButtonsAndAreas(TaskbarButtonsAndAreas taskbarButtonsAndAreasToShowHide, int taskbar)
        {
            IntPtr taskbarWindow;
            if (taskbar == 0)
            {
                taskbarWindow = FindWindow("Shell_TrayWnd", "");
            }
            else
            {
                taskbarWindow = FindWindow("Shell_SecondTrayWnd", "");
            }

            IntPtr startBtn = FindWindowEx(taskbarWindow, IntPtr.Zero, "Start", "Start");
            IntPtr searchBtn = FindWindowEx(taskbarWindow, IntPtr.Zero, "TrayButton", "Zur Suche Text hier eingeben");
            IntPtr cortanaBtn = FindWindowEx(taskbarWindow, IntPtr.Zero, "TrayButton", "Mit Cortana sprechen");
            IntPtr taskviewBtn = FindWindowEx(taskbarWindow, IntPtr.Zero, "TrayButton", "Aktive Anwendungen");
            IntPtr contactsBtn = FindWindowEx(taskbarWindow, IntPtr.Zero, "TrayButton", "Kontakte");
            IntPtr newsBtn = FindWindowEx(taskbarWindow, IntPtr.Zero, "TrayButton", "Kontakte");

            if (contactsBtn == IntPtr.Zero)
            {
                contactsBtn = FindWindowEx(taskbarWindow, IntPtr.Zero, "TrayButton", "Contacts");
            }

            switch (taskbarButtonsAndAreasToShowHide)
            {
                case TaskbarButtonsAndAreas.StartBtn:
                    ShowHideWindowDependingOnVisibility(startBtn);
                    break;
                case TaskbarButtonsAndAreas.SearchBtn:
                    ShowHideWindowDependingOnVisibility(searchBtn);
                    break;
                case TaskbarButtonsAndAreas.CortanaBtn:
                    ShowHideWindowDependingOnVisibility(cortanaBtn);
                    break;
                case TaskbarButtonsAndAreas.TaskviewBtn:
                    ShowHideWindowDependingOnVisibility(taskviewBtn);
                    break;
                case TaskbarButtonsAndAreas.ContactsBtn:
                    ShowHideWindowDependingOnVisibility(contactsBtn);
                    break;
                case TaskbarButtonsAndAreas.NewsBtn:
                    ShowHideWindowDependingOnVisibility(newsBtn);
                    break;
                case TaskbarButtonsAndAreas.TrayBtn:
                    break;
                default:
                    break;
            }
        }

        private void ShowHideWindowDependingOnVisibility(IntPtr intPtr)
        {
            if (IsWindowVisible(intPtr)) ShowWindow(intPtr, 0); else ShowWindow(intPtr, 1);
        }

        private void SearchBtn(object sender, RoutedEventArgs e)
        {
            ShowHideTaskbarButtonsAndAreas(TaskbarButtonsAndAreas.SearchBtn, Convert.ToInt32(((CheckBox)sender).Tag));
            //Show Hides the taskbar button of the primary secondary or third ... (third ... not implemented)
            //according to the tag of the checkbox
        }


        private void CortanaBtn(object sender, RoutedEventArgs e)
        {
            ShowHideTaskbarButtonsAndAreas(TaskbarButtonsAndAreas.CortanaBtn, Convert.ToInt32(((CheckBox)sender).Tag));
            //Show Hides the taskbar button of the primary secondary or third ... (third ... not implemented)
            //according to the tag of the checkbox
        }

        private void TaskviewBtn(object sender, RoutedEventArgs e)
        {
            ShowHideTaskbarButtonsAndAreas(TaskbarButtonsAndAreas.TaskviewBtn, Convert.ToInt32(((CheckBox)sender).Tag));
        }

        private void ContactsBtn(object sender, RoutedEventArgs e)
        {
            ShowHideTaskbarButtonsAndAreas(TaskbarButtonsAndAreas.ContactsBtn, Convert.ToInt32(((CheckBox)sender).Tag));
        }

        private void NewsBtn(object sender, RoutedEventArgs e)
        {
            ShowHideTaskbarButtonsAndAreas(TaskbarButtonsAndAreas.NewsBtn, Convert.ToInt32(((CheckBox)sender).Tag));
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Author: Simon Staudt \nGithub: https://github.com/SimonStaudt/HideTaskbarButtons", Title + " - About");
        }
    }
}
