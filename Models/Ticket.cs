﻿namespace mpt_rest.Models
{
    public class Ticket //тикет из прошлой реализации, без постановки сложно понять, нужны ли изменения
    {   /// <summary>
        /// Идентификатор
        /// </summary>
        public long? ID { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата посещения
        /// </summary>
        public DateTime VisitDate { get; set; }

        /// <summary>
        /// Количество людей
        /// </summary>
        public int VisitorsNumber { get; set; }
    }
}
