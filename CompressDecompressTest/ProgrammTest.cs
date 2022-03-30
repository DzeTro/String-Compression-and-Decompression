using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompressDecompressTest
{
    [TestClass]
    public class ProgrammTest
    {
        [TestMethod]
        public void Compressiion_TextString_Valid()
        {
            var plainText = "QQQQRRRRRRTTTTTTTTTTLLLLLLLLLLLMNNNVVVVVVVVVVVAAAAAAAAAAAAA";
            var expectedCompressedString = "§4Q§6R§10T§11LMNNN§11V§13A";

            var compressedString = Programm.Compression(plainText);
            Assert.AreEqual(expectedCompressedString, compressedString);
        }

        [TestMethod]
        public void Compressiion_TextString_Invalid()
        {
            var plainText = "QQQQRRRRRRTTTTTTTTTTLLLLLLLLLLLMNNNVVVVVVVVVVVAAAAAAAAAAAAA";
            var expectedCompressedString = "§4Q§6R4510T§11LMNNN§11V§13A";

            var compressedString = Programm.Compression(plainText);
            Assert.AreNotEqual(expectedCompressedString, compressedString);
        }

        [TestMethod]
        public void Decompress_TextString_Valid()
        {
            var inputText = "§4Q§6R§10T§11LMNNN§11V§13A";
            var expectedDecompressedString = "QQQQRRRRRRTTTTTTTTTTLLLLLLLLLLLMNNNVVVVVVVVVVVAAAAAAAAAAAAA";

            var compressedString = Programm.Decompress(inputText);
            Assert.AreEqual(expectedDecompressedString, compressedString);
        }

        [TestMethod]
        public void Decompress_TextString_Invalid()
        {
            var inputText = "§4Q§6R§10T§11LMNNN§11V§13A";
            var expectedDecompressedString = "QQQQRRRRRRTTTTTTVVVVVVVVVVAAAAAAAAAAAAA";

            var compressedString = Programm.Decompress(inputText);
            Assert.AreNotEqual(expectedDecompressedString, compressedString);
        }
    }
}