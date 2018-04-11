using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Mal.XF.Infra.Navigation;
using Prism.Commands;
using Prism.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.Main
{
    internal class PageRow
    {
        public IReadOnlyCollection<IDisplayableNavigationToken> Items { get; }

        public PageRow(IReadOnlyCollection<IDisplayableNavigationToken> items)
        {
            this.Items = items;
        }
    }
}
