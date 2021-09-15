using Xunit;
using System;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {

        [Fact]
        public void Flatten_given_3_of_1_2_3_returns_1_2_3_three_times()
        {

            // Arrange
            var triplet = new List<int> { 1, 2, 3 };
            var input = new List<List<int>>() { triplet, triplet, triplet };

            // Act
            var output = Iterators.Flatten<int>(input);

            // Assert
            Assert.Equal(new[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 }, output);

        }

        [Fact]
        public void Filter_Even_given_1_2_3_4_5_returns_2_4()
        {
            // Arrange
            var input = new[] { 1, 2, 3, 4, 5 };
            Predicate<int> even = ArithmeticUtilities.Even;

            // Act
            var output = Iterators.Filter<int>(input, even);

            // Assert
            Assert.Equal(new[] { 2, 4 }, output);
        }
    }
}
