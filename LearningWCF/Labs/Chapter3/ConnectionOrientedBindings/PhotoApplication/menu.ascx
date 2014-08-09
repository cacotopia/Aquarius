<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="menu" %>
<table class="menu" width="100%">
<tr><td class="hborder"></td></tr>
            <tr>
           <td style="background-color:indigo; width:100%">
						<asp:Menu ID="Menu1" runat="server" DynamicHorizontalOffset="2" Orientation="Horizontal" StaticSubMenuIndent="10px" EnableTheming="True" DataSourceID="SiteMapDataSource1" ForeColor="White" Font-Size="Small">
							<StaticSelectedStyle Font-Underline="true" ForeColor="White" />
							<StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" ForeColor="White" />
							<DynamicHoverStyle Font-Bold="True" ForeColor="White" />
							<DynamicMenuStyle BackColor="Indigo" ForeColor="White" />
							<DynamicSelectedStyle Font-Underline="true" ForeColor="White" />
							<DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" ForeColor="White" />
							<StaticHoverStyle Font-Bold="True" ForeColor="White" />
						</asp:Menu>
                        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="False" />
                            </td>
            </tr>
<tr><td class="hborder"></td></tr>
</table> 
        


