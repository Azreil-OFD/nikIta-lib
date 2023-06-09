using Lib;
using Lib.Models;

GlobalManager globalManager = new GlobalManager(
    "mongodb://admin:admin@localhost:27017",
    "homeManager");

Console.Write("Введите логин: ");
var login = Console.ReadLine();

Console.Write("Введите пароль: ");
var password1 = Console.ReadLine();




var result = globalManager.User.Register(login, password1);
Console.WriteLine(result);


foreach (Post item in globalManager.Post.GetAll())
{
    Console.WriteLine(item.Images[0]);
}
var ig = globalManager.Image.AddImage("/Users/marin/Downloads/flatter-3077077-3756163946.png");
Console.WriteLine(ig);

var igi = globalManager.Image.GetImageById(ig);

Console.WriteLine(igi);

string fileName = "image.jpg"; // Specify the desired file name
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
{
    igi.Position = 0; // Make sure the stream is at the beginning
    igi.CopyTo(fileStream);
}