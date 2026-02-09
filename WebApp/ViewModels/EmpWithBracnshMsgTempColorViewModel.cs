namespace WebApp.ViewModels
{
    public class EmpWithBracnshMsgTempColorViewModel
    {
        //----Hide & send some Property
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        //--add Extra Property
        public string Message { get; set; }
        public int Temp { get; set; }
        public string Color { get; set; }

        //-------merge another Model
        public List<string> Branches { get; set; }
    }
}
