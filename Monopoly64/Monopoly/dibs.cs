using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monopoly
{

    //Класс для создания, перемещения фишек и обработки координат
    class dibs
    {
        #region переменные фишек

        public Random rnd = new Random();

        public int step = 0; //пременная для выполнения только одного if
        public int turn = 0;

        public int x; //позиция фишки по Х
        public int y; //позиция фишки по Y

        public int round; //колличество пройденых кругов

        public int money; //денег на счете

        public int tax;//налоги с предприятий

        public int zp;//зарплата с предприятий

        public bool die;
        public bool spravka;

        #endregion

        #region методы фишек

        public ConsoleColor color; //цвет фишки

        public void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = color;
            Console.Write(" ");

        }//отрисовка позиции фишки

        public void cube()
        {
            turn = rnd.Next(1, 7);
        }//Кубыч

        public void dvizh()
        {
            while (turn > 0 && turn < 7)
            {

                step++;

                if (x <= 21 && y == 1 && step == 1)
                {
                    Thread.Sleep(5);

                    clear();

                    x++;

                    draw();

                    step--;
                    turn--;
                }

                if (x == 22 && y <= 21 && step == 1)
                {
                    Thread.Sleep(5);

                    clear();

                    y++;

                    draw();

                    step--;
                    turn--;
                }

                if (x >= 2 && y == 22 && step == 1)
                {
                    Thread.Sleep(5);

                    clear();

                    x--;

                    draw();

                    step--;
                    turn--;
                }

                if (x == 1 && y <= 22 && step == 1)
                {
                    Thread.Sleep(5);

                    clear();

                    y--;

                    draw();

                    step--;
                    turn--;
                }

            }
        }//пердвижение фишки

        public void clear()
        {
            Console.SetCursorPosition(x, y);
            Console.ResetColor();
            Console.Write(" ");
        }//очистка старой позиции фишки

        public void take()
        {
            #region проверка субсидий

            if (x == 15 && y == 1)
            {
                money = money + 100;
            }

            if (x == 10 && y == 22)
            {
                money = money + 100;
            }

            if (x == 1 && y == 9)
            {
                money = money + 100;
            }

            if (x == 22 && y == 15)
            {
                money = money + 100;
            }

            #endregion

            #region проверка налоговой

            if (x == 22 && y == 18)
            {
                money = money - 200;
            }

            if (x == 1 && y == 13)
            {
                money = money - 200;
            }

            if (x == 19 && y == 1)
            {
                money = money - 200;
            }

            if (x == 11 && y == 22)
            {
                money = money - 200;
            }

            #endregion

            #region проверка карточек

            if (x == 1 && y == 20)
            {
                carts();
            }

            if (x == 8 && y == 1)
            {
                carts();
            }

            if (x == 18 && y == 22)
            {
                carts();
            }

            if (x == 22 && y == 12)
            {
                carts();
            }

            #endregion

        }//действие на координату

        public void carts()
        {
            Console.SetCursorPosition(5, 25);
            Console.ResetColor();
            Console.Write("Карта игрока:");

            Console.SetCursorPosition(18, 25);
            Console.BackgroundColor = color;
            Console.Write(" ");

            switch (rnd.Next(1, 26))
            {
                case 1:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Ваша жена попросила");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("оплатить ей маникюр");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "1000 " + "монет");

                    money = money - 1000;

                    break;

                case 2:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("У вас сломалась");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("машина, придеться");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("ехать на такси");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "600 " + "монет");

                    money = money - 600;

                    break;

                case 3:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы выиграли патент");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("на постройку кафе.");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("Оформим их  как ЗП");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+" + "750 " + "монет");

                    money = money + 750;

                    break;

                case 4:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вам понадобилось");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("купить новенький");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("ипхон для любовницы");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "1799 " + "монет");

                    money = money - 1799;

                    break;

                case 5:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вас направили");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("получить справку");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("о наличии справки");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "300 " + "монет");

                    money = money - 300;

                    break;

                case 6:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вас замучал сушняк,");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("вы купили epta-cola");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "79 " + "монет");

                    money = money - 79;

                    break;

                case 7:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Опа очирик!");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+" + "10 " + "монет");

                    money = money + 10;

                    break;

                case 8:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вас обокрали");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("цыгане на саммите");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("по коноводству");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "450 " + "монет");

                    money = money - 450;

                    break;

                case 9:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы сдали деньги");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("на шторы школе");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("(ЗП преподу)");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "1000 " + "монет");

                    money = money - 1000;

                    break;

                case 10:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы сходили к ");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("гадалке, она ");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("накалдовала запор");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+5 к удаче");                    

                    break;

                case 11:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы сходили в KFS");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("но друг забыл");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("деньги дома");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "600 " + "монет");

                    money = money - 600;

                    break;

                case 12:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы обокрали");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("трансформатор");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("и сдали медь,");

                    Console.SetCursorPosition(2, 35);
                    Console.ResetColor();
                    Console.Write("шутка, сдали вас");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "300 " + "монет");

                    money = money - 300;

                    break;

                case 13:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("у вас умер дед");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("печаль");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("(успех)");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+" + "2000 " + "монет");

                    money = money + 2000;

                    break;

                case 14:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Запомни, сынок,");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("друзей купить");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("нельзя, но можно");

                    Console.SetCursorPosition(2, 35);
                    Console.ResetColor();
                    Console.Write("продать (дорого)");


                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+" + "1861 " + "монет");

                    money = money + 1861;

                    break;

                case 15:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы продали почку");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("любвницы");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("любишь ипхоны");

                    Console.SetCursorPosition(2, 35);
                    Console.ResetColor();
                    Console.Write("люби и почки");

                    Console.SetCursorPosition(2, 37);
                    Console.ResetColor();
                    Console.Write("отдавать");


                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+" + "1199 " + "монет");

                    money = money + 1199;

                    break;

                case 16:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Вы продали пачку");

                    Console.SetCursorPosition(2, 31);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("белого порошка ");

                    Console.SetCursorPosition(2, 33);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("(мука :) )");


                    Console.SetCursorPosition(2, 40);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("+" + "700 " + "монет");

                    money = money + 700;

                    break;

                case 17:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы стали владельцем");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("лучшей шаурмяшной");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("в вашем городе.");

                    Console.SetCursorPosition(2, 35);
                    Console.ResetColor();
                    Console.Write("Это был сон");


                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+40 к депрессии");


                    break;

                case 18:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы купили курсы");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("по саморазвитию");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("у Гасанова");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "1999 " + "монет");

                    money = money - 1999;

                    break;

                case 19:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы встретили ждина,");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("загадали у него");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("денег, но он дал");

                    Console.SetCursorPosition(2, 35);
                    Console.ResetColor();
                    Console.Write("вам леща");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-5 к вере в чудо");                    

                    break;

                case 20:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("В дверь постучали");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("8 раз, осьминог");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("подумали вы...");

                    Console.SetCursorPosition(2, 35);
                    Console.ResetColor();
                    Console.Write("Открывайте,");

                    Console.SetCursorPosition(2, 37);
                    Console.ResetColor();
                    Console.Write("налоговая");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "800 " + "монет");

                    money = money - 800;

                    break;

                case 21:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы купили курсы по");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("уменьшении трат");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "499 " + "монет");

                    money = money - 499;

                    break;

                case 22:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы стали донором");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("спермы, тепрь с вас");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("требуют алименты");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("-" + "100 " + "налогов");

                    tax = tax + 100;

                    break;

                case 23:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы продали ОЗУ");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("(не с колледжа)");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+" + "600 " + "монет");

                    money = money + 600;

                    break;

                case 24:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Папа римсий");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("организовал");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("кресовый поход.");

                    Console.SetCursorPosition(2, 35);
                    Console.ResetColor();
                    Console.Write("AVE MARIA");

                    Console.SetCursorPosition(2, 37);
                    Console.ResetColor();
                    Console.Write("DEUS VULT");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+" + "777 " + "монет");

                    money = money + 777;

                    break;

                case 25:

                    //Console.Write("                   ");

                    Console.SetCursorPosition(2, 29);
                    Console.ResetColor();
                    Console.Write("Вы стали епископом,");

                    Console.SetCursorPosition(2, 31);
                    Console.ResetColor();
                    Console.Write("все из-за любви к");

                    Console.SetCursorPosition(2, 33);
                    Console.ResetColor();
                    Console.Write("Богу (нет)");

                    Console.SetCursorPosition(2, 40);
                    Console.ResetColor();
                    Console.Write("+" + "20 " + "ЗП");

                    zp = zp + 20;

                    break;

               
            }

            switch(rnd.Next(1,100))
            {
                case 66:

                    die = true;

                break;
            }


        }//карточки

        public void rip()
        {
            if(money <= 0)
            {
                die = true;
                spravka = true;
            }
        }

        #endregion







    }
}










