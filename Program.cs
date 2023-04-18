using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookStoreWebApp.Services;
using BookStoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using BookStoreWebApp.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BookService>();
builder.Services.AddControllersWithViews();

// Configure MySQL database connection
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("BookStoreDB").Replace("{MYSQL_PASSWORD}", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

// TestConnection route
app.MapControllerRoute(
    name: "testConnection",
    pattern: "test-connection",
    defaults: new { controller = "Book", action = "TestConnection" });

app.MapFallbackToFile("index.html");

app.Run();
