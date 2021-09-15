using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Assignment1
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            var pattern = @"[a-zA-Z0-9]+";
            foreach (var line in lines)
            {
                var matches = Regex.Matches(line, pattern);

                foreach (var match in matches)
                {
                    var stringBuilder = new StringBuilder(match.ToString());
                    stringBuilder.Append("\n");
                    var result = stringBuilder.ToString();
                    yield return result;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            var pattern = @"(?<width>[0-9]+)x(?<height>[0-9]+)";
            var matches = Regex.Matches(resolutions, pattern);

            // why does var treat match as of type object?
            foreach (Match match in matches)
            {
                var width = Int32.Parse(match.Groups["width"].Value);
                var height = Int32.Parse(match.Groups["height"].Value);

                yield return (width, height);
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            throw new NotImplementedException();
        }
    }
}
