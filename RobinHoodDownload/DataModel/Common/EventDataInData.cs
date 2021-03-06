﻿using RobinHoodDownload.DataModel.Common;
using System;

namespace RobinHoodDownload.DataModels.Common
{
    public class EventDataInData : DataModelBase
    {
        public int EventFunctionalSeqNumb { get; set; } = 0;
        public string ProcessID { get; set; } = string.Empty;
        public DateTime EffectiveEventDate { get; set; } = DateTime.MinValue;

    }

}