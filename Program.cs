using NewDiary;
using System;

namespace NewDiary;

internal class Program
{


    static void Main()
    {
        string choose = "";
        int IdTask = 0;
        bool run = true;
        bool flag = true;
        
        while (flag2)
        {
            Console.WriteLine("1 - зарегистрироватся \n2 - Войти");
            choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    DatabaseRequests.CreateNewUser();
                    break;
                case "2":
                    DatabaseRequests.LoginUser();
                    if (DatabaseRequests.activeUser != "")
                    {
		   flag = false;
                    } 
                    break;
                default:
                    Console.WriteLine("Неверный формат ввода");
                    break;
            }
        }
        
        while (run)
        {
            Console.WriteLine(
                " \n Введите команду: \n 1 - Добавить задачу \n 2 - Удалить задачу \n 3 - Все задачи \n 4 - Предстоящие задачи \n 5 - Прошедшие задачи \n 6 - Задачи на сегодня \n 7 - Задачи на завтра \n 8 - Задачи на эту неделю \n 9 - Изменить задачу \n 0 - Выход");
            choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    DatabaseRequests.CreateNewTask();
                    break;
                case "2":
                    Console.WriteLine("Введите id задачи, которую хотите удалить: ");
                    IdTask = int.Parse(Console.ReadLine());
                    DatabaseRequests.DeleteTask(IdTask);
                    break;
                case "3":
                    DatabaseRequests.WriteAllTasks();
                    break;
                case "4":
                    DatabaseRequests.WriteUpcomingTasks();
                    break;
                case "5":
                    DatabaseRequests.WritePastTasks();
                    break;
                case "6":
                    DatabaseRequests.WriteTodayTasks();
                    break;
                case "7":
                    DatabaseRequests.WriteTomorrowTasks();
                    break;
                case "8":
                    DatabaseRequests.WriteWeekTasks();
                    break;
                case "9":
                    Console.WriteLine("Введите id задачи, которую хотите изменить: ");
                    IdTask = int.Parse(Console.ReadLine());
                    DatabaseRequests.UpdateTask(IdTask);
                    break;
                case "0":
                    Console.WriteLine("Хорошего дня!:) ");
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Введена неправильная команда.");
                    break;
            }
        }
    }
}
