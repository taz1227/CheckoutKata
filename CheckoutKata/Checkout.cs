using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutKata
{
    public static class Checkout
    {
        public static double ProcessOrder(string order )
        {
            // Populate Order object with values sent through
            Order itemA = new Order
            {
                ItemSKU = "A",
                Item = new Item { UnitPrice = 10},
                Quantity = GetQuantityOfItem(order, 'A')
            };

            Order itemB = new Order
            {
                ItemSKU = "B",
                Item = new Item { UnitPrice = 15 },
                Quantity = GetQuantityOfItem(order, 'B')
            };
            Order itemC = new Order
            {
                ItemSKU = "C",
                Item = new Item { UnitPrice = 40 },
                Quantity = GetQuantityOfItem(order, 'C')
            };
            Order itemD = new Order
            {
                ItemSKU = "D",
                Item = new Item { UnitPrice = 55 },
                Quantity = GetQuantityOfItem(order, 'D')
            };

            List<Order> orderList = new List<Order>();

            orderList.Add(itemA);
            orderList.Add(itemB);
            orderList.Add(itemC);
            orderList.Add(itemD);

            return BasketTotal(orderList);
        }

        public static double BasketTotal(List<Order> order)
        {
            double totalPrice = 0;

            foreach (var item in order)
            {
                // Apply 3 for 40 discount
                if (item.ItemSKU == "B")
                {
                    // Discount Applied
                    totalPrice = totalPrice + (GetDiscountForItemB(item) * 40);

                    // Add remaining items of order
                    totalPrice = totalPrice + ((item.Quantity % 3) * item.Item.UnitPrice);
                }

                // Apply 25% off for every 2 purchased together
                else if (item.ItemSKU == "D")
                {
                    totalPrice = totalPrice + (item.Quantity * item.Item.UnitPrice - GetDiscountForItemD(item));
                }

                // Apply normal calculations for items A and C
                else
                {
                    totalPrice = totalPrice + (item.Item.UnitPrice * item.Quantity);
                }
            }

            return Math.Round(totalPrice, 2);
        }

        /// <summary>
        /// Get quantity of each item given in the order
        /// </summary>
        /// <param name="order"></param>
        /// <param name="itemSKU"></param>
        /// <returns></returns>
        private static int GetQuantityOfItem(string order, char itemSKU)
        {
            return order.ToCharArray().Count(x => x == itemSKU);
        }

        /// <summary>
        ///  Calculate the item for Item B
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static int GetDiscountForItemB(Order item)
        { 
            return (item.Quantity - item.Quantity % 3) / 3;
        }

        /// <summary>
        /// Calculate the discount for Item D
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static double GetDiscountForItemD(Order item)
        {
            int mutiplesOf2InQuantity = (item.Quantity - item.Quantity % 2) / 2;

            return mutiplesOf2InQuantity * item.Item.UnitPrice * 2 / 100.0 * 25.0;
        }

    }
}
