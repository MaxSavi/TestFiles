using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Member
{
    public string name { get; set; }
    public int age { get; set; }
    public string secretIdentity { get; set; }
    public List<string> powers { get; set; }
}

public class Squad
{
    public string squadName { get; set; }
    public string homeTown { get; set; }
    public int formed { get; set; }
    public string secretBase { get; set; }
    public bool active { get; set; }
    public List<Member> members { get; set; }
}

class Program
{
    static void Main()
    {
        //Читаем JSON-файл
        string jsonFilePath = "C:\\Users\\Asus\\Downloads\\SuperHero.json";
        string jsonContent = File.ReadAllText(jsonFilePath);

        Squad ListJson = JsonConvert.DeserializeObject<Squad>(jsonContent);

        //Создание новых участников
        Member newMember1 = new Member
        {
            name = "SuperMan",
            age = 45,
            secretIdentity = "Clark Joseph Kent",
            powers = new List<string> { "Superhuman strength", "Invulnerability", "Flight", "Superhuman speed", "X-ray vision" }
        };

        Member newMember2 = new Member
        {
            name = "Flash",
            age = 30,
            secretIdentity = "Barry Allen",
            powers = new List<string> { "Speed Force Conduit", "Superhuman Speed", "Superhuman Reflexes", "Superhuman Stamina", "Superhuman Agility", "Superhuman Strength" }
        };

        //Добавление новых участников к существующим
        ListJson.members.Add(newMember1);
        ListJson.members.Add(newMember2);

        //Сортировка по возрасту по убыванию
        ListJson.members = ListJson.members.OrderByDescending(m => m.age).ToList();

        string updatedJson = JsonConvert.SerializeObject(ListJson, Formatting.Indented);
        //Сохранение обновленный JSON-файл
        string UpdJsonFilePath = "C:\\Users\\Asus\\Downloads\\SuperHeroUpd.json";
        File.WriteAllText(UpdJsonFilePath, updatedJson);

        Console.WriteLine("JSON файл успешно обновлен.");
    }
}