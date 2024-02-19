namespace Program_Test_StringInReverseOrder
{
    public class UnitTest1
    {
        [Fact]
        public void ReverseString_InputString_ReturnsReversedString()
        {
            // Arrange
            string input = "hello";
            string expectedOutput = "olleh";

            // Act
            string actualOutput = Program_StringInReverseOrder.Program.StringInReverseOrder(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
