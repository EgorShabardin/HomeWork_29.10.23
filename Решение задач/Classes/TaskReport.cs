using System;

namespace Решение_задач
{
    class TaskReport
    {
        #region Поля
        private string reportText;
        private DateTime dateAcceptanceTheReport;
        private Employee executor;
        private ProjectTask taskToWhichReportBelongs;
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле reportText.
        /// </summary>
        public string ReportText
        {
            get
            {
                return reportText;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле dateAcceptanceTheReport.
        /// </summary>
        public DateTime DateAcceptanceTheReport
        {
            get
            {
                return dateAcceptanceTheReport;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле executor.
        /// </summary>
        public Employee Executor
        {
            get
            {
                return executor;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле taskToWhichReportBelongs.
        /// </summary>
        public ProjectTask TaskToWhichReportBelongs
        {
            get
            {
                return taskToWhichReportBelongs;
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, позволяющий установить дату завершения работы над отчетом.
        /// </summary>
        /// <param name="dateCompletionReport"> Дата завершения работы над отчетом. </param>
        public void AddReportAcceptanceDate(DateTime dateCompletionReport)
        {
            dateAcceptanceTheReport = dateCompletionReport;
        
        }

        /// <summary>
        /// Метод, позволяющий переписать отчет о работне над задачей.
        /// </summary>
        public void RewriteTheTaskReport()
        {
            reportText = $"Отчет на тему {taskToWhichReportBelongs.TaskDescription}";
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, позволяющий создать экземпляр класса TaskReport.
        /// </summary>
        /// <param name="reportText"> Текст отчета. </param>
        /// <param name="executor"> Работник, ответсвенный за отчет. </param>
        /// <param name="taskToWhichReportBelongs"> Задача, к которой отчет принадлежит. </param>
        public TaskReport(string reportText, Employee executor, ProjectTask taskToWhichReportBelongs)
        {
            this.reportText = reportText;
            this.executor = executor;
            this.taskToWhichReportBelongs = taskToWhichReportBelongs;
        }
        #endregion
    }
}
