using Microsoft.Azure.Cosmos.Table;
using System;
using System.Threading.Tasks;

namespace HSCoreAppCosmos
{
    class Program
    {
        static string connection_string= "DefaultEndpointsProtocol=https;AccountName=hugosilvastorageacc;AccountKey=nFrfgm3JtMCNjEMqGiVq9PXUTkD5k3C6KOCm1/is4+1NstuAJ3XM5r3NFH41DNuZI5C2umNRWC5fmK11ilFLzA==;EndpointSuffix=core.windows.net";
        static void Main(string[] args)
        {
            //NewVideo().Wait();
            //ReadVideo().Wait();
            //UpdateVideo().Wait();
            //DeleteVideo().Wait();
            Console.ReadLine();
        }

        static async Task NewVideo()
        {
            CloudStorageAccount p_account = CloudStorageAccount.Parse(connection_string);
            
            CloudTableClient p_tableclient = p_account.CreateCloudTableClient();
            
            CloudTable p_table = p_tableclient.GetTableReference("Videos");

            Videos obj = new Videos("1", "Hugo Silva Youtube", "https://www.youtube.com/c/HugoSilvaRocha");
            TableOperation p_operation = TableOperation.Insert(obj);
            TableResult response = await p_table.ExecuteAsync(p_operation);

            Console.WriteLine("Entity added");
        }

        static async Task ReadVideo()
        {
            CloudStorageAccount p_account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient p_tableclient = p_account.CreateCloudTableClient();

            CloudTable p_table = p_tableclient.GetTableReference("Videos");

            string partition_key = "1";
            string rowkey = "Hugo Silva Youtube";

            TableOperation p_operation = TableOperation.Retrieve<Videos>(partition_key, rowkey);
            TableResult response = await p_table.ExecuteAsync(p_operation);

            Videos return_obj = (Videos)response.Result;

            Console.WriteLine("Customer ID is {0}", return_obj.PartitionKey);
            Console.WriteLine("Customer Name is {0}", return_obj.RowKey);
            Console.WriteLine("Customer Url is {0}", return_obj.url);


        }

        static async Task UpdateVideo()
        {
            CloudStorageAccount p_account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient p_tableclient = p_account.CreateCloudTableClient();

            CloudTable p_table = p_tableclient.GetTableReference("Videos");

            string partition_key = "1";
            string rowkey = "Hugo Silva Youtube";

            Videos updated_obj = new Videos(partition_key, rowkey, "http://hugorsilva.blogspot.com/");

            TableOperation p_operation = TableOperation.InsertOrReplace(updated_obj);
            TableResult response = await p_table.ExecuteAsync(p_operation);
            Console.WriteLine("Entity updated");

        }

        static async Task DeleteVideo()
        {
            CloudStorageAccount p_account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient p_tableclient = p_account.CreateCloudTableClient();

            CloudTable p_table = p_tableclient.GetTableReference("Videos");

            string partition_key = "1";
            string rowkey = "Hugo Silva Youtube";

            TableOperation p_operation = TableOperation.Retrieve<Videos>(partition_key, rowkey);
            TableResult response = await p_table.ExecuteAsync(p_operation);

            Videos return_obj = (Videos)response.Result;


            TableOperation p_delete = TableOperation.Delete(return_obj);

            response = await p_table.ExecuteAsync(p_delete);
            Console.WriteLine("Entity deleted");

        }
    }
    }
