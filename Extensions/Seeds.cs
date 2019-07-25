using System;
using Microsoft.EntityFrameworkCore;
using BankApp.Models;

namespace BankApp.Extensions
{
    public static class Seeds
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            AccountTypes(modelBuilder);
            Banks(modelBuilder);
            Cities(modelBuilder);
            Clients(modelBuilder);
            Countries(modelBuilder);
            Savings(modelBuilder);
        }

        public static void AccountTypes(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<AccountType>().HasData(new AccountType { Id = 1, Name = "Current Account" });
            modelBuilder.Entity<AccountType>().HasData(new AccountType { Id = 2, Name = "Savings Account" });

        }

        public static void Banks(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Bank>().HasData(new Bank { Id = 1, Name = "PBZ", CityId = 1, IBAN = "221111111111111", Phone = "0915555555", Email = "PBZ@nesto.com" });
            modelBuilder.Entity<Bank>().HasData(new Bank { Id = 2, Name = "The Paris National Bank", CityId = 2, IBAN = "331111111111111", Phone = "0917777777", Email = "ParisBank@nesto.com" });
            modelBuilder.Entity<Bank>().HasData(new Bank { Id = 3, Name = "Bank of New York", CityId = 2, IBAN = "441111111111111", Phone = "0918888888", Email = "NYbank@nesto.com" });
            modelBuilder.Entity<Bank>().HasData(new Bank { Id = 4, Name = "Lloyds Bank", CityId = 2, IBAN = "551111111111111", Phone = "0919991111", Email = "Lloyds@nesto.com" });
            modelBuilder.Entity<Bank>().HasData(new Bank { Id = 5, Name = "Rabobank", CityId = 2, IBAN = "661111111111111", Phone = "0918751111", Email = "Rabobank@nesto.com" });
        }
        public static void Cities(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Zagreb", CountryId = 1, Zip = "10000" });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "New York", CountryId = 2, Zip = "10001" });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "London ", CountryId = 4, Zip = "56273" });
            modelBuilder.Entity<City>().HasData(new City { Id = 4, Name = "Paris", CountryId = 3, Zip = "75000" });
            modelBuilder.Entity<City>().HasData(new City { Id = 5, Name = "Amsterdam ", CountryId = 5, Zip = "1011" });
        }

        public static void Clients(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Client>().HasData(new Client { Id = 1, FirstName = "Luke", LastName = "Skywalker", CityId = 1, Email = "lukeS@nesto.com", Address = "Tatooine 5", Birthdate = (DateTime.Parse("1996-03-01 11:30:15")), IBAN = "111111111111111" });
            modelBuilder.Entity<Client>().HasData(new Client { Id = 2, FirstName = "Darth", LastName = "Vader", CityId = 2, Email = "Anakin@nesto.com", Address = "Naboo  3", Birthdate = (DateTime.Parse("1989-01-15 10:30:15")), IBAN = "22222222222222" });
            modelBuilder.Entity<Client>().HasData(new Client { Id = 3, FirstName = "Leia", LastName = "Organa", CityId = 1, Email = "Princess@nesto.com", Address = "Alderaan  5", Birthdate = (DateTime.Parse("1996-03-01 11:30:15")), IBAN = "333333333333333" });
            modelBuilder.Entity<Client>().HasData(new Client { Id = 4, FirstName = "Han", LastName = "Solo", CityId = 1, Email = "Chewie@nesto.com", Address = "Cantonica 9", Birthdate = (DateTime.Parse("1994-03-01 11:30:15")), IBAN = "444444444444444" });
            modelBuilder.Entity<Client>().HasData(new Client { Id = 5, FirstName = "Obi-Wan", LastName = "Kenobi", CityId = 1, Email = "obi_wan@nesto.com", Address = "Dagobah 17", Birthdate = (DateTime.Parse("1984-03-01 11:30:15")), IBAN = "555555555555555" });
        }

        public static void Countries(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Croatia" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "United States" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "England" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 5, Name = "Netherlands" });
        }

        public static void Savings(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Saving>().HasData(new Saving { Id = 1, Interest_rate = 0.2m, Amount = 500000, StartOfSaving = (DateTime.Parse("2015-03-01 11:30:15")), BankId = 1, AccountTypeId = 1, ClientId = 1 });
            modelBuilder.Entity<Saving>().HasData(new Saving { Id = 2, Interest_rate = 0.0m, Amount = 100000, StartOfSaving = (DateTime.Parse("2017-04-01 13:30:15")), BankId = 2, AccountTypeId = 2, ClientId = 2 });
            modelBuilder.Entity<Saving>().HasData(new Saving { Id = 3, Interest_rate = 0.3m, Amount = 700000, StartOfSaving = (DateTime.Parse("2018-01-01 15:30:15")), BankId = 3, AccountTypeId = 1, ClientId = 3 });
            modelBuilder.Entity<Saving>().HasData(new Saving { Id = 4, Interest_rate = 0.0m, Amount = 180000, StartOfSaving = (DateTime.Parse("2011-07-01 09:30:15")), BankId = 4, AccountTypeId = 2, ClientId = 4 });
            modelBuilder.Entity<Saving>().HasData(new Saving { Id = 5, Interest_rate = 0.4m, Amount = 175800, StartOfSaving = (DateTime.Parse("2014-09-01 07:30:15")), BankId = 5, AccountTypeId = 1, ClientId = 5 });
        }
    }
}
