using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mal.XF.Infra.Collections;
using Mal.XF.Infra.DevApp.Pages.Main;
using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.Main
{
    internal class LoadPagesStrategy : ILoadPagesStrategy
    {
        private readonly IHomePageServiceProvider service;
        private readonly IPageRowFactory pageRowFactory;

        public LoadPagesStrategy(IHomePageServiceProvider service, IPageRowFactory pageRowFactory)
        {
            this.service = service;
            this.pageRowFactory = pageRowFactory;
        }
        public Task<IReadOnlyCollection<PageRow>> LoadItemsAsync(int pageNumber, int pageSize)
        {
            return Task.Run(() => this.GetRows(pageNumber, pageSize));
        }

        private IReadOnlyCollection<PageRow> GetRows(int pageNumber, int pageSize)
        {
            var rows = new List<PageRow>();
            var numberOfTokenPerRow = 4;
            var pages = this.service.Items.Skip(numberOfTokenPerRow * pageNumber * pageSize)
                                          .Take(numberOfTokenPerRow * pageSize).ToArray();

            for (var i = 0; i < pages.Length; i = i + numberOfTokenPerRow)
                rows.Add(new PageRow(this.GetTokensInRow(pages, i, numberOfTokenPerRow)));

            return rows;
        }

        private IReadOnlyCollection<IDisplayableNavigationToken> GetTokensInRow(IReadOnlyList<IDisplayableNavigationToken> allTokens, int startIndex, int numberOfTokenPerRow)
        {
            var tokens = new List<IDisplayableNavigationToken>();

            for (int i = 0; i < numberOfTokenPerRow; i++)
            {
                if (startIndex + i >= allTokens.Count)
                    break;

                tokens.Add(this.pageRowFactory.CreateToken(allTokens[startIndex + i]));
            }

            return tokens;
        }
    }
}
