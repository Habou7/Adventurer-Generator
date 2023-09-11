using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class Default : System.Web.UI.Page
    {
        List<string> AdventurerTypes = new List<string>()
        {
            "Mage",
            "Paladin",
        };
        List<Adventurer> adventurers = new List<Adventurer>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (string AdventurerType in AdventurerTypes)
                {
                    ddlType.Items.Add(new ListItem(AdventurerType));
                }
            }
        }

        protected void Clear_Form()
        {
            txtName.Text = string.Empty;
            ddlType.SelectedIndex = 0;
        }
        public class Paladin : Adventurer
        {
            public Paladin(string name) : base(name)
            {
            }

            public override double StrengthMultiplier => 1.5;
            public override double ManaMultiplier => 0.5;

            public override string Greeting()
            {
                return "I live to serve.";
            }
        }

        public class Mage : Adventurer
        {
            public Mage(string name) : base(name)
            {
            }

            public override double StrengthMultiplier => 0.5;
            public override double ManaMultiplier => 1.5;

            public override string Greeting()
            {
                return "Magic is all around us.";
            }
        }

        protected void Display_Adventurers()
        {
            tblAdventurers.Rows.Clear(); 

            foreach (int index in Enumerable.Range(0, adventurers.Count))
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                HyperLink adventurerLink = new HyperLink();
                adventurerLink.Text = $"{adventurers[index].Name} ({adventurers[index].GetType().Name})";
                adventurerLink.NavigateUrl = $"Details.aspx?id={index}"; 
                cell.Controls.Add(adventurerLink);

                row.Cells.Add(cell);
                tblAdventurers.Rows.Add(row);
            }
        }



        protected void btnCreateAdventurer_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string type = ddlType.SelectedValue;

            Adventurer newAdventurer;

            if (type == "Mage")
            {
                newAdventurer = new Mage(name);
            }
            else if (type == "Paladin")
            {
                newAdventurer = new Paladin(name);
            }
            else
            {
                
                return;
            }

            adventurers.Add(newAdventurer);
            Session["adventurers"] = adventurers; 

            Clear_Form();
            Display_Adventurers(); 
        }

    }
}