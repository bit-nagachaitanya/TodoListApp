using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoListApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTaskList();
            }
        }

        private void BindTaskList()
        {
            // Bind the GridView with data from TaskRepository
            gvTasks.DataSource = TaskRepository.GetTasks();
            gvTasks.DataBind();
        }

        protected void gvTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
            if (e.CommandName == "Edit")

            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                int id = Convert.ToInt32(gvTasks.DataKeys[rowIndex].Value);

                // Redirect to the ManageTask page with the selected task ID
                Response.Redirect("ManageTask.aspx?id=" + id);
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Check if DataKeys are set and retrieve the TaskId of the row being deleted
            if (gvTasks.DataKeys[e.RowIndex] != null)
            {
                if (gvTasks.DataKeys.Count == 0)
                {
                    // No keys are available, return or handle accordingly
                    return;
                }

                // Retrieve the TaskId of the row being deleted from DataKeys
                int taskId = 0;
                if (gvTasks.DataKeys[e.RowIndex] != null)
                {
                    taskId = Convert.ToInt32(gvTasks.DataKeys[e.RowIndex].Value);
                }
                else
                {
                    // Handle the case where DataKey might be missing for this row
                    return;
                }








               

                // Call the TaskRepository's delete method to delete the task from the database
                TaskRepository.DeleteTask(taskId);

                // Rebind the GridView to reflect the updated list
                BindTaskList();
            }
        }
        protected void gvTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
