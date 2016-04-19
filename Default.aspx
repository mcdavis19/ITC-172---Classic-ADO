<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href='https://fonts.googleapis.com/css?family=Ubuntu|Arimo' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
    <div id="wrapper">
        <asp:DropDownList 
            ID="DropDownList1" 
            runat="server" 
            AutoPostBack="true"
            OneSelectedIndexChanged="ServiceDropDownList_SelectedIndexChanged"
            CssClass="list" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
        </asp:DropDownList>

        <asp:GridView 
            ID="GridView1" 
            runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
