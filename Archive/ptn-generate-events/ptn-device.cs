using System;
using System.Collections.Generic;
using System.Text;

namespace ptn_generate_events
{
    public class PTNDevice
    {
        public int DeviceId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Value { get; set; }
        public int Value_Quality { get; set; }

        public string Summary;
    }
}
