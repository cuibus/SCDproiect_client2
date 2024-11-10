using System.Net.Http.Headers;
using System.Text.Json;

namespace WinFormsApp1
{
    internal class PostService
    {
        static HttpClient client = new HttpClient();

        public void createConnection()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:8082/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Post> GetPosts()
        {
            List<Post> posts = null;
            HttpResponseMessage response = client.GetAsync("post").Result;
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("received : " + resultString);
                posts = JsonSerializer.Deserialize<List<Post>>(resultString);
                return posts;

            }
            return null;
        }

        public List<User> GetActiveUsers()
        {
            List<Post> posts = this.GetPosts();
            return posts.Select(p => p.user).Where(u => u != null).DistinctBy(c => c.name).ToList();
        }
    }
}
