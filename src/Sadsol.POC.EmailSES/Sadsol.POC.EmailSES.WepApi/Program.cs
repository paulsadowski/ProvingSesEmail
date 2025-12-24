using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Sadsol.POC.EmailSES.WepApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonSimpleEmailService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection(EmailSettings.ConfigurationSection));
// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}
app.MapPost("email" async (string email, IAmazonSimpleEmailService emailService, EmailSettings settings) =>
{
	var request = new SendEmailRequest 
	{ 
		Source = settings.SenderEmail,
		Destination = new Destination
		{
			ToAddresses = [email]
		},
		Message = new Message
		{
			Subject = new Content("This is a email message from AWS."),
			Body = new Body
			{
				Html = new Content(
					"""
						<html> 
							<body>
								<h1>Welcome to our Platform</H1>
								<p>Way to be here</p>
								<ul>
									<li> Item 1 </li>
									<li> Item 2 </li>
									<li> ITem 3 </li>
								</ul>
							</body>
						</html>
					""")
			}
		}
	};
	var response = await emailService.SendEmailAsync(request);
	return Results.Ok(new { response.MessageId, response.HttpStatusCode });
});

app.UseHttpsRedirection();

//app.UseAuthorization();

///app.MapControllers();

app.Run();
