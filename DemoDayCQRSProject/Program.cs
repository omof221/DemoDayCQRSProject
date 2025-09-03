using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Handlers.CarHandlers;
using DemoDayCQRSProject.CQRS.Handlers.CategoryHandlers;
using DemoDayCQRSProject.CQRS.Handlers.ContactHandlers;
using DemoDayCQRSProject.CQRS.Handlers.CustomerHandlers;
using DemoDayCQRSProject.CQRS.Handlers.ProductHandlers;
using DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers;
using DemoDayCQRSProject.CQRS.Handlers.WorkerHandlers;
using DemoDayCQRSProject.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DemoContext>();
builder.Services.AddScoped<GetCategoryQueryHandler>();  
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetProductQueryHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();
builder.Services.AddScoped<RemoveProductCommandHandler>();

builder.Services.AddHttpClient<GooglePlacesService>();

builder.Services.AddHttpClient<CarAsistantService>();

builder.Services.AddHttpClient<FuelPriceService>();


builder.Services.AddScoped<GetCustomerQueryHandler>();
builder.Services.AddScoped<GetCustomerByIdQueryHandler>();
builder.Services.AddScoped<CreateCustomerCommandHandler>();
builder.Services.AddScoped<RemoveCustomerCommanHandler>();
builder.Services.AddScoped<UpdateCustomerCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();      
builder.Services.AddScoped<RemoveCarCommandHandler>();      

builder.Services.AddScoped<GetWorkerQueryHandler>();
builder.Services.AddScoped<GetWorkerByIdQueryHandler>();
builder.Services.AddScoped<CreateWorkerCommandHandler>();
builder.Services.AddScoped<UpdateWorkerCommandHandler>();
builder.Services.AddScoped<RemoveWorkerCommandHandler>();

builder.Services.AddScoped<GetReservationQueryHandler>();
builder.Services.AddScoped<GetReservationByIdQueryHandler>();
builder.Services.AddScoped<CreateReservationCommandHandler>();
builder.Services.AddScoped<UpdateReservationCommandHandler>();
builder.Services.AddScoped<RemoveReservationCommandHandler>();


builder.Services.AddScoped<SearchAvailableCarsHandler>();   

builder.Services.AddScoped<GetCarCountQueryHandler>();

builder.Services.AddHttpClient<RapidAiService>();

builder.Services.AddScoped<ContactMessageService>();


builder.Services.AddScoped<MailService>();


builder.Services.AddScoped<GetReservationCountByMonthQueryHandler>();
// Add services to the container.
builder.Services.AddControllersWithViews();






builder.Services.AddScoped<CreateContactMessageCommandHandler>();
builder.Services.AddScoped<SetAiReplyForContactMessageCommandHandler>();
builder.Services.AddScoped<GetContactMessagesQueryHandler>();
builder.Services.AddScoped<GetContactMessageByIdQueryHandler>();








var app = builder.Build();
//builder.Services.AddScoped<DemoDayCQRSProject.CQRS.Handlers.CategoryHandlers.GetCategoryQueryHandler>();
// Configure the HTTP request pipeline.








if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
