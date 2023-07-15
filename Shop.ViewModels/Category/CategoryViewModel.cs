using Shop.Data.Enums;

namespace Shop.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public bool IsShowOnHome { set; get; }
        public int? ParentId { set; get; }
        public Status Status { set; get; }
    }
}
