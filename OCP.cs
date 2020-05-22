using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        var computers = new List<Computers>
        {
            new Computers { Name = "Asus ROG", Processor = Processor.AMD, Type = ComputerType.Laptop},
            new Computers { Name = "Artline Gaming GX", Processor = Processor.Intel, Type = ComputerType.Desktop },
            new Computers { Name = "MSI Gaming", Processor = Processor.AMD, Type = ComputerType.Laptop }        
        };

        var filter = new ComputersFilter();

        var laptops = filter.Filter(computers, new ComputerTypeSpecification(ComputerType.Laptop));
        Console.WriteLine("All Laptops:");
        foreach (var computer in laptops)
        {
        Console.WriteLine($"Name: {computer.Name}, Type: {computer.Type}, Processor: {computer.Processor}");
        }
    }
 }

public enum ComputerType
{
    Desktop,
    Laptop
    
}

public enum Processor
{
    AMD,
    Intel
}

public class Computers
{
    public string Name { get; set; }
    public ComputerType Type { get; set; }
    public Processor Processor { get; set; }
}
public class ComputersFilter
{
    public List<Computers> FilterByType(IEnumerable<Computers> computers, ComputerType type) =>
            computers.Where(с => с.Type == type).ToList();

    public List<Computers> FilterByProcessor(IEnumerable<Computers> computers, Processor processor) =>
            computers.Where(с => с.Processor == processor).ToList();

    public List<Computers> Filter(IEnumerable<Computers> computers, ISpecification<Computers> specification) =>
        computers.Where(с => specification.isSatisfied(с)).ToList();

}



 public interface ISpecification<T>
{
    bool isSatisfied(T item);
}

public interface IFilter<T>
{
    List<T> Filter(IEnumerable<T> computers, ISpecification<T> specification);
}

public class ComputerTypeSpecification: ISpecification<Computers>
{
    private readonly ComputerType _type;

    public ComputerTypeSpecification(ComputerType type)
    {
        _type = type;
    }

    public bool isSatisfied(Computers item) => item.Type == _type;
}


