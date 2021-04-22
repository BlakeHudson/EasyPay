﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasyPay
{
    /// <summary>
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        List<Product> products = new List<Product>();
        public ProductsWindow()
        {
            InitializeComponent();

            LoadCustomerList();
        }

        public void LoadCustomerList()
        {
            products = SQLiteDataAccess.LoadProducts();

            WireUpProductList(products);
        }

        public void WireUpProductList(List<Product> products)
        {
            ProductListBox.ItemsSource = products;
        }

        public void setTextBlank()
        {
            NameBox.Text = "";
            PriceBox.Text = "";
            IDBox.Text = "";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != "" && PriceBox.Text != "")
            {
                if(ProductListBox.SelectedItem != null)
                {
                    MessageBox.Show("Updating Product information.");
                    string name = NameBox.Text;
                    double price = double.Parse(PriceBox.Text);
                    int id = -1;

                    string s = ProductListBox.SelectedItem.ToString();
                    foreach(Product p in products)
                    {
                        if (p.compareTo(s))
                            id = p.Product_ID;
                    }

                    if (id != -1)
                    {
                        Product product = new Product(id, name, price);

                        SQLiteDataAccess.UpdateProduct(product);

                        setTextBlank();
                        LoadCustomerList();
                    }
                    else
                        MessageBox.Show("Could not find product index.");
                }
                else
                {
                    MessageBox.Show("Adding new Product.");
                    string name = NameBox.Text;
                    double price = double.Parse(PriceBox.Text);
                    int id = products.Last().Product_ID + 1;
                    Product product = new Product(id, name, price);

                    SQLiteDataAccess.SaveProduct(product);

                    setTextBlank();
                    LoadCustomerList();
                }
            }
            else
                MessageBox.Show("Please enter information in both boxes.");
        }

        private void ProductListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductListBox.SelectedItem != null)
                Add_UpdateProdBlock.Text = "Update Selected Product: ";
            else
                Add_UpdateProdBlock.Text = "Add Product: ";
        }
    }
}
