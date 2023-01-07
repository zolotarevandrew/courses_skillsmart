using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace OOAP2.lesson2
{

    public enum LogLevel
    {
        Info = 1,
        Warning = 2,
        Error = 3,
    }
    
    public abstract class Logger
    {
        public abstract Task LogAsync(string message, LogLevel level);
    }

    //специализация класса-родителя (наследник задаёт более специализированный случай родителя)
    public class FileLogger : Logger
    {
        protected readonly string _filePath;
        protected readonly string _fileName;

        public FileLogger(string filePath, string fileName)
        {
            _filePath = filePath;
            _fileName = fileName;
        }

        public override async Task LogAsync(string message, LogLevel level)
        {
            var path = GetFilePath();
            await File.WriteAllTextAsync(path, level.ToString().ToUpperInvariant() + " - " + message);
        }

        protected virtual string GetFilePath()
        {
            return _filePath + _fileName;
        }
    }

    public enum RollingFilePeriod
    {
        Minute = 1,
        Hour = 2,
        Day = 3
    }
    
    //расширение класса-родителя (наследник задаёт более общий случай родителя);
    //логируем текст но уже в новый файл с определенным периодом
    public class RollingFileLogger : FileLogger
    {
        private readonly RollingFilePeriod _period;
        private DateTime _lastLog;
        private string _lastFilePath;

        public RollingFileLogger(string filePath, string fileName, RollingFilePeriod period) : base(filePath, fileName)
        {
            _period = period;
            LogChanged();
        }

        public override Task LogAsync(string message, LogLevel level)
        {
            LogChanged();
            return base.LogAsync(message, level);
        }

        protected override string GetFilePath()
        {
            return _lastFilePath;
        }
        
        string GetRolledFileName()
        {
            var now = DateTime.UtcNow;
            var nowStr = now.ToString(CultureInfo.InvariantCulture);
            var newFileName = nowStr + _fileName;
            return _filePath + newFileName;
        }

        bool ShouldRollFile()
        {
            if (string.IsNullOrEmpty(_lastFilePath)) return true;
            
            var now = DateTime.UtcNow;
            var minutesDiff = (int)(now - _lastLog).TotalMinutes;
            
            if (minutesDiff >= 1 && _period == RollingFilePeriod.Minute)
            {
                _lastFilePath = GetRolledFileName();
            }
            if (minutesDiff >= 60 && _period == RollingFilePeriod.Hour)
            {
                _lastFilePath = GetRolledFileName();
            }
            if (minutesDiff >= 60 * 24 && _period == RollingFilePeriod.Day)
            {
                _lastFilePath = GetRolledFileName();
            }

            return false;
        }
        
        void LogChanged()
        {
            if (ShouldRollFile())
            {
                _lastFilePath = GetRolledFileName();
            }
            _lastLog = DateTime.UtcNow;
        }
    }
}