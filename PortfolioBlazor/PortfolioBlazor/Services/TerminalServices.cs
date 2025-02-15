namespace PortfolioBlazor.Services
{
    public class TerminalServices
    {
        public List<string> Logs { get; private set; } = new();

        public void AddLog(string message)
        {
            Logs.Add(message);
            if (Logs.Count > 100)
                Logs.RemoveAt(0); // Limit log size
        }

        public void ClearLogs()
        {
            Logs.Clear();
            AddLog("[INFO] Terminal cleared.");
        }

        public string ProcessCommand(string command)
        {
            return command.ToLower() switch
            {
                "cd projects" => "/projects",
                "ls skills" => "/skills",
                "deploy portfolio" => "/portfolio",
                "cd home" => "/",
                _ => "[ERROR] Command not found.",
            };
        }
    }
}
