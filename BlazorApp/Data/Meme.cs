using System.Data.SqlClient;

namespace BlazorApp.Data
{
    
    public class Meme
    {

        public int Id { get; set; }
        public string MemeName { get; set; }
        public string Url { get; set; }

        
    }
}
