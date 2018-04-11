using System;
using System.Collections.Generic;
using System.Text;
using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.Main
{
    internal interface IPageRowFactory
    {
        IDisplayableNavigationToken CreateToken(IDisplayableNavigationToken token);
    }
}
