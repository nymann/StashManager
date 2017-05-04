using System.Windows.Forms;
using PoeHUD.Plugins;
using StashManager.Helper;

namespace StashManager
{
    public class StashManager : BasePlugin
    {
        public override void Render()
        {
            var stashPanel = GameController.Game.IngameState.ServerData.StashPanel;
            if (!stashPanel.IsVisible)
            {
                return;
            }

            while (!IsAllStashTabsViewable())
            {
                ViewAllTabs((int) stashPanel.TotalStashes);
            }

            ShowNameOfEachNonNulLTab();
        }

        private void ShowNameOfEachNonNulLTab()
        {
            var stashPanel = GameController.Game.IngameState.ServerData.StashPanel;

            var numberOfStashes = (int)stashPanel.TotalStashes;

            var content = "";

            for (var i = 0; i < numberOfStashes; i++)
            {
                var tabName = stashPanel.getStashName(i);
                if (tabName == null)
                {
                    content += "tab name of tab no. " + i + ", is null.\n";
                    continue;
                }

                content += "tab name of tab no. " + i + ", is '" + tabName + "'.\n";
            }

            MessageBox.Show(content);
        }

        private bool IsAllStashTabsViewable()
        {
            var stashPanel = GameController.Game.IngameState.ServerData.StashPanel;
            var counter = 0;

            for (var i = 0; i < stashPanel.TotalStashes; i++)
            {
                if (stashPanel.getStashInventory(i) == null || stashPanel.getStashName(i) == null || stashPanel.getStashName(i).Equals(""))
                {
                    continue;
                }

                counter++;
            }

            return counter == stashPanel.TotalStashes;
        }

        private static void ViewAllTabs(int ammountOfTabs)
        {
            // View all the tabs, by simulating pressing on the Right Arrow key.
            for (var i = 0; i < ammountOfTabs; i++)
            {
                Keyboard.keybd_event(VirtualKeys.Right, 0, KeyboardEventFlags.Keydown, 0);
                Keyboard.keybd_event(VirtualKeys.Right, 0, KeyboardEventFlags.Keyup, 0);
            }

            // Backtrack to the first tab, by simmulating Left Arrow key presses.
            for (var i = 0; i < ammountOfTabs; i++)
            {
                Keyboard.keybd_event(VirtualKeys.Left, 0, KeyboardEventFlags.Keydown, 0);
                Keyboard.keybd_event(VirtualKeys.Left, 0, KeyboardEventFlags.Keyup, 0);
            }
        }
    }
}