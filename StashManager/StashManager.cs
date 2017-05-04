using System.Threading;
using System.Windows.Forms;
using PoeHUD.Controllers;
using PoeHUD.Plugins;
using SharpDX;
using SharpDX.Direct3D9;
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
            /*_inventoryZone = _ingameState.ReadObject<Element>(_ingameState.IngameUi.InventoryPanel.Address + Element.OffsetBuffers + 0x42C);
            
            foreach (var child in _inventoryZone.Children)
            {
                var item = child.AsObject<NormalInventoryItem>().Item;
                if (string.IsNullOrEmpty(item?.Path))
                {
                    continue;
                }

                var position = child.GetClientRect();
                var itemName = item.Path.Split('/').Last();
                // Let's draw a frame arround each item in our inventory.
                Graphics.DrawFrame(position, 2f, Color.Azure);
                Graphics.DrawText(itemName, 20, new Vector2(position.X, position.Y), Color.DarkCyan);
            }
            */

            while (!IsAllStashTabsViewable())
            {
                ViewAllTabs((int)stashPanel.TotalStashes);
            }

            //MessageBox.Show(GameController.Game.IngameState.ServerData.StashPanel.getStashName(0));
            ShowItemCountOfEachNonNullTab();

            // Kinda works.
            /*var titleElement = stashPanel.getStashTitleElement(stashPanel.getStashName(0));
            var position = titleElement.GetClientRect();
            Graphics.DrawFrame(titleElement.GetClientRect(), 10f, Color.Aqua);
            Graphics.DrawText(titleElement.Children.Count.ToString(), 20, new Vector2(position.X, position.Y));*/

            /*for (var i = 0; i < stashPanel.TotalStashes; i++)
            {
                var titleElement = stashPanel.getStashTitleElement(stashPanel.getStashName(i));
                var position = titleElement.GetClientRect();
                Graphics.DrawText(stashPanel.getStashName(i), 20, new Vector2(position.X, position.Y));
            }*/
        }

        #region tests
        private void ShowItemCountOfEachNonNullTab()
        {
            var stashPanel = GameController.Game.IngameState.ServerData.StashPanel;

            var numberOfStashes = (int)stashPanel.TotalStashes;
            var content = "";
            for (int i = 0; i < numberOfStashes; i++)
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


        #endregion

        private bool IsAllStashTabsViewable()
        {
            var stashPanel = GameController.Game.IngameState.ServerData.StashPanel;
            var counter = 0;

            for (var i = 0; i < stashPanel.TotalStashes; i++)
            {
                if (stashPanel.getStashInventory(i) == null /*|| stashPanel.getStashName(i) == null*/)
                {
                    continue;
                }

                counter++;
            }

            return counter == stashPanel.TotalStashes;
        }

        private static void ViewAllTabs(int ammountOfTabs)
        {
            for (var i = 0; i < ammountOfTabs; i++)
            {
                Keyboard.keybd_event(VirtualKeys.Right, 0, KeyboardEventFlags.Keydown, 0);
                Keyboard.keybd_event(VirtualKeys.Right, 0, KeyboardEventFlags.Keyup, 0);
            }

            for (var i = 0; i < ammountOfTabs; i++)
            {
                Keyboard.keybd_event(VirtualKeys.Left, 0, KeyboardEventFlags.Keydown, 0);
                Keyboard.keybd_event(VirtualKeys.Left, 0, KeyboardEventFlags.Keyup, 0);
            }
        }
    }
}