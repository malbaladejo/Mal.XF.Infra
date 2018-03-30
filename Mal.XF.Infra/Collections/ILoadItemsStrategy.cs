using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mal.XF.Infra.Collections
{
    public interface ILoadItemsStrategy<T>
    {
        Task<IReadOnlyCollection<T>> LoadItemsAsync(int pageNumber, int pageSize);
    }
}
