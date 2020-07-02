using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch19_Filters.Infrastructure
{
    public interface IFilterDiagnostics
    {
        IEnumerable<string> Message { get; }
        void AddMessage(string message);
    }

    public class DefaultFilterDiagnostics : IFilterDiagnostics
    {
        private List<string> messages = new List<string>();

        public IEnumerable<string> Message => messages;

        public void AddMessage(string message)
        {
            messages.Add(message);
        }
    }
}
