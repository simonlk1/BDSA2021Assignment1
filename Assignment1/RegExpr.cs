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
                    yield return match.ToString();
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            var pattern = @"(?<width>\d+)x(?<height>\d+)";
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
            var pattern = $@"<(?<tag>{tag}).*?>(?<capture>.*?)</\k<tag>>";
            var matches = Regex.Matches(html, pattern);

            var removeTagPattern = @"<[^>]*>";
            foreach (Match match in matches)
            {
                var toReplace = match.Groups["capture"].ToString();
                var result = Regex.Replace(toReplace, removeTagPattern, String.Empty);
                yield return result;
            }
        }
    }
}
