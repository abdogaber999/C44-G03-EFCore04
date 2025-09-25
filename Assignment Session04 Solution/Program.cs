using Assignment_Session04_Solution.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Session04_Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Section A : Loading Related Data
            #region 1. Load "EgyptAir" With all its aircrafts and their routes
            // Eager Loading
            using (var context = new AirlineDbContext())
            {
                var egyptAir = context.Airlines
                    .Where(a => a.Name == "EgyptAir")
                    .Include(a => a.AirCraft)
                        .ThenInclude(ac => ac.Routes)
                    .FirstOrDefault();

                if (egyptAir != null)
                {
                    Console.WriteLine($"Airline: {egyptAir.Name}");

                    foreach (var aircraft in egyptAir.AirCraft)
                    {
                        Console.WriteLine($"  Aircraft: {aircraft.Model}");

                        foreach (var route in aircraft.Routes)
                        {
                            Console.WriteLine($"    Route: {route.Origin} -> {route.Destination}");
                        }
                    }
                }
            }
            #endregion

            #region 2. Retrieve all airlines with their employees, and for each employee load their qualifications.
            // Eager Loading
            using (var context = new AirlineDbContext())
            {
                var airlines = context.Airlines
                    .Include(a => a.Employees)
                    .ToList();

                foreach (var airline in airlines)
                {
                    Console.WriteLine($"Airline: {airline.Name}");

                    foreach (var employee in airline.Employees)
                    {
                        Console.WriteLine($"  Employee: {employee.Name} - Position: {employee.Position}");
                        Console.WriteLine($"    Qualifications: {employee.Qualifications}");
                    }
                }
            }


            #endregion

            #region 3. Load all airlines with their transactions, but only include transactions where Amount > 10000 
            // Eager Loading with Filter
            using (var context = new AirlineDbContext())
            {
                var airlines = context.Airlines
                    .Include(a => a.Transactions.Where(t => t.Amount > 10000))
                    .ToList();

                foreach (var airline in airlines)
                {
                    Console.WriteLine($"Airline: {airline.Name}");
                    foreach (var transaction in airline.Transactions)
                    {
                        Console.WriteLine($"  Transaction ID: {transaction.Id}, Amount: {transaction.Amount}");
                    }
                }
            }

            #endregion

            #region 4. Select all routes along with the model of aircrafts assigned to them 
            // Eager Loading
            using (var context = new AirlineDbContext())
            {
                var routesWithAircrafts = context.Routes
                    .Include(r => r.AirCraft)
                    .ToList();
                foreach (var route in routesWithAircrafts)
                {
                    Console.WriteLine($"Route: {route.Origin} -> {route.Destination}, Aircraft Model: {route.AirCraft.Model}");
                }
            }
            #endregion

            #region 5. Retrieve all aircrafts with their airline and the airline’s phones.
            Eager Loading
            using (var context = new AirlineDbContext())
            {
                var aircrafts = context.AirCrafts
                    .Include(a => a.Airline)
                        .ThenInclude(al => al.AirlinePhoneAirlines)
                    .ToList();

                foreach (var aircraft in aircrafts)
                {
                    Console.WriteLine($"Aircraft: {aircraft.Model}, Airline: {aircraft.Airline.Name}");

                    foreach (var phone in aircraft.Airline.AirlinePhoneAirlines)
                    {
                        Console.WriteLine($"   Phone: {phone.PhoneNumber}");
                    }
                }
            }

            #endregion

            #endregion

            #region Section B : Join Operators 
            #region 1. List all employees with their airline name.

            using (var context = new AirlineDbContext())
            {
                var query = from emp in context.Employees
                            join al in context.Airlines
                            on emp.AirlineId equals al.Id
                            select new
                            {
                                EmployeeName = emp.Name,
                                AirlineName = al.Name
                            };

                foreach (var item in query)
                {
                    Console.WriteLine($"Employee: {item.EmployeeName}, Airline: {item.AirlineName}");
                }
            }
            #endregion

            #region 2. Show all routes with the aircraft model assigned and the airline name that owns the aircraft. 

            using (var context = new AirlineDbContext())
            {
                var query = from route in context.Routes
                            join ac in context.AirCrafts
                            on route.AirCraftId equals ac.Id
                            join al in context.Airlines
                            on ac.AirlineId equals al.Id
                            select new
                            {
                                Route = route.Origin + " -> " + route.Destination,
                                AircraftModel = ac.Model,
                                AirlineName = al.Name
                            };

                foreach (var item in query)
                {
                    Console.WriteLine($"Route: {item.Route}, Aircraft: {item.AircraftModel}, Airline: {item.AirlineName}");
                }
            }

            #endregion

            #region 3. For each airline, list its aircraft models.

            using (var context = new AirlineDbContext())
            {
                var query = from al in context.Airlines
                            join ac in context.AirCrafts
                            on al.Id equals ac.AirlineId
                            select new
                            {
                                AirlineName = al.Name,
                                AircraftModel = ac.Model
                            };

                foreach (var item in query)
                {
                    Console.WriteLine($"Airline: {item.AirlineName}, Aircraft Model: {item.AircraftModel}");
                }
            }


            #endregion

            #region 4. Show all transactions (id, amount, description) along with the airline name, but only where Amount > 20000.

            using (var context = new AirlineDbContext())
            {
                var query = from t in context.Transactions
                            join al in context.Airlines
                            on t.AirlineId equals al.Id
                            where t.Amount > 20000
                            select new
                            {
                                TransactionId = t.Id,
                                Amount = t.Amount,
                                Description = t.Description,
                                AirlineName = al.Name
                            };
                foreach (var item in query)
                {
                    Console.WriteLine($"Transaction ID: {item.TransactionId}, Amount: {item.Amount}, Desc: {item.Description}, Airline: {item.AirlineName}");
                }

            }
            #endregion
            #endregion

        }
    }
}
