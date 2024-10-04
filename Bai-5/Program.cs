using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_5
{

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Khởi tạo mảng
            Item[] items = new Item[20]
            {
            new Item { Id = 1, Name = "Item 1", Price = 10.5, CreatedDate = DateTime.Now.AddDays(-1), IsActive = true },
            new Item { Id = 2, Name = "Item 2", Price = 21.0, CreatedDate = DateTime.Now.AddDays(-2), IsActive = false },
            new Item { Id = 3, Name = "Item 3", Price = 31.5, CreatedDate = DateTime.Now.AddDays(-3), IsActive = true },
            new Item { Id = 4, Name = "Item 4", Price = 42.0, CreatedDate = DateTime.Now.AddDays(-4), IsActive = false },
            new Item { Id = 5, Name = "Item 5", Price = 52.5, CreatedDate = DateTime.Now.AddDays(-5), IsActive = true },
            new Item { Id = 6, Name = "Item 6", Price = 63.0, CreatedDate = DateTime.Now.AddDays(-6), IsActive = false },
            new Item { Id = 7, Name = "Item 7", Price = 73.5, CreatedDate = DateTime.Now.AddDays(-7), IsActive = true },
            new Item { Id = 8, Name = "Item 8", Price = 84.0, CreatedDate = DateTime.Now.AddDays(-8), IsActive = false },
            new Item { Id = 9, Name = "Item 9", Price = 94.5, CreatedDate = DateTime.Now.AddDays(-9), IsActive = true },
            new Item { Id = 10, Name = "Item 10", Price = 105.0, CreatedDate = DateTime.Now.AddDays(-10), IsActive = false },
            new Item { Id = 11, Name = "Item 11", Price = 115.5, CreatedDate = DateTime.Now.AddDays(-11), IsActive = true },
            new Item { Id = 12, Name = "Item 12", Price = 126.0, CreatedDate = DateTime.Now.AddDays(-12), IsActive = false },
            new Item { Id = 13, Name = "Item 13", Price = 136.5, CreatedDate = DateTime.Now.AddDays(-13), IsActive = true },
            new Item { Id = 14, Name = "Item 14", Price = 147.0, CreatedDate = DateTime.Now.AddDays(-14), IsActive = false },
            new Item { Id = 15, Name = "Item 15", Price = 157.5, CreatedDate = DateTime.Now.AddDays(-15), IsActive = true },
            new Item { Id = 16, Name = "Item 16", Price = 168.0, CreatedDate = DateTime.Now.AddDays(-16), IsActive = false },
            new Item { Id = 17, Name = "Item 17", Price = 178.5, CreatedDate = DateTime.Now.AddDays(-17), IsActive = true },
            new Item { Id = 18, Name = "Item 18", Price = 189.0, CreatedDate = DateTime.Now.AddDays(-18), IsActive = false },
            new Item { Id = 19, Name = "Item 19", Price = 199.5, CreatedDate = DateTime.Now.AddDays(-19), IsActive = true },
            new Item { Id = 20, Name = "Item 20", Price = 210.0, CreatedDate = DateTime.Now.AddDays(-20), IsActive = false }
            };
            //Code here…
            ArrayList arrayListItems = new ArrayList(items); // Chuyển mảng items sang ArrayList
            List<Item> listItems = new List<Item>(items); // Chuyển mảng items sang List<Item>
            // Hiển thị danh sách mảng
            Console.WriteLine("Danh sách các sản phẩm:");
            DisplayItems(items);
            Console.WriteLine("Danh sách sản phẩm trong ArrayList:");
            DisplayItems(arrayListItems);
            Console.WriteLine("Danh sách sản phẩm trong List<Item>:");
            DisplayItems(listItems);
            // 
            // Tìm kiếm phần tử có Id = 10 trong ArrayList
            FindItemInArrayList(arrayListItems, 10);

            // Tìm kiếm phần tử có Id = 10 trong List<Item>
            FindItemInList(listItems, 10);
            // Xóa các sản phẩm có giá nhỏ hơn 100 trong ArrayList
            ItemPriceLessThan100(arrayListItems, 100);
            // Xóa các sản phẩm có giá nhỏ hơn 100 trong List<Item>
            ItemPriceLessThan100(listItems, 100);
            // Hiển thị danh sách sau khi xóa
            Console.WriteLine("Danh sách sản phẩm trong ArrayList sau khi xóa các sản phẩm có giá nhỏ hơn 100:");
            DisplayItems(arrayListItems);
            Console.WriteLine("Danh sách sản phẩm trong List<Item> sau khi xóa các sản phẩm có giá nhỏ hơn 100:");
            DisplayItems(listItems);
            // Hiển thị danh sách sản phẩm có IsActive = true
            Console.WriteLine("Danh sách sản phẩm có IsActive = true trong ArrayList:");
            DisplayActiveItems(arrayListItems);
            Console.WriteLine("Danh sách sản phẩm có IsActive = true trong List<Item>:");
            DisplayActiveItems(listItems);

            // Hiển thị sản phẩm được tạo trong vòng 10 ngày
            Console.WriteLine("Danh sách sản phẩm được tạo trong vòng 10 ngày:");
            DisplayItemsInLast10Days(listItems);
            // Câu 7: Sắp xếp danh sách theo Price từ lớn đến nhỏ
            Console.WriteLine("Danh sách sản phẩm sau khi sắp xếp theo Price từ lớn đến nhỏ (ListItem):");
            var sortedItems = listItems.OrderByDescending(i => i.Price).ThenBy(i => i.Name).ToList();
            DisplayItems(sortedItems);
            var sortedArrayList = SortArrayList(arrayListItems);
            Console.WriteLine("Danh sách sản phẩm sau khi sắp xếp theo Price từ lớn đến nhỏ (ArrayList):");
            DisplayItems(sortedArrayList);
            // Câu 8: Nhập vào tên sản phẩm để tìm kiếm
            Console.Write("Nhập tên sản phẩm để tìm kiếm: ");
            string nameToFind = Console.ReadLine();
            SearchItemByNameInArrayList(arrayListItems, nameToFind);
            SearchItemByNameInList(listItems, nameToFind);

            // Câu 9: Tính tổng giá tiền của tất cả sản phẩm
            double totalPriceArrayList = CalculateTotalPrice(arrayListItems);
            double totalPriceList = CalculateTotalPrice(listItems);
            Console.WriteLine($"Tổng giá tiền trong ArrayList: {totalPriceArrayList}");
            Console.WriteLine($"Tổng giá tiền trong ListItem: {totalPriceList}");

            // Câu 10: Tìm sản phẩm có giá trị lớn nhất
            FindMaxPriceItemsAndSortByCreatedDate(listItems);
            FindMaxPriceItemsAndSortByCreatedDate(arrayListItems);




        }
        // Hàm hiển thị danh sách sản phẩm
        static void DisplayItems(Item[] items)
        {
            Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-20} | {4,-10}", "ID", "Name", "Price", "Created Date", "IsActive");

            Console.WriteLine(new string('-', 80));
            foreach (var item in items)
            {
                Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-20} | {4,-10}",
                    item.Id, item.Name, item.Price, item.CreatedDate.ToString("dd/MM/yyyy"), item.IsActive ? "Active" : "Inactive");
            }
            Console.WriteLine(); // Dòng trống sau khi hiển thị danh sách
        }
        static void DisplayItems(ArrayList items)
        {
            Console.WriteLine($"Tổng số lượng sản phẩm: {items.Count}");
            Console.WriteLine();
            Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-20} | {4,-10}", "ID", "Name", "Price", "Created Date", "IsActive");
            Console.WriteLine(new string('-', 80));

            foreach (Item item in items)
            {
                Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-20} | {4,-10}",
                    item.Id, item.Name, item.Price, item.CreatedDate.ToString("dd/MM/yyyy"), item.IsActive ? "Active" : "Inactive");
            }

            Console.WriteLine(); // Dòng trống sau khi hiển thị danh sách
        }
        static void DisplayItems(List<Item> items)
        {
            Console.WriteLine($"Tổng số lượng sản phẩm: {items.Count}");
            Console.WriteLine();
            Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-20} | {4,-10}", "ID", "Name", "Price", "Created Date", "IsActive");
            Console.WriteLine(new string('-', 80));

            foreach (Item item in items)
            {
                Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-20} | {4,-10}",
                    item.Id, item.Name, item.Price, item.CreatedDate.ToString("dd/MM/yyyy"), item.IsActive ? "Active" : "Inactive");
            }

            Console.WriteLine(); // Dòng trống sau khi hiển thị danh sách
        }
        // Hàm tìm kiếm trong ArrayList
        static void FindItemInArrayList(ArrayList items, int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Item item = (Item)items[i]; // Ép kiểu về Item
                if (item.Id == id)
                {
                    Console.WriteLine($"Tìm thấy trong ArrayList: Id = {item.Id}, Name = {item.Name}, Price = {item.Price}, Vị trí: {i} , IsActive : {(item.IsActive ? "Active" : "InActive")}");
                    return;
                }
            }
            Console.WriteLine($"Không tìm thấy phần tử có Id = {id} trong ArrayList.");
        }

        // Hàm tìm kiếm trong List<Item>
        static void FindItemInList(List<Item> items, int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id)
                {
                    Console.WriteLine($"Tìm thấy trong ListItem: Id = {items[i].Id}, Name = {items[i].Name}, Price = {items[i].Price}, Vị trí: {i}, IsActive : {(items[i].IsActive ? "Active" : "InActive")}");
                    return;
                }
            }
            Console.WriteLine($"Không tìm thấy phần tử có Id = {id} trong List<Item.");
        }
        static void ItemPriceLessThan100(ArrayList items, double pricebehon100)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                Item item = (Item)items[i]; // Ép kiểu về Item
                if (item.Price < pricebehon100)
                {
                    items.RemoveAt(i); // Xóa phần tử tại vị trí i
                }
            }
        }
        static void ItemPriceLessThan100(List<Item> items, double pricenhohon100)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Price < pricenhohon100)
                {
                    items.RemoveAt(i); // Xóa phần tử tại vị trí i
                }
            }
        }
        // Hàm hiển thị danh sách sản phẩm có IsActive = true trong ArrayList
        static void DisplayActiveItems(ArrayList items)
        {
            foreach (Item item in items)
            {
                if (item.IsActive)
                {
                    Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Price: {item.Price}, IsActive = {(item.IsActive ? "Active" : "Inactive")}");
                    Console.WriteLine(new string('-', 50)); // Ngăn cách giữa các sản phẩm
                }
            }
            Console.WriteLine(); // Dòng trống sau khi hiển thị danh sách
        }

        // Hàm hiển thị danh sách sản phẩm có IsActive = true trong List<Item>
        static void DisplayActiveItems(List<Item> items)
        {
            foreach (Item item in items)
            {
                if (item.IsActive)
                {
                    Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Price: {item.Price}, IsActive = {(item.IsActive ? "Active" : "Inactive")}");
                    Console.WriteLine(new string('-', 50)); // Ngăn cách giữa các sản phẩm
                }
            }
            Console.WriteLine(); // Dòng trống sau khi hiển thị danh sách
        }
        // Hàm hiển thị danh sách sản phẩm được tạo trong vòng 10 ngày
        static void DisplayItemsInLast10Days(List<Item> items)
        {
            DateTime tenDaysAgo = DateTime.Now.AddDays(-10); // Lấy thời điểm 10 ngày trước
            bool found = false; // Biến để kiểm tra xem có sản phẩm nào được tìm thấy không

            foreach (var item in items)
            {
                if (item.CreatedDate <= tenDaysAgo) // Kiểm tra ngày tạo
                {
                    Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Price: {item.Price}, CreatedDate: {item.CreatedDate:dd/MM/yyyy}");
                    found = true; // Đã tìm thấy ít nhất một sản phẩm
                }
            }

            if (!found) // Nếu không tìm thấy sản phẩm nào
            {
                Console.WriteLine("Không có sản phẩm nào được tạo trong vòng 10 ngày qua.");
            }

            Console.WriteLine(); // Dòng trống sau khi hiển thị danh sách
        }
        static void FindItemByName(List<Item> items, string name)
        {
            bool found = false;
            foreach (var item in items)
            {
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Tìm thấy sản phẩm: Id = {item.Id}, Name = {item.Name}, Price = {item.Price}, IsActive: {(item.IsActive ? "Active" : "Inactive")}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Không tìm thấy sản phẩm với tên '{name}'.");
            }
            Console.WriteLine(); // Dòng trống sau khi hiển thị kết quả
        }
        static void FindMaxPriceItemsAndSortByCreatedDate(ArrayList items)
        {
            List<Item> itemList = new List<Item>();
            foreach (Item item in items)
            {
                itemList.Add(item);
            }
            var maxPrice = itemList.Max(i => i.Price);
            var maxPriceItems = itemList.Where(i => i.Price == maxPrice).ToList();

            // Sắp xếp theo CreatedDate
            maxPriceItems = maxPriceItems.OrderBy(i => i.CreatedDate).ToList();

            Console.WriteLine($"Sản phẩm có giá trị lớn nhất trong ArrayList ({maxPrice}):");
            foreach (var item in maxPriceItems)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, CreatedDate: {item.CreatedDate:dd/MM/yyyy}, IsActive: {(item.IsActive ? "Active" : "Inactive")}");
            }
            Console.WriteLine(); // Dòng trống sau khi hiển thị danh sách
        }
        static void FindMaxPriceItemsAndSortByCreatedDate(List<Item> items)
        {
            var maxPrice = items.Max(i => i.Price);
            var maxPriceItems = items.Where(i => i.Price == maxPrice).ToList();

            // Sắp xếp theo CreatedDate
            maxPriceItems = maxPriceItems.OrderBy(i => i.CreatedDate).ToList();

            Console.WriteLine($"Sản phẩm có giá trị lớn nhất trong ListItem ({maxPrice}):");
            foreach (var item in maxPriceItems)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, CreatedDate: {item.CreatedDate:dd/MM/yyyy}, IsActive: {(item.IsActive ? "Active" : "Inactive")}");
            }
            Console.WriteLine(); // Dòng trống sau khi hiển thị danh sách
        }
        static double CalculateTotalPrice(List<Item> items)
        {
            double total = items.Sum(item => item.Price);
            return total;
        }

        static double CalculateTotalPrice(ArrayList items)
        {
            double total = 0;
            foreach (Item item in items)
            {
                total += item.Price;
            }
            return total;
        }
        static ArrayList SortArrayList(ArrayList items)
        {
            var sortedList = items.Cast<Item>()
                .OrderByDescending(i => i.Price)
                .ThenBy(i => i.Name)
                .ToList();
            return new ArrayList(sortedList);
        }
        static void SearchItemByNameInArrayList(ArrayList items, string name)
        {
            bool found = false;
            foreach (Item item in items)
            {
                if (item.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"Tìm thấy trong ArrayList: Id = {item.Id}, Name = {item.Name}, Price = {item.Price}, IsActive = {(item.IsActive ? "Active" : "Inactive")}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Không tìm thấy sản phẩm với tên '{name}' trong ArrayList.");
            }
            Console.WriteLine(); // Empty line after displaying result
        }
        static void SearchItemByNameInList(List<Item> items, string name)
        {
            bool found = false;
            foreach (var item in items)
            {
                if (item.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"Tìm thấy trong List<Item>: Id = {item.Id}, Name = {item.Name}, Price = {item.Price}, IsActive = {(item.IsActive ? "Active" : "Inactive")}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Không tìm thấy sản phẩm với tên '{name}' trong List<Item>.");
            }
            Console.WriteLine();
        }
    }

}



