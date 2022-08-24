using Challenge;

namespace ChallengeTests
{
    public class CompressorFixture
    {
        public Compressor compressor = new Compressor();
    }
    public class CompressorTest : IClassFixture<CompressorFixture>
    {
        private readonly CompressorFixture _compressorFixture;

        public CompressorTest(CompressorFixture compressorFixture)
        {
            _compressorFixture = compressorFixture;
        }

        [Theory]
        [InlineData("uuueeeenzzzzz", "u3e4nz5")]
        [InlineData("uuueeeennzzzzz", "u3e4nnz5")]
        [InlineData("uuueeeennzzzzza", "u3e4nnz5a")]
        [InlineData("zzzzzzzzzzuuueeeenna", "z10u3e4nna")]
        public void GivenUncompressedString_ReturnsCompressedString(string uncompressedStrin, string expectedResult)
        {
            Compressor compressor = _compressorFixture.compressor;

            var result = compressor.compressString(uncompressedStrin);

            Assert.Contains("successfully", result.msg);
            Assert.Equal(expectedResult, result.result);
        }

        [Theory]
        [InlineData("ab4444444444444444444444444444444444", "ab434")]
        [InlineData("abbbb3333", "ab434")]
        [InlineData("ab43333", "ab434")]
        public void GivenUncompressedStringWithNumbers_ReturnsCompressedString(string uncompressedStrin, string expectedResult)
        {
            Compressor compressor = _compressorFixture.compressor;

            var result = compressor.compressString(uncompressedStrin);

            Assert.Contains("successfully", result.msg);
            Assert.Equal(expectedResult, result.result);
        }

        [Theory]
        [InlineData("ab434", "ab434")]
        [InlineData("u3e4nnz5a", "u3e4nnz5a")]
        [InlineData("u3e4nz5", "u3e4nz5")]
        public void GivenCompressedString_ReturnsCertainMessage(string uncompressedStrin, string expectedResult)
        {
            Compressor compressor = _compressorFixture.compressor;

            var result = compressor.compressString(uncompressedStrin);

            Assert.Contains("String is already compressed", result.msg);
            Assert.Equal(expectedResult, result.result);
        }
    }
}