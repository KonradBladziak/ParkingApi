using DAL.DataContext;
using DAL.IRepository;
using DAL.Repository;
using DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>();
//Repo
builder.Services.AddScoped<IMiastoRepository, MiastoRepository>();
builder.Services.AddScoped<IMiejsceInwalidzkieRepository, MiejsceInwalidzkieRepository>();
builder.Services.AddScoped<IMiejsceRepository, MiejsceRepository>();
builder.Services.AddScoped<IOpiekunRepository, OpiekunRepository>();
builder.Services.AddScoped<IRezerwacjaRepository, RezerwacjaRepository>();
builder.Services.AddScoped<IParkingRepository, ParkingRepository>();

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
