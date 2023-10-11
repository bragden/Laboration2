using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace Laboration2
{
    internal class Program
    {
        public static List<Product> products = new List<Product>();

        Product Soda = new Product("Soda", 5);
        Product Chips = new Product("Chips", 10);
        Product Gun = new Product("Gun", 20000);

        public static List<Product> cart = new List<Product>();
        
        public static List<Customer> users = new List<Customer>();
        
        Customer Knatte = new Customer("Knatte", "123");
        Customer Fnatte = new Customer("Fnatte", "321");
        Customer Tjatte = new Customer("Tjatte", "213");
        


        private static Customer? loggedInCustomer;

        


        static void Main(string[] args)
        {
            users.Add(new Customer("Knatte", "123"));
            users.Add(new Customer("Fnatte", "321"));
            users.Add(new Customer("Tjatte", "213"));

            products.Add(new Product("Soda", 5));
            products.Add(new Product("Chips", 10));
            products.Add(new Product("Gun", 20000));
            
            
            
            
            MainMenu();
            
        }
        public static void MainMenu()
        {
            Console.WriteLine("------BLACKMARKET------");
            Console.WriteLine("[1] LOGIN");
            Console.WriteLine("[2] NEW CUSTOMER");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Login();
                    break;

                case 2:
                    Register();
                    Console.WriteLine("------REGISTER------");
                    break;
            }
        }

        public static void Menu()
        {
            while (true)
            {

            Console.Clear();
            Console.WriteLine("------MENU------");
            Console.WriteLine("[1] SHOP");
            Console.WriteLine("[2] CART");
            Console.WriteLine("[3] CHECKOUT");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Shop();
                    break;
                case "2":
                    ViewCart();
                    Console.WriteLine("------CART------");
                    break;
                case "3":
                    Checkout();
                    Console.WriteLine("------CHECKOUT------");
                    break;
                case "4":
                    SignOut();
                    Console.WriteLine("------SIGN OUT------");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;

            }



            }
        }

        public static void Shop()
        {


            while (true)
            {

            Console.Clear();
            Console.WriteLine("------SHOP------");
            Console.WriteLine("List of Products:");

            int index = 1;

            foreach (Product product in products)
            { 
                Console.WriteLine($"{index++}: Product Name: {product.Name}, Price: {product.Price:C}");
            }
                Console.WriteLine($"99: return to menu");

                {
                //index++;
                Console.WriteLine("Enter the number of desired product");

                    if (int.TryParse(Console.ReadLine(), out int selectedProduct) && selectedProduct >= 1 && selectedProduct <= products.Count)
                    {
                        Product product = products[selectedProduct - 1];
                        loggedInCustomer.Cart.Add(product);



                    }
                    else if (selectedProduct == 99)
                    {
                        
                        return;

                    }
                    else
                    {
                        Console.WriteLine("Invalid input, press enter to try again");
                        Console.ReadLine();
                    }
                        

                    


            }

            }







        }

        public static void ViewCart()
        {
            Console.Clear();
            Console.WriteLine("------CART------");
            Console.WriteLine("Your Cart:");
            Console.WriteLine(loggedInCustomer);
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();


        }

        public static void Checkout()
        {
            Console.Clear();
            Console.WriteLine("------CHECKOUT------");
            Console.WriteLine("Your order will be deliver in 3-5 days.");
            Console.ReadLine();
                    
        }
        
        public static void SignOut()
        {
            Console.Clear();
            Console.WriteLine("------SIGN OUT------");
        }

        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("USERNAME:");
            string username = Console.ReadLine();
            Console.WriteLine("PASSWORD:");
            string password = Console.ReadLine();

            Customer customer = users.FirstOrDefault(u => u.Name == username && u.Password == password);
            
            if (customer != null)
            {
                
                Console.WriteLine($"Welcome {username}!! press any key");
                Console.ReadKey();
                loggedInCustomer = customer;
                Menu();
                
            }
            else
            {
                Console.WriteLine("Username or password incorrect, would you like to try again or create a new account?");
                Console.WriteLine("[1] TRY AGAIN");
                Console.WriteLine("[2] CREATE ACCOUNT");

                int choice = int.Parse(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                }
            }
        }

        public static void Register()
        {
            Console.Clear();
            Console.WriteLine("------REGISTER------");
            Console.WriteLine(" USERNAME:");
            string newUsername = Console.ReadLine();
            Console.WriteLine("NEW PASSWORD:");
            string newPassword = Console.ReadLine();

            Customer existingCustomer = users.FirstOrDefault(u => u.Name == newUsername);
            if (existingCustomer != null)
            {
                Console.WriteLine("Username is already existing");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                Register();
            }
            else
            {
                Customer newCustomer = new Customer(newUsername, newPassword);
                users.Add(newCustomer);
            }

            Console.WriteLine("New account created!! press any key");
            Console.ReadKey();
            Login();
        }

                


            

        
    }
}