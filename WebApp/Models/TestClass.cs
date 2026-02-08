namespace WebApp.Models
{
    public class TestClass
    {
        public int Sum(int x, int y)
        {

            return x + y;
        }
        public void test()
        {
            
            int a = 10;
            int b = 20;
            Sum(a, b);
            int f = 100, v = 200;
            Sum(f, v);
            
        }
    }
}
