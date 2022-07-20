using ConsumeAPIApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeAPIApp
{
    class Program
    {
        static HttpClient client  = new HttpClient();

        static async Task Main(string[] args)
        {
            await RunAsync();
        }

        private async static Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:49155/");
            //client.BaseAddress = new Uri("http://lb-todo-api-465364725.us-east-1.elb.amazonaws.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                string json;
                HttpResponseMessage response;

                //get all items
                #region GET ALL
                response = await client.GetAsync("/api/getitems");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    IEnumerable<TodoItem> items = JsonConvert.DeserializeObject<IEnumerable<TodoItem>>(json);

                    foreach (TodoItem item in items)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("Internal Server Error");
                }
                #endregion

                //get specific item
                #region GET SPECIFIC ITEM
                //int id = 4;
                //TodoItem item;
                //response = await client.GetAsync($"api/TodoItems/{id}");

                //if (response.IsSuccessStatusCode)
                //{
                //    item = await response.Content.ReadAsAsync<TodoItem>();
                //    Console.WriteLine(item);
                //} else
                //{
                //    Console.WriteLine("Internal Server Error");
                //}

                #endregion

                //add new items
                #region POST NEW ITEM

                //TodoItem item = new TodoItem { id = 9, name = "Lab#8", isComplete = false };
                //json = JsonConvert.SerializeObject(item);

                //response = await client.PostAsJsonAsync("/api/TodoItems", item);

                //Console.WriteLine($"status from POST {response.StatusCode}");
                //response.EnsureSuccessStatusCode();
                //Console.WriteLine($"added resource at {response.Headers.Location}");

                //json = await response.Content.ReadAsStringAsync();

                //Console.WriteLine("todo item has been inserted" + json);

                #endregion

                //update specific item 
                #region PUT UPDATED ITEM

                //TodoItem item = new TodoItem
                //{
                //    id = 3,
                //    name = "Group Project",
                //    isComplete = true
                //};

                //json = JsonConvert.SerializeObject(item);

                //response = await client.PutAsJsonAsync($"/api/TodoItems/{item.id}", item);

                //Console.WriteLine($"status from PUT {response.StatusCode}");
                //response.EnsureSuccessStatusCode();


                #endregion

                //delete specifc item

                #region DELETE ITEM

                //response = await client.DeleteAsync("/api/TodoItems/3");
                //Console.WriteLine($"status from DELETE {response.StatusCode}");
                //response.EnsureSuccessStatusCode();

                #endregion

            }
            catch (Exception ex )
            {

                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();

        }
    }
}
