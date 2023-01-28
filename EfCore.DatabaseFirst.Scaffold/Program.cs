using EfCore.DatabaseFirst.Scaffold.Models;
using Microsoft.EntityFrameworkCore;


using (var _context = new EfCoreDatabaseFirstContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(x =>
    {
        Console.WriteLine(x.Id + " " + x.Name + " " + x.Price);
    });

}

Console.ReadLine();