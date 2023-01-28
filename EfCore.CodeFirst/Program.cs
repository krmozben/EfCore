using AutoMapper.QueryableExtensions;
using EfCore.CodeFirst.DAL;
using EfCore.CodeFirst.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using (var _context = new AppDbContext())
{

    //var category = new Category() { Name = "Kalemler" };
    //category.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 200, Barcode = "123", ProductFeature = new() { Color = "Red", Width = 100, Height = 200 } });
    //category.Products.Add(new Product() { Name = "Kalem 2", Price = 100, Stock = 200, Barcode = "123", ProductFeature = new() { Color = "Red", Width = 100, Height = 200 } });
    //category.Products.Add(new Product() { Name = "Kalem 3", Price = 100, Stock = 200, Barcode = "123", ProductFeature = new() { Color = "Red", Width = 100, Height = 200 } });

    //_context.Add(category);


    //_context.SaveChanges();

    //var productFull = _context.ProductFulls.FromSqlRaw(@"select p.Id 'Product_Id',c.Name 'CategoryName', p.Name,p.Price,pf.Height from Products p
    //join ProductFeatures pf on p.Id = pf.Id
    //join Categories c on p.Category_Id = c.Id").ToList();

    ////2 li join
    //var result = _context.Categories.Join(_context.Products, c => c.Id, p => p.Category_Id, (c, p) =>
    //new
    //{
    //    CategoryName = c.Name,
    //    ProductName = p.Name,
    //    ProductPrice = p.Price
    //}).ToList();

    //var result2 = (from c in _context.Categories
    //               join p in _context.Products on c.Id equals p.Category_Id
    //               select new
    //               {
    //                   CategoryName = c.Name,
    //                   ProductName = p.Name,
    //                   ProductPrice = p.Price
    //               }).ToList();

    ////3 lü join

    //var __result = _context.Categories
    //    .Join(_context.Products, c => c.Id, p => p.Category_Id, (c, p) => new { c, p })
    //    .Join(_context.ProductFeatures, cp => cp.p.Id, pf => pf.Id, (cp, pf) => new
    //    {
    //        CategoryName = cp.p.Name,
    //        ProductName = cp.p.Name,
    //        ProductFeature = pf
    //    }).ToList();

    //var _result2 = (from c in _context.Categories
    //               join p in _context.Products on c.Id equals p.Category_Id
    //               join pf in _context.ProductFeatures on p.Id equals pf.Id
    //               select new
    //               {
    //                   c,
    //                   p,
    //                   pf
    //               }).ToList();

    ////left join
    //var _result = (from p in _context.Products
    //              join pf in _context.ProductFeatures on p.Id equals pf.Id into pflist
    //              from pf in pflist.DefaultIfEmpty()
    //              select new
    //              {
    //                  ProductName = p.Name,
    //                  ProductColor = pf.Color,
    //                  ProductWith = (int?)pf.Width
    //              }).ToList();


    ////right join
    //var _resulrft2 = (from pf in _context.ProductFeatures
    //               join p in _context.Products on pf.Id equals p.Id into plist
    //               from p in plist.DefaultIfEmpty()
    //               select new
    //               {
    //                   ProductName = p.Name,
    //                   ProductColor = pf.Color,
    //                   ProductWith = (int?)pf.Width
    //               }).ToList();

    ////fullouther join

    //var left = (from p in _context.Products
    //            join pf in _context.ProductFeatures on p.Id equals pf.Id into pflist
    //            from pf in pflist.DefaultIfEmpty()
    //            select new
    //            {
    //                Id = p.Id,
    //                Name = p.Name,
    //                Color = pf.Color
    //            }).ToList();

    //var right = await (from pf in _context.ProductFeatures
    //                   join p in _context.Products on pf.Id equals p.Id into plist
    //                   from p in plist.DefaultIfEmpty()
    //                   select new
    //                   {
    //                       Id = p.Id,
    //                       Name = p.Name,
    //                       Color = pf.Color
    //                   }).ToListAsync();

    //var outerJoin = left.Union(right).ToList();

    ////sql raw
    //var products = await _context.Products.FromSqlRaw("select * from products where price > {0}", 100).ToListAsync();
    //var products2 = await _context.Products.FromSqlInterpolated($"select * from products where price > {100}").ToListAsync();

    //var products3 = await _context.ProductEssentials.Where(x => x.Price > 100).ToListAsync();
    //var products4 = await _context.Products.IgnoreQueryFilters().ToListAsync();

    //var a = _context.ProductFulls.FromSql($"exec sp_test");

    //var product = _context.Products.ToList();

    //var pdto = ObjectMapper.Mapper.Map<List<ProductDto>>(product);

    //var pp = _context.Products.ProjectTo<ProductDto>(ObjectMapper.Mapper.ConfigurationProvider).ToList();

    /// transaction yapısı birden fazla SaveChanges() kullanıldığı durumlarda oluşturmak mantıklıdır. Çünkü ef core zaten default olarak tek SaveChanges() te transation uygulamaktadır.


    //using (var transaction = _context.Database.BeginTransaction())
    //{
    //    var category = new Category() { Name = "Kılıflar" };
    //    _context.Categories.Add(category);
    //    _context.SaveChanges();

    //    var product = new Product()
    //    {
    //        Name = "Kalem 1",
    //        Price = 100,
    //        Stock = 200,
    //        Barcode = "123",
    //        ProductFeature = new() { Color = "Red", Width = 100, Height = 200 },
    //        Category_Id = category.Id
    //    };
    //    _context.Products.Add(product);
    //    _context.SaveChanges();

    //    //transaction.Commit();

    //    // tüm değişiklikler en son Commit() metodu sayesinde db ye yansıcaktır.
    //    // eğer custom bir işlem yapılmayacaksa(log atma vs..) try cacth bloguna alıp rollback yapmaya gerek yok. zaten hata oluştuğu anda commit metodu çalışmayacak ve işlem db ye yansımayacaktır.

    //    // multiple dbcontext transaction
    //    using (var _context2 = new AppDbContext())
    //    {
    //        _context2.Database.UseTransaction(transaction.GetDbTransaction());

    //        var c = new Category() { Name = "test" };
    //        _context2.Categories.Add(c);
    //        _context2.SaveChanges();
    //    }


    //    transaction.Commit();
    //}

    //using (var transction = _context.Database.BeginTransaction())
    //{
    //    //var b = _context.Products.First();
    //    var b = _context.Products.Where(x => x.Id == 2030).First();

    //    b.Name = "ürün";
    //    b.Stock = 87;

    //    _context.Add(new Product() { Barcode = " 123", Category_Id = 1, Name = "t1", Price = 4, Stock = 60 });

    //     _context.SaveChanges();



    //    transction.Commit();
    //}



}




Console.ReadLine();

