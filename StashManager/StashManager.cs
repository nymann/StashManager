using System.Threading;
using System.Windows.Forms;
using PoeHUD.Plugins;
using StashManager.Helper;

namespace StashManager
{
    public class StashManager : BasePlugin
    {
        private const int NumberOfTotalStashes = 4; // Wanted to test if certain ammount of tabs could be a problem.
        public override void Render()
        {

            var stashPanel = GameController.Game.IngameState.ServerData.StashPanel;
            if (!stashPanel.IsVisible)
            {
                return;
            }
            
            if (!IsAllStashTabsViewable((int) stashPanel.TotalStashes))
            {
                ViewAllTabs((int)GameController.Game.IngameState.CurLatency * 4, (int) stashPanel.TotalStashes);
            }

            ShowItemCountOfEachNonNullTab((int) stashPanel.TotalStashes);
            ShowNameOfEachNonNulLTab((int) stashPanel.TotalStashes);
        }

        #region tests
        private void ShowItemCountOfEachNonNullTab(int numberOfTotalStashes = NumberOfTotalStashes)
        {
            var stashPanel = GameController.Game.IngameState.ServerData.StashPanel;
            var content = "";
            for (var i = 0; i < numberOfTotalStashes; i++)
            {
                var stashTab = stashPanel.getStashInventory(i);
                if (stashTab == null)
                {
                    content += "stash tab no. " + i + ", is null.\n";
                    continue;
                }
                var itemCount = stashTab.ItemCount;
                content += "stash tab no. " + i + ", has " + itemCount + " items in it.\n";
            }

            MessageBox.Show(content);
        }

        private void ShowNameOfEachNonNulLTab(int numberOfTotalStashes = NumberOfTotalStashes)
        {
            var stashPanel = GameController.Game.IngameState.ServerData.StashPanel;

            var content = "";

            for (var i = 0; i < numberOfTotalStashes; i++)
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


        #endregion

        private bool IsAllStashTabsViewable(int numberOfTotalStashes = NumberOfTotalStashes)
        {
            var stashPanel = GameController.Game.IngameState.ServerData.StashPanel;
            var counter = 0;

            for (var i = 0; i < numberOfTotalStashes; i++)
            {
                if (stashPanel.getStashInventory(i) == null)
                {
                    continue;
                }

                counter++;
            }

            return counter == stashPanel.TotalStashes;
        }

        private static void ViewAllTabs(int delay, int numberOfTotalStashes = NumberOfTotalStashes)
        {
            for (var i = 0; i < numberOfTotalStashes; i++)
            {
                Keyboard.keybd_event(VirtualKeys.Right, 0, KeyboardEventFlags.Keydown, 0);
                Keyboard.keybd_event(VirtualKeys.Right, 0, KeyboardEventFlags.Keyup, 0);
                Thread.Sleep(delay);
            }

            for (var i = 0; i < numberOfTotalStashes; i++)
            {
                Keyboard.keybd_event(VirtualKeys.Left, 0, KeyboardEventFlags.Keydown, 0);
                Keyboard.keybd_event(VirtualKeys.Left, 0, KeyboardEventFlags.Keyup, 0);
                Thread.Sleep(delay);
            }
        }
    }
}