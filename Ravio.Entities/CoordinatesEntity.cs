﻿namespace Ravio.Entities
{
    public class CoordinatesEntity
    {
        public CoordinatesEntity(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
