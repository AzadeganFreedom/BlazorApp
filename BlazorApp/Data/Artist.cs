using System.Data.SqlClient;

namespace BlazorApp.Data
{
    
    public class Artist
    {
        //Use the same property names here to make a SQL table
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public string Url { get; set; }

        
    }
}
