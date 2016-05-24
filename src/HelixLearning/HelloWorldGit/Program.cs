using System;
using System.Collections.Generic;
using System.IO;

namespace Drumstorments
{
    //TODO
    // 1. Нужно путь к файлу вынести в переменную, чтобы можно было менять его из одного места
    // 2. switch-case константы команд лучше именовать не цифрами а значениями перечисленй https://msdn.microsoft.com/ru-ru/library/sbbt4032.aspx
    // 3. установить решарпер версию 8-9, у нас лицензии нету, у меня дистриб потерялся ;) - он поможет с форматированием кода
    // так же по форматированию кода можно ознакомиться с нотацией рсдн: https://rsdn.ru/article/mag/200401/codestyle.XML
    // 4. разобраться что такое var и заменить, где можно https://msdn.microsoft.com/ru-ru/library/bb383973.aspx?f=255&MSPPError=-2147217396
    

    class Program 
    {
        static void Main(string[] args)
        {
            int menuSelect;
            Console.WriteLine(@"Добро пожаловать в магазин TiredTires!!");
            do
            {
                menuSelect = Program.MenuSelect();
                switch (menuSelect)
                {
                    case 1:
                        Program.ViewList();
                        menuSelect = 0;
                        break;

                    case 2:
                        Program.AddNewCar();
                        menuSelect = 0;
                        break;
                }
            }
            while (menuSelect != 3);
        }

        
        //Смотрим список
        static void ViewList()
        {
            int i = 0;
            foreach (string car in File.ReadAllLines(@"E:\1.txt"))
            {
                i++;
                Console.WriteLine("Car{1}: {0}", car,i);
            }
        }

        


        //Добавляем тачку
        static void AddNewCar()
        {
            string car = Console.ReadLine();
            string path = @"E:\1.txt";
            
            //Добавляем новую тачку
            var carsList = new List<string>();
            carsList.Add(car.ToLower());
            //Судя по сигратуре, метод принимает 
            // 1) путь + массив строк 
            // 2) путь + коллекцию строк
            File.WriteAllLines(path, carsList);
        }
     
   
        //Выбор меню
        static int MenuSelect ()
        {
            int menuSelect;
            do
            {
            Console.WriteLine(
@"Выберите действие:
1 - смотреть существующий список
2 - создать новый автомобиль
3 - выход");
            menuSelect = int.Parse(Console.ReadLine());
            }
            while (menuSelect != 1 & menuSelect != 2 & menuSelect != 3);
            return menuSelect;
        }
    }
}
