using Newtonsoft.Json.Converters;


namespace DotNet.ApplicationCore.DTOs.Converters
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
