using System;
using System.Collections.Generic;
using System.Data;
namespace WebApplication
{
    public partial class ViewForm : System.Web.UI.Page
    {
        public object SqlDataSource1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
 
        }
        protected void lbInsert_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["Name"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
            SqlDataSource1.InsertParameters["Gender"].DefaultValue =
                ((DropDownList)GridView1.FooterRow.FindControl("ddlInsertGender")).SelectedValue;
            SqlDataSource1.InsertParameters["City"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;
            SqlDataSource1.Insert();
        }
    }
}