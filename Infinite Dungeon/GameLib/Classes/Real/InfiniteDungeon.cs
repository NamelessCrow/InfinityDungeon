using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
namespace GameLib.Classes.Real
{
    public class InfiniteDungeon : Abstract.Game
    {
        public InfiniteDungeon()
            : base(800, 600, "Infinite Dungeon", Color.Cyan)
        {
            
        }

        protected override void Initialize()
        {
            
        }

        protected override void LoadContent()
        {
             Item = fun.loadinv();
        }

        protected override void Tick()
        {
            List<List<int>> a = new List<List<int>>();
            List<int> b = new List<int>();
            List<int> c = new List<int>();
            List<int> d = new List<int>();
            List<int> e = new List<int>();
            //a.Add()
            b.Add(0);
            b.Add(1);
            b.Add(2);
 //           b.Add(3);
            b.Add(3);
            b.Add(4);
            b.Add(5);
            a.Add(b);
            //b.Clear();
            c.Add(8);
            c.Add(9);
            c.Add(2);
            c.Add(3);
  //          c.Add(4);
            c.Add(4);
            c.Add(5);
            a.Add(c);
            d.Add(0);
            d.Add(1);
            d.Add(2);
            d.Add(3);
     //       d.Add(4);
            d.Add(5);
            d.Add(6);
            a.Add(d);
            e.Add(0);
            e.Add(1);
            e.Add(2);
            e.Add(3);
            e.Add(4);
            e.Add(5);
            e.Add(5);
            e.Add(4);
            e.Add(3);
            //e.Add(2);
            a.Add(e);
            List<fun.attr> atrs = new List<fun.attr>();
            fun.attr testatr = new fun.attr(1,1,1,1,1);
            fun.attr testatr2 = new fun.attr(4, 4, 4, 4, 4);
            fun.attr testatr3 = new fun.attr(1, 1, 1, 1, 1);
            atrs.Add(testatr);
            atrs.Add(testatr2);
            atrs.Add(testatr3);
            //a[0] = new int[2] { 1, 2 };
            //a[1] = new int[2] { 3, 4 };
            Inventory_event.open_inv(a,atrs,window.Size.X, window.Size.Y);
        }

        protected override void Render()
        {
            
        }
    }
}
