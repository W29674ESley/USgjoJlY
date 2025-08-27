// 代码生成时间: 2025-08-27 15:04:09
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp
{
    /// <summary>
    /// Represents a product in the shopping cart.
    /// </summary>
    public class Product
    {
        public string Id { get; set; } // Unique identifier for the product
        public string Name { get; set; } // Name of the product
        public decimal Price { get; set; } // Price of the product
        public int Quantity { get; set; } // Quantity of the product in the cart
    }

    /// <summary>
    /// Represents the shopping cart service.
    /// </summary>
    public class ShoppingCartService
    {
        private readonly List<Product> _items = new List<Product>();

        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        /// <param name="product">The product to be added.</param>
        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (product.Quantity <= 0) throw new ArgumentException("Quantity must be greater than zero.");

            var existingProduct = _items.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
            }
            else
            {
                _items.Add(product);
            }
        }

        /// <summary>
        /// Removes a product from the cart.
        /// </summary>
        /// <param name="productId">The ID of the product to be removed.</param>
        public void RemoveProduct(string productId)
        {
            if (string.IsNullOrEmpty(productId)) throw new ArgumentException("Product ID cannot be null or empty.");

            var productToBeRemoved = _items.FirstOrDefault(p => p.Id == productId);
            if (productToBeRemoved != null)
            {
                _items.Remove(productToBeRemoved);
            }
            else
            {
                throw new KeyNotFoundException("Product with the specified ID does not exist in the cart.");
            }
        }

        /// <summary>
        /// Updates the quantity of a product in the cart.
        /// </summary>
        /// <param name="productId">The ID of the product to be updated.</param>
        /// <param name="newQuantity">The new quantity of the product.</param>
        public void UpdateProductQuantity(string productId, int newQuantity)
        {
            if (string.IsNullOrEmpty(productId)) throw new ArgumentException("Product ID cannot be null or empty.");
            if (newQuantity < 0) throw new ArgumentException("Quantity cannot be negative.");

            var productToUpdate = _items.FirstOrDefault(p => p.Id == productId);
            if (productToUpdate != null)
            {
                productToUpdate.Quantity = newQuantity;
            }
            else
            {
                throw new KeyNotFoundException("Product with the specified ID does not exist in the cart.");
            }
        }

        /// <summary>
        /// Calculates the total price of the cart.
        /// </summary>
        /// <returns>The total price of the cart.</returns>
        public decimal CalculateTotalPrice()
        {
            return _items.Sum(item => item.Price * item.Quantity);
        }

        /// <summary>
        /// Clears all items from the cart.
        /// </summary>
        public void ClearCart()
        {
            _items.Clear();
        }

        /// <summary>
        /// Gets the list of products in the cart.
        /// </summary>
        /// <returns>The list of products.</returns>
        public List<Product> GetCartItems()
        {
            return _items.ToList();
        }
    }
}
