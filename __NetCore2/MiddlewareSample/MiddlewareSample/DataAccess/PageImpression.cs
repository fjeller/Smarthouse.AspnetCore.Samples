﻿using System;
using System.Collections.Generic;

namespace MiddlewareSample.DataAccess.DataAccess
{
    public partial class PageImpression
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public int Count { get; set; }
    }
}