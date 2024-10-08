using AutoMapper;
using GamblingGameWebApi.Applications.GambleRequests.Commands;
using GamblingGameWebApi.Entities.Domains.GambleRequests;
using Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamblingGameWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendGambleRequestController : ControllerBase
    {
        private ICommandHandler<SendRequestCommand, GambleResponse> _sendRequestCommandHandler;
        private IMapper _mapper;
        public SendGambleRequestController(
            ICommandHandler<SendRequestCommand, GambleResponse> sendRequestCommandHandler,
            IMapper mapper)
        {
            _sendRequestCommandHandler = sendRequestCommandHandler;
            _mapper = mapper;
        }

        // GET: api/<SendGambleRequestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SendGambleRequestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SendGambleRequestController>
        [HttpPost]
        public async Task Post([FromBody] GambleRequestDto gambleRequestDto)
        {
            GambleRequest gambleRequest = _mapper.Map<GambleRequest>(gambleRequestDto);
            SendRequestCommand sendRequestCommand = new()
            {
                gambleRequest = gambleRequest
            };

            GambleResponse gambleResponse = await _sendRequestCommandHandler.HandleAsync(sendRequestCommand);
        }

        // PUT api/<SendGambleRequestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SendGambleRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
