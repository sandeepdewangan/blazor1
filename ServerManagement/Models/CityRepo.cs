namespace ServerManagement.Models
{
    public class CityRepo
    {
        private static List<String> cities = new List<String>()
        {
            "Raipur",
            "Bilaspur",
            "Kanker",
            "Dhamtari",
            "Balod",
            "Surguja",
        };
        public static List<String> GetCities() => cities;

    }
}
