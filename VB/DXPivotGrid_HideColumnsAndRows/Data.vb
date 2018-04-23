Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports DevExpress.Xpf.PivotGrid

Namespace DXPivotGrid_HideColumnsAndRows
	Public Class DataItem
		Private privateEmployee As String
		Public Property Employee() As String
			Get
				Return privateEmployee
			End Get
			Set(ByVal value As String)
				privateEmployee = value
			End Set
		End Property
		Private privateWidget As String
		Public Property Widget() As String
			Get
				Return privateWidget
			End Get
			Set(ByVal value As String)
				privateWidget = value
			End Set
		End Property
		Private privateMonth As Integer
		Public Property Month() As Integer
			Get
				Return privateMonth
			End Get
			Set(ByVal value As Integer)
				privateMonth = value
			End Set
		End Property
		Private privateRetailPrice As Double
		Public Property RetailPrice() As Double
			Get
				Return privateRetailPrice
			End Get
			Set(ByVal value As Double)
				privateRetailPrice = value
			End Set
		End Property
		Private privateWholesalePrice As Double
		Public Property WholesalePrice() As Double
			Get
				Return privateWholesalePrice
			End Get
			Set(ByVal value As Double)
				privateWholesalePrice = value
			End Set
		End Property
		Private privateQuantity As Integer
		Public Property Quantity() As Integer
			Get
				Return privateQuantity
			End Get
			Set(ByVal value As Integer)
				privateQuantity = value
			End Set
		End Property
		Private privateRemains As Integer
		Public Property Remains() As Integer
			Get
				Return privateRemains
			End Get
			Set(ByVal value As Integer)
				privateRemains = value
			End Set
		End Property
	End Class
	Public NotInheritable Class PivotHelper
		Public Const Employee As String = "Employee"
		Public Const Widget As String = "Widget"
		Public Const Month As String = "Month"
		Public Const RetailPrice As String = "RetailPrice"
		Public Const WholesalePrice As String = "WholesalePrice"
		Public Const Quantity As String = "Quantity"
		Public Const Remains As String = "Remains"

		Public Const EmployeeA As String = "Employee A"
		Public Const EmployeeB As String = "Employee B"
		Public Const WidgetA As String = "Widget A"
		Public Const WidgetB As String = "Widget B"
		Public Const WidgetC As String = "Widget C"

		Private Sub New()
		End Sub
		Public Shared Sub FillPivot(ByVal pivot As PivotGridControl)
			pivot.Fields.Add(Employee, FieldArea.RowArea)
			pivot.Fields.Add(Widget, FieldArea.RowArea)
			pivot.Fields.Add(Month, FieldArea.ColumnArea).AreaIndex = 0
			pivot.Fields.Add(RetailPrice, FieldArea.DataArea)
			pivot.Fields.Add(WholesalePrice, FieldArea.DataArea)
			pivot.Fields.Add(Quantity, FieldArea.DataArea)
			For Each field As PivotGridField In pivot.Fields
				field.AllowedAreas = GetAllowedArea(field.Area)
			Next field
			pivot.RowTotalsLocation = FieldRowTotalsLocation.Far
			pivot.ColumnTotalsLocation = FieldColumnTotalsLocation.Far
			pivot.DataFieldArea = DataFieldArea.ColumnArea
			pivot.DataFieldAreaIndex = 1
		End Sub
		Private Shared Function GetAllowedArea(ByVal area As FieldArea) As FieldAllowedAreas
			Select Case area
				Case FieldArea.ColumnArea
					Return FieldAllowedAreas.ColumnArea
				Case FieldArea.RowArea
					Return FieldAllowedAreas.RowArea
				Case FieldArea.DataArea
					Return FieldAllowedAreas.DataArea
				Case FieldArea.FilterArea
					Return FieldAllowedAreas.FilterArea
				Case Else
					Return FieldAllowedAreas.All
			End Select
		End Function
		Public Shared Function GetData() As List(Of DataItem)
			Dim list As New List(Of DataItem)()
			list.Add(New DataItem() With {.Employee = EmployeeA, .Widget = WidgetA, .Month = 6, .RetailPrice = 45.6, .WholesalePrice = 40, .Quantity = 3})
			list.Add(New DataItem() With {.Employee = EmployeeA, .Widget = WidgetA, .Month = 7, .RetailPrice = 38.9, .WholesalePrice = 30, .Quantity = 6})
			list.Add(New DataItem() With {.Employee = EmployeeA, .Widget = WidgetB, .Month = 6, .RetailPrice = 24.7, .WholesalePrice = 20, .Quantity = 7})
			list.Add(New DataItem() With {.Employee = EmployeeA, .Widget = WidgetB, .Month = 7, .RetailPrice = 8.3, .WholesalePrice = 7.5, .Quantity = 5})
			list.Add(New DataItem() With {.Employee = EmployeeA, .Widget = WidgetC, .Month = 6, .RetailPrice = 10.0, .WholesalePrice = 9, .Quantity = 4})
			list.Add(New DataItem() With {.Employee = EmployeeA, .Widget = WidgetC, .Month = 7, .RetailPrice = 20.0, .WholesalePrice = 18.5, .Quantity = 5})
			list.Add(New DataItem() With {.Employee = EmployeeB, .Widget = WidgetA, .Month = 6, .RetailPrice = 77.8, .WholesalePrice = 70, .Quantity = 2})
			list.Add(New DataItem() With {.Employee = EmployeeB, .Widget = WidgetA, .Month = 7, .RetailPrice = 32.5, .WholesalePrice = 30, .Quantity = 1})
			list.Add(New DataItem() With {.Employee = EmployeeB, .Widget = WidgetB, .Month = 6, .RetailPrice = 12, .WholesalePrice = 11, .Quantity = 10})
			list.Add(New DataItem() With {.Employee = EmployeeB, .Widget = WidgetB, .Month = 7, .RetailPrice = 6.7, .WholesalePrice = 5.5, .Quantity = 4})
			list.Add(New DataItem() With {.Employee = EmployeeB, .Widget = WidgetC, .Month = 6, .RetailPrice = 30.0, .WholesalePrice = 28.7, .Quantity = 6})
			list.Add(New DataItem() With {.Employee = EmployeeB, .Widget = WidgetC, .Month = 7, .RetailPrice = 40.0, .WholesalePrice = 38.3, .Quantity = 7})
			Return list
		End Function
	End Class
End Namespace
