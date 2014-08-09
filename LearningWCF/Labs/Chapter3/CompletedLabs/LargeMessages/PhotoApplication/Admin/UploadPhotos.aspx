<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="UploadPhotos.aspx.cs" Inherits="Admin_UploadPhotos" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Upload Photo</h1>

<table id="Table1" style="border:0" cellspacing="1" cellpadding="1" >
	<tr>
		<td valign="top" align="right" style="width: 75px">Filename:</td>
		<td valign="top" align="left">
            <asp:FileUpload ID="fileUpload" runat="server" Width="300px" />
		
            <asp:RequiredFieldValidator ID="requiredFile" runat="server" ErrorMessage="Please select a file to upload." ControlToValidate="fileUpload" ></asp:RequiredFieldValidator></td>
	</tr>
	<tr>
		<td valign="top" align="right" style="width: 75px">Title:</td>
		<td valign="top" align="left"><asp:textbox id="txtTitle" runat="server" Width="300px"></asp:textbox>
            <asp:RequiredFieldValidator ID="requiredTitle" runat="server" ErrorMessage="Please enter a title." ControlToValidate="txtTitle" ></asp:RequiredFieldValidator></td>
	</tr>
	<tr>
		<td valign="top" align="right" style="width: 75px">Description:</td>
		<td valign="top" align="left"><asp:textbox id="txtDescription" runat="server" Height="64px" Width="300px" TextMode="MultiLine"></asp:textbox>
            <asp:RequiredFieldValidator ID="requiredDescription" runat="server" ErrorMessage="Please enter a description." ControlToValidate="txtDescription" ></asp:RequiredFieldValidator></td>
	</tr>
	<tr>
		<td valign="top" align="right" style="width: 75px">Date:</td>
		<td valign="top" align="left">
            <asp:Calendar ID="dateSelector" runat="server"></asp:Calendar>
        </td>
	</tr>
	<tr>
		<td valign="top" align="right" style="width: 75px">Category:</td>
		<td valign="top" align="left">
            <asp:TextBox ID="txtCategory" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredCategory" runat="server" ErrorMessage="Please select or enter a new category." ControlToValidate="txtCategory" ></asp:RequiredFieldValidator>
            <br />
            <asp:RadioButtonList ID="lstCategories" runat="server" DataSourceID="ObjectDataSource2" Width="300px" Height="2px" BorderStyle="Solid" BorderWidth="1" AutoPostBack="false" OnDataBound="lstCategories_DataBound">
            </asp:RadioButtonList></td>
	</tr>
</table>
<asp:button id="cmdUploadPhoto" runat="server" Text="Upload Photo" OnClick="cmdUploadPhoto_Click" ></asp:button>&nbsp;
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetCategories" TypeName="PhotoManagerFacade"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" InsertMethod="UploadPhoto" TypeName="PhotoManagerFacade" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPhotos">
        <InsertParameters>
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="url" Type="String" />
            <asp:Parameter Name="linkitem_type" />
            <asp:Parameter Name="date_linkitem" Type="DateTime" />
            <asp:Parameter Name="date_end" Type="DateTime" />
            <asp:Parameter Name="cat" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>

