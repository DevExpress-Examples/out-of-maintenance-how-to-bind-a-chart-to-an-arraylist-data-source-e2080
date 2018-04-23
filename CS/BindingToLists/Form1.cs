using System;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace BindingToLists {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public class Record {
            int id, age;
            string name;
            public Record(int id, string name, int age) {
                this.id = id;
                this.name = name;
                this.age = age;
            }
            public int ID {
                get { return id; }
                set { id = value; }
            }
            public string Name {
                get { return name; }
                set { name = value; }
            }
            public int Age {
                get { return age; }
                set { age = value; }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a list.
            ArrayList listDataSource = new ArrayList();

            // Populate the list with records.
            listDataSource.Add(new Record(1, "Jane", 19));
            listDataSource.Add(new Record(2, "Joe", 30));
            listDataSource.Add(new Record(3, "Bill", 15));
            listDataSource.Add(new Record(4, "Michael", 42));

            // Bind the chart to the list.
            ChartControl myChart = chartControl1;
            myChart.DataSource = listDataSource;

            // Create a series, and add it to the chart.
            Series series1 = new Series("My Series", ViewType.Bar);
            myChart.Series.Add(series1);

            // Adjust the series data members.
            series1.ArgumentDataMember = "name";
            series1.ValueDataMembers.AddRange(new string[] { "age" });

            // Access the view-type-specific options of the series.
            ((BarSeriesView)series1.View).ColorEach = true;
            series1.LegendPointOptions.Pattern = "{A}";
        }
    }
}