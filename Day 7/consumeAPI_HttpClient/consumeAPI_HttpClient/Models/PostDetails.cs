namespace consumeAPI_HttpClient.Models
{
    public class PostDetails
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public int userId { get; set; }

        private static List<PostDetails> postList = new List<PostDetails>();

        public List<PostDetails> GetPostDetails()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var call = client.GetAsync(url).Result;

            if (call.IsSuccessStatusCode)
            {
                var data = call.Content.ReadAsAsync<List<PostDetails>>(); //need to add package
                                                                          //Microsoft.AspNet.WebApi.Client

                data.Wait();
                postList = data.Result;

            }
            else
            {
                throw new Exception("Could not get data please contact admin");
            }

            return postList;
        }

    }
}
