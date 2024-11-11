using System;
using TodoListApp;

public partial class ManageTask : System.Web.UI.Page
{
    public bool IsEdit => Request.QueryString["id"] != null;
    protected int TaskId => IsEdit ? int.Parse(Request.QueryString["id"]) : 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && IsEdit)
        {
            Task task = TaskRepository.GetTasks().Find(t => t.Id == TaskId);
            if (task != null)
            {
                txtTitle.Text = task.Title;
                chkCompleted.Checked = task.IsCompleted;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var task = new Task
        {
            Id = TaskId,
            Title = txtTitle.Text,
            IsCompleted = chkCompleted.Checked
        };

        if (IsEdit)

        {
            TaskRepository.UpdateTask(task);
        }
        else
        {
            TaskRepository.AddTask(task);
        }

        Response.Redirect("Default.aspx");
    }
}
