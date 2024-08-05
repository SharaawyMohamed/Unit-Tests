namespace EMR.Tests
{
    public class BMICalculatorTests
    {
        [Fact]
        public void BMICalculate_WhenHeightGreaterThanZeroAndWeightGreaterThanZero_ThenShouldCalculateBMICorrectly()
        {
            // AAA

            #region Arrange
            // In This Section Declare all Prerequistes int this section
            var sut = new BMICalculator();// sut : Appriviation to Subject Under Test  
            #endregion

            #region Act
            // In this Section We Calculate Actual Result
            var actual = Math.Round(sut.BMICalculate(1.75, 90),2);
            var Expected = 27.56;
            #endregion

            #region Assert
            // In This Section we Compere Actual Result With Expected Result
            Assert.Equal(Expected, actual);
            #endregion

        }
        
        [Fact]
        public void BMICalculate_WhenHeightIsZeroAndWeightIsZero_ThenShouldCalculateBMICorrectly()
        {
            // AAA

            #region Arrange
            // In This Section Declare all Prerequistes int this section
            var sut = new BMICalculator();// sut : Appriviation to Subject Under Test  
            #endregion

            #region Act
            // In this Section We Calculate Actual Result
            var actual = Math.Round(sut.BMICalculate(0, 0),2);
            var Expected = 0;
            #endregion

            #region Assert
            // In This Section we Compere Actual Result With Expected Result
            Assert.Equal(Expected, actual);
            #endregion

        }
    }
}