abstract class Learner
{
    protected string Name;

    public Learner(string name)
    {
        Name = name;
    }

    public abstract void Study();
}

class Schoolchild : Learner
{
    public Schoolchild(string name) : base(name)
    {
    }

    public override void Study()
    {
        Console.WriteLine(Name + " is studying school subjects");
    }
}

class Student : Learner
{
    public Student(string name) : base(name)
    {
    }

    public override void Study()
    {
        Console.WriteLine(Name + " is studying university subjects");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Learner[] learners = {
            new Schoolchild("Ivan"),
            new Student("Maria"),
            new Schoolchild("Petr"),
            new Student("Anna")
        };

        foreach (Learner learner in learners)
        {
            learner.Study();
        }
    }
}
