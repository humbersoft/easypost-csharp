﻿using System;

namespace EasyPost {
    public class CarrierDetail {
        public DateTime? guaranteed_delivery_date { set; get; }
        public string origin_location { get; set; }
        public string destination_location { get; set; }
        public string service { set; get; }
        public string container_type { set; get; }
        public string est_delivery_date_local { set; get; }
        public string est_delivery_time_local { set; get; }
    }
}