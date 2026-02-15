using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week6Learning
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;

        public override string ToString()
        {
            return $"{Name} {Class} {Marks}";
        }
    }
    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }
    class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public double Price;
    }
    class Sale
    {
        public int ProductId;
        public int Qty;
    }

    class Book 
    { 
        public string Title; 
        public string Author; 
        public string Genre; 
        public int Year; 
        public double Price; 
    }
    class Customer 
    { 
        public int Id; 
        public string Name; 
        public string City; 
    }
    class Order 
    { 
        public int OrderId; 
        public int CustomerId; 
        public double Amount; 
    }
    class Movie 
    { 
        public string Title; 
        public string Genre; 
        public double Rating; 
        public int Year; 
    }
    class Transaction 
    { 
        public int AccountNumber; 
        public double Amount;
        public string TransactionType;
        public DateTime Date;
    }
    class CartItem
    {
        public string Name;
        public string Category;
        public double Price;
        public int Qty;
    }

    class User
    {
        public int Id;
        public string Name;
        public string Country;
    }

    class Post
    {
        public int UserId;
        public int Likes;
        public int Comments; 
    }

    internal class DemoLINQExercise
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
    new Student{Id=1, Name="Amit", Class="10A", Marks=85},
    new Student{Id=2, Name="Neha", Class="10A", Marks=72},
    new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
    new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
    new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };

            //Get top 3 students by marks
            var top3Student = students.OrderByDescending(s => s.Marks).Take(3);
            Console.WriteLine("Top 3 Students");
            foreach (var student in top3Student)
            {
                Console.WriteLine(student.Name + " - " + student.Marks);
            }
            Console.WriteLine();

            //Group students by class and calculate average marks
            Console.WriteLine("Group student by class and average");
            var groupByClass = students.GroupBy(s => s.Class).Select(s => new { Class = s.Key, Avg = s.Average(s => s.Marks) });
            foreach (var avg in groupByClass)
            {
                Console.WriteLine(avg.Class + " - " + avg.Avg);
            }
            Console.WriteLine();

            //List students who scored below class average
            Console.WriteLine("Student Below class Average");
            var scoreBelowAvg = students.GroupBy(s => s.Class)
                .Select(g => new { Class = g.Key, Names = g.Where(s => s.Marks < g.Average(s => s.Marks)).Select(s => s.Name) });
            foreach (var group in scoreBelowAvg)
            {
                Console.WriteLine("Class: " + group.Class);

                foreach (var name in group.Names)
                {
                    Console.WriteLine(name);
                }
            }
            Console.WriteLine();

            //Order Students by Marks
            var studMarksDesc = students.OrderBy(o => o.Class).ThenByDescending(o => o.Marks);
            Console.WriteLine("Order student by class and then Marks Descending");
            foreach (var marks in studMarksDesc)
            {
                Console.WriteLine(marks);
            }
            Console.WriteLine();

            var employees = new List<Employee>
            {
    new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
    new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
    new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
    new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };

            //Get Highest and Lowest Salary
            var highest = employees.GroupBy(d => d.Dept).Select(s => new { dept = s.Key, highest = s.Max(x => x.Salary) });
            var lowest = employees.GroupBy(d => d.Dept).Select(s => new { dept = s.Key, lowest = s.Min(x => x.Salary) });
            Console.WriteLine("Highest Salary");
            foreach (var employee in highest)
            {
                Console.WriteLine(employee.dept + " - " + employee.highest);
            }
            Console.WriteLine();
            Console.WriteLine("Lowest Salary");
            foreach (var employee in lowest)
            {
                Console.WriteLine(employee.dept + " - " + employee.lowest);
            }
            Console.WriteLine();

            //Count Employees per department
            var countEmployees = employees.GroupBy(d => d.Dept).Select(s => new { dept = s.Key, count = s.Count() });
            Console.WriteLine("Employee Count per Department");
            foreach (var employee in countEmployees)
            {
                Console.WriteLine(employee.dept + " - " + employee.count);
            }
            Console.WriteLine();

            //Filter employee joined after 2020
            var empJoinedAfter2020 = employees.Where(e => e.JoinDate.Year > 2020);
            Console.WriteLine("Employees Joined after 2020");
            foreach (var employee in empJoinedAfter2020)
            {
                Console.WriteLine(employee.Name + " " + employee.Dept + " " + employee.Salary + " " + employee.JoinDate);
            }
            Console.WriteLine();

            //Anonymous object with Name and AnnualSalary
            Console.WriteLine("Anonymous object with Name and AnnualSalary");
            var anonyobj = employees.Select(e => new { Name = e.Name, annualSalary = e.Salary * 12 });
            foreach (var employee in anonyobj)
            {
                Console.WriteLine(employee.Name + " - " + employee.annualSalary);
            }
            Console.WriteLine();

            var products = new List<Product>
             {
    new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
    new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
    new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
    new Sale{ProductId=1, Qty=10},
    new Sale{ProductId=2, Qty=20}
            };

            //Join Products with sales
            var joinedData = products.Join(sales, o => o.Id, i => i.ProductId, (p, s) => new{
                p.Id,
                p.Name,
                p.Category,
                p.Price,
                s.Qty
            });
            Console.WriteLine("Join Products with Sales");
            foreach(var j in joinedData)
            {
                Console.WriteLine(j.Name+" - "+j.Qty);
            }
            Console.WriteLine();

            //Calculate total revenue per product
            var revenueProduct = products.Join(sales, o => o.Id, i => i.ProductId, (p, s) => new { p.Name, Revenue = p.Price * s.Qty }).GroupBy(x => x.Name).Select(g => new {ProductName=g.Key,TotalRevenue=g.Sum(x=>x.Revenue)});
            Console.WriteLine("Total Revenue per product");
            foreach(var product in revenueProduct)
            {
                Console.WriteLine(product.ProductName+" - "+product.TotalRevenue);
            }
            Console.WriteLine();

            //Get best-selling product
            var bestSellingProduct = products.Join(sales,p => p.Id,s => s.ProductId,(p, s) => new{p.Name,TotalQty = s.Qty}).OrderByDescending(x => x.TotalQty).FirstOrDefault();

            Console.WriteLine($"Best Selling Product: {bestSellingProduct.Name} - Qty: {bestSellingProduct.TotalQty}");
            Console.WriteLine();

            //List products with zero sales
            var productsWithZeroSales = products.GroupJoin(sales,p => p.Id,s => s.ProductId,(p, saleGroup) => new{p.Name,TotalQty = saleGroup.Sum(x => x.Qty)}).Where(x => x.TotalQty == 0);
            Console.WriteLine("Product with zero Sales:");
            foreach (var item in productsWithZeroSales)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

            var books = new List<Book>
            {
        new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
    new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
    new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };

            //Find books publishes after 2015
            Console.WriteLine("Books publishes after 2015");
            var bookAfter2015 = books.Where(b => b.Year > 2015);
            foreach(var book in books)
            {
                Console.WriteLine(book.Title+"-"+book.Year);
            }
            Console.WriteLine();

            //Group by genre and count books
            Console.WriteLine("Group by Genre and count books");
            var groupGenreCount=books.GroupBy(g => g.Genre).Select(s => new { Genre = s.Key, count = s.Count() });
            foreach(var book in groupGenreCount)
            {
                Console.WriteLine(book.Genre+" - "+book.count);
            }
            Console.WriteLine();

            //Get most expensive book by Genre
            Console.WriteLine("Get most expensive book per Genre");
            var expensiveBook=books.GroupBy(g=>g.Genre).Select(s => new { Genre = s.Key, expensive = s.Max(x => x.Price) });
            foreach(var book in expensiveBook)
            {
                Console.WriteLine(book.Genre+" - "+book.expensive);
            }
            Console.WriteLine();

            //Return distinct authors list
            Console.WriteLine("Distinct authors list");
            var distinctAuthors = books.DistinctBy(d => d.Author);
            foreach(var author in distinctAuthors) {
                Console.WriteLine(author.Author);
            }
            Console.WriteLine();

            //Customer Order Analysis
            var customers = new List<Customer>
            {
    new Customer{Id=1, Name="Ajay", City="Delhi"},
    new Customer{Id=2, Name="Sunita", City="Mumbai"}
            };

            var orders = new List<Order>
            {
    new Order{OrderId=1, CustomerId=1, Amount=20000},
    new Order{OrderId=2, CustomerId=1, Amount=40000}
            };

            //Get total Order amount per customer
            Console.WriteLine("Total Order Amount per Customer: ");
            var totalPerCustomer = customers.GroupJoin(orders,c => c.Id,o => o.CustomerId,(c, orderGroup) => new{c.Name,TotalAmount = orderGroup.Sum(x => x.Amount)});

            foreach (var item in totalPerCustomer)
            {
                Console.WriteLine($"{item.Name} - {item.TotalAmount}");
            }
            Console.WriteLine();

            //List Customers with no orders
            Console.WriteLine("List of Customers with no orders: ");
            var customersWithNoOrders = customers.Where(c => !orders.Any(o => o.CustomerId == c.Id));

            foreach (var c in customersWithNoOrders)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine();

            //Get customers who spent above 50000
            Console.WriteLine("Customers who spent above 50000");
            var bigSpenders = customers.GroupJoin(orders,c => c.Id,o => o.CustomerId,(c, orderGroup) => new{c.Name,TotalAmount = orderGroup.Sum(x => x.Amount)}).Where(x => x.TotalAmount > 50000);

            foreach (var item in bigSpenders)
            {
                Console.WriteLine($"{item.Name} - {item.TotalAmount}");
            }
            Console.WriteLine();

            //Sort customers by total spending
            Console.WriteLine("Sort customers by Total spending (Descending)");
            var sortedCustomers = customers.GroupJoin(orders,c => c.Id,o => o.CustomerId,(c, orderGroup) => new{c.Name,TotalAmount = orderGroup.Sum(x => x.Amount)}).OrderByDescending(x => x.TotalAmount);

            foreach (var item in sortedCustomers)
            {
                Console.WriteLine($"{item.Name} - {item.TotalAmount}");
            }
            Console.WriteLine();

            // Movie Streaming Platform Query System
            var movies = new List<Movie>
            {
    new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
    new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
    new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
            };

            //Filter movies with rating >8
            Console.WriteLine("Movies with rating>8 :");
            var highRatedMovies = movies.Where(m => m.Rating > 8);

            foreach (var m in highRatedMovies)
            {
                Console.WriteLine($"{m.Title} - {m.Rating}");
            }
            Console.WriteLine();

            //Group Movies by Genre and get average rating
            Console.WriteLine("Group Movies by Genre and Average Rating: ");
            var avgRatingByGenre = movies.GroupBy(m => m.Genre).Select(g => new{Genre = g.Key,AvgRating = g.Average(x => x.Rating)});

            foreach (var item in avgRatingByGenre)
            {
                Console.WriteLine($"{item.Genre} - {item.AvgRating}");
            }
            Console.WriteLine();

            //Find latest movie per genre
            Console.WriteLine("Latest Movie per Genre: ");
            var latestMoviePerGenre = movies.GroupBy(m => m.Genre).SelectMany(g =>g.OrderByDescending(x => x.Year).Take(1));

            foreach (var m in latestMoviePerGenre)
            {
                Console.WriteLine($"{m.Genre} - {m.Title} ({m.Year})");
            }
            Console.WriteLine();

            //Get top 5 highest rated movies
            Console.WriteLine("Top 5 Highest rated Movies: ");
            var topMovies = movies.OrderByDescending(m => m.Rating).Take(5);

            foreach (var m in topMovies)
            {
                Console.WriteLine($"{m.Title} - {m.Rating}");
            }
            Console.WriteLine();

            // Bank Transaction Analyzer
            var transactions = new List<Transaction>
            {
    new Transaction{AccountNumber=101, Amount=5000, TransactionType="Credit", Date=new DateTime(2024,1,10)},
    new Transaction{AccountNumber=101, Amount=2000, TransactionType="Debit",  Date=new DateTime(2024,1,15)},
    new Transaction{AccountNumber=102, Amount=10000,TransactionType="Debit",  Date=new DateTime(2024,2,5)}
            };

            //Calculate total balance per account
            Console.WriteLine("Total Balance per account");
            var balancePerAccount = transactions.GroupBy(t => t.AccountNumber).Select(g => new{Account = g.Key,Balance = g.Sum(x =>x.TransactionType == "Credit" ? x.Amount : -x.Amount)});

            foreach (var item in balancePerAccount)
            {
                Console.WriteLine($"Acc {item.Account} - Balance: {item.Balance}");
            }
            Console.WriteLine();

            //List suspicious accounts (total debit > credit)
            Console.WriteLine("Suspicious accounts: ");
            var suspiciousAccounts = transactions.GroupBy(t => t.AccountNumber).Select(g => new{Account = g.Key,TotalCredit = g.Where(x => x.TransactionType == "Credit").Sum(x => x.Amount),TotalDebit = g.Where(x => x.TransactionType == "Debit").Sum(x => x.Amount)}).Where(x => x.TotalDebit > x.TotalCredit);

            foreach (var acc in suspiciousAccounts)
            {
                Console.WriteLine($"Suspicious Account: {acc.Account}");
            }
            Console.WriteLine();

            //Group transactions by month
            Console.WriteLine("Transactions by month: ");
            var transactionsByMonth = transactions.GroupBy(t => new { t.Date.Year, t.Date.Month });

            foreach (var group in transactionsByMonth)
            {
                Console.WriteLine($"{group.Key.Month}/{group.Key.Year}");

                foreach (var t in group)
                {
                    Console.WriteLine($"   Acc:{t.AccountNumber} Amount:{t.Amount}");
                }
            }
            Console.WriteLine();

            //Find highest transaction amount per account
            Console.WriteLine("Highest Transaction Amount per Account: ");
            var highestTxnPerAccount = transactions.GroupBy(t => t.AccountNumber).Select(g => new{Account = g.Key,MaxAmount = g.Max(x => x.Amount)});

            foreach (var item in highestTxnPerAccount)
            {
                Console.WriteLine($"Acc {item.Account} - Highest Txn: {item.MaxAmount}");
            }
            Console.WriteLine();

            // E-Commerce Cart Processing
            var cart = new List<CartItem>
            {
    new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
    new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };

            //Calculate total cart value
            var totalCartValue = cart.Sum(x => x.Price * x.Qty);

            Console.WriteLine($"Total Cart Value: {totalCartValue}");
            Console.WriteLine();

            //Group by Category and Total Category cost
            Console.WriteLine("Group by Category and total category cost: ");
            var categoryTotals = cart.GroupBy(x => x.Category).Select(g => new{Category = g.Key,TotalCost = g.Sum(x => x.Price * x.Qty)});

            foreach (var item in categoryTotals)
            {
                Console.WriteLine($"{item.Category} - {item.TotalCost}");
            }
            Console.WriteLine();

            //Apply 10% discount for Electronics
            Console.WriteLine("Apply 10% discount for Electronics");
            var discountedCart = cart.Select(x => new{x.Name,x.Category,x.Price,x.Qty,FinalPrice = x.Category == "Electronics"? (x.Price * x.Qty) * 0.9: (x.Price * x.Qty)});

            foreach (var item in discountedCart)
            {
                Console.WriteLine($"{item.Name} - Final: {item.FinalPrice}");
            }
            Console.WriteLine();

            //Return cart summary DTO objects
            Console.WriteLine("Return cart summary DTO objects");
            var cartSummary = cart.Select(x => new{x.Name,x.Category,TotalPrice = x.Price * x.Qty});
            foreach (var item in cartSummary)
            {
                Console.WriteLine($"{item.Name} | {item.Category} | {item.TotalPrice}");
            }
            Console.WriteLine();

            // Social Media User Analytics
            var users = new List<User>
            {
    new User{Id=1, Name="A", Country="India"},
    new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
    new Post{UserId=1, Likes=100, Comments=10},
    new Post{UserId=1, Likes=50, Comments=5}
            };

            //Get top users by total likes
            Console.WriteLine("Top users by total likes: ");
            var topUsers = users.Join(posts,u => u.Id,p => p.UserId,(u, p) => new { u.Name, p.Likes }).GroupBy(x => x.Name).Select(g => new{Name = g.Key,TotalLikes = g.Sum(x => x.Likes)}).OrderByDescending(x => x.TotalLikes);

            foreach (var u in topUsers)
            {
                Console.WriteLine($"{u.Name} - {u.TotalLikes}");
            }
            Console.WriteLine();

            //Group users by country
            Console.WriteLine("Group users by country");
            var usersByCountry = users.GroupBy(u => u.Country);

            foreach (var group in usersByCountry)
            {
                Console.WriteLine(group.Key);

                foreach (var u in group)
                {
                    Console.WriteLine($"   {u.Name}");
                }
            }
            Console.WriteLine();

            //List inactive users (no posts)
            Console.WriteLine("Inactive Users: ");
            var inactiveUsers = users.GroupJoin(posts,u => u.Id,p => p.UserId,(u, postGroup) => new{User = u,PostCount = postGroup.Count()}).Where(x => x.PostCount == 0).Select(x => x.User.Name);

            foreach (var name in inactiveUsers)
            {
                Console.WriteLine($"Inactive: {name}");
            }
            Console.WriteLine();

            //Calculate average likes per post
            var avgLikes = posts.Average(p => p.Likes);

            Console.WriteLine($"Average Likes Per Post: {avgLikes}");

        }
    }
}

