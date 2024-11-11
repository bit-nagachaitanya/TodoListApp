<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoListApp._Default" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>To-Do List</title>
    <!-- Bootstrap CDN for styling -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-pzjw8f+ua7Kw1TIq0i7ex3mw7CgXHzZNCfdo5h1zPfnOBsmz6Qp5mLkfoXn8uXz8" crossorigin="anonymous">
    <style>
        /* Custom CSS to improve the appearance */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f7fc;
        }
        h2 {
            text-align: center;
            color: #4CAF50;
            margin-top: 20px;
            font-size: 2.5rem;
        }
        .container {
            margin-top: 50px;
        }
        .grid-container {
            display: flex;
            justify-content: flex-end;
            margin-bottom: 20px;
        }
        .add-task-btn {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border-radius: 5px;
            font-weight: bold;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }
        .add-task-btn:hover {
            background-color: #45a049;
        }
        .gridview-table {
            width: 100%;
            border-collapse: collapse;
        }
        .gridview-table th, .gridview-table td {
            padding: 15px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
        .gridview-table th {
            background-color: #f8f9fa;
            color: #333;
        }
        .gridview-table td {
            background-color: white;
            color: #555;
        }
        .gridview-table .btn {
            padding: 5px 10px;
            margin-right: 5px;
            border-radius: 3px;
        }
        .gridview-table .btn-edit {
            background-color: #007bff;
            color: white;
        }
        .gridview-table .btn-edit:hover {
            background-color: #0056b3;
        }
        .gridview-table .btn-delete {
            background-color: #f44336;
            color: white;
        }
        .gridview-table .btn-delete:hover {
            background-color: #e53935;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>To-Do List</h2>
            <div class="grid-container">
                <!-- Add Task Button -->
                <a href="ManageTask.aspx" class="add-task-btn">Add New Task</a>
            </div>

                <asp:GridView ID="gvTasks" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" OnRowCommand="gvTasks_RowCommand" OnRowDeleting="OnRowDeleting" OnSelectedIndexChanged="gvTasks_SelectedIndexChanged" class="gridview-table">
                <Columns>
                     <asp:BoundField DataField="Id" HeaderText="ID" />
                     <asp:BoundField DataField="Title" HeaderText="Task" />
                     <asp:CheckBoxField DataField="IsCompleted" HeaderText="Completed" />
                     <asp:ButtonField  CommandName="Edit" Text="Edit" />
                     <asp:ButtonField   CommandName="Delete" Text="Delete" />
                </Columns>
                </asp:GridView>

               

        </div>
    </form>

    <!-- Bootstrap JS and dependencies -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zyG7b0n4zLtb60U6Q6De4PiB+Yp5OX+5P4xh0sw2" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-pzjw8f+ua7Kw1TIq0i7ex3mw7CgXHzZNCfdo5h1zPfnOBsmz6Qp5mLkfoXn8uXz8" crossorigin="anonymous"></script>
</body>
</html>
