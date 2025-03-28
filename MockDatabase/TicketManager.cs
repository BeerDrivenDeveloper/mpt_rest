﻿using mpt_rest.Models;
//Тут что-то странное происходит. Переделать бы это на простую InMemory-базейку, но если пользоваться можно, то пусть будет так

namespace mpt_rest.MockDatabase
{
    /// <summary>
    /// Менеджер для работы с БД
    /// Синглтон-заглушка, чтоб не мудрить с базой ради тестового задания
    /// </summary>
    public class TicketManager : IManager
    {
        private readonly Dictionary<string, List<Ticket>> _tickets;
        private readonly object _lock;

        private readonly string _context;

        public TicketManager(string context)
        {
            _context = context;
            _tickets = new Dictionary<string, List<Ticket>> { { _context, new List<Ticket>() } };
            _lock = new object();
        }

        /// <summary>
        /// Возвращаем список. Так как эмулируем базу, то будем тут клонировать, чтоб оригинал не трогать
        /// </summary>
        /// <returns></returns>
        public List<Ticket> GetTickets()
        {
            List<Ticket> res;

            lock (_lock)
            {
                res = _tickets[_context].Select(t => new Ticket()
                {
                    ID = t.ID,
                    Title = t.Title,
                    CreationDate = t.CreationDate,
                    Description = t.Description,
                    VisitDate = t.VisitDate,
                    VisitorsNumber = t.VisitorsNumber
                }).ToList();
            }

            return res;
        }

        /// <summary>
        /// Добавляем тоже как типовое поведение всех причуд для работы с базой
        /// </summary>
        /// <param name="ticket"></param>
        public long? AddTicket(Ticket ticket) //поменял интерфейс. в этой реализации
        {
            if (ticket == null || ticket.ID.HasValue)
                return -1;

            lock (_lock)
            {
                ticket.ID = _tickets[_context].Count; //тут был баг - отсутствовало [_context], из-за чего Count и, соответственно, ID поулчались некорректными

                _tickets[_context].Add(new Ticket()
                {
                    ID = ticket.ID,
                    Title = ticket.Title,
                    VisitDate = ticket.VisitDate,
                    VisitorsNumber = ticket.VisitorsNumber,
                    Description = ticket.Description,
                    CreationDate = DateTime.UtcNow
                });
            }

            return ticket.ID;
        }
    }
}
