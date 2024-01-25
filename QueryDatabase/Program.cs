using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

var person = new List<Person>();
var lee = new Person { Name = "Lee", DateOfBirth = new DateTime(1890, 5, 7) };

person.Add(lee);

var robert = new Person { Name = "Robert", DateOfBirth = new DateTime(1920, 7, 10), Father = lee };

lee.Children.Add(robert);

person.Add(robert);

var kris = new Person { Name = "Kris", DateOfBirth = new DateTime(1944, 12, 26), Father = lee };

lee.Children.Add(kris);

person.Add(kris);



void Senirity(string name,List<Person> persons,bool desc)
{
    var thatGuy = person.Find(x => x.Name == name);

    if (thatGuy != null && thatGuy.Children.Any())
    {
        if (desc)
        {
            var order = thatGuy.Children.OrderByDescending(x => x.DateOfBirth)
                .Select(c => c.Name);
        
            Console.WriteLine($"Result: {string.Join(">",order)}");
        }
        else
        {
            var order = thatGuy.Children.OrderBy(x => x.DateOfBirth)
                .Select(c => c.Name);
        
            Console.WriteLine($"Result: {string.Join("<",order)}");
        }
        
        
    }
    else
    {
        Console.WriteLine("Result: Not Found");
    }
}

Console.WriteLine("=========Answer 3================");

Senirity("Lee",person,true);

Senirity("Kris",person,true);

Console.WriteLine("=========Answer 4================");
// Answer 4
Senirity("Lee",person,false);

Senirity("Kris",person,false);

public class Person
{
    [Key]
    public int PersonId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    public DateTime DateOfBirth { get; set; }

    // Foreign key for Parent (assuming a person can only have one father and one mother)
    public int? FatherId { get; set; }
    public int? MotherId { get; set; }

    // Navigation properties
    [ForeignKey("FatherId")]
    public virtual Person Father { get; set; }

    [ForeignKey("MotherId")]
    public virtual Person Mother { get; set; }

    public virtual ICollection<Person> Children { get; set; }

    public Person()
    {
        Children = new HashSet<Person>();
    }
}


 