using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreFront.DATA.EF.Models;
using Newtonsoft.Json;
using StoreFront.UI.MVC.Models;

namespace StoreFront.UI.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        #region Steps to Implement Session Based Shopping Cart
        /*
         * 1) Register Session in program.cs (builder.Services.AddSession... && app.UseSession())
         * 2) Create the CartItemViewModel class in [ProjName].UI.MVC/Models folder
         * 3) Add the 'Add To Cart' button in the Index and/or Details view of your Products
         * 4) Create the ShoppingCartController (empty controller -> named ShoppingCartController)
         *      - add using statements
         *          - using GadgetStore.DATA.EF.Models;
         *          - using Microsoft.AspNetCore.Identity;
         *          - using GadgetStore.UI.MVC.Models;
         *          - using Newtonsoft.Json;
         *      - Add props for the GadgetStoreContext && UserManager
         *      - Create a constructor for the controller - assign values to context && usermanager
         *      - Code the AddToCart() action
         *      - Code the Index() action
         *      - Code the Index View
         *          - Start with the basic table structure
         *          - Show the items that are easily accessible (like the properties from the model)
         *          - Calculate/show the lineTotal
         *          - Add the RemoveFromCart <a>
         *      - Code the RemoveFromCart() action
         *          - verify the button for RemoveFromCart in the Index view is coded with the controller/action/id
         *      - Add UpdateCart <form> to the Index View
         *      - Code the UpdateCart() action
         *      - Add Submit Order button to Index View
         *      - Code SubmitOrder() action
         * */
        #endregion

        //Properties
        private readonly StoreFrontContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController(StoreFrontContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            //retrieve the cart
            var sessionCart = HttpContext.Session.GetString("cart");

            //create the shell for the local (C#) shopping czart 
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            //if the session cart is null, or if there are 0 items in the session cart, return a message to notify user that cart is empty
            if (sessionCart == null || sessionCart.Count() == 0)
            {
                ViewBag.Message = "There are no items in your cart.";

                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }
            else
            {
                ViewBag.Message = null;

                shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);
            }

            return View(shoppingCart);
        }

        public IActionResult AddToCart(int id)
        {
            //TODO: handle creating cart item, adding to session, serializing...

            //Local cart instance
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            //retrieve the session instance of the cart to see if it exists yet
            var sessionCart = HttpContext.Session.GetString("cart");

            //if the session cart is null, instantiate the local shopping cart
            if (sessionCart == null)
            {


                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }

            //otherwise, retrieve and convert the contents from the session cart
            //here, we are taking the JSON that is in sessionCart, and converting it into C# for our local instance shoppingCart
            else
            {
                shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);
                //Deserialize is just a fancy term for 'convert' -- it is converting JSON into C#
            }

            Equipment product = _context.Equipment.Find(id);

            CartItemViewModel civm = new CartItemViewModel(1, product);

            if (shoppingCart.ContainsKey(product.EquipmentId))
            {
                shoppingCart[product.EquipmentId].Qty++;
            }
            else
            {
                shoppingCart.Add(product.EquipmentId, civm);
            }

            string jsonCart = JsonConvert.SerializeObject(shoppingCart);
            HttpContext.Session.SetString("cart", jsonCart);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            //Retrieve our cart from session
            var sessionCart = HttpContext.Session.GetString("cart");

            //Convert JSON cart to C#
            Dictionary<int, CartItemViewModel> shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);

            //Remove the cart item from the C# collection
            shoppingCart.Remove(id);

            //Update session again
            if (shoppingCart.Count == 0)
            {
                HttpContext.Session.Remove("cart");
            }
            else
            {
                string jsonCart = JsonConvert.SerializeObject(shoppingCart);
                HttpContext.Session.SetString("cart", jsonCart);
            }

            //Send the user back to the ShoppingCart index
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCart(int productId, int qty)
        {
            var sessionCart = HttpContext.Session.GetString("cart");

            Dictionary<int, CartItemViewModel> shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);

            shoppingCart[productId].Qty = qty;

            string jsonCart = JsonConvert.SerializeObject(shoppingCart);
            HttpContext.Session.SetString("cart", jsonCart);

            return RedirectToAction("Index");
        }

    }
}
