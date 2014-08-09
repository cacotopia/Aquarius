<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1>Photos
				</h1>
			<P>Uploaded photos will be displayed here. If the page is empty, upload some photos from the Upload Photos page.</P>
			<asp:datalist id="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" DataSourceID="ObjectDataSource1">
				<ItemTemplate>
					<table cellSpacing="10" cellPadding="10" border="0">
						<tr>
							<td align="center" width="300">
							
								<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl='<%# Eval("id", "~/displayphoto.aspx?id={0}")%>'>
								<asp:Image id="Image2" width="200" height="200" BorderWidth="2" runat="server" ImageUrl='<%# String.Format("{0}/{1}", System.Configuration.ConfigurationManager.AppSettings["photosDir"], ((ContentTypes.PhotoLink)Container.DataItem).Url)%>' >
</asp:Image>
								
																	
								</asp:HyperLink>
<br/>
								<b>
									<asp:Label id="Label1" runat="server" Text='<%# Eval("Title") %>'>
									</asp:Label></b><br>
</td>
						</tr>
					</table>
				</ItemTemplate>
			</asp:datalist>&nbsp;
			   <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetPhotos" TypeName="PhotoManager.PhotoUploadUtil"></asp:ObjectDataSource>

</asp:Content>

