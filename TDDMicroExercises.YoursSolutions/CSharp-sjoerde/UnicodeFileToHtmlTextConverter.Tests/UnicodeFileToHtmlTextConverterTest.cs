using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Tests
{
    public class TestUnicodeFileToHtmlTextConverter : UnicodeFileToHtmlTextConverter
    {
        public override TextReader OpenFile(string fullFilenameWithPath)
        {
            if (fullFilenameWithPath != "abc.txt") 
            {
                throw new ArgumentOutOfRangeException();
            }
            return new StringReader(string.Format("a{0}bc{0}d", Environment.NewLine));
        }
    }

    [TestClass]
    public class UnicodeFileToHtmlTextConverterTest
    {
        [TestMethod]
        public void EncodeOneLine() 
        { 
            // Arrange
            var converter = new UnicodeFileToHtmlTextConverter();
            string line = "blabla";

            // Act
            string encoded = converter.EncodeLine(line);

            // Assert
            Assert.AreEqual("blabla<br />", encoded);
        }

        [TestMethod]
        public void EncodeTextReader()
        {
            // Arrange
            var converter = new UnicodeFileToHtmlTextConverter();
            var reader = new StringReader(string.Format("a{0}bc{0}d", Environment.NewLine));

            // Act
            string encoded = converter.ConvertToHtml(reader);

            // Assert
            Assert.AreEqual("a<br />bc<br />d<br />", encoded);
        }

        [TestMethod]
        public void EncodeFile()
        {
            // Arrange
            var converter = new TestUnicodeFileToHtmlTextConverter();

            // Act
            string encoded = converter.ConvertToHtml("abc.txt");

            // Assert
            Assert.AreEqual("a<br />bc<br />d<br />", encoded);
        }
    }
}
