namespace mpt_rest.Dtos
{
    public class TicketSaveDto
    {
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
