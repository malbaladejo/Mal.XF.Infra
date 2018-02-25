using System;
using System.Runtime.CompilerServices;

namespace Mal.XF.Infra.Log
{
    public interface ILogger
    {
        void Debug(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null);
        void Info(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null);
        void Warning(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null);
        void Error(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null);
        void Error(string message, Exception e, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null);
    }
}
