using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Tests
{
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
    }
}
