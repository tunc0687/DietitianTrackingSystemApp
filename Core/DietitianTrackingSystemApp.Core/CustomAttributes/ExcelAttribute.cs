namespace DietitianTrackingSystemApp.Core.CustomAttributes
{
    public class ExcelAttribute : Attribute
    {
        public string ColumnName { get; set; }

        public bool Discard { get; set; }
    }
}