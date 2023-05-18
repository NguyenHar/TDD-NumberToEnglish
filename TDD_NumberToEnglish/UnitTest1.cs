namespace TDD_NumberToEnglish
{
    public class TestNumberToEnglish
    {

        [Theory]
        [InlineData(56d, "fifty six dollars")]
        [InlineData(12.62d, "twelve dollars sixty two cents")]
        [InlineData(0.50d, "fifty cents")]
        [InlineData(9d, "nine dollars")]
        [InlineData(1.59d, "one dollars fifty nine cents")]
        [InlineData(13.59d, "thirteen dollars fifty nine cents")]
        [InlineData(10000d, "ten thousand dollars")]
        [InlineData(12000d, "twelve thousand dollars")]
        [InlineData(12300d, "twelve thousand three hundred dollars")]
        [InlineData(12350d, "twelve thousand three hundred fifty dollars")]
        [InlineData(12050d, "twelve thousand fifty dollars")]
        [InlineData(12005d, "twelve thousand five dollars")]
        [InlineData(12465d, "twelve thousand four hundred sixty five dollars")]
        [InlineData(1230652d, "one million two hundred thirty thousand six hundred fifty two dollars")]
        [InlineData(1230652.62d, "one million two hundred thirty thousand six hundred fifty two dollars sixty two cents")]
        [InlineData(1000000d, "one million dollars")]
        [InlineData(9000002d, "nine million two dollars")]
        [InlineData(0.00d, "")]
        [InlineData(1234567d, "one million two hundred thirty four thousand five hundred sixty seven dollars")]
        [InlineData(1000d, "one thousand dollars")]
        [InlineData(117300d, "one hundred seventeen thousand three hundred dollars")]
        [InlineData(1111111111.11d, "one billion one hundred eleven million one hundred eleven thousand one hundred eleven dollars eleven cents")]

        public void TestToEnglish(double num, string expected)
        {
            NumberToEnglish n = new NumberToEnglish();
            string actual = n.ToEnglish(num);
            Assert.Equal(expected, actual);
        }
    }
}