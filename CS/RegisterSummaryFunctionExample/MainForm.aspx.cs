using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraCharts;

namespace RegisterSummaryFunctionExample {
    public partial class WebForm1 : System.Web.UI.Page {
        const string summaryFunctionName = "PRODUCT";

        // Declare the Product summary function.
        private static SeriesPoint[] CalculateProductValue(
            Series series,
            object argument,
            string[] functionArguments,
            DataSourceValues[] values,
            object[] colors) {

            // Create an array of the resulting series points.
            List<SeriesPoint> points = new List<SeriesPoint>();
            // Calculate the resulting series points as Price * Count.
            for (int i = 0; i < values.Length; i++) {
                double value = Convert.ToDouble(values[i][functionArguments[0]]) *
                    Convert.ToDouble(values[i][functionArguments[1]]);
                if (value > 0)
                    points.Add(new SeriesPoint(argument, value));
            }
            // Return the result.
            return points.ToArray();
        }

        String BuildSummaryFunction(String price, String count) {
            return 
                new StringBuilder(summaryFunctionName)
                    .Append("([")
                    .Append(price)
                    .Append("],[")
                    .Append(count)
                    .Append("])")
                    .ToString();
        }

        protected void Page_Load(object sender, EventArgs e) {
            // Register the summary function in a chart.
            chartControl.RegisterSummaryFunction(summaryFunctionName, summaryFunctionName, 1,
                new SummaryFunctionArgumentDescription[] { 
                    new SummaryFunctionArgumentDescription("Price", ScaleType.Numerical), 
                    new SummaryFunctionArgumentDescription("Count", ScaleType.Numerical)},
                CalculateProductValue);
            
            // Specify the summary function for the series.
            Series series = chartControl.Series["Product"];
            series.SummaryFunction = BuildSummaryFunction("UnitPrice", "UnitsOnOrder");
        }
    }
}