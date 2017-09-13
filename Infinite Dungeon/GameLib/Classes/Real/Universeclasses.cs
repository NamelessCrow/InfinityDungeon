using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft;
using SFML.System;

namespace GameLib.Classes.Real
{
    //public class 
    public class fun
    {
        //Класс, в который дессириализуется Json файл. Состоит из массива из элементов, содержащих информацию о каждом предмете в игре
        public class Item_info
        {
            public Users[] items { get; set; }
            //поиск индекса предмета по имени
            public int find_item(string target)
            {
                int i = 0;
                try
                {
                    while (true)
                    {
                        if (items[i].Name == target)
                            return i;
                        i++;
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    return -1;
                }
            }
        }
        //класс содержащий параметры предмета
        public class Users
        {
            public string Name { get; set; }
            public int type { get; set; }
            public int plank { get; set; }
            public int edu_bonus { get; set; }
            public int str_bonus { get; set; }
            public int stm_bonus { get; set; }
            public int agi_bonus { get; set; }
            public int knw_bonus { get; set; }
        }
        //загрузка инвентаря из Json файла
        public static Item_info loadinv()
        {
            Item_info test1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Item_info>(File.ReadAllText("../../../GameLib/Resources/Item.Json"));
            return test1;
        }
        
        public class attr
        {
            int edu, str, stm, agi, knw;
            public attr(int edu3, int str1, int stm2, int agi4, int knw5)
            {
                edu = edu3;
                str = str1;
                stm = stm2;
                agi = agi4;
                knw = knw5;
            }
            attr()
            { }
            
            void delatr()
            {
                edu = -1;
                str = -1;
                stm = -1;
                agi = -1;
                knw = -1;
            }
            public int type(int i)
            {
                switch(i)
                {
                    case 1:
                        return str;
                    case 2:
                        return stm;
                    case 3:
                        return edu;
                    case 4:
                        return agi;
                    default:
                        return knw;
                }
                
            }
        };


        public class pos //класс содержащий координаты x и y
        {
            public float x, y;
            public pos(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            ~pos()
            {
            }
        };
    }
    
}