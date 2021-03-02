using RobinHoodDownload.API.Models;
using RobinHoodDownload.DataModel.Common;
using System;
using System.Collections.Generic;

namespace RobinHoodDownload.DataModels.CoreDataModel
{

    public class OutRecordsListData<T> : StatusOut
    {
    
        public List<T> Data { get; set; } = new List<T>();

      
        public OutRecordsListData()
        {
        }

       
    }
}