namespace HomeWorkDelegate
{
    public class ReadDirectory
    {
        public event EventHandler<FileFoundEvenArgs>? FileFound; 

        private bool _cancelSearch = false;

        public void ReadDir(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Directory '{directoryPath}' does not exist.");
                return;
            }

            try
            {
                foreach (var file in Directory.EnumerateFiles(directoryPath))
                {
                    var args = new FileFoundEvenArgs(file);
                    OnFileFound(args);

                    if (_cancelSearch)
                    {
                        Console.WriteLine("Search canceled by the handler.");
                        return;
                    }
                }

                foreach (var subDir in Directory.EnumerateDirectories(directoryPath))
                {
                    ReadDir(subDir);
                    if (_cancelSearch)
                    {
                        return;
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied to '{directoryPath}': {ex.Message}");
            }
        }


        protected virtual void OnFileFound(FileFoundEvenArgs e)
        {
            FileFound?.Invoke(this, e); 
        }

        public void CancelSearch() => _cancelSearch = true;
    }
}
