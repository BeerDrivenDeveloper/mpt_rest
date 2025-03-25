using mpt_rest.Models;

namespace mpt_rest.MockDatabase
{
    public interface IManager
    {
        public List<Ticket> GetTickets();
        public long? AddTicket(Ticket ticket);
    }
}
