using StoreFront.DATA.EF.Models;

namespace StoreFront.UI.MVC.Models
{
    public class CartItemViewModel
    {
        public int Qty { get; set; }
        public Equipment CartProd { get; set; }

        public CartItemViewModel() { }
        public CartItemViewModel(int qty, Equipment product) //Parameter names don't need to match the Property names.
        {
            Qty = qty;
            CartProd = product;
        }
    }
}


//CartItemViewModel civm = new CartItemViewModel();
//civm.CartProd