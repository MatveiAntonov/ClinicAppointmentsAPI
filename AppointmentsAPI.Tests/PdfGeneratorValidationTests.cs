using Appointments.Application.Logic;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.Text;

namespace AppointmentsAPI.Tests
{
    public class PdfGeneratorValidationTests
    {
        [Fact]
        public void CreatePDF_GivenValidInputs_ReturnsByteArray()
        {
            // Arrange
            string complaints = "Test Complaints";
            string conclusion = "Test Conclusion";
            string recommendations = "Test Recommendations";

            // Act
            byte[] result = PdfGenerator.CreatePDF(complaints, conclusion, recommendations);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void CreatePDF_GivenNullInputs_ThrowsArgumentNullException()
        {
            // Arrange
            string complaints = null;
            string conclusion = null;
            string recommendations = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => PdfGenerator.CreatePDF(complaints, conclusion, recommendations));
        }

        [Fact]
        public void CreatePDF_GivenEmptyInputs_ThrowsArgumentException()
        {
            // Arrange
            string complaints = string.Empty;
            string conclusion = string.Empty;
            string recommendations = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => PdfGenerator.CreatePDF(complaints, conclusion, recommendations));
        }

        [Fact]
        public void CreatePDF_ValidInputs_ReturnsNonEmptyByteArray()
        {
            // Arrange
            string complaints = "Complaints";
            string conclusion = "Conclusion";
            string recommendations = "Recommendations";

            // Act
            byte[] result = PdfGenerator.CreatePDF(complaints, conclusion, recommendations);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void CreatePDF_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string complaints = "Complaints";
            string conclusion = null;
            string recommendations = "Recommendations";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => PdfGenerator.CreatePDF(complaints, conclusion, recommendations));
        }

        [Fact]
        public void CreatePDF_ValidInputs_GeneratesPDFWithExpectedText()
        {
            // Arrange
            string complaints = "Complaints";
            string conclusion = "Conclusion";
            string recommendations = "Recommendations";
            byte[] pdf = PdfGenerator.CreatePDF(complaints, conclusion, recommendations);

            // Act
            string pdfText = ReadPdfText(pdf);

            // Assert
            Assert.Contains("Appointment Result", pdfText);
            Assert.Contains("Complaints", pdfText);
            Assert.Contains(complaints, pdfText);
            Assert.Contains("Conclusion", pdfText);
            Assert.Contains(conclusion, pdfText);
            Assert.Contains("Recommendations", pdfText);
            Assert.Contains(recommendations, pdfText);
        }

        private static string ReadPdfText(byte[] pdf)
        {
            using (var reader = new PdfReader(pdf))
            {
                var text = new StringBuilder();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
                return text.ToString();
            }
        }
    }
}
