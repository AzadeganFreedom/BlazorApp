using System.Data.SqlClient;

namespace BlazorApp.Data
{
    
    public class Artist
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Url { get; set; }

        
    }
}
