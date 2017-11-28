using System;

namespace helloword
{
    class Program
    {
        static void Main(string[] args)
        {
          //  B tmp = new B();
            Console.WriteLine("Hello World!");
        }
    }


    class A{
        public A(int i)
        {

        }
    }
    class B : A{
            public B(int i):base(i)
            {}
    }
}
