<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProductsForm.aspx.cs" Inherits="Stored_Procedure_Demo.AddProductsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 5px">
            <h2>Add Data using SQL Stored Procedure</h2>

            <table class="table table-condensed" style="width: 500px">
                <tr>
                    <td>Product Name:</td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server" placeholder="Enter Product Name" width="250px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Product Description:</td>
                    <td>
                        <asp:TextBox ID="txtProductDescription" runat="server" placeholder="Enter Product Description" width="250px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="BtnSubmit" runat="server" Text="Save" OnClick="BtnSubmit_Click" />
                    </td>
                </tr>
            </table>

            <asp:Label runat="server" ID="InfoLabel"></asp:Label>
            <br /><br />

            <asp:GridView runat="server" ID="ProductDataGrid" CssClass="table table-condensed" Width="500px"></asp:GridView>
        </div>
    </form>
</body>
</html>
