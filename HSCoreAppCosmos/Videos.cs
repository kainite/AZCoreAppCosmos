using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace HSCoreAppCosmos
{
    class Videos : TableEntity
    {
        public string url { get; set; }
        public Videos()
        {

        }

        public Videos(string p_id,string p_name,string p_url)
        {
            PartitionKey = p_id;
            RowKey = p_name;
            url = p_url;
        }
    }
}
