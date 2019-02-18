﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithnet.GoogleApps
{
    public static class Settings
    {
        public static bool DisableGzip { get; set; }
        public static TimeSpan DefaultTimeout => new TimeSpan(0, 2, 0);
    }
}
