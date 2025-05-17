using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elysynth.UI.MainForm.MainTabs
{ 
    public partial class EntitiesTab
    {
        private Panel panel;

        EntitiesTab(Panel panel)
        { this.panel = panel; }

        void Update()
        {
            panel.Controls.Clear();

        }

    }
}
