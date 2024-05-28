using Business.Manager;
using Business.Service;
using Business.Services;
using DAL.Abstract;
using DAL.Concrete;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IAboutUsService,AboutUsManager>();
builder.Services.AddScoped<IAboutDAL, AboutUsRepository>();

builder.Services.AddScoped<IReservationService, ReservationManager>();
builder.Services.AddScoped<IReservationDAL, ReservationRepository>();

builder.Services.AddScoped<IContactUsService, ContactUsManager>();
builder.Services.AddScoped<IContactUsDAL, ContactUsRepository>();

builder.Services.AddScoped<ITestimonialService, TestimonialMananger>();
builder.Services.AddScoped<ITestimonialDAL, TestimonialRepository>();

builder.Services.AddScoped<IFeaturesService, FeaturesManager>();
builder.Services.AddScoped<IFeaturesDAL, FeaturesRepository>();

builder.Services.AddScoped<IOffersService, OffersManager>();
builder.Services.AddScoped<IOffersDAL, OfferRepository>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDAL, ProductRepository>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDAL, CategoryRepository>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDAL, SocialMediaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
