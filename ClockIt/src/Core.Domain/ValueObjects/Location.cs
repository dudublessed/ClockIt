using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ClockIt.src.Core.Domain.ValueObjects
{
    public class Location
    {
        public string Country { get; }
        public string State { get; }
        public string City { get; }

        public Location (string country, string state, string city)
        {
            country.Trim();
            state.Trim();
            city.Trim();

            ValidateLocation(country, state, city);

            Country = country;
            State = state;
            City = city;
        }

        public static void ValidateLocation(string country, string state, string city)
        {
            bool isAnyFieldEmpty = (
                string.IsNullOrWhiteSpace(country) 
                || string.IsNullOrWhiteSpace(state)
                || string.IsNullOrWhiteSpace(city));

            if (isAnyFieldEmpty)
            {
                throw new ArgumentException("Localização inválida. Por favor, tente novamente.");
            }
        }
    }
}
