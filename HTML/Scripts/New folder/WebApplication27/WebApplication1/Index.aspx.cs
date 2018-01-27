using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        ServiceReference1.WebService1SoapClient Client = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = Client.Students();
            GridView1.DataBind();
        }

       
             protected void Button1_Click(object sender, EventArgs e)
        {
            string S="";
            if(CheckBox1.Checked)
            {
               S=S+CheckBox1.Text+",";
            }
            if(CheckBox2.Checked)
            {
               S=S+CheckBox2.Text+",";
            }
            if(CheckBox3.Checked)
            {
               S=S+CheckBox3.Text+",";
            }
int i=  Client.InsertData(UName.Text, Convert.ToInt32(UAge.Text), UEmail.Text, RadioButtonList1.SelectedItem.Text, DropDownList1.SelectedItem.Text, S);
if (i == 1)
{
    Label1.Text = "Data Inserted";
}
else if (i == 0)
{
    Label1.Text = "Duplicate Data Can not Be inserted";
}
else
{
    Label1.Text = "Data Not Inserted";
}
      }

             protected void Button2_Click(object sender, EventArgs e)
             {

             }

             protected void Button3_Click(object sender, EventArgs e)
             {
                 int i=Client.DeleteRecord(UEmail.Text);
                 if (i == 1)
                 {
                     Label1.Text = "Data Deleted";
                 }
             }

             protected void SearchButton_Click(object sender, EventArgs e)
             {
                 GridView1.DataSource = Client.SearchRecord(UEmail.Text);
                 GridView1.DataBind();
             }

             protected void UpDateRecord_Click(object sender, EventArgs e)
             {
              var i= Client.SearchRecord(UEmail.Text);
              UName.Text=i.Select(x => x.Name).ToString();
                 
             }
    }

       
    }
