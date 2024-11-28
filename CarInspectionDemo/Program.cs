using System;
using InspectorLib;

namespace CarInspectionDemo
{
    internal class Program
    {


        static void Main(string[] args)
        {
            FunctionInsp insp = new FunctionInsp();

            LibDemonstration(insp);
            InteractiveDemonstration(insp);
        }




        // Демонстрация методов
        static void LibDemonstration(FunctionInsp insp)
        {
            Console.WriteLine("\nНазвание автоинспекции:");
            Console.WriteLine(insp.GetCarInspection());

            Console.WriteLine("\nСписок сотрудников: ");
            foreach (string name in insp.GetWorker())
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nГлавный инспектор:");
            Console.WriteLine(insp.GetInspector());

            Console.WriteLine("\nИзменяем главного инспектора на Иванова И.И.");
            insp.SetInspector("Иванов И. И.");

            Console.WriteLine("\nГлавный инспектор:");
            Console.WriteLine(insp.GetInspector());


            Console.WriteLine("\nГенерируем гос знак:");
            Console.WriteLine(insp.GenerateNumber());

            Console.WriteLine("\nГенерируем гос знак с номером региона 12:");
            Console.WriteLine(insp.GenerateNumber(12));

            Console.WriteLine("\nГенерируем гос знак А1234_56");
            Console.WriteLine(insp.GenerateNumber(1234, "а", 56));

            try
            {
                Console.WriteLine("\n\n\nПопытаемся сгенерировать неправильный знак (А12345_75):\n");
                Console.WriteLine(insp.GenerateNumber(12345, "А"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                Console.WriteLine("\n\n\nПопытаемся сгенерировать неправильный знак (Z1234_75):\n");
                Console.WriteLine(insp.GenerateNumber(1234, "Z"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                Console.WriteLine("\n\n\nПопытаемся сгенерировать неправильный знак (А1234_100):\n");
                Console.WriteLine(insp.GenerateNumber(1234, "а", 100));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n\n\n");
            Console.WriteLine("Добавляем сотрудника Сидорова Сидора Сидоровича");
            insp.AddWorker("Сидоров Сидор Сидорович");

            Console.WriteLine("\nСписок сотрудников: ");
            foreach (string name in insp.GetWorker())
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nИзменяем главного инспектора на Сидорова Сидора Сидоровича");
            insp.SetInspector("Сидоров Сидор Сидорович");

            Console.WriteLine("\nГлавный инспектор:");
            Console.WriteLine(insp.GetInspector());

            Console.WriteLine("\nПопробуем изменить главного инспектора на Сидорова Ивана Сидоровича:");
            insp.SetInspector("Сидоров Иван Сидорович");

            Console.WriteLine("\nГлавный инспектор:");
            Console.WriteLine(insp.GetInspector());
        }



        // Интерактивная демонстрация
        static void InteractiveDemonstration(FunctionInsp insp)
        {
            void PrintMenu()
            {
                Console.WriteLine("\n\n1. Вывести название инспекции\n2. Вывести всех сотрудников\n3. Вывести Главного инспектора\n4. Установить нового главного инспектора\n5. Сгенерировать госномер\n6. Добавить сотрудника\n0. Выйти");
            }



            while (true)
            {
                PrintMenu();

                string key = Console.ReadLine();
                Console.WriteLine("\n");
                if (key == "0" || key == "")
                {
                    return;
                }
                if (key == "1")
                {
                    Console.WriteLine(insp.GetCarInspection());
                }
                if (key == "2")
                {
                    foreach (string name in insp.GetWorker())
                    {
                        Console.WriteLine(name);
                    }
                }
                if (key == "3")
                {
                    Console.WriteLine("Главный инспектор:");
                    Console.WriteLine(insp.GetInspector());
                }
                if (key == "4")
                {
                    Console.WriteLine("Введите имя инспектора: ");
                    string name = Console.ReadLine();
                    insp.SetInspector(name);
                }
                if (key == "5")
                {
                    while (true)
                    {
                        Console.WriteLine("\n\n1. Случайный госномер\n2. Ввести данные\n3. Случайный госномер с кодом региона 75\n0. Отмена");
                        string _key = Console.ReadLine();
                        if (_key == "0" || _key == "")
                        {
                            break;
                        }
                        if (_key == "1")
                        {
                            var rand = new Random();
                            Console.WriteLine("\n" + insp.GenerateNumber(rand.Next(0, 85)));
                        }
                        if (_key == "2")
                        {
                            Console.WriteLine("Введите номер:");
                            string num = Console.ReadLine();
                            Console.WriteLine("Введите букву:");
                            string letter = Console.ReadLine();
                            Console.WriteLine("Введите код региона: ");
                            string code = Console.ReadLine();

                            try
                            {
                                Console.WriteLine("\n" + insp.GenerateNumber(int.Parse(num), letter, int.Parse(code)));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        if (_key == "3")
                        {
                            Console.WriteLine("\n" + insp.GenerateNumber());
                        }

                    }
                }

                if (key == "6")
                {
                    Console.WriteLine("Введите ФИО сотрудника: ");
                    insp.AddWorker(Console.ReadLine());
                }
            }
        }
    }
}
