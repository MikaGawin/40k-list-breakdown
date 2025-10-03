using System.Collections.Generic;
using System.Linq; // Needed for Select
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace WarhammerStats.Core;

public class PdfParser
{
    public List<string> ExtractUnits(string pdfPath)
    {
        var lines = new List<string>();

        using (var document = PdfDocument.Open(pdfPath))
        {
            foreach (var page in document.GetPages())
            {
                // PdfPig gives raw text; may not be "line broken" nicely
                var text = page.Text ?? string.Empty;

                // Split on both \n and \r\n, remove empty entries, trim whitespace
                var splitLines = text
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(l => l.Trim());

                lines.AddRange(splitLines);
            }
        }

        return lines;
    }
}