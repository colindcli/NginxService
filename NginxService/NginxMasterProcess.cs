using System.Diagnostics;
using System.IO;

namespace NginxService
{
    public class NginxMasterProcess
    {
        private readonly NginxExeLocator _nginxExeLocator = new NginxExeLocator();
        private Process _nginxProcess;

        public void StartMasterProcess()
        {
            if (_nginxProcess == null)
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = _nginxExeLocator.GetNginxExePath(),
                    WorkingDirectory = _nginxExeLocator.GetCurrentExecutingDirectory(),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false
                };

                _nginxProcess = new Process
                {
                    StartInfo = startInfo
                };
                
                _nginxProcess.Start();
            }
        }

        public void StopMasterProcess()
        {
            var signalProcess = new NginxSignalProcess();
            signalProcess.SendShutdownCommand();

            if (_nginxProcess != null)
            {
                _nginxProcess.Close();
                _nginxProcess = null;
            }
        }

        public bool IsRunning()
        {
            return File.Exists(_nginxExeLocator.GetNginxPidPath());
        }

        public string GetNginxPidPath()
        {
            return _nginxExeLocator.GetNginxPidPath();
        }
    }
}