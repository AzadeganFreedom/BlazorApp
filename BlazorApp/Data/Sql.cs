using System.Data.SqlClient;

namespace BlazorApp.Data
{
    public class Sql
    {
        //When making a SQL table in ArtistDB, name it 
        static string connectionString = "Data Source=.;Initial Catalog=ArtistDB;User ID=sa;Password=Passw0rd;";//The data source is originally: 192.168.2.3 (PC2)


        public static List<Artist> Read()
        {
            List<Artist> list = new List<Artist>();
            SqlConnection con = new(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ArtistTable order by name", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Artist artist = new Artist() 
                { 
                    Id =dr.GetInt32(0), 
                    Name = dr.GetString(1), 
                    Country = dr.GetString(2), 
                    Genre = dr.GetString(3), 
                    Url = dr.GetString(4) 
                };
                list.Add(artist);

            }
            con.Close();

            return list;
        }

        public static void Create(Artist artist)
        {
            using (SqlConnection conn = new(connectionString)) 
            {
                var cmd = new SqlCommand("INSERT INTO ArtistTABLE (Name, Country, Genre, Url) VALUES(@artistName, @artistCountry, @artistGenre, @artistUrl)", conn);
                cmd.Parameters.Add("@artistName", System.Data.SqlDbType.NVarChar).Value = artist.Name;
                cmd.Parameters.Add("@artistCountry", System.Data.SqlDbType.NVarChar).Value = artist.Country;
                cmd.Parameters.Add("@artistGenre", System.Data.SqlDbType.NVarChar).Value = artist.Genre;
                cmd.Parameters.Add("@artistUrl", System.Data.SqlDbType.NVarChar).Value = artist.Url;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void Delete(int id)
        {
            using (SqlConnection conn = new(connectionString))
            {
                SqlCommand cmd = new("DELETE FROM ArtistTable WHERE Id = @id", conn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
