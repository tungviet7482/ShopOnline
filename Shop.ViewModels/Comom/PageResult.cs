using System.Collections.Generic;


namespace Shop.ViewModels.Comom
{
    public class PageResult<T>
    {
        public List<T> Items { set; get; }
        public int ToTalRecord { set; get; }
        public PageResult(List<T> list, int t)
        {
            Items = list;
            ToTalRecord = t;
        }
    }
}
