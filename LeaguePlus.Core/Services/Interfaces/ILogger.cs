using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlus.Core
{
    public interface ILogger
    {
        void LogError(string content);

        void LogWarning(string content);

        void LogInformation(string content);

        void LogSuccessful(string content);

        void LogDevInfo(string content);
    }
}
