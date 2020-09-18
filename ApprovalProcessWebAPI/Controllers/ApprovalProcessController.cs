using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApprovalProcessWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApprovalProcessWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalProcessController : ControllerBase
    {
        // GET: api/<ApprovalProcessController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // TODO: Get the current state?  What should a get do?  Return a JSON structure
            // that describes the state machine?
            ExampleApprovalProcess exAppProcess = ExampleApprovalProcess.GetInstance();
            return exAppProcess.ApprovalWorkflow.PossibleTransitions();
            //return new string[] { "value1", "value2" };
        }

        [HttpGet("transitions")]
        public IEnumerable<string> GetTransitions()
        {
            ExampleApprovalProcess exAppProcess = ExampleApprovalProcess.GetInstance();
            return exAppProcess.ApprovalWorkflow.PossibleTransitions();
        }

        [HttpPut]
        public void Put(TransitionViewModel transition)
        {
            ExampleApprovalProcess exAppProcess = ExampleApprovalProcess.GetInstance();
            exAppProcess.ApprovalWorkflow.Transition(transition.Name);
        }

        // GET api/<ApprovalProcessController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApprovalProcessController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApprovalProcessController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApprovalProcessController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
