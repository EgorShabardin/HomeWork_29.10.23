using System;

namespace Решение_задач
{
    /// <summary>
    ///  Класс, описывающий работника.
    /// </summary>
    class Employee
    {
        #region Поля
        private string employeeName;
        private object assignedTask;
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле employeeName.
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле assignedTask.
        /// </summary>
        public object AssignedTask
        {
            get
            {
                return assignedTask;
            }
        }
        #endregion

        #region Методы ответсвенного за проект
        /// <summary>
        /// Метод, позволяющий ответсвенному за проект создавать задачу.
        /// </summary>
        /// <param name="taskDescription"> Описание задачи. </param>
        /// <param name="taskDeadline"> Срок выполнения задачи. </param>
        /// <returns> Возвращает true, если создать задачу возможно, иначе false. </returns>
        public bool CreatingTask(string taskDescription, DateTime taskDeadline)
        {
            Project project = assignedTask as Project;

            if ((project != null) && (project.ProjectStatus == ProjectStatuses.Проект))
            {
                ProjectTask projectTask = new ProjectTask(taskDescription, taskDeadline, this, project);
                project.AddingTaskToList(projectTask);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, позволяющий ответсвенному за проект назначить задачу работнику.
        /// </summary>
        /// <param name="projectTask"> Задача проекта. </param>
        /// <param name="tasPerformer"> Работник, которому назначается задача. </param>
        /// <param name="taskReportDate"> Дата следующего отчета по задаче. </param>
        /// <param name="taskStartDate"> Дата начала работы над задачей. </param>
        /// <returns> Возвращает true, если задачу можно дать работнику задачу, иначе false. </returns>
        public bool DistributeTheTask(ProjectTask projectTask, Employee tasPerformer, DateTime taskReportDate, DateTime taskStartDate)
        {
            Project project = assignedTask as Project;

            if ((project != null) && (projectTask.TaskPerformer == null) && (tasPerformer.AssignedTask == null) && (project.ProjectStatus == ProjectStatuses.Проект))
            {
                tasPerformer.AddTask(projectTask);
                projectTask.AddingTaskPerformer(tasPerformer);
                projectTask.SettingReportDate(taskReportDate, taskStartDate);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод позволяющий ответсвенному за проект удалить задачу.
        /// </summary>
        /// <param name="projectTask"> Удаляемая задача. </param>
        /// <returns> Возвращает true, если удаление задачи возможно, иначе false. </returns>
        public bool DeleteTask(ProjectTask projectTask)
        {
            Project project = assignedTask as Project;

            if ((project != null) && (project.ProjectStatus == ProjectStatuses.Проект))
            {
                project.RemoveTaskFromList(projectTask);

                return true;
            }

            return false;
        }

        #endregion

        #region Методы всех работников
        /// <summary>
        /// Метод, позволяющий добавить задание работнику (заполнить поле assignedTask).
        /// </summary>
        /// <param name="task"> Задание (проект или задача по проекту). </param>
        /// <returns> Возвращает true, если задание добавить возможно, иначе false. </returns>
        public bool AddTask(object task)
        {
            Project project = task as Project;
            ProjectTask projectTask = task as ProjectTask;

            if ((project != null) && (assignedTask == null) && (project.TeamLead == null) && (project.ProjectStatus == ProjectStatuses.Проект))
            {
                assignedTask = project;

                return true;
            }
            else if ((projectTask != null) && (assignedTask == null) && (projectTask.TaskPerformer == null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
            {
                assignedTask = projectTask;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, позволяющий работнику взять задачу в работу.
        /// </summary>
        /// <returns> Возвращает true, если работник может взять задачу, иначе false. </returns>
        public bool TakeTask()
        {
            ProjectTask projectTask = assignedTask as ProjectTask;

            if ((projectTask != null) && (projectTask.ProjectToWhichItRelates != null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
            {
                projectTask.TransitionToStatusWork();
                projectTask.ProjectToWhichItRelates.TransitionToExecutionStatus();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, позволяющий работнику делегировать задачу другому работнику.
        /// </summary>
        /// <param name="newTaskPerformer"> Новый работник, которому назначается задача. </param>
        /// <returns> Возвращает true, если делегирование задачи возможно, иначе false. </returns>
        public bool DelegateTask(Employee newTaskPerformer)
        {
            ProjectTask projectTask = assignedTask as ProjectTask;

            if ((projectTask != null) && (projectTask.ProjectToWhichItRelates != null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
            {
                projectTask.AddingTaskPerformer(newTaskPerformer);

                assignedTask = null;
                newTaskPerformer.assignedTask = projectTask;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, позволяющий работнику отказаться от задачи.
        /// </summary>
        /// <returns> Возвращает true, если отказаться от задачи возможно, иначе false. </returns>
        public bool AbandonTheTask()
        {
            ProjectTask projectTask = assignedTask as ProjectTask;

            if ((projectTask != null) && (projectTask.ProjectToWhichItRelates != null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
            {
                projectTask.RemovePerformer();
                assignedTask = null;

                return true;
             }

            return false;
        }

        /// <summary>
        /// Метод, позволяющий работнику создавать отчеты о ходе выполнения задачи.
        /// </summary>
        /// <param name="reportText"> Текст отчета. </param>
        /// <param name="dateAfterReport"> Дата начала работы после отчета. </param>
        /// <returns> Возвращает true, если создание отчета возможно, иначе false. </returns>
        public TaskReport CreatingReport(string reportText, DateTime dateAfterReport)
        {
            ProjectTask projectTask = assignedTask as ProjectTask;

            if ((projectTask != null) && (projectTask.TaskStatus == TaskStatuses.В_работе))
            {
                TaskReport taskReport = new TaskReport(reportText, this, projectTask);
                DateTime nextTaskReportDate = projectTask.NextTaskReportDate.Add(projectTask.NextTaskReportDate.Subtract(projectTask.StartDateAfterReport));

                if (nextTaskReportDate <= projectTask.TaskDeadline)
                {
                    projectTask.SettingReportDate(nextTaskReportDate, dateAfterReport);
                }
                else
                {
                    projectTask.SettingReportDate(projectTask.TaskDeadline, dateAfterReport);
                }

                return taskReport;
            }

            return null;
        }

        /// <summary>
        /// Метод, позволяющий работнику, назначившему задачу проверить отчет.
        /// </summary>
        /// <param name="checkResult"> Результат проверки (true - отчет утвержден, false - отчет нужно доработать). </param>
        /// <param name="taskReport"> Отчет о работе над задачей пректа. </param>
        /// <param name="date"> Дата проекрки отчета. </param>
        /// <returns> Возвращает true, если отчет утвержден. Возвращает flase, если проверка отчета невозможна или отчет нужно доработать. </returns>
        public bool CheckingTheReport(bool checkResult, TaskReport taskReport, DateTime date)
        {
            if (taskReport.TaskToWhichReportBelongs.TaskAssigner == this)
            {
                if (checkResult)
                {
                    taskReport.AddReportAcceptanceDate(date);
                    taskReport.TaskToWhichReportBelongs.AddTaskReportToList(taskReport);
                    return true;
                }
                else
                {
                    taskReport.RewriteTheTaskReport();
                    return false;
                }
            }

            return false;
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Кончтруктор, позволяющий создать экземпляр класса Employee.
        /// </summary>
        /// <param name="employeeName"> Имя работника. </param>
        public Employee(string employeeName)
        {
            this.employeeName = employeeName;
        }
        #endregion
    }
}
