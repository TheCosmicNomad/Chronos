﻿using Chronos.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Major> Get (int DegreeID)
        {
            using var db = new AppDbContext();

            IEnumerable<int> MajorIDs = db.Majors.Where(i => i.DegreeID == DegreeID).Select(i => i.MajorID);

            return
              from Major in db.Majors
              join id in MajorIDs on Major.MajorID equals id
              select Major;
        }
    }
}

      