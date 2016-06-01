using System;
using System.Collections.Generic;
using System.IO;

namespace Drumstorments
{
    //TODO
    // DONE 1. Нужно путь к файлу вынести в переменную, чтобы можно было менять его из одного места
    // 2. switch-case константы команд лучше именовать не цифрами а значениями перечисленй https://msdn.microsoft.com/ru-ru/library/sbbt4032.aspx
    // 3. установить решарпер версию 8-9, у нас лицензии нету, у меня дистриб потерялся ;) - он поможет с форматированием кода
    // так же по форматированию кода можно ознакомиться с нотацией рсдн: https://rsdn.ru/article/mag/200401/codestyle.XML
    // Done  4. разобраться что такое var и заменить, где можно https://msdn.microsoft.com/ru-ru/library/bb383973.aspx?f=255&MSPPError=-2147217396
    

    class Program 
    {
        
        
        static void Main(string[] args)
        {
            
            var fpath = @"E:\1.txt";
            var menuSelect = 0;
            
            Console.WriteLine("Добро пожаловать в магазин TiredTires!!");
            do
            {
                menuSelect = Program.MenuSelect();
                switch (menuSelect)
                {
                    case 1:
                        Program.ViewList(fpath);
                        menuSelect = 0;
                        break;

                    case 2:
                        Program.AddNewCar(fpath);
                        menuSelect = 0;
                        break;
                        
                    case 3:
                        ConcatTests();
                        menuSelect = 0;
                        break;
                }
            }
            while (menuSelect != 4);
        }

        private static void ConcatTests()
        {
            ConcatStrings(null, null);
            ConcatStrings(null, "message 2");
            ConcatStrings("message 1", null);
            ConcatStrings("message 1", "message 2");
        }


        //Смотрим список
        static void ViewList(string fpath)
        {
            var i = 0;
            foreach (var car in File.ReadAllLines(fpath))
            {
                i++;
                Console.WriteLine("Car{1}: {0}", car,i);
            }
        }

        


        //Добавляем тачку
        static void AddNewCar(string fpath)
        {
            string car = Console.ReadLine();
                        
            //Добавляем новую тачку
            var carsList = new List<string>();
            carsList.Add(car.ToLower());
            //Судя по сигратуре, метод принимает 
            // 1) путь + массив строк 
            // 2) путь + коллекцию строк
            File.WriteAllLines(fpath, carsList);
        }
     
   
        //Выбор меню
        static int MenuSelect ()
        {
            int menuSelect = 0;
            do
            {
            Console.WriteLine(
@"Выберите действие:
1 - смотреть существующий список
2 - создать новый автомобиль
3 - тестирование строк
4 - выход");
            menuSelect = int.Parse(Console.ReadLine());
            }
            while (menuSelect != 1 & menuSelect != 2 & menuSelect != 3);
            return menuSelect;
        }

        static void ConcatStrings(string message1, string message2)
        {
            //Console.WriteLine("Введите первую строку:");
            //var message1 = Console.ReadLine();
            //Console.WriteLine("Введите вторую строку:");
            //var message2 = Console.ReadLine();
            string resultMessage;
            if (message1.Length == 0 | message2.Length == 0) resultMessage = message1 + message2;
            else resultMessage = message1 + ";" + message2;
            Console.WriteLine(resultMessage);

        }

    }
    public enum MenuSelect { View, New, Exit };



   



}



