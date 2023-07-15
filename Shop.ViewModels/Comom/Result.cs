



namespace Shop.ViewModels.Comom
{
    public class Result<T>
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public T ResultObj { set; get; }
        public Result(string mes, bool s, T res)
        {
            Message = mes;
            Status = s;
            ResultObj = res;
        }
    }
}
