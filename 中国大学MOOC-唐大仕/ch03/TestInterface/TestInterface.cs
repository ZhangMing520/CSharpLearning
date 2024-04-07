using System;

namespace TestInterface
{
    class TestInterface
    {
        static void m1(Runner r)
        {
            r.run();
        }

        static void m2(Swimmer s)
        {
            s.swim();
        }

        static void m3(Animal a)
        {
            a.eat();
        }

        static void m4(Person p)
        {
            p.speak();
        }

        /// <summary>
        /// 多态 Person 可以传给 Runner、Swimmer、Animal
        /// </summary>
        /// <param name="args"></param>
        static void Main2(string[] args)
        {
            Person p = new Person();
            m1(p);
            m2(p);
            m3(p);
            m4(p);

            Runner r = new Person();
            r.run();

            Console.ReadKey();
        }
    }

}


interface Runner
{
    void run();
}

interface Swimmer
{
    void swim();
}

abstract class Animal
{
    abstract public void eat();
}

/// <summary>
/// 单继承类，多实现接口
/// </summary>
class Person : Animal, Runner, Swimmer
{
    public override void eat()
    {
        Console.WriteLine("eat");
    }

    public void run()
    {
        Console.WriteLine("run");
    }

    public void swim()
    {
        Console.WriteLine("swim");
    }

    public void speak()
    {
        Console.WriteLine("speak");
    }

}
