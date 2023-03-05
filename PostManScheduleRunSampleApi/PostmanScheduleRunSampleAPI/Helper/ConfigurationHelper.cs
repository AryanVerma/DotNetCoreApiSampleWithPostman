namespace PostmanScheduleRunSampleAPI.Helper
{
    public static class ConfigurationHelper
    {
        public static IConfiguration config;
        public static void Initialize(IConfiguration Configuration)
        {
            config = Configuration;
        }
        public static string MysqlDbConnectionString => config["ConnectionStrings:SampleApi"];
    }
}
