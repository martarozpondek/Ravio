namespace Ravio.Entities
{
    public class CoordinatesEntity
    {
        public CoordinatesEntity(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
