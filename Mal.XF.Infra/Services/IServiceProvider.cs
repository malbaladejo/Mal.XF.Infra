using System.Collections.Generic;

namespace Mal.XF.Infra.Services
{
    public interface IServiceProvider<T>
    {
        void Register(T token);

        IReadOnlyCollection<T> Items { get; }
    }

    public class ServiceProvider<T> : IServiceProvider<T>
    {
        private readonly List<T> items;

        public ServiceProvider()
        {
            this.items = new List<T>();
        }

        public void Register(T token) => this.items.Add(token);

        public IReadOnlyCollection<T> Items => this.items;
    }
}
