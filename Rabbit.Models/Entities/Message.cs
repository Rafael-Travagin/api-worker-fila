﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Models.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
    }
}
