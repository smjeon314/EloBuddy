using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using Circle = EloBuddy.SDK.Rendering.Circle;
using System.Threading;
using EloBuddy.SDK.Menu;

namespace SimpleSkin
{
    class Program
    {
        public static Menu YMenu;
        public static void Change(Object sender, EventArgs args)
        {
            if (YMenu["use"].Cast<CheckBox>().CurrentValue)
            {
                Player.SetSkinId(YMenu["id"].Cast<Slider>().CurrentValue);
            }
        }

        public static void Load()
        {
            Mainmenu();

        }
        public static void Mainmenu()
        {
            YMenu = MainMenu.AddMenu("SimpleSkin", "skinmain");
            YMenu.AddGroupLabel("Welcome to my addon SimpleSkin");
            YMenu.Add("use", new CheckBox("Use SimpleSkin"));
            YMenu.Add("id", new Slider(Player.Instance.ChampionName + "'s SkinID", 0, 0, 15)).OnValueChange += Change;
        }
        static void Main(string[] args) { Loading.OnLoadingComplete += OnLoadingComplete; }

        static void OnLoadingComplete(EventArgs args)
        {
            Chat.Print("Simple Skin by smjeon314");
            Load();
        }
    }
}
