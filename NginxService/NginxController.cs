using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

#if DEBUG
using System.Diagnostics;
#endif

namespace NginxService
{
    public class NginxController
    {
        private NginxMasterProcess _nginxProcess;

        public void Start()
        {
#if DEBUG
            Debugger.Launch();
#endif

            Stop();
            StartMasterProcess();
            AssertNginxWasStarted();
            HeartBeatCheck();
        }

        public void Stop()
        {
            if (_nginxProcess != null)
            {
                _nginxProcess.StopMasterProcess();
            }
        }

        private void StartMasterProcess()
        {
            if (_nginxProcess == null)
            {
                _nginxProcess = new NginxMasterProcess();
                _nginxProcess.StartMasterProcess();
            }
        }

        private void AssertNginxWasStarted()
        {
            Execute.UntilTrueOrTimeout(_nginxProcess.IsRunning, 10, TimeSpan.FromMilliseconds(250));
            if (!_nginxProcess.IsRunning())
            {
                throw new FileNotFoundException("Failed to start the nginx process.");
            }
        }

        private void HeartBeatCheck(int wait = 0)
        {
            if (wait > 0)
            {
                System.Threading.Thread.Sleep(wait);
            }

            if (_nginxProcess.IsRunning())
            {
                // queue another heartbeat check
                System.Threading.Tasks.Task.Run(() => HeartBeatCheck(1000));
                return;
            }

            // kill it
            var service = Process.GetProcessesByName("nginxservice").FirstOrDefault();
            if (service != null)
            {
                try
                {
                    service.Kill();
                    service.WaitForExit();
                }
                finally
                {
                    service.Dispose();
                }
            }
        }
    }
}