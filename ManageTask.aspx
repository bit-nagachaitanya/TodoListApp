<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ManageTask.aspx.cs" Inherits="ManageTask" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Manage Task</title>
    <!-- Add Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Link to custom CSS file (optional) -->
    <link href="styles.css" rel="stylesheet" />
    <style>
    body {
    background-color: #f8f9fa;
}
.container {
    max-width: 600px;
}
.btn {
    padding: 10px 20px;
    font-size: 16px;
}  </style>
</head>
<body>
    <div class="container mt-5">
        <form id="form1" runat="server">
            <h2 class="text-center mb-4"><%: IsEdit ? "Edit Task" : "Add New Task" %></h2>
            
            <div class="mb-3">
                <asp:Label ID="lblTitle" runat="server" Text="Task:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <div class="mb-3 form-check">
                <asp:CheckBox ID="chkCompleted" runat="server" CssClass="form-check-input" />
                <asp:Label ID="lblCompleted" runat="server" Text="Completed" CssClass="form-check-label"></asp:Label>
            </div>
            
            <div class="d-grid gap-2">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
            </div>
        </form>
    </div>

    <!-- Add Bootstrap JS (optional for interactive features) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
