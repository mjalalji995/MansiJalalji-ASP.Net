using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class web : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\20SOECA21015\NET1\WebSite2\App_Data\emp.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SqlDataAdapter adpt = new SqlDataAdapter("select id from emp1",con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            ddlID.DataSource = ds.Tables[0];
            ddlID.DataTextField = "id";
            ddlID.DataValueField = "id";
            ddlID.DataBind();
            getData();
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into emp1 values(@name,@age)",con);
        cmd.Parameters.AddWithValue("@name",txtName.Text);
        cmd.Parameters.AddWithValue("@age",Convert.ToInt32( txtAge.Text));
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("Data Inserted");
        getData();
    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("update emp1 set name=@name,age=@age where id=@id",con);
        cmd.Parameters.AddWithValue("@name",txtName.Text);
        cmd.Parameters.AddWithValue("@age",txtAge.Text);
        cmd.Parameters.AddWithValue("@id",ddlID.SelectedItem.ToString());
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("Data Updated");
        getData();
    }

    protected void ddlID_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataAdapter adpt = new SqlDataAdapter("select * from emp1 where id='" + ddlID.SelectedItem.ToString()+"'",con);
        DataSet ds = new DataSet();
        adpt.Fill(ds);
        txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
        txtAge.Text = ds.Tables[0].Rows[0]["age"].ToString();
        getData();
    }

    public void getData()
    {
        SqlDataAdapter adpt = new SqlDataAdapter("select * from emp1", con);
        DataSet ds = new DataSet();
        adpt.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
}