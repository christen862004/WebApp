namespace WebApp.Models
{
    class TestView
    {
        object data;//
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        public dynamic DyanmicData
        {
            get { return data; }
            set { data = value; }
        }
    }



    class Parent<T>
    {
        public T Data { get; set; }
    }
    class Child1:Parent<int>
    {

    }

    class Child2<T>:Parent<T> { }

    public class TestClass
    {
        public int Sum(int x, int y)
        {

            return x + y;
        }
        public void test()
        {
            TestView v = new TestView();
            v.Data = 1;
            Console.WriteLine(v.DyanmicData);



            //create objec tfrom generic
            Parent<int> p = new Parent<int>();
            Child1 c = new Child1();
            Child2<int> c2 = new Child2<int>();





            dynamic x = 10;//runtime 
            dynamic msg = "hi";
            dynamic obj = new Student();


            msg = obj - x;//dynaimc exception "rnutime" bad 


            int a = 10;
            int b = 20;
            Sum(a, b);
            //int f = 100, v = 200;
            //Sum(f, v);
            
        }
    }
}
