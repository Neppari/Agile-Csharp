using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lecture_5.Controllers
{
    [ApiController]
    [Route("api")]
    public class ListController : ControllerBase
    {
        private static List<string> names = new List<string>
        { "Arttu", "Mika" };

        [HttpGet("names")]
        public List<string> Get()
        {
            return names;
        }

        [HttpGet("numberlist/{k:int}")]
        public int[] GetNumberArray(int k)
        {
            int[] arr = new int[k];
            for (int i = 0; i < k; i++)
            {
                arr[i] = i + 1;
            }
            return arr;
        }
    }
}
