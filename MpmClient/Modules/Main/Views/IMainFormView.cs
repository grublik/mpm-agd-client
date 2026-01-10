using System;
using System.Collections.Generic;
using System.Text;

namespace MpmClient.Modules.Main.Views
{
    internal interface IMainFormView
    {
        event EventHandler Load;
        event FormClosedEventHandler FormClosed;

        void ShowLoginView();
    }
}
