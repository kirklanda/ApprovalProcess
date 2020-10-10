using System;
using System.Linq;

namespace ApprovalProcessPersistence
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ExampleContext())
            {
                /*
                // Create
                Console.WriteLine("Inserting a new ExampleModel");
                db.Add(new ExampleModel { Name = "Bob" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Query for an ExampleModel");
                var exModel = db.ExampleModels
                    .OrderBy(m => m.ExampleModelId)
                    .First();
                Console.WriteLine("Model name is " + exModel.Name);
                */

                Console.WriteLine("Inserting new Order");
                Order anOrder = new Order();
                OrderLineItem anItem = new OrderLineItem { Amount = 5.99M };
                anOrder.OrderLineItems.Add(anItem);

                db.Add(anOrder);
                db.SaveChanges();
            }
        }
    }
}
