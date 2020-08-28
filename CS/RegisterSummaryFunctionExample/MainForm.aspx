<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="RegisterSummaryFunctionExample.WebForm1" %>

<%@ Register Assembly="DevExpress.XtraCharts.v15.1.Web, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register assembly="DevExpress.XtraCharts.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dxchartsui:WebChartControl ID="chartControl" runat="server" CrosshairEnabled="True" DataSourceID="DataSource1" Height="600px" Width="800px" PaletteName="Office 2013" style="margin-right: 0px">
                <diagramserializable>
                    <cc1:XYDiagram>
                        <axisx visibleinpanesserializable="-1">
                        </axisx>
                        <axisy visibleinpanesserializable="-1">
                        </axisy>
                    </cc1:XYDiagram>
                </diagramserializable>
                <seriesserializable>
                    <cc1:Series 
                        Name="Product" 
                        ArgumentDataMember="ProductName" 
                        ValueDataMembersSerializable="UnitPrice"/>
                </seriesserializable>
                <titles>
                    <cc1:ChartTitle Text="Products Comparison" />
                </titles>
            </dxchartsui:WebChartControl>
            
            <asp:SqlDataSource 
                ID="DataSource1" 
                runat="server" 
                ConnectionString="<%$ ConnectionStrings:nwindConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:nwindConnectionString.ProviderName %>" 
                SelectCommand="SELECT * FROM [Products]"/>
        </div>
    </form>
</body>
</html>

