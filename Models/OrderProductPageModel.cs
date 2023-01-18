using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagazinAranjamenteFlorale.Models
{
    public class OrderProductPageModel:PageModel
    {
        public List<AssignedProductData> availableProducts;
        public void PopulateProducts(MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext context, Order Order)
        {
            var allProducts = context.Product;
            var orderProducts = new HashSet<int>(Order.OrderProducts.Select(p => p.ProductID));
            availableProducts = new List<AssignedProductData>();
            foreach(var prod in allProducts)
            {
                availableProducts.Add(new AssignedProductData
                {
                    ProductID = prod.ID,
                    Name = prod.Name,
                    Assigned = orderProducts.Contains(prod.ID),
                    Price = prod.Price
                });
            }
        }

        public void UpdateOrderProducts(
            MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext context,
            Order Order,
            string[] selectedProducts
            )
        {
            if (selectedProducts == null)
            {
                Order.OrderProducts = new List<OrderProduct>();
                return;
            }

            var selectedProductsMap = new HashSet<string>(selectedProducts);
            var orderProducts = new HashSet<int>(Order.OrderProducts.Select(p => p.ID));

            foreach(var prod in context.Product)
            {
                if (selectedProductsMap.Contains(prod.ID.ToString()))
                {
                    if (!orderProducts.Contains(prod.ID))
                    {
                        Order.OrderProducts.Add(new OrderProduct
                        {
                            OrderID = Order.ID,
                            ProductID = prod.ID
                        });
                    }
                } else
                {
                    if (orderProducts.Contains(prod.ID))
                    {
                        OrderProduct productToRemove = Order.OrderProducts.SingleOrDefault(p => p.ProductID == prod.ID);
                        if (productToRemove != null)
                        {
                            context.Remove<OrderProduct>(productToRemove);
                        }
                    }
                }
            }
        }
    }
}
