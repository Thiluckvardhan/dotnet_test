
public abstract class Employee
{
    protected int Id{get;set;}
    protected string Name{get;set;}
    protected double Salary{get;set;}

    protected Employee(int id,string name)
    {
        Id=id;
        Name=name;
    }
    public abstract void CalcSalary(int days,double dailyfees);

    public abstract void DisplaySal();
}

public class FullTimeEmployee:Employee
{
    public FullTimeEmployee(int id,string name):base(id,name)
    {
        Console.WriteLine($"Full Time Employee {Name} has joined the Company with Id {Id}");
    }

    public override void CalcSalary(int days,double dailyfees)
    {
        Salary=days*dailyfees+500;  //Five hundered  is bonus for Full time Employee
    }

    public override void DisplaySal()
    {
        Console.WriteLine($"{Name}'s Salary is : {Salary}");
    }
}

public class ContractEmployee:Employee
{
    public ContractEmployee(int id,string name):base(id,name)
    {
        Console.WriteLine($"Contract Employee  {Name} has joined the Company with Id {Id}");
    }

    public override void CalcSalary(int days,double dailyfees)
    {
        Salary=days*dailyfees+200;  //Two hundered  is bonus for Full time Employee
    }
    
}