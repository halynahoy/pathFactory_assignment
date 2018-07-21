namespace PathFactoryAutomation
{
    public class WebSiteConfiguration
    {
        //this code can be improved, so that configuration is read from config file

        public static string BaseUrl
        {
            get
            {
                return "http://automationpractice.com/index.php";
            }
        }
    }
}