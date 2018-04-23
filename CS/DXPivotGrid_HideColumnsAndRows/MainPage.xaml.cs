using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_HideColumnsAndRows {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        // Handles the CustomFieldValueCells event to remove
        // specific rows.
        void pivotGridControl1_CustomFieldValueCells(object sender, 
            PivotCustomFieldValueCellsEventArgs e) {
            if (pivotGridControl1.DataSource == null) return;
            if (rbDefault.IsChecked == true) return;

            // Iterates through all row headers.
            for (int i = e.GetCellCount(false) - 1; i >= 0; i--) {
                FieldValueCell cell = e.GetCell(false, i);
                if (cell == null) continue;

                // If the current header corresponds to the "Employee B"
                // field value, and is not the Total Row header,
                // it is removed with all corresponding rows.
                if (object.Equals(cell.Value, "Employee B") &&
                    cell.ValueType != FieldValueType.Total)
                    e.Remove(cell);
            }
        }
        private void rbDefault_Checked(object sender, RoutedEventArgs e) {
            if (pivotGridControl1 == null) return;
            pivotGridControl1.LayoutChanged();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            PivotHelper.FillPivot(pivotGridControl1);
            pivotGridControl1.DataSource = PivotHelper.GetData();
            pivotGridControl1.BestFit();
        }
        private void pivotGridControl1_FieldValueDisplayText(object sender,
            PivotFieldDisplayTextEventArgs e) {
            if (e.Value == null) return;
            if (e.Field == pivotGridControl1.Fields[PivotHelper.Month]) {
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)e.Value);
            }
        }
    }
}
