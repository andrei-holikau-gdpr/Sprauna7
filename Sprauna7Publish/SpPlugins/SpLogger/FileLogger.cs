#pragma warning disable CS8633

namespace Sprauna7Publish.SpPlugins.SpLogger
{
    public class FileLogger : ILogger, IDisposable
    {
        string filePath;
        static object _lock = new object();
        public FileLogger(string path)
        {
            filePath = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose() { }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId,
                    TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                if(exception != null)
                {
                    var ExceptionMessage = exception.Message;

                    if (exception.InnerException != null)
                    {
                        var InnerException = exception.InnerException;
                        var InnerExceptionMessage = InnerException.Message;

                        File.AppendAllText(filePath, formatter(state, InnerException) + Environment.NewLine);
                    }
                }                
                File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
            }
        }
    }
}