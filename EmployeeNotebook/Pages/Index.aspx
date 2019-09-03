<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EmployeeNotebook.Index" %>
<%@ Import Namespace="EmployeeNotebook" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees notebook</title>
            <link rel="stylesheet" href="../Static/Styles.css" />
</head>
<body>
    <h1>Employees notebook</h1>
   
    <form id="form1" runat="server">
        <div>
             <asp:Button ID="AddEmployee" runat="server" Text="Add employee" OnClick="AddEmployee_Click" />
        </div>
                <div id="blockAllRecords">
        <div>
            <br />
             <asp:Button ID="SortBySurnameAndBirthYear" runat="server" Text="Sort by surname and birth year" OnClick="SortBySurnameAndBirthYear_Click"  Width="200px" />
        </div>

        <asp:GridView ID="EmployeeGridView" runat="server" ItemType="EmployeeNotebook.EmployeeRecord" 
            DataKeyNames="Id" AutoGenerateColumns="false" AllowSorting="true" 
            OnRowDeleting="EmployeeGridView_RowDeleting" OnSorting="EmployeeGridView_Sorting">
    <Columns>
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <%# Item.Name %>
            </ItemTemplate>
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Surname" SortExpression="Surname">
            <ItemTemplate>
                <%# Item.Surname %>
            </ItemTemplate>
        </asp:TemplateField>
                <asp:TemplateField HeaderText="YearOfBirth" SortExpression="YearOfBirth" >
            <ItemTemplate>
                <%# Item.YearOfBirth %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Phone" >
            <ItemTemplate>
                <%# Item.Phone %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowDeleteButton="True" />
<asp:TemplateField Visible="false">
            <ItemTemplate>
            <asp:HiddenField ID="Id" runat="server" Value='<%# Item.Id %>' Visible="false" />
            </ItemTemplate>
</asp:TemplateField>
    </Columns>
</asp:GridView>
         </div>



                <div id="blockFoundRecords">
             <div>
            <p>Введите значения для поиска</p>
        </div>
        <div>
            <label>Name:</label><input type="text" id="name" runat="server" /></div>
        <div>
            <label>Surname:</label><input type="text" id="surname" runat="server" /></div>
        <div>
            <label>Phone:</label><input type="text" id="phone" runat="server" /></div>
        <div>
             <asp:Button ID="Button2" runat="server" Text="Find records" OnClick="FindRecords_Click" />
        </div>


        <asp:GridView ID="FoundRecordsGridView" runat="server" ItemType="EmployeeNotebook.EmployeeRecord" DataKeyNames="Id" AutoGenerateColumns="false" AllowSorting="true" OnRowDeleting="EmployeeGridView_RowDeleting" >
    <Columns>
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <%# Item.Name %>
            </ItemTemplate>
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Surname" >
            <ItemTemplate>
                <%# Item.Surname %>
            </ItemTemplate>
        </asp:TemplateField>
                <asp:TemplateField HeaderText="YearOfBirth" >
            <ItemTemplate>
                <%# Item.YearOfBirth %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Phone" >
            <ItemTemplate>
                <%# Item.Phone %>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
    </div>
    </form>


</body>
</html>
