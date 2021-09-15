using System;
using System.Collections.Generic;
using Xunit;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void SplitLine_given_Hej_med_dig_returns_3_lines()
        {
            // Arrange
            var input = new[] { "Hej", "med", "dig" };

            // Act
            var output = RegExpr.SplitLine(input);

            // Assert
            Assert.Equal(new[] { "Hej", "med", "dig" }, output);
        }

        [Fact]
        public void SplitLine_given_Hej_med_dig_and_whitespace_returns_3_lines()
        {
            // Arrange
            var input = new[] { "Hej    ", " med  ", "dig" };

            // Act
            var output = RegExpr.SplitLine(input);

            // Assert
            Assert.Equal(new[] { "Hej", "med", "dig" }, output);
        }

        [Fact]
        public void SplitLine_given_Hej23_med1_dig_50_returns_4_lines()
        {
            // Arrange
            var input = new[] { "Hej23", "med1", "dig", "50" };

            // Act
            var output = RegExpr.SplitLine(input);

            // Assert
            Assert.Equal(new[] { "Hej23", "med1", "dig", "50" }, output);
        }

        [Fact]
        public void SplitLine_given_Hej23_med1_dig_50_and_whitespace_returns_4_lines()
        {
            // Arrange
            var input = new[] { "  Hej23  ", " med1", "dig  ", "50" };

            // Act
            var output = RegExpr.SplitLine(input);

            // Assert
            Assert.Equal(new[] { "Hej23", "med1", "dig", "50" }, output);
        }

        [Fact]
        public void SplitLine_given_Hej23_med1_dig_50_and_whitespace_mixed_string_returns_4_lines()
        {
            // Arrange
            var input = new[] { "  Hej23  med1", " dig   50 " };

            // Act
            var output = RegExpr.SplitLine(input);

            // Assert
            Assert.Equal(new[] { "Hej23", "med1", "dig", "50" }, output);
        }

        [Fact]
        public void Resolutions_given_1920x1080_1024x768_800x600_returns_3_tuples()
        {
            // Arrange
            var input = "1920x1080 1024x768 800x600";

            // Act
            var output = RegExpr.Resolution(input);
            var expected = new List<(int, int)> { (1920, 1080), (1024, 768), (800, 600) };

            // Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void InnerText_not_nested_tags()
        {
            // Arrange
            var input = @"<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p</div>";

            // Act
            var output = RegExpr.InnerText(input, "a");
            var expected = new[] { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" };

            // Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void InnerText_with_nested_tags()
        {
            // Arrange
            var input = @"<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";

            // Act
            var output = RegExpr.InnerText(input, "p");
            var expected = new[] { "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." };

            // Assert
            Assert.Equal(expected, output);
        }
    }
}
