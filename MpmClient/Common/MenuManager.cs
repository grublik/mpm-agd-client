using System;
using System.Collections.Generic;
using System.Text;

namespace MpmClient.Common
{
    public class MenuManager
    {
        private MenuStrip _menuStrip;
        private Dictionary<string, EventHandler> _menuActionDictionary;

        public MenuManager(MenuStrip menu)
        {
            _menuStrip = menu;
            _menuActionDictionary = new Dictionary<string, EventHandler>();
        }

        public void AddActionEntries(Dictionary<string, EventHandler> actions)
        {
            foreach (var action in actions)
            {
                if (!_menuActionDictionary.ContainsKey(action.Key))
                    _menuActionDictionary.Add(action.Key, action.Value);
            }
        }

        public void GenerateMenuFromActions()
        {
            _menuStrip.Items.Clear();
            foreach (var actionEntry in _menuActionDictionary)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();

                menuItem.Text = actionEntry.Key; // Using the key as the label
                menuItem.Tag = actionEntry.Key;
                menuItem.Click += actionEntry.Value;

                _menuStrip.Items.Add(menuItem);
            }
        }

        //public void GenerateMenu(MenuPracownikDTO menuObj)
        //{
        //    _menuStrip.Items.Clear();

        //    //calosc menu
        //    foreach (var cat in menuObj.Kategorie)
        //    {
        //        ToolStripMenuItem mainItem = new ToolStripMenuItem();
        //        mainItem.Text = cat.Etykieta;

        //        foreach (var mod in cat.Moduly)
        //        {
        //            ToolStripMenuItem nested = new ToolStripMenuItem();
        //            nested.Text = mod.Etykieta;
        //            nested.Tag = mod.Kod;

        //            if (_menuActionDictionary.ContainsKey(mod.Kod))
        //                nested.Click += _menuActionDictionary[mod.Kod];

        //            mainItem.DropDownItems.Add(nested);

        //        }

        //        _menuStrip.Items.Add(mainItem);
        //    }

        //    //moje menu
        //    ToolStripMenuItem myItem = new ToolStripMenuItem("Moje menu");
        //    foreach (var mod in menuObj.MojeMenu)
        //    {
        //        ToolStripMenuItem nested = new ToolStripMenuItem();
        //        nested.Text = mod.Etykieta;
        //        nested.Tag = mod.Kod;

        //        if (_menuActionDictionary.ContainsKey(mod.Kod))
        //            nested.Click += _menuActionDictionary[mod.Kod];

        //        myItem.DropDownItems.Add(nested);
        //    }

        //    _menuStrip.Items.Add(myItem);

        //}

        public bool InvokeActionEntry(string code)
        {
            if (_menuActionDictionary.ContainsKey(code))
            {
                _menuActionDictionary[code]?.Invoke(null, null);
                return true;
            }
            else
                return false;
        }
    }
}
