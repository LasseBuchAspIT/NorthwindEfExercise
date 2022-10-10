using Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;

NorthwindContext context = new();
Console.WriteLine("1.1: \n--------------------------------------");
foreach(Product p in context.Products.ToList())
{
    if(p.Discontinued == true)
    {
        Console.WriteLine($"{p.ProductName}");
    }
}

Console.WriteLine("\n1.2: \n--------------------------------------");

List<Supplier> suppliers = context.Suppliers.Where(s => s.Region == "Québec").ToList();
foreach (Supplier s in suppliers)
{
    Console.WriteLine(s.CompanyName + ", " + s.Region);
}

Console.WriteLine("\n1.3: \n--------------------------------------");
foreach (Supplier s in context.Suppliers.ToList())
{
    if (s.Country == "Germany" || s.Country == "France")
    {
        Console.WriteLine(s.CompanyName + ", " + s.Country);
    }
}

Console.WriteLine("\n1.4: \n--------------------------------------");
foreach (Supplier s in context.Suppliers.ToList())
{
    if (string.IsNullOrEmpty(s.HomePage))
    {
        Console.WriteLine(s.CompanyName + ", " + s.HomePage);
    }
}


Console.WriteLine("\n1.5: \n--------------------------------------");
List<string> euCountries = new List<string>() { "Denmark", "Germany", "France", "Belgium", "Netherlands", "Poland", "UK", "Spain", "Sweden", "Italy", "Finland"};
foreach (Supplier s in context.Suppliers.ToList())
{
    foreach (string country in euCountries)
    {
        if (s.Country == country && !string.IsNullOrEmpty(s.HomePage))
        {
            Console.WriteLine(s.CompanyName + ", " + s.Country + ", " + s.HomePage);
        }
    }
}

Console.WriteLine("\n1.6: \n--------------------------------------");
foreach (Employee e in context.Employees.ToList())
{
    if (e.FirstName[0] == 'M')
    {
        Console.WriteLine(e.FirstName + " " + e.LastName);
    }
}

Console.WriteLine("\n1.7: \n--------------------------------------");
foreach (Employee e in context.Employees.ToList())
{
    if (e.LastName.EndsWith("an"))
    {
        Console.WriteLine(e.FirstName + " " + e.LastName);
    }
}

Console.WriteLine("\n1.8: \n--------------------------------------");
foreach (Employee e in context.Employees.ToList())
{
    if (e.TitleOfCourtesy == "Ms." || e.TitleOfCourtesy == "Mrs.")
    {
        Console.WriteLine(e.TitleOfCourtesy + " " + e.LastName);
    }
}

Console.WriteLine("\n1.9: \n--------------------------------------");
foreach (Employee e in context.Employees.ToList())
{
    if (e.Title == "Sales Representative" && e.Country == "Uk")
    {
        Console.WriteLine(e.FirstName + " " + e.Title);
    }
}

Console.WriteLine("\n1.10: \n--------------------------------------");
Console.WriteLine(context.Products.ToList().Count);

Console.WriteLine("\n1.11: \n--------------------------------------");
    decimal? totalPrice = 0;
    foreach(Product p in context.Products.ToList())
    {
        totalPrice += p.UnitPrice;
    }
Console.WriteLine(totalPrice / context.Products.ToList().Count);


Console.WriteLine("\n1.12: \n--------------------------------------");
List<Product> newProductList = context.Products.ToList().OrderBy(p => p.UnitPrice).ToList();

foreach(Product product in newProductList)
{
    if(product.UnitPrice > 20)
    {
        Console.WriteLine($"{product.ProductName}, {product.UnitPrice}kr");
    }
}

Console.WriteLine("\n1.13: \n--------------------------------------");
newProductList = context.Products.ToList().OrderBy(p => p.ProductName).ToList();
foreach(Product p in newProductList)
{
    if(p.UnitsInStock <= 0)
    {
        Console.WriteLine($"{p.ProductName}: {p.UnitsInStock}");
    }
}

Console.WriteLine("\n1.14: \n--------------------------------------");
newProductList.Reverse();
foreach(Product p in newProductList)
{
    if(p.UnitsInStock <= 0 && p.UnitsOnOrder == 0 && !p.Discontinued)
    {
        Console.WriteLine($"{p.ProductName}: {p.UnitsInStock}");
    }
}

Console.WriteLine("\n1.15: \n--------------------------------------");
newProductList.Reverse();
List<Customer> newCustomerList = context.Customers.ToList().OrderBy(c => c.Country).ThenBy(c => c.ContactName).ToList();
foreach(Customer c in newCustomerList)
{
    if (c.Country == "UK" && c.ContactTitle.ToLower().Contains("sale"))
    {
        Console.WriteLine(c.Country + ": " + c.ContactTitle + ", " + c.ContactName);
    }
    else if(c.Country == "France" && c.ContactTitle == "Owner")
    {
        Console.WriteLine(c.Country + ": " + c.ContactTitle + ", " + c.ContactName);
    }
}

Console.WriteLine("\n1.16: \n--------------------------------------");
List<string> americanCountries = new List<string>() { "USA", "Venezuela", "Brazil", "Canada", "Mexico", "Argentina" };
foreach (Customer c in context.Customers.ToList())
{
    foreach(string countries in americanCountries)
    {
        if(c.Country == countries)
        {
            if (string.IsNullOrEmpty(c.Fax) || c.Fax == "No fax number")
            {
                Console.WriteLine(c.ContactName + " " + c.Country);
            }
        }
    }
}

Console.WriteLine("\n2.1: \n--------------------------------------");
foreach(Customer c in context.Customers.ToList())
{
    if (string.IsNullOrEmpty(c.Fax))
    {
        c.Fax = "No fax number";
    }
}
foreach(Supplier s in context.Suppliers.ToList())
{
    if (string.IsNullOrEmpty(s.Fax))
    {
        s.Fax = "No fax number";
    }
}
context.SaveChanges();

Console.WriteLine("\n2.2: \n--------------------------------------");
foreach(Product p in context.Products)
{
    if(p.ReorderLevel == 0 && p.UnitsInStock < 20)
    {
        p.ReorderLevel = 10;
    }
}

context.SaveChanges();

Console.WriteLine("\n2.3: \n--------------------------------------");
foreach (Customer c in context.Customers)
{
    if(c.Country == "Spain")
    {
        if(c.City == "Mardid")
        {
            c.Region = "Madrid";
        }
        else if(c.City == "Barcelona")
        {
            c.Region = "Catalonia";
        }
        else if(c.City == "Seville")
        {
            c.Region = "Andalusia";
        }
    }
}

context.SaveChanges();

Console.WriteLine("\n2.4: \n--------------------------------------");

foreach(Customer c in context.Customers)
{
    if (c.CompanyName == "Simons bistro")
    {
        c.CompanyName = "Simons Vaffelhus";
        c.Address = "Strandvej 65";
        c.City = "Vejle";
        c.PostalCode = "7100";
        c.Region = "Syddanmark";
    }
}

context.SaveChanges();

Console.WriteLine("\n2.5: \n--------------------------------------");

foreach (Customer c in context.Customers)
{
    if(c.CompanyName == "White clover markets")
    {
        c.City = "Chicago";
        c.Address = "247 New Avenue";
        c.Phone = "555-20159";
        c.PostalCode = "60007";
    }
}

context.SaveChanges();

Console.WriteLine("\n2.6: \n--------------------------------------");
foreach (Employee e in context.Employees.ToList())
{
    if(e.FirstName == "Janet")
    {
        foreach(Employee e2 in context.Employees.ToList())
        {
            if(e2.FirstName == "Andrew")
            {
                e.Address = e2.Address;
                e.City = e2.City;
                e.PostalCode = e2.PostalCode;
                e.Region = e2.Region;
            }
        }
    }
}

context.SaveChanges();

Console.WriteLine("\n3.1: \n--------------------------------------");

Employee employee = new();
employee.FirstName = "Kim";
employee.LastName = "Larsen";
employee.City = "Sønderborg";
employee.Address = "Violvej 45";
employee.HomePhone = "75835264";
employee.HireDate = new(2023, 01, 01);
employee.Extension = "0745";



context.Employees.Add(employee);



Console.WriteLine("\n3.2: \n--------------------------------------");



Employee employee2 = new();
employee2.FirstName = "Dima";
employee2.LastName = "Viktor";
employee2.City = "Odense";
employee2.Address = "Vedikke 45";
employee2.HomePhone = "758753264";
employee2.HireDate = new(2022, 11, 01);
employee2.Extension = "0745";



Employee employee3 = new();
employee3.FirstName = "Mads";
employee3.LastName = "Mikkel Rasmussen";
employee3.City = "Vejle";
employee3.Address = "Vedikke 46";
employee3.HomePhone = "75835242";
employee3.HireDate = new(2022, 11, 01);
employee3.Extension = "0745";



context.Employees.Add(employee2);
context.Employees.Add(employee3);




Console.WriteLine("\n3.3: \n--------------------------------------");



Product product1 = new();
product1.ProductName = "SuperDuperBeer";
product1.QuantityPerUnit = "2";
product1.UnitPrice = 12;



context.Products.Add(product1);


Console.WriteLine("\n3.4: \n--------------------------------------");



Supplier s2 = new();
s2.ContactTitle = "Campus Vejle";
s2.Fax = "53262";
s2.PostalCode = "7100";
s2.Region = "Østjylland";
s2.City = "Vejle";
s2.CompanyName = "Campus Vejle";
s2.ContactName = "Campus Vejle";
s2.Country = "Danmark";
s2.HomePage = "campusvejle.dk";



context.Suppliers.Add(s2);
product1.Supplier = s2;
context.SaveChanges();



Console.WriteLine("\n3.5: \n--------------------------------------");



Shipper s4 = new();
s4.Phone = "62462624";
s4.CompanyName = "Mærsk";



Console.WriteLine("\n3.6: \n--------------------------------------");



context.SaveChanges();

Console.WriteLine("\n4.1: \n--------------------------------------");

List<string> returnStrings = new List<string>();
foreach(Territory t in context.Territories.ToList())
{
    foreach(Region r in context.Regions.ToList())
    {
        if(r.RegionId == t.RegionId)
        {
            if (!returnStrings.Contains(t.TerritoryDescription + ": " + r.RegionDescription))
            {
                returnStrings.Add(t.TerritoryDescription + ": " + r.RegionDescription);
            }  
        } 
    }
}

foreach(string s in returnStrings)
{
    Console.WriteLine(s);
}

Console.WriteLine("\n4.2: \n--------------------------------------");

UnitOfWork unitOfWork = new();

