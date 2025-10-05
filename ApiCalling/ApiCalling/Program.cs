using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System;

class Program
{
    // Reuse a single static HttpClient instance
    private static readonly HttpClient httpClient = new HttpClient();

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting API Load Tester...");

        while (true) // Run forever
        {
            int parallelRequests = 5;

            var tasks = new Task[parallelRequests];

            for (int i = 0; i < parallelRequests; i++)
            {
                tasks[i] = Task.Run(() => CallApi(i));
            }

            await Task.WhenAll(tasks);

            await Task.Delay(20000); // Wait between request batches
        }
    }

    static async Task CallApi(int requestId)
    {
        try
        {
            // Send POST request to the correct API endpoint
            var response = await httpClient.PostAsync("https://localhost:7124/api/CuttingDown/transfer", null);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Request {requestId} - Status: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Request {requestId} - Error: {ex.Message}");
        }
    }
}
