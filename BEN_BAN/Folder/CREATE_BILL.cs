using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BEN_NGAN_HANG
{
    public class CREATE_BILL
    {
        private void AddItemToTable(HtmlNode parent, string itemName, string quantity, string price, string total)
        {
            var newRow = parent.OwnerDocument.CreateElement("tr");
            newRow.InnerHtml = $@"
                <td>{itemName}</td>
                <td>{quantity}</td>
                <td>{price}</td>
                <td>{total}</td>";
            parent.AppendChild(newRow);
        }
        public void create_bill(out string html_bill, string buyer_name, string buyer_phone, string buyer_location, List<Item> items)
        {
            // Load the sample HTML file
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load("..\\..\\Signature\\contract.html");

            // Update the necessary information
            doc.GetElementbyId("transaction-date").InnerHtml = DateTime.Now.ToString("dd-MM-yyyy");
            doc.GetElementbyId("seller-name").InnerHtml = "Nguyen Thanh Tai";
            doc.GetElementbyId("seller-phone").InnerHtml = "0777412175";
            doc.GetElementbyId("seller-location").InnerHtml = "Ho Chi Minh";
            doc.GetElementbyId("buyer-name").InnerHtml = buyer_name;
            doc.GetElementbyId("buyer-phone").InnerHtml = buyer_phone;
            doc.GetElementbyId("buyer-location").InnerHtml = buyer_location;

            // Add sample items to the item list
            var itemList = doc.GetElementbyId("item-list");
            int total = 0;
            string delivery_charges = "20000";
            for (int i = 0; i < items.Count; ++i)
            {
                Item item = items[i];
                AddItemToTable(itemList, item.item, item.quantity.ToString(), item.price.ToString(), item.total.ToString());
                total += item.total;
            }
            doc.GetElementbyId("delivery_charges").InnerHtml = delivery_charges;
            doc.GetElementbyId("total").InnerHtml = (total + Convert.ToInt32(delivery_charges)).ToString();
            // Calculate the subtotal, tax, and total
            // Save the updated HTML to a new file
            html_bill = doc.DocumentNode.OuterHtml;

        }
    }
}
