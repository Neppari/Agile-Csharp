using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Homework_5.Models;
using Homework_5.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework_5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntriesController : ControllerBase
    {

        [HttpGet]
        public List<Entry> Get() =>
            EntriesRepository.Instance.Entries;

        [HttpGet("{id:int}")]
        public Entry GetEntry(int id)
        {
            Entry entry = EntriesRepository.Instance.GetEntries()
                .SingleOrDefault(x => x.Id.Equals(id));

            return entry;
        }

        [HttpPost]
        public string Post([FromBody] Entry entry)
        {
            EntriesRepository.Instance.AddEntry(entry);
            return "Entry added successfully!";
        }
    }
}
