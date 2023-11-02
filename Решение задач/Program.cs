using System;
using System.Collections.Generic;

namespace Решение_задач
{
    class Program
    {
        static void Main()
        {
            // Программа TaskManager.
            Console.WriteLine("{0, 72}", "Программа TaskManager\n");

            #region Создание сотрудников компании
            Console.WriteLine("{0, 75}", "Создание сотрудников компании");

            Employee Vitya = new Employee("Витя");
            Employee Maria = new Employee("Мария");
            Employee Anton = new Employee("Антон");
            Employee Volodya = new Employee("Володя");
            Employee Anna = new Employee("Анна");
            Employee Alina = new Employee("Алина");
            Employee Peter = new Employee("Петр");
            Employee Ivan = new Employee("Иван");
            Employee Ilya = new Employee("Илья");
            Employee Anastasia = new Employee("Анастасия");
            Employee Zhenya = new Employee("Женя");

            Console.WriteLine($"Сотрудники компании: {Vitya.EmployeeName}, {Maria.EmployeeName}, {Anton.EmployeeName}, {Volodya.EmployeeName}, {Anna.EmployeeName}, " +
                              $"{Alina.EmployeeName}, {Peter.EmployeeName}, {Ivan.EmployeeName}, {Ilya.EmployeeName}, {Anastasia.EmployeeName}, {Zhenya.EmployeeName}");

            Console.Write("\nЧтобы продолжить выполнение, нажмите на любую кнопку ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Создание проекта и добавление ответсвенного.
            Console.WriteLine("{0, 83}", "Создание проекта и добавление ответсвенного\n");

            Project gameDevelopment = new Project("Разработать компьютерную игру", DateTime.Today.AddYears(1), "ООО GameCompany");
            gameDevelopment.AppointTeamLeader(Vitya);

            Console.WriteLine($"Описание проекта: {gameDevelopment.ProjectDescription}. Срок сдачи: {gameDevelopment.ProjectDeadline.ToLongDateString()}\n" +
                              $"Заказчик: {gameDevelopment.ProjectCustomer}. Ответсвенный: {gameDevelopment.TeamLead.EmployeeName}. Статус проекта: {gameDevelopment.ProjectStatus}");

            Console.Write("\nЧтобы продолжить выполнение, нажмите на любую кнопку ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Создание задач
            Console.WriteLine("{0, 69}", "Создание задач\n");

            Vitya.CreatingTask("Написать сюжет", DateTime.Today.AddMonths(2));
            Vitya.CreatingTask("Выбрать главного героя", DateTime.Today.AddMonths(2));
            Vitya.CreatingTask("Нарисовать текстуры", DateTime.Today.AddMonths(4));
            Vitya.CreatingTask("Нарисовать карту игры", DateTime.Today.AddMonths(1));
            Vitya.CreatingTask("Сделать анимации", DateTime.Today.AddMonths(7));
            Vitya.CreatingTask("Разработать механику игры", DateTime.Today.AddMonths(10));
            Vitya.CreatingTask("Разработать интерфейс", DateTime.Today.AddMonths(6));
            Vitya.CreatingTask("Прорекламировать игру", DateTime.Today.AddMonths(10));
            Vitya.CreatingTask("Протестировать", DateTime.Today.AddMonths(9));
            Vitya.CreatingTask("Исправить ошибки", DateTime.Today.AddMonths(11));

            List<ProjectTask> projectTasks = gameDevelopment.ProjectTasks;

            Console.WriteLine("{0, 68}", "Задачи проекта");
            Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", "Описание", "Срок", "Назначил", "Статус");

            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskAssigner.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }

            Console.Write("\nЧтобы продолжить выполнение, нажмите на любую кнопку ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Распределение задач по работникам
            Console.WriteLine("{0, 72}", "Распределение задач\n");

            Vitya.DistributeTheTask(projectTasks[0], Maria, DateTime.Today.AddDays(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[1], Anton, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[2], Volodya, DateTime.Today.AddDays(2), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[3], Anna, DateTime.Today.AddDays(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[4], Alina, DateTime.Today.AddMonths(2), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[5], Peter, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[6], Ivan, DateTime.Today.AddDays(7), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[7], Ilya, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[8], Anastasia, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[9], Zhenya, DateTime.Today.AddDays(7), DateTime.Today);

            projectTasks = gameDevelopment.ProjectTasks;

            Console.WriteLine("{0, 68}", "Задачи проекта");
            Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", "Описание", "Срок", "Ответсвенный", "Статус");

            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskPerformer.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }

            Console.Write("\nЧтобы продолжить выполнение, нажмите на любую кнопку ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Решения сотрудников компании
            Console.WriteLine("{0, 75}", "Решения сотрудников компании\n");

            Maria.TakeTask();
            Anton.TakeTask();
            Volodya.TakeTask();
            Anna.TakeTask();
            Alina.DelegateTask(Ivan);
            Peter.TakeTask();
            Ivan.TakeTask();
            Ilya.AbandonTheTask();
            Anastasia.AbandonTheTask();
            Zhenya.TakeTask();

            Vitya.DistributeTheTask(projectTasks[8], Alina, DateTime.Today.AddMonths(1), DateTime.Today);
            Alina.TakeTask();

            Vitya.DistributeTheTask(projectTasks[6], Ilya, DateTime.Today.AddDays(7), DateTime.Today);
            Ilya.TakeTask();

            Vitya.DeleteTask(projectTasks[7]);
            Vitya.CreatingTask("Доработать задания", DateTime.Today.AddMonths(7));
            projectTasks = gameDevelopment.ProjectTasks;
            Vitya.DistributeTheTask(projectTasks[9], Anastasia, DateTime.Today.AddMonths(3), DateTime.Today);
            Anastasia.TakeTask();

            Console.WriteLine($"Описание проекта: {gameDevelopment.ProjectDescription}. Срок сдачи: {gameDevelopment.ProjectDeadline.ToLongDateString()}\n" +
                              $"Заказчик: {gameDevelopment.ProjectCustomer}. Ответсвенный: {gameDevelopment.TeamLead.EmployeeName}. Статус проекта: {gameDevelopment.ProjectStatus}\n");

            Console.WriteLine("{0, 68}", "Задачи проекта");
            Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", "Описание", "Срок", "Ответсвенный", "Статус");

            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskPerformer.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }

            Console.Write("\nЧтобы продолжить выполнение, нажмите на любую кнопку ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Симуляция работы над проектом
            Console.WriteLine("{0, 75}", "Симуляция работы над проектом\n");

            Console.WriteLine("{0, 60}", "Отчеты");
            Console.WriteLine("{0, 40} {1, 45} {2, 30}", "Текст отчета", "Дата выполнения отчета", "Ответсвенный");

            for (DateTime date = DateTime.Today; date <= gameDevelopment.ProjectDeadline; date = date.AddDays(1))
            {
                for (int i = 0; i < projectTasks.Count; i++)
                {
                    if ((projectTasks[i].NextTaskReportDate == date) && (projectTasks[i].TaskStatus == TaskStatuses.В_работе))
                    {
                        bool checkResult = false;
                        TaskReport taskReport = projectTasks[i].TaskPerformer.CreatingReport($"Отчет задачи {projectTasks[i].TaskDescription}", date);

                        do
                        {
                            bool result;
                            Random randomNumbers = new Random();
                            int randomNum = randomNumbers.Next(0, 2);

                            if (randomNum == 0)
                            {
                                result = false;
                            }
                            else
                            {
                                result = true;
                            }

                            checkResult = projectTasks[i].TaskAssigner.CheckingTheReport(result, taskReport, date);
                        } while (!checkResult);

                        if (checkResult)
                        {
                            if (date == projectTasks[i].TaskDeadline)
                            {
                                projectTasks[i].CheckingTask(Vitya);
                                projectTasks[i].ProjectToWhichItRelates.TransitionToClosedStatus();
                            }

                            Console.WriteLine("{0, 40} {1, 45} {2, 30}", $"{taskReport.ReportText}", $"{taskReport.DateAcceptanceTheReport.ToLongDateString()}", $"{taskReport.Executor.EmployeeName}");
                        }
                    }
                }
            }

            Console.WriteLine($"\nОписание проекта: {gameDevelopment.ProjectDescription}. Срок сдачи: {gameDevelopment.ProjectDeadline.ToLongDateString()}\n" +
                              $"Заказчик: {gameDevelopment.ProjectCustomer}. Ответсвенный: {gameDevelopment.TeamLead.EmployeeName}. Статус проекта: {gameDevelopment.ProjectStatus}\n");

            Console.WriteLine("{0, 68}", "Задачи проекта");
            Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", "Описание", "Срок", "Ответсвенный", "Статус");

            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskPerformer.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }
            #endregion
        }
    }
}