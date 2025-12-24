// See https://aka.ms/new-console-template for more information
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

Console.WriteLine("Sending Email . . . . ");
using (var clinet = new AmazonSimpleEmailServiceClient(Amazon.RegionEndpoint.USEast1))
{
	var sendRequest = new SendEmailRequest
	{
		Source = "paul.j.sadowski@gmail.com",
		Destination = new Destination
		{
			ToAddresses = new List<string> { "paul.j.sadowski@gmail.com" }
		},
		Message = new Message
		{
			Subject = new Content("This is from the Amazon SES Email."),
			Body = new Body
			{
				Html= new Content("""
					<html><body><h1>Hello from Amazon</h1></body></html>
					""")
			}
		}
	};
	try
	{
		var response = clinet.SendEmailAsync(sendRequest).Result;
		Console.WriteLine("Email Sent! Message ID = {0}", response.MessageId);

	}
	catch (Exception ex)
	{

		Console.WriteLine("Send failed with exception: {0}", ex.Message);
	}
	Console.WriteLine("Press any key to continue. . . . ");
	Console.ReadKey();
}
