using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class Details : System.Web.UI.Page
    {
        List<Adventurer> adventurers = new List<Adventurer>(); // List to store adventurers
        List<Item> items = Helper.GetAvailableItems(); // List to store available items

        int index = -1; // Index to track the selected adventurer

        protected void Page_Load(object sender, EventArgs e)
        {
            Get_Index(); // Retrieve index from query string
            Get_Adventurers(); // Retrieve adventurers from session
            Reset_ErrorMessages(); // Hide and reset error messages

            if (!IsPostBack)
            {
                Populate_Items(); // Populate items checklist only on initial page load
            }

            Display_AdventurerDetails(); // Display adventurer's details
        }

        protected void Get_Index()
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Default.aspx"); // Redirect to default page if index is not provided
            }

            index = int.Parse(Request.QueryString["id"]); // Parse index from query string
        }

        protected void Get_Adventurers()
        {
            if (Session["adventurers"] != null)
            {
                adventurers = (List<Adventurer>)Session["adventurers"]; // Retrieve adventurers from session
            }
        }

        protected void Reset_ErrorMessages()
        {
            lblErrorMessages.Visible = false;
            lblErrorMessages.Text = string.Empty; // Hide and clear error messages
        }

        protected void Populate_Items()
        {
            int itemIndex = 0;
            foreach (Item item in items)
            {
                ListItem listItem = new ListItem($"{item.Name} ({item.StrengthRequirement}/{item.DexterityRequirement}/{item.ManaRequirement})", itemIndex.ToString());

                if (adventurers.Count > 0)
                {
                    if (adventurers[index].Item_Equiped(item))
                    {
                        listItem.Selected = true; // Select items that are already equipped by the adventurer
                    }
                }

                cblItems.Items.Add(listItem); // Add item to the checklist

                itemIndex++;
            }
        }

        protected void Display_AdventurerDetails()
        {
            if (index >= 0 && index < adventurers.Count)
            {
                Adventurer adventurer = adventurers[index];

                // Display adventurer's details on the page
                txtName.InnerText = adventurer.Name;
                txtType.InnerText = adventurer.Type;
                txtPhrase.InnerText = adventurer.Greeting();

                lblStrength.Text = adventurer.Strength.ToString();
                lblDexterity.Text = adventurer.Dexterity.ToString();
                lblVitality.Text = adventurer.Vitality.ToString();
                lblMana.Text = adventurer.Mana.ToString();
            }
            else
            {
                Response.Redirect("Default.aspx"); // Redirect to default page if adventurer details can't be displayed
            }
        }

        protected void btnEquipItems_Click(object sender, EventArgs e)
        {
            if (index >= 0 && index < adventurers.Count)
            {
                Adventurer adventurer = adventurers[index];

                adventurer.EquippedItems.Clear(); // Clear currently equipped items

                List<Item> unequippedItems = new List<Item>(); // List to store unequipped items

                foreach (ListItem itemListItem in cblItems.Items)
                {
                    int itemIndex = int.Parse(itemListItem.Value);
                    Item item = items[itemIndex];

                    if (itemListItem.Selected)
                    {
                        try
                        {
                            adventurer.Equip_Item(item); // Try to equip the selected item
                        }
                        catch (Exception ex)
                        {
                            unequippedItems.Add(item); // If equipping fails, add to unequipped items list
                        }
                    }
                }

                if (unequippedItems.Count > 0)
                {
                    lblErrorMessages.Visible = true;

                    // Display unequipped item names in error message
                    foreach (Item unequippedItem in unequippedItems)
                    {
                        lblErrorMessages.Text += $"{unequippedItem.Name} cannot be equipped.";
                    }

                    // Unselect unequipped items in the checklist
                    foreach (ListItem itemListItem in cblItems.Items)
                    {
                        int itemIndex = int.Parse(itemListItem.Value);
                        Item item = items[itemIndex];

                        if (unequippedItems.Contains(item))
                        {
                            itemListItem.Selected = false;
                        }
                    }
                }
                else
                {
                    // Update session and redirect if no errors
                    Session["adventurers"] = adventurers;
                    Response.Redirect($"Details.aspx?id={index}");
                }
            }
        }
    }
}
