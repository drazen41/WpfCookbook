using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Ch05.UnhandledException
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += OnUnhandledException;
        }

        private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Trace.WriteLine(string.Format("{0}: Error: {1}", DateTime.Now,e.Exception));
            MessageBox.Show("Error encountered! Please contact support." + Environment.NewLine + e.Exception.Message);
            Shutdown(1);
            e.Handled = true;
        }
    }
}
