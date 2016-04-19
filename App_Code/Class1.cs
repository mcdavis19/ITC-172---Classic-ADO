using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//New libraries
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BooksAndAuthors
{
    //Object that connects to the database
    SqlConnection connect;

    public BooksAndAuthors()
    {
        connect = new SqlConnection(ConfigurationManager
            .ConnectionStrings["BookReviewDbConnectionString"].ToString() );
    }
    /// <summary>
    /// Called in aspx.cs file.
    /// Gets list of author names to populate dropdown list.
    /// </summary>
    /// <returns>DataTable witn names of authors</returns>
    public DataTable GetAuthors()
    {
        //sql command
        string sql = 
            "SELECT AuthorKey, AuthorName FROM Author ORDER BY authorname";
        //new datatable object
        DataTable table;
        //Connect to DB
        SqlCommand cmd = new SqlCommand(sql, connect);
        try
        {
            //execute the sql command. Store result in table.
            table = ProcessQuery(cmd);
        } catch(Exception excep)
        {
            //Error!
            throw excep;
        }
        //return table
        return table;
    }

    public DataTable GetBooksByAuthor(int authorKey)
    {
        DataTable table = null;
        //SQL command
        String sql = " SELECT * FROM book " +
            " INNER JOIN authorbook " +
            " ON book.bookkey = authorbook.bookkey " +
            " WHERE authorkey = @authorkey";
        SqlCommand cmd = new SqlCommand(sql, connect);
        //Put variable into sql
        cmd.Parameters.AddWithValue("@authorkey", authorKey);
        try
        {
            table = ProcessQuery(cmd);
        } catch (Exception ex)
        {
            throw ex;
        }
        return table;
    }

    private DataTable ProcessQuery(SqlCommand cmd)
    {
        //Table to hold data
        DataTable table = new DataTable();
        //Object to read data from database
        SqlDataReader reader;
        try
        {
            //Connect to server
            connect.Open();
            //Execute SQL
            reader = cmd.ExecuteReader();
            //Put returned data into the table
            table.Load(reader);
            //Close connection and reader
            connect.Close();
            reader.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return table;
    }
}
