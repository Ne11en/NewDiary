using NewDiary.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NewDiary;

public static class DatabaseRequests
{
    
    public static string activeUser = "";
    
    public static void CreateNewUser()
    {
        Console.WriteLine("Введите login ");
        string login = Console.ReadLine();
        Console.WriteLine("Введите password ");
        string password = Console.ReadLine();

        Models.User newClient = new User()
        {
            Login = login,
            Password = password
        };
        try
        {
            DatabaseServisce.GetDbContext().Users.Add(new User());
            DatabaseServisce.GetDbContext().SaveChanges();
        }
        catch 
        {
            Console.WriteLine("Такой пользователь уже существует");
        }
        
    }
    
    public static bool LoginUser()
    {
        Console.WriteLine("Введите login ");
        string login = Console.ReadLine();
        Console.WriteLine("Введите password ");
        string password = Console.ReadLine();

        var searchedUser = DatabaseServisce.GetDbContext().Users
            .FirstOrDefault(n => n.Login == login && n.Password == password);

        if (searchedUser != null)
        {
            activeUser = searchedUser.Login;
            return true;
        }

        return false;
    }
    
    public static void CreateNewTask()
    {
        Console.WriteLine("Введите название задачи: ");
        string nameTask = Console.ReadLine();
        Console.WriteLine("Введите описание задачи: ");
        string descriptionTask = Console.ReadLine();
        Console.WriteLine("Введите дату в формате гггг-мм-дд ");
        DateOnly taskDate = new DateOnly();
        try
        {
            taskDate = DateOnly.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Неверный формат даты");
            return;
        }

        Models.Diary newDiary = new Diary()
        {
            Userlogin = activeUser,
            NameTask = nameTask,
            DescriptionTask = descriptionTask,
            TaskDate = taskDate
        };
        DatabaseServisce.GetDbContext().Diaries.Add(newDiary);
        DatabaseServisce.GetDbContext().SaveChanges();
    }
    
    public static void DeleteTask(int id)
    {
        var DeleteTask = DatabaseServisce.GetDbContext().Diaries.FirstOrDefault(n => n.IdTask == id && n.Userlogin == activeUser);
        if (DeleteTask != null)
        {
            DatabaseServisce.GetDbContext().Diaries.Remove(DeleteTask);
            DatabaseServisce.GetDbContext().SaveChanges();
        }
    }
    
    public static void UpdateTask(int id)
    {
        Console.WriteLine("Введите название задачи: ");
        string nameTask = Console.ReadLine();
        Console.WriteLine("Введите описание задачи: ");
        string descriptionTask = Console.ReadLine();
        Console.WriteLine("Введите дату в формате гггг-мм-дд ");
        DateOnly taskDate = new DateOnly();
        try
        {
            taskDate = DateOnly.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Неверный формат даты");
            return;
        }

        var updateTask = DatabaseServisce.GetDbContext().Diaries.FirstOrDefault(n => n.IdTask == id);
        if (updateTask != null)
        {
            updateTask.NameTask = nameTask;
            updateTask.DescriptionTask = descriptionTask;
            updateTask.TaskDate = taskDate;
            DatabaseServisce.GetDbContext().SaveChanges();
        }

    }
    
    public static void WriteTodayTasks()
    {
        string today = DateTime.Today.ToString();
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.Userlogin == activeUser && task.TaskDate == DateOnly.Parse(today))
                Console.WriteLine($"Id: {task.IdTask} \nНазвание: {task.NameTask} \nЗадача: {task.DescriptionTask} \nДата выполнения: {task.TaskDate}");
        }
    }
    
    public static void WriteTomorrowTasks()
    {
         string tomorrow = DateOnly.FromDateTime(DateTime.Today.AddDays(1)).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.Userlogin == activeUser && task.TaskDate == DateOnly.Parse(tomorrow))
                Console.WriteLine($"Id: {task.IdTask} \nНазвание: {task.NameTask} \nЗадача: {task.DescriptionTask} \nДата выполнения: {task.TaskDate}");
        }
    }
    
    public static void WriteWeekTasks()
    {
        int weekConvert = (int)DateTime.Today.DayOfWeek;
        if (weekConvert == 0)
        {
            weekConvert = 7;
        }

        string today = DateOnly.FromDateTime(DateTime.Today).ToString();
        string week = DateOnly.FromDateTime(DateTime.Today.AddDays(7 - weekConvert)).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.Userlogin == activeUser && task.TaskDate >= DateOnly.Parse(today) && task.TaskDate <= DateOnly.Parse(week))
                Console.WriteLine($"Id: {task.IdTask} \nНазвание: {task.NameTask} \nЗадача: {task.DescriptionTask} \nДата выполнения: {task.TaskDate}");
        }
    }
    
    public static void WriteAllTasks()
    {
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.Userlogin == activeUser)
                Console.WriteLine($"Id: {task.IdTask} \nНазвание: {task.NameTask} \nЗадача: {task.DescriptionTask} \nДата выполнения: {task.TaskDate}");
        }
    }
    
    public static void WriteUpcomingTasks()
    {
        string today = DateOnly.FromDateTime(DateTime.Today).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.Userlogin == activeUser && task.TaskDate >= DateOnly.Parse(today))
                Console.WriteLine($"Id: {task.IdTask} \nНазвание: {task.NameTask} \nЗадача: {task.DescriptionTask} \nДата выполнения: {task.TaskDate}");
        }
    }
    
    public static void WritePastTasks()
    {
        string today = DateOnly.FromDateTime(DateTime.Today).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.Userlogin == activeUser && task.TaskDate <= DateOnly.Parse(today))
                Console.WriteLine($"Id: {task.IdTask} \nНазвание: {task.NameTask} \nЗадача: {task.DescriptionTask} \nДата выполнения: {task.TaskDate}");
        }
    }

}
