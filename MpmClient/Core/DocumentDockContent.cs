using System;
using System.Collections.Generic;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using MpmClient.Core.Interface;

namespace MpmClient.Core
{
    public class DocumentDockContent : DockContent, INotifiable
    {
        private bool _disposed = false;
        public DocumentDockContent()
        {
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            DockAreas = DockAreas.Document | DockAreas.Float;
        }

        public Action<bool>? ShowAppProgressBar;
        /// <summary>
        /// Method for loading main grid data
        /// </summary>
        protected virtual void LoadStartUpData()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _disposed = true;
            base.Dispose(disposing);
        }

        bool INotifiable.IsDisposed()
        {
            return _disposed;
        }
    }
}
