using BareMvvm.Core.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolsPortable;
using Windows.UI.Core;

namespace PowerPlannerUno.Shared.Interfaces
{
    public class UnoDispatcher : PortableDispatcher
    {
        public override async Task RunAsync(Action codeToExecute)
        {
            NativeUwpAppWindow window = PortableApp.Current?.GetCurrentWindow()?.NativeAppWindow as NativeUwpAppWindow;

            if (window != null)
            {
                await window.Window.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate { codeToExecute(); });
            }
            else
            {
                codeToExecute();
            }
        }
    }
}
