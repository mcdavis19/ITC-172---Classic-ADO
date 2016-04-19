using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    //Create object. Connects to database on server.
    BooksAndAuthors ba = new BooksAndAuthors();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillDropDownList();
        } 
    }//End Page_Load

    

    protected void FillDropDownList()
    {
        DataTable table = null;
        try
        {
            table = ba.GetAuthors();
        } catch (Exception ex)
        {
            throw ex;
        }
        //Put data from database into dropdown list.
        DropDownList1.DataSource = table;
        DropDownList1.DataTextField = "AuthorName";
        DropDownList1.DataValueField = "AuthorKey";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Choose a Service");
        
    }//End FillDropDownList

    protected void FillGridView()
    {
        //Table to store books
        DataTable booksTable = null;
        //Get author key from dropdown list.
        int authorKey = int.Parse(DropDownList1.SelectedValue.ToString() );
        try
        {
            booksTable = ba.GetBooksByAuthor(authorKey);
            //debugging
            //if (booksTable.Rows.Count > 0)
            //{
            //    throw new Exception();
            //}
        } catch (Exception ex)
        {
            throw ex;
        }
        //Put data into gridview
        GridView1.DataSource = booksTable;
        GridView1.DataBind();
    }//End FillGridView

    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        FillGridView();
    }
}//End class