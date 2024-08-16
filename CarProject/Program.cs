using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // User CRUD Operations
            UserManager userManager = new UserManager(new EfUserDal());

            // Add a new user
            userManager.Add(new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password"
            });

            // List all users
            var users = userManager.GetAll();
            Console.WriteLine("Users:");
            foreach (var user in users.Data)
            {
                Console.WriteLine($"{user.Id} - {user.FirstName} {user.LastName} - {user.Email}");
            }




            // Customer CRUD Operations
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            // Add a new customer
            customerManager.Add(new Customer
            {
                UserId = users.Data[0].Id,
                CompanyName = "Doe Inc."
            });

            // List all customers
            var customers = customerManager.GetAll();
            Console.WriteLine("\nCustomers:");
            foreach (var customer in customers.Data)
            {
                Console.WriteLine($"{customer.UserId} - {customer.CompanyName} (User Id: {customer.UserId})");
            }

            // Rental CRUD Operations
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            // Add a new rental
            var rentalResult = rentalManager.Add(new Rental
            {
                CarId = 1,  // Assuming there is a car with Id 1
                CustomerId = customers.Data[0].UserId,
                RentDate = DateTime.Now
            });

            Console.WriteLine($"\nRental Add Result: {rentalResult.Message}");

            // List all rentals
            var rentals = rentalManager.GetAll();
            Console.WriteLine("\nRentals:");
            foreach (var rental in rentals.Data)
            {
                Console.WriteLine($"Rental Id: {rental.Id}, Car Id: {rental.CarId}, Customer Id: {rental.CustomerId}, Rent Date: {rental.RentDate}, Return Date: {rental.ReturnDate}");
            }

            // Try to rent a car that is already rented
            var rentalResult2 = rentalManager.Add(new Rental
            {
                CarId = 1,  // Trying to rent the same car again
                CustomerId = customers.Data[0].UserId,
                RentDate = DateTime.Now
            });

            Console.WriteLine($"\nRental Add Result: {rentalResult2.Message}");

            // Update a rental (Returning a car)
            var rentalToUpdate = rentals.Data[0];
            rentalToUpdate.ReturnDate = DateTime.Now;
            rentalManager.Update(rentalToUpdate);

            // List all rentals after update
            rentals = rentalManager.GetAll();
            Console.WriteLine("\nRentals After Update:");
            foreach (var rental in rentals.Data)
            {
                Console.WriteLine($"Rental Id: {rental.Id}, Car Id: {rental.CarId}, Customer Id: {rental.CustomerId}, Rent Date: {rental.RentDate}, Return Date: {rental.ReturnDate}");
            }
        }
    }
}
