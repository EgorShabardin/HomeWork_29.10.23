using System;
using System.Collections.Generic;

namespace Решение_задач
{
    /// <summary>
    /// Перечислимый тип, содержащий статусы выполнения задачи.
    /// </summary>
    enum TaskStatuses
    {
        Не_назначена,
        Назначена,
        В_работе,
        На_проверке,
        Выполнена
    }

    /// <summary>
    /// Класс, описывающий задачу проекта.
    /// </summary>
    class ProjectTask
    {
        #region Поля
        private string taskDescription;
        private DateTime taskDeadline;
        private DateTime startDateAfterReport;
        private DateTime nextTaskReportDate;
        private Employee taskAssigner;
        private Employee taskPerformer;
        private TaskStatuses taskStatus;
        private Project projectToWhichItRelates;
        private List<TaskReport> taskReports = new List<TaskReport>();
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле taskDescription.
        /// </summary>
        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле taskDeadline.
        /// </summary>
        public DateTime TaskDeadline
        {
            get
            {
                return taskDeadline;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле startDateAfterReport.
        /// </summary>
        public DateTime StartDateAfterReport
        {
            get
            {
                return startDateAfterReport;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле nextTaskReportDate.
        /// </summary>
        public DateTime NextTaskReportDate
        {
            get
            {
                return nextTaskReportDate;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле taskAssigner.
        /// </summary>
        public Employee TaskAssigner
        {
            get
            {
                return taskAssigner;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле taskPerformer.
        /// </summary>
        public Employee TaskPerformer
        {
            get
            {
                return taskPerformer;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле taskStatus.
        /// </summary>
        public TaskStatuses TaskStatus
        {
            get
            {
                return taskStatus;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле projectToWhichItRelates.
        /// </summary>
        public Project ProjectToWhichItRelates
        {
            get
            {
                return projectToWhichItRelates;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле taskReports.
        /// </summary>
        public List<TaskReport> TaskReports
        {
            get
            {
                return taskReports;
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, позволяющий назначить задаче проекта работника.
        /// </summary>
        /// <param name="newTaskPerformer"> Работник. </param>
        public void AddingTaskPerformer(Employee newTaskPerformer)
        {
            ProjectTask projectTask = newTaskPerformer.AssignedTask as ProjectTask;

            if (projectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект)
            {
                if (projectTask != null)
                {
                    projectTask.taskPerformer = null;
                    projectTask.taskStatus = TaskStatuses.Не_назначена;
                }

                taskPerformer = newTaskPerformer;
                taskStatus = TaskStatuses.Назначена;
            }
        }

        /// <summary>
        /// Метод, меняющий статус задачи проекта на "В работе".
        /// </summary>
        public void TransitionToStatusWork()
        {
            if (projectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект)
            {
                taskStatus = TaskStatuses.В_работе;
            }
        }

        /// <summary>
        /// Метод, назначающий дату отчета по задаче.
        /// </summary>
        /// <param name="taskReportDate"> Дата следующего отчета по задаче. </param>
        /// <param name="dateAfterReport"> Дата начала работы после отчета. </param>
        public void SettingReportDate(DateTime taskReportDate, DateTime dateAfterReport)
        {
            startDateAfterReport = dateAfterReport;
            nextTaskReportDate = taskReportDate;
        }

        /// <summary>
        /// Метод, убиращий работника с выполнения задачи.
        /// </summary>
        public void RemovePerformer()
        {
            if (projectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект)
            {
                taskPerformer = null;
                taskStatus = TaskStatuses.Не_назначена;
            }
        }

        /// <summary>
        /// Метод, добавляющий отчет в список отчетов по задаче.
        /// </summary>
        /// <param name="taskReport"> Отчет о работе над задачей. </param>
        public void AddTaskReportToList(TaskReport taskReport)
        {
            if (taskStatus == TaskStatuses.В_работе)
            {
                taskReports.Add(taskReport);
            }
        }
        
        /// <summary>
        /// Метод, позволяющий назначившему задачу работнику проверить ее.
        /// </summary>
        public void CheckingTask(Employee taskAssigner)
        {
            if (this.taskAssigner == TaskAssigner)
            {
                taskStatus = TaskStatuses.На_проверке;
                TransitionToStageCompleted();
            }
        }

        /// <summary>
        /// Метод, меняющий статус задачи на "Выполнена".
        /// </summary>
        private void TransitionToStageCompleted()
        {
            if (taskStatus == TaskStatuses.На_проверке)
            {
                taskStatus = TaskStatuses.Выполнена;
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, позволяющий создать экземпляр класса ProjectTask.
        /// </summary>
        /// <param name="taskDescription"> Описание задачи. </param>
        /// <param name="taskDeadline"> Дата окончания работы над задачей. </param>
        /// <param name="taskAssigner"> Работник, создавший задачу. </param>
        /// <param name="projectToWhichItRelates"> Проект, к которому задача относиться. </param>
        public ProjectTask(string taskDescription, DateTime taskDeadline, Employee taskAssigner, Project projectToWhichItRelates)
        {
            this.taskDescription = taskDescription;
            this.taskDeadline = taskDeadline;
            this.taskAssigner = taskAssigner;
            this.projectToWhichItRelates = projectToWhichItRelates;
            taskStatus = TaskStatuses.Не_назначена;
            taskPerformer = null;         
        }
        #endregion
    }
}
