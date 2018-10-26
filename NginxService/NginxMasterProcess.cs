using System.Diagnostics;

namespace NginxService
{
    public class NginxMasterProcess
    {
        private readonly NginxExeLocator _nginxExeLocator = new NginxExeLocator();
        private Process _nginxProcess;

        /// <summary>
        /// Starts nginx if the process is not running
        /// </summary>
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

        /// <summary>
        /// Stops nginx if the process is running
        /// </summary>
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

        /// <summary>
        /// Checks to see if nginx is running as a process
        /// </summary>
        /// <returns></returns>
        public bool IsRunning()
        {
            var processes = Process.GetProcessesByName("nginx");
            return processes.Length > 0;
        }
    }
}