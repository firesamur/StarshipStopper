using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starshipStops.Model
{
    public class Starship
    {
        /// <summary>The name of this starship. The common name, such as "Death Star".</summary>
        public string Name { get; set; }

        /// <summary>The model or official name of this starship. Such as "T-65 X-wing" or "DS-1 Orbital Battle Station".</summary>
        public string Model { get; set; }

        /// <summary>The manufacturer of this starship. Comma separated if more than one.</summary>
        public string Manufacturer { get; set; }

        /// <summary>The cost of this starship new, in galactic credits.</summary>
        public string Cost_in_credits { get; set; }

        /// <summary>The length of this starship in meters.</summary>
        public string Length { get; set; }

        /// <summary>The maximum speed of this starship in the atmosphere. "N/A" if this starship is incapable of atmospheric flight.</summary>
        public string Max_atmosphering_speed { get; set; }

        /// <summary>The number of personnel needed to run or pilot this starship.</summary>
        public string Crew { get; set; }

        /// <summary>The number of non-essential people this starship can transport.</summary>
        public string Passengers { get; set; }

        /// <summary>The maximum number of kilograms that this starship can transport.</summary>
        public string Cargo_capacity { get; set; }

        /// <summary>The maximum length of time that this starship can provide consumables for its entire crew without having to resupply.</summary>
        public string Consumables { get; set; }

        /// <summary>The class of this starships hyperdrive.</summary>
        public string Hyperdrive_rating { get; set; }

        /// <summary>The Maximum number of Megalights this starship can travel in a standard hour.</summary>
        public string MGLT { get; set; }

        /// <summary>The class of this starship, such as "Starfighter" or "Deep Space Mobile Battlestation".</summary>
        public string Starship_class { get; set; }

        /// <summary>An array of People URL Resources that this starship has been piloted by.</summary>
        public IEnumerable<string> Pilots { get; set; }

        /// <summary>An array of Film URL Resources that this starship has appeared in.</summary>
        public IEnumerable<string> Films { get; set; }

        /// <summary>The ISO 8601 date format of the time that this resource was created.</summary>
        public string Created { get; set; }

        /// <summary>The ISO 8601 date format of the time that this resource was edited.</summary>
        public string Edited { get; set; }

        /// <summary>The hypermedia URL of this resource.</summary>
        public string Url { get; set; }

        /// <summary>Total amount of stops this starship will need in order to drive the total distance specified (in MGLT).</summary>
        public int NoStops { get; set; }


        /// <summary>
        /// Calculates the total amount of stops that this Starship will require for resupply, depending of the distance settet up.
        /// </summary>
        /// <param name="distance">Specified distance to calculate. 1000000 by default.</param>
        public void CalculateNoStops(int distance = 1000000) {
            int hoursPerTravel = 0;

            if (Consumables.Contains("hour"))
            {
                hoursPerTravel = Convert.ToInt32(Consumables.Replace("hours", "").Replace("hour", "").Replace(" ", ""));
                hoursPerTravel = hoursPerTravel * Convert.ToInt32(this.MGLT);
                this.NoStops = distance / hoursPerTravel;

            }
            else if (Consumables.Contains("day"))
            {
                hoursPerTravel = Convert.ToInt32(Consumables.Replace("days", "").Replace("day", "").Replace(" ", ""));
                hoursPerTravel = (hoursPerTravel * 24) * Convert.ToInt32(this.MGLT);
                this.NoStops = distance / hoursPerTravel;
            }
            else if (Consumables.Contains("week"))
            {
                hoursPerTravel = Convert.ToInt32(Consumables.Replace("weeks", "").Replace("week", "").Replace(" ", ""));
                hoursPerTravel = (hoursPerTravel * 7 * 24) * Convert.ToInt32(this.MGLT);
                this.NoStops = distance / hoursPerTravel;
            }
            else if (Consumables.Contains("month"))
            {
                hoursPerTravel = Convert.ToInt32(Consumables.Replace("months", "").Replace("month", "").Replace(" ", ""));
                hoursPerTravel = (hoursPerTravel * 4 * 7 * 24) * Convert.ToInt32(this.MGLT);
                this.NoStops = distance / hoursPerTravel;
            }
            else if (Consumables.Contains("year"))
            {
                int leapYears = 0;

                hoursPerTravel = Convert.ToInt32(Consumables.Replace("years", "").Replace("year", "").Replace(" ", ""));
                // For every leap year, we add 24h to final time. Anyway, I think in the interstellar travels they should not have 29th February!
                leapYears = (hoursPerTravel / 4) * 24;
                hoursPerTravel = (hoursPerTravel * 12 * 4 * 7 * 24 + leapYears) * Convert.ToInt32(this.MGLT);
                this.NoStops = distance / hoursPerTravel;
            }
        }
    }
}
