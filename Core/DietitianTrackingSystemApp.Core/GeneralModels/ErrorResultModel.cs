﻿using Newtonsoft.Json;

namespace DietitianTrackingSystemApp.Core.GeneralModels
{
    public class ErrorResultModel
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}