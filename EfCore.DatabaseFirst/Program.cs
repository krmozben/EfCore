using EfCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;

DbContextInitializer.Build();

using (var _context = new AppDbContext(DbContextInitializer.OptionsBuilder.Options))
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(x =>
    {
        Console.WriteLine(x.Id + " " + x.Name + " " + x.Price);
    });

}

using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(x =>
    {
        Console.WriteLine(x.Id + " " + x.Name + " " + x.Price);
    });

}

Console.ReadLine();