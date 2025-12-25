// See https://aka.ms/new-console-template for more information
using TesseractOCR;
using TesseractOCR.Enums;

Console.WriteLine("Hello, World!");
using var engine = new Engine(@"./tessdata", Language.English, EngineMode.Default);
using var img = TesseractOCR.Pix.Image.LoadFromFile(@"C:\Temp\Receipt_20241017_PGN.pdf");
using var page = engine.Process(img);
Console.WriteLine("Mean confidence: {0}", page.MeanConfidence);
Console.WriteLine("Text: \r\n{0}", page.Text);