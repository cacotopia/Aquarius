<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DeepIn.WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <thead>
               <tr>
                   <th>RouteCollection.RouteExistingFiles</th>
                   <th colspan="2">True</th>
                   <th colspan="2">False</th>
               </tr>
               <tr>
                   <th>Route.RouteExistingFiles</th>
                   <th>True</th>
                   <th>False</th>
                   <th>True</th>
                   <th>False</th>
               </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Route.GetRouteData()</td>
                    <td><%= this.GetRouteData(RouteOrRouteCollection.Route,true,true) ==null? "Null":"RouteData" %></td>
                    <td><%= this.GetRouteData(RouteOrRouteCollection.Route,true,false) ==null? "Null":"RouteData" %></td>
                    <td><%= this.GetRouteData(RouteOrRouteCollection.Route,false,true) ==null? "Null":"RouteData" %></td>
                    <td><%= this.GetRouteData(RouteOrRouteCollection.Route,false,false) ==null? "Null":"RouteData" %></td>
                </tr>
                <tr>
                    <td>RouteCollection.GetRouteData()</td>
                    <td><%= this.GetRouteData(RouteOrRouteCollection.RouteCollection,true,true) ==null? "Null":"RouteData" %></td>
                    <td><%= this.GetRouteData(RouteOrRouteCollection.RouteCollection,true,false) ==null? "Null":"RouteData" %></td>
                    <td><%= this.GetRouteData(RouteOrRouteCollection.RouteCollection,false,true) ==null? "Null":"RouteData" %></td>
                    <td><%= this.GetRouteData(RouteOrRouteCollection.RouteCollection,false,false) ==null? "Null":"RouteData" %></td>
                </tr>
            </tbody>
        </table>    
    </div>
    </form>
</body>
</html>
