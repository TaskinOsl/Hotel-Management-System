using System.Collections.Generic;

namespace Model.HMS.ViewModel
{
    public class MenuViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public long ParentId { get; set; }
        public int SortOrder { get; set; }
        public IList<MenuViewModel> Menus { get; set; }

        public MenuViewModel()
        {
            Menus = new List<MenuViewModel>();
        }
    }
}
