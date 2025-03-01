using Microsoft.AspNetCore.Components;

namespace PortfolioBlazor.Services
{
    public class TerminalServices
    {
        public List<MarkupString> Logs { get; private set; } = new();

        public void AddLog(string message)
        {
            Logs.Add((MarkupString)message);
        }




        public void ClearLogs()
        {
            Logs.Clear();
            AddLog("[INFO] Terminal cleared.");  // Now works because AddLog(string) exists
        }


    }
}
