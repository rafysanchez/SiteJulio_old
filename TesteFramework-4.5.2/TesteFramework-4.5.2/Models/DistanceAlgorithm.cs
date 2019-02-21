using System;

namespace TesteFramework.Models
{
    public class DistanceAlgorithm
    {
        const double PIx = 3.141592653589793;
        const double RADIO = 6378.16;

        /// <summary>
        /// This class cannot be instantiated.
        /// </summary>
        private DistanceAlgorithm() { }

        /// <summary>
        /// Convert degrees to Radians
        /// </summary>
        /// <param name="x">Degrees</param>
        /// <returns>The equivalent in radians</returns>
        public static double Radians(double x)
        {
            return x * PIx / 180;
        }

        /// <summary>
        /// Calculate the distance between two places.
        /// </summary>
        /// <param name="lon1"></param>
        /// <param name="lat1"></param>
        /// <param name="lon2"></param>
        /// <param name="lat2"></param>
        /// <returns></returns>
        public static double DistanceBetweenPlaces(
            double lon1,
            double lat1,
            double lon2,
            double lat2)
        {
            double dlon = Radians(lon2 - lon1);
            double dlat = Radians(lat2 - lat1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return (angle * RADIO) * 0.62137;//distance in miles
        }

    }


    public class Haversine
    {
        public static void Bas()
        {
            Console.WriteLine("Hello World");

            var meLat = -33.922982;
            double meLong = 151.083853;


            var result1 = HaversineInM(meLat, meLong, -32.236457779983745, 148.69094705162837);
            var result2 = HaversineInM(meLat, meLong, -33.609020205923713, 150.77061469270831);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        static double _eQuatorialEarthRadius = 6378.1370D;
        static double _d2r = (Math.PI / 180D);

        private static int HaversineInM(double lat1, double long1, double lat2, double long2)
        {
            return (int)(1000D * HaversineInKM(lat1, long1, lat2, long2));
        }

        private static double HaversineInKM(double lat1, double long1, double lat2, double long2)
        {
            double dlong = (long2 - long1) * _d2r;
            double dlat = (lat2 - lat1) * _d2r;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(lat1 * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = _eQuatorialEarthRadius * c;

            return d;
        }
    }

}





// in the sql server

//--will return the radius for a given number
//create function getRad(@variable float)--function to return rad
//returns float
//as
//begin
//declare @retval float 
//select @retval=(@variable * PI()/180)
//--print @retval
//return @retval
//end
//go

//--calc distance
//--drop function dbo.getDistance
//create function getDistance(@cLat float,@cLong float, @tLat float, @tLong float)
//returns float
//as
//begin
//declare @emr float
//declare @dLat float
//declare @dLong float
//declare @a float
//declare @distance float
//declare @c float

//set @emr = 6371--earth mean 
//set @dLat = dbo.getRad(@tLat - @cLat);
//set @dLong = dbo.getRad(@tLong - @cLong);
//set @a = sin(@dLat/2)*sin(@dLat/2)+cos(dbo.getRad(@cLat))*cos(dbo.getRad(@tLat))*sin(@dLong/2)*sin(@dLong/2);
//set @c = 2*atn2(sqrt(@a),sqrt(1-@a))
//set @distance = @emr*@c;
//set @distance = @distance * 0.621371 -- i needed it in miles
//--print @distance
//return @distance;
//end 
//go


//--get all zipcodes within 2 miles, the hardcoded #'s would be passed in by C#
//select *
//from cityzips a where dbo.getDistance(29.76,-95.38,a.lat,a.long) <3
//order by zipcode


////