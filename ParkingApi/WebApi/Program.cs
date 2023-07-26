using DAL.DataContext;
using DAL.IRepository;
using DAL.Repository;
using DAL.UnitOfWork;
using BLL.IWorkServices;
using BLL.WorkServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>();
//Repository
builder.Services.AddScoped<IMiastoRepository, MiastoRepository>();
builder.Services.AddScoped<IMiejsceInwalidzkieRepository, MiejsceInwalidzkieRepository>();
builder.Services.AddScoped<IMiejsceRepository, MiejsceRepository>();
builder.Services.AddScoped<IOpiekunRepository, OpiekunRepository>();
builder.Services.AddScoped<IRezerwacjaRepository, RezerwacjaRepository>();
builder.Services.AddScoped<IParkingRepository, ParkingRepository>();

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//Service
builder.Services.AddScoped<IMiastoService, MiastoService>();
builder.Services.AddScoped<IParkingService, ParkingService>();
builder.Services.AddScoped<IOpiekunService, OpiekunService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddCors(p => p.AddPolicy("CorsPolicy", build =>
{
    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
