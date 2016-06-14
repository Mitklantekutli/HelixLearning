using System;
using System.Collections.Generic;
using System.IO;

namespace Drumstorments
{
    //TODO
    // DONE  1. Нужно путь к файлу вынести в переменную, чтобы можно было менять его из одного места
    // DONE  2. switch-case константы команд лучше именовать не цифрами а значениями перечисленй https://msdn.microsoft.com/ru-ru/library/sbbt4032.aspx
    // DONE  3. установить решарпер версию 8-9, у нас лицензии нету, у меня дистриб потерялся ;) - он поможет с форматированием кода
    // DONE  так же по форматированию кода можно ознакомиться с нотацией рсдн: https://rsdn.ru/article/mag/200401/codestyle.XML
    // Done  4. разобраться что такое var и заменить, где можно https://msdn.microsoft.com/ru-ru/library/bb383973.aspx?f=255&MSPPError=-2147217396
    // Done  5. Что происходит когда нет файла? Нужно что то с этим сделать
    // Done  6. По пункту 2 - заиспользовать енам MenuSelect в свиче
    // Done 7. Сохранение списка тачек
    // Done 7.1 Сначала сделаем простое сохранение названий тачек - по названию на строку
    // Done 7.2 Т.е. при добавлении нужно построчно записывать новые машины в файл
    // 7.3 Должно корректно отрабатывать чтение сохраненного списка тачек                         - несовсем понял
    // Done 7.4 Сделать функцию удаления тачек из списка
    // Done 7.5 Сделать функцию изменения названия тачки по номеру в списке (так же в рамках этого пункта нужно добавить нумерацию тачек в списке)
    // Good luck :)

    class Program 
    {

        //MAIN---------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            
            var fpath = @"E:\1.txt";
            var menuSelect = MenuSelectTypes.None;
            Console.WriteLine("Добро пожаловать в магазин TiredTires!!");
            Program.FileExist(fpath);
                   
            do
            {
                
                menuSelect = Program.MenuSelect();
                switch (menuSelect)
                {
                    case MenuSelectTypes.View:
                        Program.ViewList(fpath);
                        menuSelect = MenuSelectTypes.None;
                        break;

                    case MenuSelectTypes.New:
                        Program.AddNewCar(fpath);
                        menuSelect = MenuSelectTypes.None;
                        break;

                    case MenuSelectTypes.Remove:
                        Program.RemoveCar(fpath);
                        menuSelect = MenuSelectTypes.None;
                        break;

                    case MenuSelectTypes.Rename:
                        Program.ReplaseCar(fpath);
                        menuSelect = MenuSelectTypes.None;
                        break;
                }
            }
            while (menuSelect != MenuSelectTypes.Exit);

        }
        
        //МЕТОД Проверяем сущ-вание файла------------------------------------------------------
        static void FileExist(string fpath)
        {
            if (File.Exists(fpath) == false)
            {
                Console.WriteLine("Файл не найден, создан новый");
                File.Create(fpath);
            }
        }

        //МЕТОД Смотрим список-----------------------------------------------------------------
        static void ViewList(string fpath)
        {
            var i = 1;
            foreach (var car in File.ReadAllLines(fpath))
            {
                Console.WriteLine("Машина №{1}: {0}", car,i);
                i++;
            }
        }

        //МЕТОД Добавляем тачку----------------------------------------------------------------
        static void AddNewCar(string fpath)
        {
            string car = Console.ReadLine();
            var carsList = new List<string>();
            foreach (string line in File.ReadAllLines(fpath))
                    carsList.Add(line);
            carsList.Add(car);
            File.WriteAllLines(fpath, carsList);
        }

        //МЕТОД Удаляем тачку------------------------------------------------------------------
        static void RemoveCar(string fpath)
        {
            Program.ViewList(fpath);
            Console.WriteLine("Выберите номер автомобиля, который нужно удалить:");

            var carsList = new List<string>();           
            int removeLine = 0;
            var isCorrect = false;
            string input;              
            while (!isCorrect)
            {
                input = Console.ReadLine();
                isCorrect = int.TryParse(input, out removeLine);
            }
            foreach (string line in File.ReadAllLines(fpath))
                {
                    carsList.Add(line);
                }
            if (removeLine != 0) carsList.RemoveAt(removeLine - 1);
            File.WriteAllLines(fpath, carsList);
        }

        //МЕТОД Переименовываем тачку----------------------------------------------------------
        static void ReplaseCar(string fpath)
        {
            Program.ViewList(fpath);
            Console.WriteLine("Выберите номер автомобиля, который нужно переименовать:");

            var carsList = new List<string>();
            int replaseLine = 0;
            string input;
            do
                {
                    input = Console.ReadLine();
                }
            while (int.TryParse(input, out replaseLine) == false);
            Console.WriteLine("Введите новое имя:");
            string newname = Console.ReadLine();
            foreach (string line in File.ReadAllLines(fpath))
                {
                    carsList.Add(line);
                }
            carsList[replaseLine-1] = newname;
            File.WriteAllLines(fpath, carsList);
        }

        //МЕТОД Выбор меню---------------------------------------------------------------------
        static MenuSelectTypes MenuSelect ()
        {
            var menuSelect = 0;
            do
               {
               Console.WriteLine(
@"Выберите действие:
1 - смотреть существующий список
2 - создать новый автомобиль
3 - удалить автомобиль
4 - переименовать автомобиль
5 - выход");
               var input = Console.ReadLine();
               int.TryParse(input, out menuSelect);
               }
            while ( menuSelect > 5 & menuSelect < 1 );
            return (MenuSelectTypes)menuSelect;
        }

        // Перечисление меню-------------------------------------------------------------------
        public enum MenuSelectTypes {None, View, New, Remove, Rename, Exit};
    }

    
}



