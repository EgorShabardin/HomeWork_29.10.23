using System;
using System.Collections.Generic;

namespace Решение_задач
{
    /// <summary>
    /// Перечислимый тип, содержащий статусы выполнения проекта.
    /// </summary>
    enum ProjectStatuses
    {
        Проект,
        Исполнение,
        Закрыт
    }
    
    /// <summary>
    /// Класс, описывающий проект.
    /// </summary>
    class Project
    {
        #region Поля
        private string projectDescription;
        private DateTime projectDeadline;
        private string projectCustomer;
        private Employee teamLead;
        private ProjectStatuses projectStatus;
        private List<ProjectTask> projectTasks = new List<ProjectTask>();
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле projectDescription.
        /// </summary>
        public string ProjectDescription
        {
            get
            {
                return projectDescription;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле projectDeadline.
        /// </summary>
        public DateTime ProjectDeadline
        {
            get
            {
                return projectDeadline;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле projectCustomer.
        /// </summary>
        public string ProjectCustomer
        {
            get
            {
                return projectCustomer;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле teamLead.
        /// </summary>
        public Employee TeamLead
        {
            get
            {
                return teamLead;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле projectStatus.
        /// </summary>
        public ProjectStatuses ProjectStatus
        {
            get
            {
                return projectStatus;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле projectTasks.
        /// </summary>
        public List<ProjectTask> ProjectTasks
        {
            get
            {
                return projectTasks;
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, позволяющий назначить ответсвенного за проект.
        /// </summary>
        /// <param name="teamLead"> Работник, назначаемый на должность ответсвенного за проект. </param>
        /// <returns> Возвращает true, если назначение возможно, иначе false. </returns>
        public bool AppointTeamLeader(Employee teamLead)
        {
            if ((teamLead.AssignedTask == null) && (this.teamLead == null) && (projectStatus == ProjectStatuses.Проект))
            {
                teamLead.AddTask(this);
                this.teamLead = teamLead;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, позволяющий добавить новую задачу в список задач проекта.
        /// </summary>
        /// <param name="projectTask"> Задача проекта. </param>
        /// <returns> Возвращает true, если добавление возможно, иначе false. </returns>
        public bool AddingTaskToList(ProjectTask projectTask)
        {
            if (projectStatus == ProjectStatuses.Проект)
            {
                projectTasks.Add(projectTask);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, позволяющий удалить задачу из списка задач проекта.
        /// </summary>
        /// <param name="projectTask"> Задача проекта. </param>
        /// <returns> Возвращает true, если удаление возможно, иначе false. </returns>
        public bool RemoveTaskFromList(ProjectTask projectTask)
        {
            if (projectStatus == ProjectStatuses.Проект)
            {
                projectTasks.Remove(projectTask);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, переводящий проект в статус "Исполнение".
        /// </summary>
        public void TransitionToExecutionStatus()
        {
            if (projectStatus == ProjectStatuses.Проект)
            {
                bool checkResult = true;

                for (int i = 0; i < projectTasks.Count; i++)
                {
                    if (projectTasks[i].TaskStatus != TaskStatuses.В_работе)
                    {
                        checkResult = false;
                        break;
                    }
                }

                if (checkResult)
                {
                    projectStatus = ProjectStatuses.Исполнение;
                }
            }
        }

        /// <summary>
        /// Метод, переводящий проект в статус "Закрыт".
        /// </summary>
        public void TransitionToClosedStatus()
        {
            if (projectStatus == ProjectStatuses.Исполнение)
            {
                bool checkResult = true;

                for (int i = 0; i < projectTasks.Count; i++)
                {
                    if (projectTasks[i].TaskStatus != TaskStatuses.Выполнена)
                    {
                        checkResult = false;
                        break;
                    }
                }

                if (checkResult)
                {
                    projectStatus = ProjectStatuses.Закрыт;
                }
            }
        }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, позволяющий создать экземпляр класса Project.
        /// </summary>
        /// <param name="projectDescription"> Описание проекта. </param>
        /// <param name="projectDeadline"> Срок выполнения проекта. </param>
        /// <param name="projectCustomer"> Заказчик проекта. </param>
        public Project(string projectDescription, DateTime projectDeadline, string projectCustomer)
        {
            this.projectDescription = projectDescription;
            this.projectDeadline = projectDeadline;
            this.projectCustomer = projectCustomer;
            projectStatus = ProjectStatuses.Проект;
            teamLead = null;
        }
        #endregion
    }

}
