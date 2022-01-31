

using System.Configuration;

namespace MarsRover
{
    public class Logger : ILogger
    {
        public void AddLog(string log)
        {
            //System.IO.StreamWriter file = new System.IO.StreamWriter(ConfigurationManager.AppSettings["LogPath"], true);
            //file.WriteLine(log);

            //file.Close();
        }
    }
}
