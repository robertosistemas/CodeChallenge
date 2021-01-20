using AutoMapper;
using CodeChallenge.Domain.Models;
using System;
using System.Globalization;

namespace CodeChallenge.Application.Mappings
{
    public class UserTypeResolver : IValueResolver<UserImport, User, string>
    {
        private const string TYPE_USER_SPECIAL = "special";

        private const double SPECIAL_ONE_MIN_LON = -2.196998;
        private const double SPECIAL_ONE_MIN_LAT = -46.361899;
        private const double SPECIAL_ONE_MAX_LON = -15.411580;
        private const double SPECIAL_ONE_MAX_LAT = -34.276938;

        private const double SPECIAL_TWO_MIN_LON = -19.766959;
        private const double SPECIAL_TWO_MIN_LAT = -52.997614;
        private const double SPECIAL_TWO_MAX_LON = -23.966413;
        private const double SPECIAL_TWO_MAX_LAT = -44.428305;

        private const string TYPE_USER_NORMAL = "normal";

        private const double NORMAL_MIN_LON = -26.155681;
        private const double NORMAL_MIN_LAT = -54.777426;
        private const double NORMAL_MAX_LON = -34.016466;
        private const double NORMAL_MAX_LAT = -46.603598;

        private const string TYPE_USER_LABORIOUS = "laborious";

        public string Resolve(UserImport source, User destination, string member, ResolutionContext context)
        {
            var culture = new CultureInfo("en-US");
            double longitude = Convert.ToDouble(source.Location.Coordinates.Longitude, culture);
            double latitude = Convert.ToDouble(source.Location.Coordinates.Latitude, culture);

            if (latitude >= SPECIAL_ONE_MIN_LAT && latitude <= SPECIAL_ONE_MAX_LAT &&
                longitude >= SPECIAL_ONE_MAX_LON && longitude <= SPECIAL_ONE_MIN_LON)
            {
                return TYPE_USER_SPECIAL;
            }

            if (latitude >= SPECIAL_TWO_MIN_LAT && latitude <= SPECIAL_TWO_MAX_LAT &&
                longitude >= SPECIAL_TWO_MAX_LON && longitude <= SPECIAL_TWO_MIN_LON)
            {
                return TYPE_USER_SPECIAL;
            }

            if (latitude >= NORMAL_MIN_LAT && latitude <= NORMAL_MAX_LAT &&
                longitude >= NORMAL_MAX_LON && longitude <= NORMAL_MIN_LON)
            {
                return TYPE_USER_NORMAL;
            }

            return TYPE_USER_LABORIOUS;
        }
    }
}
