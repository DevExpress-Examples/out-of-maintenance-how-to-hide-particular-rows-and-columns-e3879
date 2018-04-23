using System.Collections.Generic;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_HideColumnsAndRows {
    public class DataItem {
        public string Employee { get; set; }
        public string Widget { get; set; }
        public int Month { get;  set; }
        public double RetailPrice { get; set; }
        public double WholesalePrice { get; set; }
        public int Quantity { get; set; }
        public int Remains { get; set; }
    }
    public static class PivotHelper {
        public const string Employee = "Employee";
        public const string Widget = "Widget";
        public const string Month = "Month";
        public const string RetailPrice = "RetailPrice";
        public const string WholesalePrice = "WholesalePrice";
        public const string Quantity = "Quantity";
        public const string Remains = "Remains";

        public const string EmployeeA = "Employee A";
        public const string EmployeeB = "Employee B";
        public const string WidgetA = "Widget A";
        public const string WidgetB = "Widget B";
        public const string WidgetC = "Widget C";

        public static void FillPivot(PivotGridControl pivot) {
            pivot.Fields.Add(Employee, FieldArea.RowArea);
            pivot.Fields.Add(Widget, FieldArea.RowArea);
            pivot.Fields.Add(Month, FieldArea.ColumnArea).AreaIndex = 0;
            pivot.Fields.Add(RetailPrice, FieldArea.DataArea);
            pivot.Fields.Add(WholesalePrice, FieldArea.DataArea);
            pivot.Fields.Add(Quantity, FieldArea.DataArea);
            foreach (PivotGridField field in pivot.Fields) {
                field.AllowedAreas = GetAllowedArea(field.Area);
            }
            pivot.RowTotalsLocation = FieldRowTotalsLocation.Far;
            pivot.ColumnTotalsLocation = FieldColumnTotalsLocation.Far;
            pivot.DataFieldArea = DataFieldArea.ColumnArea;
            pivot.DataFieldAreaIndex = 1;
        }
        static FieldAllowedAreas GetAllowedArea(FieldArea area) {
            switch (area) {
                case FieldArea.ColumnArea:
                    return FieldAllowedAreas.ColumnArea;
                case FieldArea.RowArea:
                    return FieldAllowedAreas.RowArea;
                case FieldArea.DataArea:
                    return FieldAllowedAreas.DataArea;
                case FieldArea.FilterArea:
                    return FieldAllowedAreas.FilterArea;
                default:
                    return FieldAllowedAreas.All;
            }
        }
        public static List<DataItem> GetData() {
            List<DataItem> list = new List<DataItem>();
            list.Add(new DataItem() { Employee = EmployeeA, Widget = WidgetA, Month = 6, RetailPrice = 45.6, WholesalePrice = 40, Quantity = 3 });
            list.Add(new DataItem() { Employee = EmployeeA, Widget = WidgetA, Month = 7, RetailPrice = 38.9, WholesalePrice = 30, Quantity = 6 });
            list.Add(new DataItem() { Employee = EmployeeA, Widget = WidgetB, Month = 6, RetailPrice = 24.7, WholesalePrice = 20, Quantity = 7 });
            list.Add(new DataItem() { Employee = EmployeeA, Widget = WidgetB, Month = 7, RetailPrice = 8.3, WholesalePrice = 7.5, Quantity = 5 });
            list.Add(new DataItem() { Employee = EmployeeA, Widget = WidgetC, Month = 6, RetailPrice = 10.0, WholesalePrice = 9, Quantity = 4 });
            list.Add(new DataItem() { Employee = EmployeeA, Widget = WidgetC, Month = 7, RetailPrice = 20.0, WholesalePrice = 18.5, Quantity = 5 });
            list.Add(new DataItem() { Employee = EmployeeB, Widget = WidgetA, Month = 6, RetailPrice = 77.8, WholesalePrice = 70, Quantity = 2 });
            list.Add(new DataItem() { Employee = EmployeeB, Widget = WidgetA, Month = 7, RetailPrice = 32.5, WholesalePrice = 30, Quantity = 1 });
            list.Add(new DataItem() { Employee = EmployeeB, Widget = WidgetB, Month = 6, RetailPrice = 12, WholesalePrice = 11, Quantity = 10 });
            list.Add(new DataItem() { Employee = EmployeeB, Widget = WidgetB, Month = 7, RetailPrice = 6.7, WholesalePrice = 5.5, Quantity = 4 });
            list.Add(new DataItem() { Employee = EmployeeB, Widget = WidgetC, Month = 6, RetailPrice = 30.0, WholesalePrice = 28.7, Quantity = 6 });
            list.Add(new DataItem() { Employee = EmployeeB, Widget = WidgetC, Month = 7, RetailPrice = 40.0, WholesalePrice = 38.3, Quantity = 7 });
            return list;
        }
    }
}
