using System.Collections.Generic;
using System.Threading.Tasks;
using Mal.XF.Infra.Collections;

namespace Mal.XF.Infra.DevApp.Pages.LazyListView
{
    internal class ImageLoadItemsStrategy: ILoadItemsStrategy<string>
    {
        public Task<IReadOnlyCollection<string>> LoadItemsAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
}