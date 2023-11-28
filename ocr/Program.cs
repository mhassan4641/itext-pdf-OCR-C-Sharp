using System.Collections.Generic;
using System.IO;
using iText.Kernel.Pdf;
using iText.Pdfocr;
using iText.Pdfocr.Tesseract4;
public class Program
{
    private static string OUTPUT_PDF = "C:/myfiles/hello.pdf";
    private static readonly Tesseract4OcrEngineProperties tesseract4OcrEngineProperties = new Tesseract4OcrEngineProperties();

    private static IList<FileInfo> LIST_IMAGES_OCR = new List<FileInfo>
    {   
        //replace with the image file name you have uploaded
        new FileInfo("C:/uploads/testocr.jpg") 
    };
    
    static void Main()
    {
        var tesseractReader = new Tesseract4LibOcrEngine(tesseract4OcrEngineProperties);
        tesseract4OcrEngineProperties.SetPathToTessData(new FileInfo("C:/training-data/tessdata_best/"));
        
        var ocrPdfCreator = new OcrPdfCreator(tesseractReader);
        using (var writer = new PdfWriter(OUTPUT_PDF))
        {
            ocrPdfCreator.CreatePdf(LIST_IMAGES_OCR, writer).Close();
        }
        
    }
}