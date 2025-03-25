using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using mpt_rest.MockDatabase;
using mpt_rest.Dtos;
using mpt_rest.Validators;
using mpt_rest.Models;

namespace mpt_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly IMapper _mapper;
        private readonly IManager _ticketManager;

        public TicketController(ILogger<TicketController> logger, IMapper mapper, IManager ticketManager)
        {
            _logger = logger;
            _mapper = mapper;
            _ticketManager = ticketManager;
        }

        /// <summary>
        /// ��������� ������
        /// </summary>
        [HttpPost]
        public IResult SaveTicket(TicketSaveDto ticketDto)
        {
            var validator = new TicketDtoValidator();
            var result = validator.Validate(ticketDto); //������ ��������� ����� - �� ������ ������ ���. ����� ������ � ���������
            if (!result.IsValid)
            {
                return Results.BadRequest(result.ToString());
            }

            ticketDto.VisitDate = ticketDto.VisitDate.ToUniversalTime();
            var newTicket = _mapper.Map<Ticket>(ticketDto);
            var ticketId = _ticketManager.AddTicket(newTicket);
            return Results.Ok(ticketId);
        }

        /// <summary>
        /// �������� ������ ������
        /// </summary>
        /// <param name = "from">���� ������, ��</param>
        /// <param name = "to">���� ������, ��</param>
        [HttpGet]
        public IResult GetTickets(DateTime from, DateTime to)
        {
            if (from > to)
            {
                return Results.BadRequest($"������ ��������� {from} �� ����� ���� ������ ��������� {to}");
            }
            var allTickets = _ticketManager.GetTickets();
            var matchingTickets = allTickets.Where(p => (p.VisitDate >= from && p.VisitDate <= to));
            return Results.Ok(matchingTickets);
        }
    }
}
