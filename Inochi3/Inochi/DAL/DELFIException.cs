using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inochi.DAL
{
    public class DELFIException
    {
        private const string EventLogSource = "BSC Exception";
        private static bool _eventLogInitialized;
        private static EventLog _eventLog;
        static DELFIException()
        {
            InitializeEventLog();
            _eventLog = new EventLog("BSC Exception Utilities");
            _eventLog.Source = DELFIException.EventLogSource;
        }
        private DELFIException() { }
        public static void DisplayException(System.Exception ex)
        {
            DELFIException.DisplayException("An unknown error occurred.", ex);
        }
        public static void DisplayException(string message)
        {
            MessageBox.Show(message, "Exception Encountered");
        }
        public static void DisplayException(string message, System.Exception ex)
        {
            LogException(message, ex);
            MessageBox.Show(message + "\n\nBelow are the details of the exception:\n\n" + ex.ToString(), "Exception Encountered");
        }
        public static void InitializeEventLog()
        {
            if (!DELFIException._eventLogInitialized)
            {
                if (!EventLog.SourceExists(DELFIException.EventLogSource))
                {
                    EventLog.CreateEventSource(DELFIException.EventLogSource, "BSC Exception Utilities");
                }

                DELFIException._eventLogInitialized = true;
            }
        }

        public static void LogException(System.Exception ex)
        {
            LogException(null, ex);
        }

        public static void LogException(string message, System.Exception ex)
        {
            try
            {
                string entryMessage;
                if (message != null && message.Length > 0)
                {
                    entryMessage = string.Format("{0}\n\n{1}\n{2}", message, ex.Message, ex.StackTrace);
                }
                else
                {
                    entryMessage = string.Format("{0}\n{1}", ex.Message, ex.StackTrace);
                }
                DELFIException._eventLog.WriteEntry(entryMessage);
            }
            catch { }
        }
    }
}
