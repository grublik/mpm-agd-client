using System;
using System.Collections.Generic;
using System.Text;

namespace MpmClient.Core.Interface
{
    internal interface IAppModule
    {
        Dictionary<string, EventHandler> GetModuleMenuActions();
        event Action<DocumentDockContent> DockContent;
    }
}
