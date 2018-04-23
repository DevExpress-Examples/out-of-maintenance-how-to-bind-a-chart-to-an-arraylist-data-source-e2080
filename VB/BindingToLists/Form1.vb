Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace BindingToLists
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Class Record
			Private id_Renamed, age_Renamed As Integer
			Private name_Renamed As String
			Public Sub New(ByVal id As Integer, ByVal name As String, ByVal age As Integer)
				Me.id_Renamed = id
				Me.name_Renamed = name
				Me.age_Renamed = age
			End Sub
			Public Property ID() As Integer
				Get
					Return id_Renamed
				End Get
				Set(ByVal value As Integer)
					id_Renamed = value
				End Set
			End Property
			Public Property Name() As String
				Get
					Return name_Renamed
				End Get
				Set(ByVal value As String)
					name_Renamed = value
				End Set
			End Property
			Public Property Age() As Integer
				Get
					Return age_Renamed
				End Get
				Set(ByVal value As Integer)
					age_Renamed = value
				End Set
			End Property
		End Class

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create a list.
			Dim listDataSource As New ArrayList()

			' Populate the list with records.
			listDataSource.Add(New Record(1, "Jane", 19))
			listDataSource.Add(New Record(2, "Joe", 30))
			listDataSource.Add(New Record(3, "Bill", 15))
			listDataSource.Add(New Record(4, "Michael", 42))

			' Bind the chart to the list.
			Dim myChart As ChartControl = chartControl1
			myChart.DataSource = listDataSource

			' Create a series, and add it to the chart.
			Dim series1 As New Series("My Series", ViewType.Bar)
			myChart.Series.Add(series1)

			' Adjust the series data members.
			series1.ArgumentDataMember = "name"
			series1.ValueDataMembers.AddRange(New String() { "age" })

			' Access the view-type-specific options of the series.
			CType(series1.View, BarSeriesView).ColorEach = True
			series1.LegendTextPattern = "{A}"
		End Sub
	End Class
End Namespace