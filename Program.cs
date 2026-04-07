using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace KeepAwakeApp
{
    internal static class Program
    {
        const string SingleInstanceMutexName = "SingleInstanceMutex";
        const string DuplicateLaunchEventName = "DuplicateLaunchEvent";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isFirstInstance;
            using (var mutex = new Mutex(true, SingleInstanceMutexName, out isFirstInstance))
            {
                var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                if (!isFirstInstance && isWindows)
                {
                    using (var duplicateLaunchEvent = EventWaitHandle.OpenExisting(DuplicateLaunchEventName))
                    {
                        duplicateLaunchEvent.Set();
                    }
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (var duplicateLaunchEvent = new EventWaitHandle(false, EventResetMode.AutoReset, DuplicateLaunchEventName))
                {
                    var mainForm = new MainForm();
                    var registeredWait = ThreadPool.RegisterWaitForSingleObject(
                        duplicateLaunchEvent,
                        (state, timedOut) =>
                        {
                            var form = state as MainForm;
                            form?.NotifyAlreadyRunning();
                        },
                        mainForm,
                        Timeout.Infinite,
                        false);

                    try
                    {
                        Application.Run(mainForm);
                    }
                    finally
                    {
                        registeredWait?.Unregister(null);
                    }
                }
            }
        }
    }
}
