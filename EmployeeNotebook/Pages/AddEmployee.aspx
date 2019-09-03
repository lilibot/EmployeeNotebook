<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="EmployeeNotebook.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="../Static/Styles.css" />
</head>
<body>
  <form id="addEmployeeForm" runat="server">
         <asp:ValidationSummary ID="validationEmployee" runat="server" ShowModelStateErrors="true" />
        <div>
            <label>Name:</label><input type="text" id="name" runat="server" /></div>
        <div>
            <label>Surname:</label><input type="text" id="surname" runat="server" /></div>
        <div>
            <label>Year of birth:</label><input type="text" id="yearOfBirth" runat="server" /></div>
        <div>
            <label>Phone</label><input type="text" id="phone" runat="server" /></div>
        <div>
            <asp:Button ID="SubmitEmployeeData" runat="server" Text="Submit" OnClick="SubmitEmployeeData_Click" />
            <asp:Button ID="Home" runat="server" Text="Home" OnClick="Home_Click" />
        </div>

    </form>
</body>
</html>
