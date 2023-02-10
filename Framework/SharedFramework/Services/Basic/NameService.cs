namespace SharedFramework.Services.Basic
{
    public class NameService
    {
        public static string FirstCharUpper(string str)
        {
            return $"{str[..1].ToUpper()}{str[1..]}";
        }
    }
}
