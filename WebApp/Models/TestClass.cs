namespace WebApp.Models
{
    //DIP IOC
    interface ISort
    {
        void Sort(int[] Arr);
    }
    class ChrisSort : ISort
    {
        public void Sort(int[] Arr)
        {
           
        }
    }
    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {

        }
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {

        }
    }



    //MyList High level + BubbleSort Low Level   (IOC ) tigh couple
    class MyList
    {
        int[] arr;
        ISort sortAl;
        public MyList(ISort _sort)//dependency Inject
        {
            arr = new int[10];
            sortAl = _sort;//new BubbleSort();//dont create but ask (Ctor  | mehtod)
        }
        public void sortAsc()//ISort _al)
        {
            sortAl.Sort(arr);
        }
    }
    class Test2
    {
        public void test()
        {
            MyList l1 = new MyList(new BubbleSort());
            MyList l2 = new MyList(new SelectionSort());
            MyList l3 = new MyList(new ChrisSort());
        }
    }








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
