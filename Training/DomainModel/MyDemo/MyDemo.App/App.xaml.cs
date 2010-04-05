using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using MyDemo.App.Views;
using MyDemo.ViewModel;

namespace MyDemo.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var shellWindow = new Window
                                  {
                                      Content = new EmployeeView {DataContext = new EmployeeShellBuilder().BuildShell()},
                                      WindowStartupLocation = WindowStartupLocation.CenterScreen,
                                      Title = "员工",
                                      Height = 768,
                                      Width = 1024
                                  };

            shellWindow.ShowDialog();
        }
    }
}
