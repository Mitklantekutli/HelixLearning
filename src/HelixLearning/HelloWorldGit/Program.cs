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
    // 5. Что происходит когда нет файла? Нужно что то с этим сделать
    // 6. По пункту 2 - заиспользовать енам MenuSelect в свиче
    // 7. Сохранение списка тачек
    // 7.1 Сначала сделаем простое сохранение названий тачек - по названию на строку
    // 7.2 Т.е. при добавлении нужно построчно записывать новые машины в файл
    // 7.3 Должно корректно отрабатывать чтение сохраненного списка тачек
    // 7.4 Сделать функцию удаления тачек из списка
    // 7.5 Сделать функцию изменения названия тачки по номеру в списке (так же в рамках этого пункта нужно добавить нумерацию тачек в списке)
    // Good luck :)

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
                        
                }
            }
            while (menuSelect != 3);
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
3 - выход");
            menuSelect = int.Parse(Console.ReadLine());
            }
            while (menuSelect != 1 & menuSelect != 2 & menuSelect != 3);
            return menuSelect;
        }

    }

    public enum MenuSelect { View, New, Exit };



   



}



