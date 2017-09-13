using System;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Resources;
using System.Drawing;
using GameLib.Classes.Abstract;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameLib.Classes.Real
{
    public class Inventory_event
    {
        public static int[] slotflag = new int[3] {0, 0, 0};
        private static string space_bar = "   ";

        static public fun.pos setcoords(int i, int j)
        {
            switch (i)
            {
                case (3):
                    return new fun.pos(52 + j * 72, 515);
                default:
                    switch (j)
                    {
                        case (0):
                            return new fun.pos(29 + i * 258, 65);
                        case (1):
                            return new fun.pos(190 + i * 258, 65);
                        case (2):
                            return new fun.pos(110 + i * 258, 113);
                        case (3):
                            return new fun.pos(110 + i * 258, 283);
                        case (4):
                        case (5):
                            if (slotflag[i] == 0)
                            {
                                slotflag[i] = 1;
                                return new fun.pos(20 + i * 258, 227);
                            }
                            else
                                return new fun.pos(20 + i * 257, 227 + 88);
                    }
                    break;
            }
            return null;
        }
   /*     static public fun.pos setcoords(int i, int j, int type)
        {
            switch (i)
            {
                case (3):
                    return new fun.pos(52 + j*72, 515);
                default:
                    switch (type)
                    {
                        case (1):
                            return new fun.pos(29 + i*258, 65);
                        case (2):
                            return new fun.pos(190 + i*258, 65);
                        case (3):
                            return new fun.pos(110 + i*258, 113);
                        case (4):
                            return new fun.pos(110 + i*258, 283);
                        case (5):
                            if (slotflag[i] == 0)
                            {
                                slotflag[i] = 1;
                                return new fun.pos(20 + i*258, 227);
                            }
                            else
                                return new fun.pos(20 + i*257, 227 + 88);
                    }
                    break;
            }
            return null;
        }*/

        /* static void swap(Vector2f a,Vector2f b)
       {
           Vector2f c = new Vector2f();
           c = new Vector2f(a.X,a.Y);//new Vector2f(a);
           a = new Vector2f(b.X,b.Y);
           b = new Vector2f (c.X,c.Y);
            
       }*/
        protected RenderWindow Window;

        /* static float get_mouse(bool X)
    {
        if (X)
        return  Mouse.GetPosition().X;
        return Mouse.GetPosition().Y;
    }*/

        static int shift_accure(int n, int m)
            //сдвигает n в зависимости от значения m (необходимо для определения номера n в списке предметов)
        {
            if (n < m)
            {
                return n;
            }
            else
            {
                return ++n;
            }
        }

        static bool check_permission(List<fun.attr> special, int i, int j, bool A_equiped, bool B_equiped, int n = 0,
                int m = 0)
            //метод проверяет соблюдены ли условия для свапа предметов
            //A(B)_equiped (True если мы переносим (хотим свапнуть с) надетый на персонажа предмет)
        {
            if ((A_equiped || B_equiped) &&
             InfiniteDungeon.Item.items[i].type == InfiniteDungeon.Item.items[j].type)
            {
                if (A_equiped &&
                    InfiniteDungeon.Item.items[j].plank >
                    special[n].type(InfiniteDungeon.Item.items[j].type) ||
                    B_equiped &&
                    InfiniteDungeon.Item.items[i].plank >
                    special[m].type(InfiniteDungeon.Item.items[i].type))
                {
                    return false;
                }
                return true;
            }
            else return false;
        }

        static int find_person(float X)
            //определяет персонажа у которого происходит свап
        {
            if (X < 200)
                return 0;
            if (X < 458)
                return 1;
            if (X < 716)
                return 2;
            else return 0;
        }


        public static void open_inv(List<List<int>> items, List<fun.attr> special, uint width, uint height)
        {
            RenderWindow Window;
            Window = new RenderWindow(new VideoMode(width, height), "Inf_dung_inv", Styles.Close);
            //Инициализация нового окна
            string info = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(info);
            bool remember_coords = true, swap = false;
            Texture Inv_tx = new Texture("../../../GameLib/Resources/Textures/interface_inventory.png");
            Sprite Inv_background = new Sprite(Inv_tx);
            Sprite c = new Sprite(); //спрайт для свапа предметов

            List<Sprite> items_sprite = new List<Sprite>();
            List<int> itemslist = new List<int>();
            fun.pos coords;
            Vector2f remember = new Vector2f(), Mouse_coords = new Vector2f();
            Vector2i Windowpos;
            int equip_num = 0; //переменная, запоминающая границу между надетыми предметами и рюкзаком
            int i, j = 0, n = 0, m = 0,kek; 
            for (i = 0; i < 4; i++)
            {

                try
                {
                    items[i][0].Equals(0);

                    {
                        while (true)
                        {
                            Inv_tx =
                                new Texture("../../../GameLib/Resources/Textures/Item_" +
                                            string.Format("0{0}{1}{2}", items[i][j]/100, (items[i][j]/10)%10,
                                                items[i][j]%10) + ".png");

                            Console.WriteLine("Item_0{0}{1}{2}", items[i][j]/100, (items[i][j]/10)%10, items[i][j]%10);
                            itemslist.Add(items[i][j]);
                            items_sprite.Add(new Sprite(Inv_tx));
                            if (i != 3)
                                equip_num++;
                            coords = setcoords(i, j/*, GameLib.Classes.Abstract.Game.Item.items[items[i][j]].type*/);
                            items_sprite[items_sprite.Count() - 1].Position = new Vector2f(coords.x, coords.y);
                            j++;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    j = 0;
                }
            }
            //for(i; i < items)   

            //Создаем события
            while (Window.IsOpen) //Пока окно открыто, будет работать главный цикл
            {

                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    Mouse_coords = Window.MapPixelToCoords(Mouse.GetPosition(Window));
                    Console.WriteLine(Mouse_coords.X + " " + Mouse_coords.Y);
                    Console.WriteLine(n);
                    try
                    {
                        while (remember_coords)
                        {

                            if (items_sprite[n].GetGlobalBounds().Contains(Mouse_coords.X, Mouse_coords.Y))
                            {

                                remember = new Vector2f(items_sprite[n].Position.X, items_sprite[n].Position.Y);
                                items_sprite[n].Position = new Vector2f(Mouse_coords.X, Mouse_coords.Y);
                                //items_sprite[n].Position.Y = Mouse_coords.Y;
                                remember_coords = false;
                                n--;
                            }
                            n++;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                    if (!remember_coords)
                    {
                        items_sprite[n].Position = new Vector2f(Mouse_coords.X - 22, Mouse_coords.Y - 22);
                    }
                }
                else
                {
                    if (!remember_coords)
                    {
                        remember_coords = true;
                        items_sprite[n].Position = new Vector2f(remember.X, remember.Y); //возвращаем коордиаты перетаскиваемому предмету
                        Mouse_coords = Window.MapPixelToCoords(Mouse.GetPosition(Window));
                        if (Mouse_coords.Y >= 500)
                            //если левая кнопка отпущена в районе рюкзака
                        {

                            for (j = 0; j < 10; j++)
                                //проходимся по всем координатам ячеек рюкзака, проверяем находится ли курсор в ячейке
                            {
                                coords = setcoords(3, j/*, 0*/);
                                if (Mouse_coords.X - coords.x <= 66 && Mouse_coords.Y - coords.y <= 66)
                                {
                                    try
                                    {
                                        m = equip_num;
                                        while (true)
                                        {
                                            //проверка на свапанье
                                            if (items_sprite[m].GetGlobalBounds()
                                                .Contains(Mouse_coords.X, Mouse_coords.Y))
                                            {
                                                if (n < equip_num)
                                                    //если мы перетаскивали надетый предмет - проверка на совместимость 2 предмета со слотом 1-го предмета. иначе свап
                                                {
                                                    //i = find_person(items_sprite[n].Position.X); //определяем номер персонажа у которого свапается предмет
                                                    if (check_permission(special, itemslist[n], itemslist[m], true,
                                                        false, find_person(items_sprite[n].Position.X), 0))
                                                    {
                                                        swap = true;
                                                        equip_num--;
                                                    }
                                                    else swap = false;


                                                }
                                                else
                                                    swap = true;      
                                                break;
                                            }
                                            m++;
                                        }
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        //переносим предмет в пустую ячейку рюкзака
                                        //m--;
                                        if (n < equip_num)
                                            equip_num--;
                                        itemslist.Insert(m, itemslist[n]);
                                        kek = shift_accure(n, m);
                                        itemslist.RemoveAt(kek);
                                        items_sprite.Insert(m, new Sprite(items_sprite[n].Texture));
                                        items_sprite.RemoveAt(kek);
                                        m--;
                                        items_sprite[m].Position = new Vector2f(coords.x,coords.y);
                                        //items_sprite[m].Position = new Vector2f(coords.x,coords.y);
                                        //if (n < equip_num)
                                        //    equip_num--;
                                    }

                                    break;
                                }

                            }
                        }
                        else //случай, когда курсор мы отпускаем в зоне где расположены персонажи
                            //проходимся по всем иконкам каждого персонажа (i - персонаж (0-3), j - слот (0-5))
                            for (i = 0; i < 3; i++)
                            {
                                for (j = 0; j < 6; j++)
                                {
                                    coords = setcoords(i, j/*,
                                        GameLib.Classes.Abstract.Game.Item.items[itemslist[m]].type*/);
                                    if (Mouse_coords.X - coords.x <= 66 && Mouse_coords.Y - coords.y <= 66)
                                    {
                                        try
                                        {
                                            m = 0;
                                            while (true)
                                            {
                                                if (items_sprite[m].GetGlobalBounds()
                                                    .Contains(Mouse_coords.X, Mouse_coords.Y))
                                                {
                                                    if (n < equip_num)
                                                    {
                                                        swap = true
                                                            ? check_permission(special, itemslist[n], itemslist[m],
                                                                true,
                                                                true, find_person(items_sprite[n].Position.X),
                                                                find_person(items_sprite[m].Position.X))
                                                            : false;
                                                    }
                                                    else
                                                    {
                                                        swap = true
                                                            ? check_permission(special, itemslist[n], itemslist[m],
                                                                false,
                                                                true, 0,
                                                                find_person(items_sprite[m].Position.X))
                                                            : false;

                                                    }
                                                    break;
                                                }
                                                m++;
                                            }
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        {
                                            //если мы переносим предмет в пустую ячейку персонажа находим индекс для клона, перенесённого на новое место в массиве (при выполнении условий)
                                            m = i*6 + j;
                                            if (check_permission(special, itemslist[n], j, false,
                                                true, 0, i))
                                            {
                                                if (n >= equip_num)
                                                    equip_num++;
                                                itemslist.Insert(m, itemslist[n]);
                                                kek = shift_accure(n, m);
                                                itemslist.RemoveAt(kek);
                                                items_sprite.Insert(m, new Sprite(items_sprite[n].Texture));
                                                items_sprite.RemoveAt(kek);
                                                items_sprite[m].Position = new Vector2f(coords.x, coords.y); //задаем координаты новой иконке
                                                break;
                                            }
                                        }

                                    }
                                }
                            }
                    }



                    if (swap)
                    {
                        Console.WriteLine(items_sprite[n].Position + space_bar + items_sprite[m].Position);
                        c = new Sprite();
                        c = new Sprite(items_sprite[n]);
                        i = itemslist[n];
                        itemslist[n] = itemslist[m];
                        itemslist[m] = i;
                        items_sprite[n].Texture = items_sprite[m].Texture;
                        items_sprite[m].Texture = c.Texture;
                        Console.WriteLine(items_sprite[n].Position + space_bar + items_sprite[m].Position);
                        swap = false;
                    }
                    n = 0;
                }

                Window.DispatchEvents();

                Window.Draw(Inv_background);
                try
                {
                    i = 0;
                    while (true)
                    {
                        Window.Draw(items_sprite[i]);
                        i++;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                }
                Window.Display(); //Вывод полотна рендера в окно
            }
        }
    }
}