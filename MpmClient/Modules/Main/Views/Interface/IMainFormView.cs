using MpmClient.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MpmClient.Modules.Main.Views.Interface
{
    internal interface IMainFormView
    {
        event EventHandler Load;
        event FormClosedEventHandler FormClosed;

        bool ShowLoginView();
        void ShowDockingContent(DocumentDockContent dockContent);

        MenuStrip MenuStrip { get; }
    }
}
