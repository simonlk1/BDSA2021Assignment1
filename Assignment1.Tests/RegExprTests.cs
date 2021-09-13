using Xunit;
using System;
using System.Collections.Generic;

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
            Assert.Equal(new[] { "Hej\n", "med\n", "dig\n" }, output);
        }

        [Fact]
        public void SplitLine_given_Hej_med_dig_and_whitespace_returns_3_lines()
        {
            // Arrange
            var input = new[] { "Hej    ", " med  ", "dig" };

            // Act
            var output = RegExpr.SplitLine(input);

            // Assert
            Assert.Equal(new[] { "Hej\n", "med\n", "dig\n" }, output);
        }

        [Fact]
        public void SplitLine_given_Hej23_med1_dig_50_returns_4_lines()
        {
            // Arrange
            var input = new[] { "Hej23", "med1", "dig", "50" };

            // Act
            var output = RegExpr.SplitLine(input);

            // Assert
            Assert.Equal(new[] { "Hej23\n", "med1\n", "dig\n", "50\n" }, output);
        }

        [Fact]
        public void SplitLine_given_Hej23_med1_dig_50_and_whitespace_returns_4_lines()
        {
            // Arrange
            var input = new[] { "  Hej23  ", " med1", "dig  ", "50" };

            // Act
            var output = RegExpr.SplitLine(input);

            // Assert
            Assert.Equal(new[] { "Hej23\n", "med1\n", "dig\n", "50\n" }, output);
        }

        [Fact]
        public void SplitLine_given_Hej23_med1_dig_50_and_whitespace_mixed_string_returns_4_lines()
        {
            // Arrange
            var input = new[] { "  Hej23  med1", " dig   50 " };

            // Act
            var output = RegExpr.SplitLine(input);

            // Assert
            Assert.Equal(new[] { "Hej23\n", "med1\n", "dig\n", "50\n" }, output);
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
            Assert.Equal(output, expected);
        }
    }
}
