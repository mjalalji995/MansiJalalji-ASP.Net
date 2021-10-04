using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class customizegridview : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\20SOECA21015\NET1\WebSite2\App_Data\emp.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData();
        }

    }

    public void getData()
    {
        SqlDataAdapter adpt = new SqlDataAdapter("select * from emp1", con);
        DataSet ds = new DataSet();
        adpt.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        getData();
    }



    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        getData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
        TextBox txtName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
        TextBox txtAge = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAge");
        FileUpload FileUpload1 = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");

        Response.Write(lblID.Text+ "<br>" +txtName.Text+ "<br>" +txtAge.Text);
    }
}