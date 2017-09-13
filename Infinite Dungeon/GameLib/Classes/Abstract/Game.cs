using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SFML.Graphics;
using SFML.Window;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft;
namespace GameLib.Classes.Abstract
{
            public abstract class Game                                                 //Базовый класс игры
            {
                protected RenderWindow window;                                  //Окно рендерера
                protected Color clearColor;                                     //Глобальный фон

                public Game
                    (uint width, uint height, string title, Color clearColor)   //Контруктор. Задает размеры, тип и заголовок окна
                {
                    window = new RenderWindow
                        (new VideoMode(width, height), title, Styles.Close);    //Инициализация нового окна
                    this.clearColor = clearColor;                               //Установка цвета глобального фона

                    //Создаем события
                    window.Closed += OnClosed;
                }

               static public GameLib.Classes.Real.fun.Item_info Item;

                public void Run()                                               //Метод игрового цикла работы
                {
                    LoadContent();

                    Initialize();

                    while (window.IsOpen)                                       //Пока окно открыто, будет работать главный цикл
                    {
                        window.DispatchEvents();                                //Отлеживание событий
                        Tick();
                        
                        window.Clear(clearColor);                               //Закрашивание экрана цветом глобального фона
                        Render();
                        window.Display();                                       //Вывод полотна рендера в окно
                    }
                }
                
                protected abstract void LoadContent();                          //Загрузка контента в память
                protected abstract void Initialize();                           //Инициализация объектов

                protected abstract void Tick();                                 //Изменения на тике
                protected abstract void Render();                               //Отрисовка

                private void OnClosed(object sender, EventArgs e)
                {
                    window.Close();
                }
            }
        }
