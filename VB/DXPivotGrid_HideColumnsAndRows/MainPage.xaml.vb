Imports Microsoft.VisualBasic
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.PivotGrid

Namespace DXPivotGrid_HideColumnsAndRows
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		' Handles the CustomFieldValueCells event to remove
		' specific rows.
		Private Sub pivotGridControl1_CustomFieldValueCells(ByVal sender As Object, _
			ByVal e As PivotCustomFieldValueCellsEventArgs)
			If pivotGridControl1.DataSource Is Nothing Then
				Return
			End If
			If rbDefault.IsChecked = True Then
				Return
			End If

			' Iterates through all row headers.
			For i As Integer = e.GetCellCount(False) - 1 To 0 Step -1
				Dim cell As FieldValueCell = e.GetCell(False, i)
				If cell Is Nothing Then
					Continue For
				End If

				' If the current header corresponds to the "Employee B"
				' field value, and is not the Total Row header,
				' it is removed with all corresponding rows.
				If Object.Equals(cell.Value, "Employee B") AndAlso _
					cell.ValueType <> FieldValueType.Total Then
					e.Remove(cell)
				End If
			Next i
		End Sub
		Private Sub rbDefault_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If pivotGridControl1 Is Nothing Then
				Return
			End If
			pivotGridControl1.LayoutChanged()
		End Sub
		Private Sub UserControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			PivotHelper.FillPivot(pivotGridControl1)
			pivotGridControl1.DataSource = PivotHelper.GetData()
			pivotGridControl1.BestFit()
		End Sub
		Private Sub pivotGridControl1_FieldValueDisplayText(ByVal sender As Object, _
			ByVal e As PivotFieldDisplayTextEventArgs)
			If e.Value Is Nothing Then
				Return
			End If
			If Object.ReferenceEquals(e.Field, pivotGridControl1.Fields(PivotHelper.Month)) Then
				e.DisplayText = _
					CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(Fix(e.Value)))
			End If
		End Sub
	End Class
End Namespace
