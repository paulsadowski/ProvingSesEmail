namespace Sadsol.POC.EmailSES.WepApi
{
	public class EmailSettings
	{
		public const string ConfigurationSection = nameof(EmailSettings);
		public string SenderEmail { get; set; } = string.Empty;

	}
}
