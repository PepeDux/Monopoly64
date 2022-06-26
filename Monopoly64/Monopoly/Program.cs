using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            #region настройки окна и полей
            int player;

            int turn = 0;

            int polex = 23;
            int poley = 23;

            int insidex = 21;
            int insidey = 21;

            Console.SetWindowSize(100, 43);//Размер окна

            Console.CursorVisible = false;

            #endregion

            #region переменные недвижимости

            string up1 = null; //здания сверху
            string up2 = null;
            string up3 = null;

            string right1 = null; //здания справа
            string right2 = null;
            string right3 = null;

            string down1 = null; //здания снизу
            string down2 = null;
            string down3 = null;

            string left1 = null; //здания слева
            string left2 = null;
            string left3 = null;

            #endregion

            #region параметры фишек

            dibs red = new dibs();
            red.x = 1;
            red.y = 1;
            red.round = 1;
            red.money = 3000;
            red.tax = 0;
            red.zp = 0;
            red.color = ConsoleColor.Red;
            red.die = false;
            red.spravka = false;

            dibs blue = new dibs();
            blue.x = 1;
            blue.y = 1;
            blue.round = 1;
            blue.money = 3000;
            blue.tax = 0;
            blue.zp = 0;
            blue.color = ConsoleColor.Blue;
            blue.die = false;
            blue.spravka = false;

            dibs yellow = new dibs();
            yellow.x = 1;
            yellow.y = 1;
            yellow.round = 1;
            yellow.money = 3000;
            yellow.tax = 0;
            yellow.zp = 0;
            yellow.color = ConsoleColor.Yellow;
            yellow.die = false;
            yellow.spravka = false;

            #endregion



            #region отрисовка и очитка игровых элементов

            void draw()
            {
                #region отрисовка полей

                for (int i = 0; i <= polex; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.BackgroundColor = ConsoleColor.DarkGray;//Левый
                    Console.Write(" ");

                    Console.SetCursorPosition(polex, i);
                    Console.BackgroundColor = ConsoleColor.DarkGray;//Правый
                    Console.Write(" ");

                    Console.SetCursorPosition(i, 0);
                    Console.BackgroundColor = ConsoleColor.DarkGray;//Верхний
                    Console.Write(" ");

                    Console.SetCursorPosition(i, poley);
                    Console.BackgroundColor = ConsoleColor.DarkGray;//Нижний
                    Console.Write(" ");
                }//внешнее поле

                for (int i = 2; i <= insidex; i++)
                {
                    Console.SetCursorPosition(2, i);
                    Console.BackgroundColor = ConsoleColor.Gray;//Левый
                    Console.Write(" ");

                    Console.SetCursorPosition(insidex, i);
                    Console.BackgroundColor = ConsoleColor.Gray;//Правый
                    Console.Write(" ");

                    Console.SetCursorPosition(i, 2);
                    Console.BackgroundColor = ConsoleColor.Gray;//Верхний
                    Console.Write(" ");

                    Console.SetCursorPosition(i, insidey);
                    Console.BackgroundColor = ConsoleColor.Gray;//Нижний
                    Console.Write(" ");
                }//внутренее поле

                for (int i = 0; i <= polex; i++)
                {
                    

                    if (i < 15)
                    {

                        Console.SetCursorPosition(polex, i + 27);
                        Console.BackgroundColor = ConsoleColor.DarkGray;//Правый
                        Console.Write(" ");

                        Console.SetCursorPosition(0, i + 27);
                        Console.BackgroundColor = ConsoleColor.DarkGray;//Левый
                        Console.Write(" ");

                    }

                    Console.SetCursorPosition(i, 27);
                    Console.BackgroundColor = ConsoleColor.DarkGray;//Верхний
                    Console.Write(" ");

                    Console.SetCursorPosition(i, 42);
                    Console.BackgroundColor = ConsoleColor.DarkGray;//Нижний
                    Console.Write(" ");
                }//поле карточек

                #endregion

                #region стрелки

                // стрелка вверх
                Console.SetCursorPosition(25, 37);
                Console.ResetColor();
                Console.Write("↑:" + "действие");
                //стрелка вправо
                Console.SetCursorPosition(25, 39);
                Console.ResetColor();
                Console.Write("→:" + "бросить кубик");
                //стрелка вниз
                Console.SetCursorPosition(25, 41);
                Console.ResetColor();
                Console.Write("↓:" + "покупка");

                #endregion

                #region игровые подсказки

                Console.SetCursorPosition(45, 37);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("O:" + "субсидии");

                Console.SetCursorPosition(45, 39);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("*:" + "налоговая");

                Console.SetCursorPosition(45, 41);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("?:" + "карточка");

                Console.SetCursorPosition(25, 20);
                Console.ResetColor();
                Console.Write("Ход игрока: ");

                Console.SetCursorPosition(66, 37);
                Console.ResetColor();
                Console.Write("каждые 10 ходов взымается аренда");

                Console.SetCursorPosition(66, 39);
                Console.ResetColor();
                Console.Write("каждые 20 ходов приходит зарплата");

                Console.SetCursorPosition(66, 41);
                Console.ResetColor();
                Console.Write("О, *, ? зачисляются автоматически");

                #endregion

                #region субсидии

                Console.SetCursorPosition(15, 2);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("O");

                Console.SetCursorPosition(10, 21);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("O");

                Console.SetCursorPosition(2, 9);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("O");

                Console.SetCursorPosition(21, 15);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("O");

                #endregion

                #region налоговая

                Console.SetCursorPosition(21, 18);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("*");

                Console.SetCursorPosition(2, 13);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("*");

                Console.SetCursorPosition(19, 2);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("*");

                Console.SetCursorPosition(11, 21);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("*");

                #endregion

                #region карточки событий

                Console.SetCursorPosition(0, 20);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("?");

                Console.SetCursorPosition(8, 0);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("?");

                Console.SetCursorPosition(18, 23);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("?");

                Console.SetCursorPosition(23, 12);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("?");

                #endregion

                #region отрисовка недвижимости

                //верх

                Console.SetCursorPosition(11, 0);
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write(" ");

                Console.SetCursorPosition(5, 0);
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write(" ");

                Console.SetCursorPosition(17, 0);
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write(" ");

                //право

                Console.SetCursorPosition(23, 5);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write(" ");

                Console.SetCursorPosition(23, 10);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write(" ");

                Console.SetCursorPosition(23, 17);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write(" ");

                //низ

                Console.SetCursorPosition(4, 23);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ");

                Console.SetCursorPosition(14, 23);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ");

                Console.SetCursorPosition(19, 23);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ");

                //лево

                Console.SetCursorPosition(0, 3);
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");

                Console.SetCursorPosition(0, 12);
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");

                Console.SetCursorPosition(0, 18);
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");

                #endregion

               

            }//поле рисовалка

            void list()
            {
                clearlist();

                if (red.die == false)
                {
                    Console.SetCursorPosition(25, 1);
                    Console.BackgroundColor = red.color;
                    Console.Write(" ");

                    Console.SetCursorPosition(25, 3);
                    Console.ResetColor();
                    Console.Write("Счет: " + red.money);

                    Console.SetCursorPosition(25, 5);
                    Console.ResetColor();
                    Console.Write("Аренда: " + red.tax);

                    Console.SetCursorPosition(25, 7);
                    Console.ResetColor();
                    Console.Write("ЗП: " + red.zp);
                }
                
                if (blue.die == false)
                {
                    Console.SetCursorPosition(41, 1);
                    Console.BackgroundColor = blue.color;
                    Console.Write(" ");

                    Console.SetCursorPosition(41, 3);
                    Console.ResetColor();
                    Console.Write("Счет: " + blue.money);

                    Console.SetCursorPosition(41, 5);
                    Console.ResetColor();
                    Console.Write("Аренда: " + blue.tax);

                    Console.SetCursorPosition(41, 7);
                    Console.ResetColor();
                    Console.Write("ЗП: " + blue.zp);
                }

                if (yellow.die == false)
                {
                    Console.SetCursorPosition(57, 1);
                    Console.BackgroundColor = yellow.color;
                    Console.Write(" ");

                    Console.SetCursorPosition(57, 3);
                    Console.ResetColor();
                    Console.Write("Счет: " + yellow.money);

                    Console.SetCursorPosition(57, 5);
                    Console.ResetColor();
                    Console.Write("Аренда: " + yellow.tax);

                    Console.SetCursorPosition(57, 7);
                    Console.ResetColor();
                    Console.Write("ЗП: " + yellow.zp);
                }           
            }//пользовательский интерфейс



            void clearlist()
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.SetCursorPosition(30+i, 3);
                    Console.ResetColor();
                    Console.Write(' ');

                    Console.SetCursorPosition(46+i, 3);
                    Console.ResetColor();
                    Console.Write(' ');

                    Console.SetCursorPosition(62+i, 3);
                    Console.ResetColor();
                    Console.Write(' ');
                }

                for (int i = 0; i < 6; i++)
                {
                    Console.SetCursorPosition(32 + i, 5);
                    Console.ResetColor();
                    Console.Write(' ');

                    Console.SetCursorPosition(48 + i, 5);
                    Console.ResetColor();
                    Console.Write(' ');

                    Console.SetCursorPosition(64 + i, 5);
                    Console.ResetColor();
                    Console.Write(' ');
                }

                for (int i = 0; i < 6; i++)
                {
                    Console.SetCursorPosition(28 + i, 7);
                    Console.ResetColor();
                    Console.Write(' ');

                    Console.SetCursorPosition(44 + i, 7);
                    Console.ResetColor();
                    Console.Write(' ');

                    Console.SetCursorPosition(60 + i, 7);
                    Console.ResetColor();
                    Console.Write(' ');
                }

                
            }//очистка счета игроков

            void clearcarts()
            {
                for (int i = 28; i < 42; i++)
                {
                    for (int j = 1; j < 23; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ResetColor();
                        Console.Write(' ');
                    }
                }

                for (int i = 0; i < 25; i++)
                {
                    Console.SetCursorPosition(i, 25);
                    Console.ResetColor();
                    Console.Write(' ');
                }
            }//очистка поле карточек


            void clearhome()
            {
                #region красная национализация

                if (red.spravka == true)
                {

                    Console.SetCursorPosition(red.x, red.y);
                    Console.ResetColor();
                    Console.Write(" ");


                    if (red.die == true && up1 == "R")
                    {
                        Console.SetCursorPosition(5, 0);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");

                        up1 = null;
                    }

                    if (red.die == true && up2 == "R")
                    {
                        Console.SetCursorPosition(11, 0);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");

                        up2 = null;
                    }

                    if (red.die == true && up3 == "R")
                    {
                        Console.SetCursorPosition(17, 0);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");

                        up3 = null;
                    }

                    ///

                    if (red.die == true && right1 == "R")
                    {
                        Console.SetCursorPosition(23, 5);
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");

                        right1 = null;
                    }

                    if (red.die == true && right2 == "R")
                    {
                        Console.SetCursorPosition(23, 10);
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");

                        right2 = null;
                    }

                    if (red.die == true && right3 == "R")
                    {
                        Console.SetCursorPosition(23, 17);
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");

                        right3 = null;
                    }

                    ///

                    if (red.die == true && down1 == "R")
                    {
                        Console.SetCursorPosition(4, 23);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");

                        down1 = null;
                    }

                    if (red.die == true && down2 == "R")
                    {
                        Console.SetCursorPosition(14, 23);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");

                        down2 = null;
                    }

                    if (red.die == true && down3 == "R")
                    {
                        Console.SetCursorPosition(19, 23);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");

                        down3 = null;
                    }

                    ///

                    if (red.die == true && left1 == "R")
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");

                        left1 = null;
                    }

                    if (red.die == true && left2 == "R")
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");

                        left2 = null;
                    }

                    if (red.die == true && left3 == "R")
                    {
                        Console.SetCursorPosition(0, 18);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");

                        left3 = null;
                    }

                    for (int i = 0; i < 15; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            Console.SetCursorPosition(25 + i, 1+j);
                            Console.ResetColor();
                            Console.Write(' ');
                        }
                    }

                    red.spravka = false;
                }

                #endregion

                #region синяя национализация

                if (blue.spravka == true)
                {
                    Console.SetCursorPosition(blue.x, blue.y);
                    Console.ResetColor();
                    Console.Write(" ");


                    if (blue.die == true && up1 == "B")
                    {
                        Console.SetCursorPosition(5, 0);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");

                        up1 = null;
                    }

                    if (blue.die == true && up2 == "B")
                    {
                        Console.SetCursorPosition(11, 0);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");

                        up2 = null;
                    }

                    if (blue.die == true && up3 == "B")
                    {
                        Console.SetCursorPosition(17, 0);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");

                        up3 = null;
                    }

                    ///

                    if (blue.die == true && right1 == "B")
                    {
                        Console.SetCursorPosition(23, 5);
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");

                        right1 = null;
                    }

                    if (blue.die == true && right2 == "B")
                    {
                        Console.SetCursorPosition(23, 10);
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");

                        right2 = null;
                    }

                    if (blue.die == true && right3 == "B")
                    {
                        Console.SetCursorPosition(23, 17);
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");

                        right3 = null;
                    }

                    ///

                    if (blue.die == true && down1 == "B")
                    {
                        Console.SetCursorPosition(4, 23);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");

                        down1 = null;
                    }

                    if (blue.die == true && down2 == "B")
                    {
                        Console.SetCursorPosition(14, 23);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");

                        down2 = null;
                    }

                    if (blue.die == true && down3 == "B")
                    {
                        Console.SetCursorPosition(19, 23);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");

                        down3 = null;
                    }

                    ///

                    if (blue.die == true && left1 == "B")
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");

                        left1 = null;
                    }

                    if (blue.die == true && left2 == "B")
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");

                        left2 = null;
                    }

                    if (blue.die == true && left3 == "B")
                    {
                        Console.SetCursorPosition(0, 18);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");

                        left3 = null;
                    }

                    for (int i = 0; i < 15; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            Console.SetCursorPosition(41 + i, 1 + j);
                            Console.ResetColor();
                            Console.Write(' ');
                        }
                    }

                    blue.spravka = false;
                }

                #endregion

                #region желтого национализация

                if (yellow.spravka == true)
                {
                    Console.SetCursorPosition(yellow.x, yellow.y);
                    Console.ResetColor();
                    Console.Write(" ");


                    if (yellow.die == true && up1 == "Y")
                    {
                        Console.SetCursorPosition(5, 0);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");

                        up1 = null;
                    }

                    if (yellow.die == true && up2 == "Y")
                    {
                        Console.SetCursorPosition(11, 0);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");

                        up2 = null;
                    }

                    if (yellow.die == true && up3 == "Y")
                    {
                        Console.SetCursorPosition(17, 0);
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");

                        up3 = null;
                    }

                    ///

                    if (yellow.die == true && right1 == "Y")
                    {
                        Console.SetCursorPosition(23, 5);
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");

                        right1 = null;
                    }

                    if (yellow.die == true && right2 == "Y")
                    {
                        Console.SetCursorPosition(23, 10);
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");

                        right2 = null;
                    }

                    if (yellow.die == true && right3 == "Y")
                    {
                        Console.SetCursorPosition(23, 17);
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");

                        right3 = null;
                    }

                    ///

                    if (yellow.die == true && down1 == "Y")
                    {
                        Console.SetCursorPosition(4, 23);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");

                        down1 = null;
                    }

                    if (yellow.die == true && down2 == "Y")
                    {
                        Console.SetCursorPosition(14, 23);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");

                        down2 = null;
                    }

                    if (yellow.die == true && down3 == "Y")
                    {
                        Console.SetCursorPosition(19, 23);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");

                        down3 = null;
                    }

                    ///

                    if (yellow.die == true && left1 == "Y")
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");

                        left1 = null;
                    }

                    if (yellow.die == true && left2 == "Y")
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");

                        left2 = null;
                    }

                    if (yellow.die == true && left3 == "Y")
                    {
                        Console.SetCursorPosition(0, 18);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");

                        left3 = null;
                    }

                    for (int i = 0; i < 15; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            Console.SetCursorPosition(57 + i, 1 + j);
                            Console.ResetColor();
                            Console.Write(' ');
                        }
                    }

                    yellow.spravka = false;
                }

                #endregion

            }//национализация недвижимости

            #endregion

            #region управление фишками

            void redkey()
            {
                ConsoleKeyInfo key = Console.ReadKey();


                if (key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.DownArrow)
                {
                    redkey();
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    red.cube();
                    red.draw();
                    red.dvizh();
                    clearcarts();
                    red.take();
                    red.rip();
                    if (blue.die == false)
                    {
                        blue.draw();
                    }

                    if (yellow.die == false)
                    {
                        yellow.draw();
                    }
                    redtax();                  
                }


                if (key.Key == ConsoleKey.DownArrow)
                {
                    redbuy();
                    red.draw();
                    clearcarts();
                    red.take();
                    red.rip();
                    if (blue.die == false)
                    {
                        blue.draw();
                    }

                    if (yellow.die == false)
                    {
                        yellow.draw();
                    }
                }


            }//кнопыч для красного

            void bluekey()
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.DownArrow)
                {
                    bluekey();
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    blue.cube();//здесь происходит паранормальщина, НЕ ТРОГАТЬ!!!
                    blue.cube();//и тут тоже
                    blue.draw();
                    blue.dvizh();
                    clearcarts();
                    blue.take();
                    blue.rip();
                    if (red.die == false)
                    {
                        red.draw();
                    }

                    if (yellow.die == false)
                    {
                        yellow.draw();
                    }
                    bluetax();
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    bluebuy();
                    blue.draw();
                    clearcarts();
                    blue.take();
                    blue.rip();
                    if (red.die == false)
                    {
                        red.draw();
                    }

                    if (yellow.die == false)
                    {
                        yellow.draw();
                    }
                }


            }//кнопыч для синего

            void yellowkey()//кнопыч для желтого
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.DownArrow)
                {
                    yellowkey();
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    yellow.cube();//здесь происходит паранормальщина, НЕ ТРОГАТЬ!!!
                    yellow.cube();//и тут тоже
                    yellow.cube();//и тут тоже
                    yellow.draw();
                    yellow.dvizh();
                    clearcarts();
                    yellow.take();
                    yellow.rip();
                    if (red.die == false)
                    {
                        red.draw();
                    }

                    if (blue.die == false)
                    {
                        blue.draw();
                    }
                    yellowtax();
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    yellowbuy();
                    yellow.draw();
                    clearcarts();
                    yellow.take();
                    yellow.rip();
                    if (red.die == false)
                    {
                        red.draw();
                    }

                    if (blue.die == false)
                    {
                        blue.draw();
                    }
                }


            }//кнопыч для синего

            #endregion

            #region методы покупки недвижимости

            void redbuy()
            {
                if (red.x == 5 && red.y == 1 && up1 == null)
                {
                    Console.SetCursorPosition(5, 0);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    up1 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                if (red.x == 11 && red.y == 1 && up2 == null)
                {
                    Console.SetCursorPosition(11, 0);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    up2 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                if (red.x == 17 && red.y == 1 && up3 == null)
                {
                    Console.SetCursorPosition(17, 0);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    up3 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                ///

                if (red.x == 22 && red.y == 5 && right1 == null)
                {
                    Console.SetCursorPosition(23, 5);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    right1 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                if (red.x == 22 && red.y == 10 && right2 == null)
                {
                    Console.SetCursorPosition(23, 10);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    right2 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                if (red.x == 22 && red.y == 17 && right3 == null)
                {
                    Console.SetCursorPosition(23, 17);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    right3 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                ///

                if (red.x == 4 && red.y == 22 && down1 == null)
                {
                    Console.SetCursorPosition(4, 23);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    down1 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                if (red.x == 14 && red.y == 22 && down2 == null)
                {
                    Console.SetCursorPosition(14, 23);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    down2 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                if (red.x == 19 && red.y == 22 && down3 == null)
                {
                    Console.SetCursorPosition(19, 23);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    down3 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                ///

                if (red.x == 1 && red.y == 3 && left1 == null)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    left1 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                if (red.x == 1 && red.y == 12 && left2 == null)
                {
                    Console.SetCursorPosition(0, 12);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    left2 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }

                if (red.x == 1 && red.y == 18 && left3 == null)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = red.color;
                    Console.Write("R");

                    left3 = "R";

                    red.money = red.money - 800;
                    red.tax = red.tax + 400;
                    red.zp = red.zp + 1000;
                }
            }//покупка недвижимости красным//НЕ ТРОГАТЬ ЪЬЬЪЬЬЪЪЬ

            void bluebuy()
            {
                if (blue.x == 5 && blue.y == 1 && up1 == null)
                {
                    Console.SetCursorPosition(5, 0);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    up1 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                if (blue.x == 11 && blue.y == 1 && up2 == null)
                {
                    Console.SetCursorPosition(11, 0);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    up2 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                if (blue.x == 17 && blue.y == 1 && up3 == null)
                {
                    Console.SetCursorPosition(17, 0);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    up3 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                ///

                if (blue.x == 22 && blue.y == 5 && right1 == null)
                {
                    Console.SetCursorPosition(23, 5);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    right1 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                if (blue.x == 22 && blue.y == 10 && right2 == null)
                {
                    Console.SetCursorPosition(23, 10);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    right2 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                if (blue.x == 22 && blue.y == 17 && right3 == null)
                {
                    Console.SetCursorPosition(23, 17);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    right3 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                ///

                if (blue.x == 4 && blue.y == 22 && down1 == null)
                {
                    Console.SetCursorPosition(4, 23);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    down1 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                if (blue.x == 14 && blue.y == 22 && down2 == null)
                {
                    Console.SetCursorPosition(14, 23);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    down2 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                if (blue.x == 19 && blue.y == 22 && down3 == null)
                {
                    Console.SetCursorPosition(19, 23);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    down3 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                ///

                if (blue.x == 1 && blue.y == 3 && left1 == null)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    left1 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                if (blue.x == 1 && blue.y == 12 && left2 == null)
                {
                    Console.SetCursorPosition(0, 12);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    left2 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }

                if (blue.x == 1 && blue.y == 18 && left3 == null)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = blue.color;
                    Console.Write("B");

                    left3 = "B";

                    blue.money = blue.money - 800;
                    blue.tax = blue.tax + 400;
                    blue.zp = blue.zp + 1000;
                }
            }//покупка недвижимости синим

            void yellowbuy()
            {
                if (yellow.x == 5 && yellow.y == 1 && up1 == null)
                {
                    Console.SetCursorPosition(5, 0);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = yellow.color;
                    Console.Write("Y");

                    up1 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                if (yellow.x == 11 && yellow.y == 1 && up2 == null)
                {
                    Console.SetCursorPosition(11, 0);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = yellow.color;
                    Console.Write("Y");

                    up2 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                if (yellow.x == 17 && yellow.y == 1 && up3 == null)
                {
                    Console.SetCursorPosition(17, 0);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = yellow.color;
                    Console.Write("Y");

                    up3 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                ///

                if (yellow.x == 22 && yellow.y == 5 && right1 == null)
                {
                    Console.SetCursorPosition(23, 5);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = yellow.color;
                    Console.Write("Y");

                    right1 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                if (yellow.x == 22 && yellow.y == 10 && right2 == null)
                {
                    Console.SetCursorPosition(23, 10);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = yellow.color;
                    Console.Write("Y");

                    right2 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                if (yellow.x == 22 && yellow.y == 17 && right3 == null)
                {
                    Console.SetCursorPosition(23, 17);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = yellow.color;
                    Console.Write("Y");

                    right3 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                ///

                if (yellow.x == 4 && yellow.y == 22 && down1 == null)
                {
                    Console.SetCursorPosition(4, 23);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = yellow.color;
                    Console.Write("Y");

                    down1 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                if (yellow.x == 14 && yellow.y == 22 && down2 == null)
                {
                    Console.SetCursorPosition(14, 23);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = yellow.color;
                    Console.Write("Y");

                    down2 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                if (yellow.x == 19 && yellow.y == 22 && down3 == null)
                {
                    Console.SetCursorPosition(19, 23);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = yellow.color;
                    Console.Write("Y");

                    down3 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                ///

                if (yellow.x == 1 && yellow.y == 3 && left1 == null)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Y");

                    left1 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                if (yellow.x == 1 && yellow.y == 12 && left2 == null)
                {
                    Console.SetCursorPosition(0, 12);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Y");

                    left2 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }

                if (yellow.x == 1 && yellow.y == 18 && left3 == null)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Y");

                    left3 = "Y";

                    yellow.money = yellow.money - 800;
                    yellow.tax = yellow.tax + 400;
                    yellow.zp = yellow.zp + 1000;
                }
            }

            #endregion

            #region методы налогов за посещение недвижимости

            //там слишком сложна, не трогайте :)

            void redtax()
            {
                #region налог синего 

                if (blue.x == 5 && blue.y == 1 && up1 == "R")
                {
                    blue.money = blue.money - 150;
                    red.money = red.money + 150;
                }

                if (blue.x == 11 && blue.y == 1 && up2 == "R")
                {
                    blue.money = blue.money - 175;
                    red.money = red.money + 175;
                }

                if (blue.x == 17 && blue.y == 1 && up3 == "R")
                {
                    blue.money = blue.money - 125;
                    red.money = red.money + 125;
                }

                ///

                if (blue.x == 22 && blue.y == 1 && right1 == "R")
                {
                    blue.money = blue.money - 150;
                    red.money = red.money + 150;
                }

                if (blue.x == 22 && blue.y == 10 && right2 == "R")
                {
                    blue.money = blue.money - 120;
                    red.money = red.money + 120;
                }

                if (blue.x == 22 && blue.y == 17 && right3 == "R")
                {
                    blue.money = blue.money - 150;
                    red.money = red.money + 150;
                }

                ///

                if (blue.x == 4 && blue.y == 22 && down1 == "R")
                {
                    blue.money = blue.money - 300;
                    red.money = red.money + 300;
                }

                if (blue.x == 14 && blue.y == 22 && down2 == "R")
                {
                    blue.money = blue.money - 150;
                    red.money = red.money + 150;
                }

                if (blue.x == 19 && blue.y == 22 && down3 == "R")
                {
                    blue.money = blue.money - 75;
                    red.money = red.money + 75;
                }

                ///

                if (blue.x == 1 && blue.y == 3 && left1 == "R")
                {
                    blue.money = blue.money - 50;
                    red.money = red.money + 50;
                }

                if (blue.x == 1 && blue.y == 12 && left2 == "R")
                {
                    blue.money = blue.money - 100;
                    red.money = red.money + 100;
                }

                if (blue.x == 1 && blue.y == 18 && left3 == "R")
                {
                    blue.money = blue.money - 250;
                    red.money = red.money + 250;
                }

                #endregion

                #region налог желтого 

                if (yellow.x == 5 && yellow.y == 1 && up1 == "R")
                {
                    yellow.money = yellow.money - 150;
                    red.money = red.money + 150;
                }

                if (yellow.x == 11 && yellow.y == 1 && up2 == "R")
                {
                    yellow.money = yellow.money - 175;
                    red.money = red.money + 175;
                }

                if (yellow.x == 17 && yellow.y == 1 && up3 == "R")
                {
                    yellow.money = yellow.money - 125;
                    red.money = red.money + 125;
                }

                ///

                if (yellow.x == 22 && yellow.y == 1 && right1 == "R")
                {
                    yellow.money = yellow.money - 150;
                    red.money = red.money + 150;
                }

                if (yellow.x == 22 && yellow.y == 10 && right2 == "R")
                {
                    yellow.money = yellow.money - 120;
                    red.money = red.money + 120;
                }

                if (yellow.x == 22 && yellow.y == 17 && right3 == "R")
                {
                    yellow.money = yellow.money - 150;
                    red.money = red.money + 150;
                }

                ///

                if (yellow.x == 4 && yellow.y == 22 && down1 == "R")
                {
                    yellow.money = yellow.money - 300;
                    red.money = red.money + 300;
                }

                if (yellow.x == 14 && yellow.y == 22 && down1 == "R")
                {
                    yellow.money = yellow.money - 150;
                    red.money = red.money + 150;
                }

                if (yellow.x == 19 && yellow.y == 22 && down3 == "R")
                {
                    yellow.money = yellow.money - 75;
                    red.money = red.money + 75;
                }

                ///

                if (yellow.x == 1 && yellow.y == 3 && left1 == "R")
                {
                    yellow.money = yellow.money - 50;
                    red.money = red.money + 50;
                }

                if (yellow.x == 1 && yellow.y == 12 && left2 == "R")
                {
                    yellow.money = yellow.money - 100;
                    red.money = red.money + 100;
                }

                if (yellow.x == 1 && yellow.y == 18 && left3 == "R")
                {
                    yellow.money = yellow.money - 250;
                    red.money = red.money + 250;
                }

                #endregion

            }//налог за посещение



            void bluetax()
            {
                #region налог красного

                if (red.x == 5 && red.y == 1 && up1 == "B")
                {
                    red.money = red.money - 150;
                    blue.money = blue.money + 150;
                }

                if (red.x == 11 && red.y == 1 && up2 == "B")
                {
                    red.money = red.money - 175;
                    blue.money = blue.money + 175;
                }

                if (red.x == 17 && red.y == 1 && up3 == "B")
                {
                    red.money = red.money - 125;
                    blue.money = blue.money + 125;
                }

                ///

                if (red.x == 22 && red.y == 1 && right1 == "B")
                {
                    red.money = red.money - 150;
                    blue.money = blue.money + 150;
                }

                if (red.x == 22 && red.y == 10 && right2 == "B")
                {
                    red.money = red.money - 120;
                    blue.money = blue.money + 120;
                }

                if (red.x == 22 && red.y == 17 && right3 == "B")
                {
                    red.money = red.money - 150;
                    blue.money = blue.money + 150;
                }

                ///

                if (red.x == 4 && red.y == 22 && down1 == "B")
                {
                    red.money = red.money - 300;
                    blue.money = blue.money + 300;
                }

                if (red.x == 14 && red.y == 22 && down2 == "B")
                {
                    red.money = red.money - 150;
                    blue.money = blue.money + 150;
                }

                if (red.x == 19 && red.y == 22 && down3 == "B")
                {
                    red.money = red.money - 75;
                    blue.money = blue.money + 75;
                }

                ///

                if (red.x == 1 && red.y == 3 && left1 == "B")
                {
                    red.money = red.money - 50;
                    blue.money = blue.money + 50;
                }

                if (red.x == 1 && red.y == 12 && left2 == "B")
                {
                    red.money = red.money - 100;
                    blue.money = blue.money + 100;
                }

                if (red.x == 1 && red.y == 18 && left3 == "B")
                {
                    red.money = red.money - 250;
                    blue.money = blue.money + 250;
                }

                #endregion

                #region налог желтого

                if (yellow.x == 5 && yellow.y == 1 && up1 == "B")
                {
                    yellow.money = yellow.money - 150;
                    blue.money = blue.money + 150;
                }

                if (yellow.x == 11 && yellow.y == 1 && up2 == "B")
                {
                    yellow.money = yellow.money - 175;
                    blue.money = blue.money + 175;
                }

                if (yellow.x == 17 && yellow.y == 1 && up3 == "B")
                {
                    yellow.money = yellow.money - 125;
                    blue.money = blue.money + 125;
                }

                ///

                if (yellow.x == 22 && yellow.y == 1 && right1 == "B")
                {
                    yellow.money = yellow.money - 150;
                    blue.money = blue.money + 150;
                }

                if (yellow.x == 22 && yellow.y == 10 && right2 == "B")
                {
                    yellow.money = yellow.money - 120;
                    blue.money = blue.money + 120;
                }

                if (yellow.x == 22 && yellow.y == 17 && right3 == "B")
                {
                    yellow.money = yellow.money - 150;
                    blue.money = blue.money + 150;
                }

                ///

                if (yellow.x == 4 && yellow.y == 22 && down1 == "B")
                {
                    yellow.money = yellow.money - 300;
                    blue.money = blue.money + 300;
                }

                if (yellow.x == 14 && yellow.y == 22 && down2 == "B")
                {
                    yellow.money = yellow.money - 150;
                    blue.money = blue.money + 150;
                }

                if (yellow.x == 19 && yellow.y == 22 && down3 == "B")
                {
                    yellow.money = yellow.money - 75;
                    blue.money = blue.money + 75;
                }

                ///

                if (yellow.x == 1 && yellow.y == 3 && left1 == "B")
                {
                    yellow.money = yellow.money - 50;
                    blue.money = blue.money + 50;
                }

                if (yellow.x == 1 && yellow.y == 12 && left2 == "B")
                {
                    yellow.money = yellow.money - 100;
                    blue.money = blue.money + 100;
                }

                if (yellow.x == 1 && yellow.y == 18 && left3 == "B")
                {
                    yellow.money = yellow.money - 250;
                    blue.money = blue.money + 250;
                }

                #endregion

            }//налог за посещение 

            void yellowtax()
            {
                #region налог красного

                if (red.x == 5 && red.y == 1 && up1 == "Y")
                {
                    red.money = red.money - 150;
                    yellow.money = yellow.money + 150;
                }

                if (red.x == 11 && red.y == 1 && up2 == "Y")
                {
                    red.money = red.money - 175;
                    yellow.money = yellow.money + 175;
                }

                if (red.x == 17 && red.y == 1 && up3 == "Y")
                {
                    red.money = red.money - 125;
                    yellow.money = yellow.money + 125;
                }

                ///

                if (red.x == 22 && red.y == 1 && right1 == "Y")
                {
                    red.money = red.money - 150;
                    yellow.money = yellow.money + 150;
                }

                if (red.x == 22 && red.y == 10 && right2 == "Y")
                {
                    red.money = red.money - 120;
                    yellow.money = yellow.money + 120;
                }

                if (red.x == 22 && red.y == 17 && right3 == "Y")
                {
                    red.money = red.money - 150;
                    yellow.money = yellow.money + 150;
                }

                ///

                if (red.x == 4 && red.y == 22 && down1 == "Y")
                {
                    red.money = red.money - 300;
                    yellow.money = yellow.money + 300;
                }

                if (red.x == 14 && red.y == 22 && down2 == "Y")
                {
                    red.money = red.money - 150;
                    yellow.money = yellow.money + 150;
                }

                if (red.x == 19 && red.y == 22 && down3 == "Y")
                {
                    red.money = red.money - 75;
                    yellow.money = yellow.money + 75;
                }

                ///

                if (red.x == 1 && red.y == 3 && left1 == "Y")
                {
                    red.money = red.money - 50;
                    yellow.money = yellow.money + 50;
                }

                if (red.x == 1 && red.y == 12 && left2 == "Y")
                {
                    red.money = red.money - 100;
                    yellow.money = yellow.money + 100;
                }

                if (red.x == 1 && red.y == 18 && left3 == "Y")
                {
                    red.money = red.money - 250;
                    yellow.money = yellow.money + 250;
                }

                #endregion

                #region налог синего 

                if (blue.x == 5 && blue.y == 1 && up1 == "Y")
                {
                    blue.money = blue.money - 150;
                    yellow.money = yellow.money + 150;
                }

                if (blue.x == 11 && blue.y == 1 && up2 == "Y")
                {
                    blue.money = blue.money - 175;
                    yellow.money = yellow.money + 175;
                }

                if (blue.x == 17 && blue.y == 1 && up3 == "Y")
                {
                    blue.money = blue.money - 125;
                    yellow.money = yellow.money + 125;
                }

                ///

                if (blue.x == 22 && blue.y == 1 && right1 == "Y")
                {
                    blue.money = blue.money - 150;
                    yellow.money = yellow.money + 150;
                }

                if (blue.x == 22 && blue.y == 10 && right2 == "Y")
                {
                    blue.money = blue.money - 120;
                    yellow.money = yellow.money + 120;
                }

                if (blue.x == 22 && blue.y == 17 && right3 == "Y")
                {
                    blue.money = blue.money - 150;
                    yellow.money = yellow.money + 150;
                }

                ///

                if (blue.x == 4 && blue.y == 22 && down1 == "Y")
                {
                    blue.money = blue.money - 300;
                    yellow.money = yellow.money + 300;
                }

                if (blue.x == 14 && blue.y == 22 && down2 == "Y")
                {
                    blue.money = blue.money - 150;
                    yellow.money = yellow.money + 150;
                }

                if (blue.x == 19 && blue.y == 22 && down3 == "Y")
                {
                    blue.money = blue.money - 75;
                    yellow.money = yellow.money + 75;
                }

                ///

                if (blue.x == 1 && blue.y == 3 && left1 == "Y")
                {
                    blue.money = blue.money - 50;
                    yellow.money = yellow.money + 50;
                }

                if (blue.x == 1 && blue.y == 12 && left2 == "Y")
                {
                    blue.money = blue.money - 100;
                    yellow.money = yellow.money + 100;
                }

                if (blue.x == 1 && blue.y == 18 && left3 == "Y")
                {
                    blue.money = blue.money - 250;
                    yellow.money = yellow.money + 250;
                }

                #endregion
            }

            #endregion



            #region основная часть

            void start()
            {
                Console.WriteLine("Выберите колличество игроков от 2-3");
                player = Convert.ToInt32(Console.ReadLine());

                if (player == 2)
                {
                    Console.Clear();
                    yellow.die = true;
                    yellow.spravka = true;
                    
                }

                if (player == 3)
                {
                    Console.Clear();
                    yellow.die = false;
                    yellow.spravka = false;

                }

                if (player != 2 && player != 3)
                {
                    Console.Clear();
                    start();                  
                }
            }

            start();
            draw();

            while (true)
            {
                if (red.die == false)
                {
                    Console.SetCursorPosition(36, 20);
                    Console.BackgroundColor = red.color;
                    Console.Write(" ");
                    list();
                    redkey();
                }

                else 
                {
                    clearhome();
                }


                if (blue.die == false)
                {
                    Console.SetCursorPosition(36, 20);
                    Console.BackgroundColor = blue.color;
                    Console.Write(" ");
                    list();
                    bluekey();
                }

                else
                {
                    clearhome();
                }

                if (yellow.die == false)
                {
                    Console.SetCursorPosition(36, 20);
                    Console.BackgroundColor = yellow.color;
                    Console.Write(" ");
                    list();
                    yellowkey();
                }

                else
                {
                    clearhome();
                }

                turn++;

                Console.SetCursorPosition(25, 22);
                Console.ResetColor();
                Console.Write("Ход: " + turn);

                

                #region ЗП и Налоги

                if (turn % 20 == 0)
                {
                    if (red.die == false)
                    {
                        red.money = red.money + red.zp;
                        list();
                    }

                    if (blue.die == false)
                    {
                        blue.money = blue.money + blue.zp;
                        list();
                    }

                    if (yellow.die == false)
                    {
                        yellow.money = yellow.money + yellow.zp;
                        list();
                    }
                }

                if (turn % 10 == 0)
                {
                    if (red.die == false)
                    {
                        red.money = red.money - red.tax;
                        list();
                        red.rip();
                        clearhome();
                    }

                    if (blue.die == false)
                    {
                        blue.money = blue.money - blue.tax;
                        list();
                        blue.rip();
                        clearhome();
                    }

                    if (yellow.die == false)
                    {
                        yellow.money = yellow.money - yellow.tax;
                        list();
                        yellow.rip();
                        clearhome();
                    }
                }

                #endregion







                if(red.die == true && blue.die == true)
                {
                    Console.Clear();
                    Console.WriteLine("Победил игрок желтый");
                    Console.ReadKey();
                }

                if (red.die == true && yellow.die == true)
                {
                    Console.Clear();
                    Console.WriteLine("Победил игрок синий");
                    Console.ReadKey();
                }

                if (yellow.die == true && blue.die == true)
                {
                    Console.Clear();
                    Console.WriteLine("Победил игрок красный");
                    Console.ReadKey();
                }


                if (red.die == true && blue.die == true && yellow.die == true) 
                {
                    Console.Clear();
                    Console.WriteLine("В который раз мы убедились в том,");
                    Console.WriteLine("что капитализм падет");
                    Console.WriteLine("под натиском революционных настроений среди пролетариев всего мира,");
                    Console.WriteLine("как пал рабовладельческий строй и феодализм.");
                    Console.ReadKey();
                }    
            }

            #endregion
        }
    }
}


#region молебельный уголок

//†храм имени рабочего кода†

//C# наш, сущий в памяти!
//да компилируется код Твой;
//да приидет царствие Софта Твоего;
//да будут действительны указатели Твои
//и в ОЗУ, как на жестком диске;
//массив наш насущный подавай нам на каждый день;
//и прости нам варнинги наши,
//как и мы избавляемся от ошибок наших;
//и не введи нас в бесконечный цикл,
//но избавь нас от винды.
//Ибо Твое есть Царство и сила и слава во веки.
//Энтер.

#endregion
