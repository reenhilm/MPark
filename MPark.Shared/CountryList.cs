namespace MPark.Shared
{
    public static class CountryList
    {
        public static IEnumerable<Country> GetCountries() =>
        new List<Country>
            {
                new Country()
                {
                    Id = 1,
                    Name = "Sweden"
                }
            };
    }
}
