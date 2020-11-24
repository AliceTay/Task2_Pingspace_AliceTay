using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ToDoApplication
{
    public partial class Main : System.Web.UI.Page
    {

        protected void btn_addnewtodolist_Click(object sender, EventArgs e)
        {
            if(txt_newtodolistitem.Text.Trim() != "") {
                try
                {

                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoListConnectionString"].ConnectionString);
                    conn.Open();
                    string insertQuery = "insert into tblToDoListItem(ToDoListItem) values (@todolistitem)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@todolistitem", txt_newtodolistitem.Text.Trim());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    chkToDoList.DataBind();
                    chkCompletedList.DataBind();
                    txt_newtodolistitem.Text = "";
                }
                catch (Exception ex)
                {
                    Response.Write("error" + ex.ToString());
                }
            }

        }

        protected void chkToDoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i=0; i < chkToDoList.Items.Count; i++)
            {
                if (chkToDoList.Items[i].Selected)
                {
                    MoveToCompleteList(chkToDoList.Items[i].Value.Trim(), chkToDoList.Items[i].Text.Trim());
                }
            }
        }

        protected void MoveToCompleteList(string ID, string item)
        {
            InsertItemCompleteList(ID, item);
            RemoveItemCompleteList(ID, item);
            chkToDoList.DataBind();
            chkCompletedList.DataBind();
        }

        protected void InsertItemCompleteList(string id, string item)
        {

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoListConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into CompletedListItem(Id,CompletedListItem) values (@id,@completeditemlist)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@completeditemlist", item);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

        }

        protected void RemoveItemCompleteList(string id, string item)
        {

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoListConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "DELETE FROM tblToDoListItem WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

        }

        protected void chkCompletedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkCompletedList.Items.Count; i++)
            {
                if (chkCompletedList.Items[i].Selected)
                {
                    MoveToToDoList(chkCompletedList.Items[i].Value.Trim(), chkCompletedList.Items[i].Text.Trim());
                }
            }
        }

        protected void MoveToToDoList(string ID, string item)
        {
            InsertItemToDoList(ID,item);
            RemoveItemToDoList(ID, item);
            chkToDoList.DataBind();
            chkCompletedList.DataBind();
        }

        protected void InsertItemToDoList(string id, string item)
        {

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoListConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into tblToDoListItem(ToDoListItem) values (@todolistitem)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@todolistitem", item);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

        }

        protected void RemoveItemToDoList(string id, string item)
        {

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoListConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "DELETE FROM CompletedListItem WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {

            if(txt_deleteitem.Text.Trim() != "")
            {
                DeleteCompletedListItem(txt_deleteitem.Text.Trim());
                DeleteToDoListItem(txt_deleteitem.Text.Trim());
                chkToDoList.DataBind();
                chkCompletedList.DataBind();
            }
            
        }

        protected void DeleteCompletedListItem(string item)
        {

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoListConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "DELETE FROM CompletedListItem WHERE CompletedListItem = @item";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@item", item);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

        }

        protected void DeleteToDoListItem(string item)
        {

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoListConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "DELETE FROM tblToDoListItem WHERE ToDoListItem = @item";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@item", item);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

        }

    }
}