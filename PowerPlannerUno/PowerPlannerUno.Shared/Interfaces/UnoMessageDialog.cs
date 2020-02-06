using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolsPortable;
using Windows.UI.Popups;

namespace PowerPlannerUno.Shared.Interfaces
{
    public class UnoMessageDialog
    {
        public static async Task ShowAsync(PortableMessageDialog portableDialog)
        {
            var dialog = new MessageDialog(portableDialog.Content);
            if (portableDialog.Title != null)
            {
                dialog.Title = portableDialog.Title;
            }

            await dialog.ShowAsync();
        }
    }
}
