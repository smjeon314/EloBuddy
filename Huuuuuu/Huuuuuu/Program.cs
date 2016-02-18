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

namespace Huuuuuu
{
    class Program
    {
        private static void DoWork()

        {

            while (true)
            {
                if (HMenu["hu"].Cast<KeyBind>().CurrentValue)
                {
                    if (HMenu["mode"].Cast<Slider>().CurrentValue == 1)
                    {
                        Player.DoEmote(Emote.Joke);
                        Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                    }
                    else if (HMenu["mode"].Cast<Slider>().CurrentValue == 2)
                    {
                        Player.DoEmote(Emote.Taunt);
                        Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                    }
                    else if (HMenu["mode"].Cast<Slider>().CurrentValue == 3)
                    {
                        Player.DoEmote(Emote.Dance);
                        Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                    }
                    else if (HMenu["mode"].Cast<Slider>().CurrentValue == 4)
                    {
                        Player.DoEmote(Emote.Laugh);
                        Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                    }
                }
                Thread.Sleep(HMenu["delay"].Cast<Slider>().CurrentValue);
            }
        }


        public static Menu HMenu;


        public static void Load()
        {
            Mainmenu();

        }
        public static void Mainmenu()
        {
            HMenu = MainMenu.AddMenu("Huuuuuuu", "main");
            HMenu.AddGroupLabel("Welcome to my firsy addon Huuuuuu");
            HMenu.Add("hu", new KeyBind("huuuuuu active", false, KeyBind.BindTypes.HoldActive, 'U'));
            HMenu.Add("mode", new Slider("huuuuuu mode, 1:joke, 2:taunt, 3:dance, 4:laugh", 3, 1, 4));
            HMenu.Add("delay", new Slider("Delay", 10, 1, 1000));
        }
        static void Main(string[] args) { Loading.OnLoadingComplete += OnLoadingComplete; }

        static void OnLoadingComplete(EventArgs args)
        {
            Chat.Print("Huuuuuu by smjeon314");
            Load();
            Thread thread = new Thread(new ThreadStart(DoWork));
            thread.Start();
        }
    }
}
