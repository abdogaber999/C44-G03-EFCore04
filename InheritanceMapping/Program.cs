using InheritanceMapping.Models;
using InheritanceMappingDemo.DatabaseContexts;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace InheritanceMapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Section C : Inheritance Mapping [ New Project ] 

            #region Q1- 1.Create a class Vehicle [Id, Model, Speed] - 2. Create a class Car [Id, Model, Speed, NumberOfDoors] - 3. Create a class Bus([Id, Model, Speed, Capacity] Note : Map them into a single table

            using var context = new AppDbContext();

            // Insert sample data
            context.Vehicles.Add(new Car { Model = "BMW", Speed = 220, NumberOfDoors = 4 });
            context.Vehicles.Add(new Bus { Model = "Mercedes", Speed = 120, Capacity = 50 });
            context.SaveChanges();

            // Retrieve data
            var vehicles = context.Vehicles.ToList();
            foreach (var v in vehicles)
            {
                Console.WriteLine($"{v.Id} - {v.Model} - {v.Speed}");
            }

            #endregion

            #region Q2- 1.Create a class Payment [Id, Amount] -2. Create a class CreditCardPayment [Id, Amount, CardNumber] - 3. Create a class CashPayment [Id, Amount, Currency] Note : Each Class Has its own Table

            using (var context = new AppDbContext())
            {
                // 1. Add some test data
                var creditPayment = new CreditCardPayment
                {
                    Amount = 5000,
                    CardNumber = "1234-5678-9999"
                };

                var cashPayment = new CashPayment
                {
                    Amount = 2000,
                    Currency = "USD"
                };

                context.CreditCardPayments.Add(creditPayment);
                context.CashPayments.Add(cashPayment);
                context.SaveChanges();

                Console.WriteLine("Payments inserted successfully.");

                // 2. Retrieve all payments (base class)
                var payments = context.Payments.ToList();

                Console.WriteLine("\nAll Payments:");
                foreach (var payment in payments)
                {
                    Console.WriteLine($"Id: {payment.Id}, Amount: {payment.Amount}");
                }

                // 3. Query specific type - CreditCardPayment
                var creditPayments = context.CreditCardPayments.ToList();
                Console.WriteLine("\nCredit Card Payments:");
                foreach (var cp in creditPayments)
                {
                    Console.WriteLine($"Id: {cp.Id}, Amount: {cp.Amount}, Card: {cp.CardNumber}");
                }

                // 4. Query specific type - CashPayment
                var cashPayments = context.CashPayments.ToList();
                Console.WriteLine("\nCash Payments:");
                foreach (var cs in cashPayments)
                {
                    Console.WriteLine($"Id: {cs.Id}, Amount: {cs.Amount}, Currency: {cs.Currency}");
                }
            }


            #endregion

            
            #region Q3- 1.Create a class Product[Id, Name] - 2. Create a class Book [Id, Name, Author] - 3. Create a class Electronics [Id, Name, Brand] -Note : No base table exists, and both Book and Electronics have their own tables.

            using (var context = new AppDbContext())
            {
                // Insert sample data
                if (!context.Books.Any() && !context.Electronics.Any())
                {
                    var book1 = new Book { Name = "C# in Depth", Author = "Jon Skeet" };
                    var book2 = new Book { Name = "Clean Code", Author = "Robert C. Martin" };

                    var electronic1 = new Electronics { Name = "Laptop", Brand = "Dell" };
                    var electronic2 = new Electronics { Name = "Smartphone", Brand = "Samsung" };

                    context.Books.AddRange(book1, book2);
                    context.Electronics.AddRange(electronic1, electronic2);

                    context.SaveChanges();
                    Console.WriteLine("Sample Books and Electronics inserted successfully!");
                }

                // Retrieve Books
                Console.WriteLine("\n--- Books ---");
                var books = context.Books.ToList();
                foreach (var book in books)
                {
                    Console.WriteLine($"Book ID: {book.Id}, Name: {book.Name}, Author: {book.Author}");
                }

                // Retrieve Electronics
                Console.WriteLine("\n--- Electronics ---");
                var electronics = context.Electronics.ToList();
                foreach (var electronic in electronics)
                {
                    Console.WriteLine($"Electronics ID: {electronic.Id}, Name: {electronic.Name}, Brand: {electronic.Brand}");
                }
            }

            #endregion
            #endregion
        }
    }
    }
