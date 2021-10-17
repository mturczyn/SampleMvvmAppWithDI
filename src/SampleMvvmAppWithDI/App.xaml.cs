using System.Windows;

namespace SampleMvvmAppWithDI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            var wnd = new MainWindow();
            wnd.Show();
        }

        /// <summary>
        /// Catches all unhandled exceptions on UI thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Unhandled error in application. Application will be closed.");
            this.Shutdown();
        }
    }
}