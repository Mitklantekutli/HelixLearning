using System;
using System.IO;

namespace Drumstorments
{
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
         //   File.WriteAllLines (path,car.ToLower);
        }
     
   
        //Выбор меню
        static int MenuSelect ()
        {
            int menuSelect;
            do
            {
            Console.WriteLine(@"Выберите действие:
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
