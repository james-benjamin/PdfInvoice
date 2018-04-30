﻿using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PdfInvoice
{
    public class Header : Pdf
    {
        public void CreateHeader(Document doc)
        {
            var table = TableSetUp(4);
            table.SpacingBefore = 0;
            table.SetWidths(new float[] { 39, 31, 12, 10 });

            table.AddCell(Logo);

            table.AddCell(EmptyColumn());

            doc.Add(HeaderText(table, new List<string>() { "Invoice", "Date", "Invoice No.", "Sale Reference" }, Date, InvoiceNo, SalesRef));
        }

        private PdfPCell Logo
        {
            get
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(LogoPath);
                image.ScaleAbsolute(84, 72);

                return AddCell(new CellRowSettings(3, 0, Element.ALIGN_JUSTIFIED, Element.ALIGN_MIDDLE, 0), image);
            }
        }

        private PdfPCell EmptyColumn()
        {
            return AddCell(new CellRowSettings(1, 0, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE, 0), "", CellBackColorWhite);
        }

        private PdfPTable HeaderText(PdfPTable table, List<string> text, string date, string invoice, string salesRefernce)
        {
            table.AddCell(AddCell(new CellRowSettings(1, 2, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE, 55), text[0], CellBackColorWhite, 24));
            table.AddCell(AddTextForCellRow(new CellRowSettings(0, 0, Element.ALIGN_LEFT, Element.ALIGN_TOP, 16), text[1], CellBackColorGrey));
            table.AddCell(AddTextForCellRow(new CellRowSettings(0, 0, Element.ALIGN_LEFT, Element.ALIGN_TOP, 16), text[2], CellBackColorGrey));
            table.AddCell(AddTextForCellRow(new CellRowSettings(0, 0, Element.ALIGN_RIGHT, Element.ALIGN_TOP, 16), text[3], CellBackColorGrey));
            table.AddCell(AddTextForCellRow(new CellRowSettings(0, 0, Element.ALIGN_LEFT, Element.ALIGN_TOP, 0), date));
            table.AddCell(AddTextForCellRow(new CellRowSettings(0, 0, Element.ALIGN_LEFT, Element.ALIGN_TOP, 0), invoice));
            table.AddCell(AddTextForCellRow(new CellRowSettings(0, 0, Element.ALIGN_RIGHT, Element.ALIGN_TOP, 0), salesRefernce));

            return table;
        }
    }
}
