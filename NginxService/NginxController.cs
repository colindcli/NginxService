using System;

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
                throw new Exception("Failed to start the nginx process");
            }
        }
    }
}