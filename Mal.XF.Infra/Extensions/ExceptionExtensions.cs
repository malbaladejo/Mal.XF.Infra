using System;
using System.Collections.Generic;
using System.Text;

namespace Mal.XF.Infra.Extensions
{
    public static class ExceptionExtensions
    {
        public static string DumpAsString(this Exception source)
        {
            var strB = new StringBuilder();
            IReadOnlyCollection<Exception> innerExceptions = null;

            if (source is AggregateException)
                innerExceptions = ((AggregateException)source).InnerExceptions;

            else if (source.InnerException != null)
                innerExceptions = new List<Exception>() { source.InnerException };


            strB.Append($"{{type:'{source.GetType().FullName}', Message:'{source.Message}', stacktrace:'{source.StackTrace}'");

            if (innerExceptions != null)
                strB.Append($", InnerExceptions:[{innerExceptions.DumpAsString()}]");

            strB.Append("}");

            return strB.ToString();
        }

        private static string DumpAsString(this IReadOnlyCollection<Exception> source)
        {
            var strB = new StringBuilder();
            foreach (var exception in source)
            {
                strB.Append(exception.DumpAsString() + ",");
            }

            return strB.ToString();
        }

    }
}
