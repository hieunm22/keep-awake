using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepAwakeApp
{
    internal static class Program
    {
        private const string SingleInstanceMutexName = "Local\\KeepAwakeApp.SingleInstanceMutex";
        private const string DuplicateLaunchEventName = "Local\\KeepAwakeApp.DuplicateLaunchEvent";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isFirstInstance;
            using (var mutex = new Mutex(true, SingleInstanceMutexName, out isFirstInstance))
            {
                if (!isFirstInstance)
                {
                    SignalRunningInstance();
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

        private static void SignalRunningInstance()
        {
            try
            {
                using (var duplicateLaunchEvent = EventWaitHandle.OpenExisting(DuplicateLaunchEventName))
                {
                    duplicateLaunchEvent.Set();
                }
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                // The first instance may still be starting up.
            }
        }
    }
}
