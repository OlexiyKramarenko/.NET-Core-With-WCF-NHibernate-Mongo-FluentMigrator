using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Entities.Newsletters;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.DataLayer.EF.Entities.Store;
using MShop.DataLayer.EF.Entities.Users;
using System.Collections.Generic;

namespace MShop.DataLayer.EF
{
	public class DataBaseContext : IdentityDbContext<ApplicationUser>
	{
		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

		public DbSet<Category> Categories { get; set; }
		public DbSet<Article> Articles { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Forum> Forums { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Newsletter> Newsletters { get; set; }
		public DbSet<Poll> Polls { get; set; }
		public DbSet<PollOption> PollOptions { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<OrderStatus> OrderStatuses { get; set; }
		public DbSet<ShippingMethod> ShippingMethods { get; set; }
		public DbSet<AnsweredUser> AnsweredUsers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>().HasKey(a => a.Id);
			modelBuilder.Entity<Category>().HasMany(a => (List<Article>)a.Articles).WithOne(a => (Category)a.Category);

			modelBuilder.Entity<Article>().HasKey(a => a.Id);
			modelBuilder.Entity<Article>().HasMany(a => (List<Comment>)a.Comments).WithOne(a => (Article)a.Article);

			modelBuilder.Entity<Forum>().HasKey(a => a.Id);
			modelBuilder.Entity<Forum>().HasMany(a => (List<Post>)a.Posts).WithOne(a => (Forum)a.Forum);

			modelBuilder.Entity<Poll>().HasKey(a => a.Id);
			modelBuilder.Entity<Poll>().HasMany(a => (List<PollOption>)a.PollOptions).WithOne(a => (Poll)a.Poll);

			modelBuilder.Entity<Department>().HasKey(a => a.Id);
			modelBuilder.Entity<Department>().HasMany(a => (List<Product>)a.Products).WithOne(a => (Department)a.Department);

			modelBuilder.Entity<Order>().HasKey(a => a.Id);
			modelBuilder.Entity<Order>().HasMany(a => (List<OrderItem>)a.OrderItems).WithOne(a => (Order)a.Order);

			modelBuilder.Entity<OrderStatus>().HasKey(a => a.Id);
			modelBuilder.Entity<OrderStatus>().HasMany(a => (List<Order>)a.Orders).WithOne(a => (OrderStatus)a.OrderStatus);

			modelBuilder.Entity<OrderItem>().HasKey(a => a.Id);
			modelBuilder.Entity<OrderItem>().HasOne(a => (Product)a.Product);
		}
	}
}
