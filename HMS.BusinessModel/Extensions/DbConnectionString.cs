namespace Model.HMS.Extensions
{
    public static class DbConnectionString
    {
        private static string conStr = "Data Source=SCL-L200765;Initial Catalog=HMS; User ID=sa; Password=scl@C0m2019;";
        public static string MssqlConnectionString
        {
            get
            {
                return conStr;
            }
            set
            {
                conStr = value;
            }
        }
        public static string MysqlConnectionString { get; set; }
    }
}
