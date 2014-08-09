<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="DisplayPhoto.aspx.cs" Inherits="DisplayPhoto" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Photo Details</h1>
    <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="ObjectDataSource1" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="id">
        <Fields>
            <asp:TemplateField>
                <ItemTemplate>
	<table border="0" width=100%>
				<tr>
					<td align="center">
						<asp:Image id=Image2 runat="server" ImageUrl='<%# String.Format("{0}/{1}", System.Configuration.ConfigurationManager.AppSettings["photosDir"], ((ContentTypes.PhotoLink)Container.DataItem).Url)%>' >
						</asp:Image>

					</td>
					<td width="10"></td>
					<td align="left" valign=top>
						<table border="0" width=300>
							<tr>
								<td>
											<h2>					<asp:Label id="lblTitle" runat="server">
											<%# Eval("Title") %>
										</asp:Label></h2>
									<asp:Label id="lblDate" runat="server">
										<%# Eval("DateStart", "{0:d}")%>
									</asp:Label><br>
									<br>
									<asp:Label id="lblDescription" runat="server">
										<%# Eval("Description") %>
									</asp:Label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>                
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetPhoto"
        TypeName="PhotoManager.PhotoUploadUtil">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

