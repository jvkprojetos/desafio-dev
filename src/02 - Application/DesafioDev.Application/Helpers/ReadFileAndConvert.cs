using MediatR;
using Microsoft.AspNetCore.Http;

namespace DesafioDev.Application.Helpers
{
    public static class ReadFileAndConvert
    {
        public static List<string> ReadAndConvertInListString(this IFormFile formFile)
        {
            string line;
            List<string> lines = new();

            using var streamReader = new StreamReader(formFile.OpenReadStream());  
            while ((line = streamReader.ReadLine()) is not null)
            {
                lines.Add(line);
            }

            return lines;
        }
    }
}
