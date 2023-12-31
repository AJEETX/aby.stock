﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Gehtsoft.PDFFlow.Builder;
using Gehtsoft.PDFFlow.Models.Shared;
using Gehtsoft.PDFFlow.Models.Enumerations;
using Gehtsoft.PDFFlow.Utils;
using AbyStockManager.Web.Model.ViewModel.Invoice;

namespace Receipt
{
    public static class ReceiptRunner
    {
        private static string ProjectDir;
        private static string ReceiptJsonFile;
        private static string ReceiptJsonContent;
        private static string ImageUrl;
        public static List<ReceiptData> ReceiptData { get; set; }
        private static readonly string[] ReceiptText;
        private static readonly FontBuilder DocumentFont;
        private static readonly FontBuilder ItalicFont;
        private static readonly FontBuilder FooterFont;
        private static readonly FontBuilder BoldFont;
        private static readonly FontBuilder TitleFont;
        private static readonly FontBuilder HiddenFont;

        static ReceiptRunner()
        {
            DocumentFont = Fonts.Helvetica(14f);
            ItalicFont = FontBuilder.New().SetSize(14f).SetName("Courier");
            FooterFont = Fonts.Helvetica(12f).SetColor(Color.FromRgba(106.0 / 255.0, 85.0 / 255.9, 189.0 / 255.0));
            BoldFont = FontBuilder.New().SetSize(14f).SetName("Courier").SetBold();
            TitleFont = FontBuilder.New().SetSize(18f).SetName("Helvetica").SetBold();
            HiddenFont = Fonts.Courier(0.01f).SetColor(Color.White);

            ReceiptText = new[]
            {
                "We received payment for your purchase.",
                "Thanks for staying with us!",
                "Questions? Please contact "
            };
        }

        public static DocumentBuilder Run(string path, List<ReceiptData> receiptDatas)
        {
            ProjectDir = path;
            ReceiptJsonFile = Path.Combine(ProjectDir, "content", "receipt.json");
            ReceiptJsonContent = File.ReadAllText(ReceiptJsonFile);
            ReceiptData = receiptDatas;
            ImageUrl = Path.Combine(ProjectDir, "img", "logo.png");

            return DocumentBuilder
                .New()
                .ApplyStyle(StyleBuilder.New().SetLineSpacing(1.2f))
                .AddReceiptSection();
        }

        private static DocumentBuilder AddReceiptSection(this DocumentBuilder builder)
        {
            builder
                .AddSection()
                .SetSectionSettings()
                .AddReceiptTitle()
                .AddReceiptTable()
                .AddReceiptText()
                .AddFooter();
            return builder;
        }

        private static SectionBuilder SetSectionSettings(this SectionBuilder s)
        {
            s.SetMargins(30).SetSize(PaperSize.A4).SetOrientation(PageOrientation.Portrait).SetNumerationStyle();
            return s;
        }

        private static SectionBuilder AddReceiptTitle(this SectionBuilder s)
        {
            s.AddImage(ImageUrl).SetScale(ScalingMode.OriginalSize).SetAlignment(HorizontalAlignment.Left);
            s.AddParagraph("Invoice / Receipt").SetMargins(0, 20, 0, 10).SetFont(TitleFont).SetAlignment(HorizontalAlignment.Right);
            s.AddLine().SetColor(Color.FromRgba(106.0 / 255.0, 85.0 / 255.9, 189.0 / 255.0)).SetStroke(Stroke.Solid).SetWidth(2);
            return s;
        }

        private static SectionBuilder AddReceiptText(this SectionBuilder s)
        {
            s.AddLine().SetColor(Color.FromRgba(106.0 / 255.0, 85.0 / 255.9, 189.0 / 255.0)).SetStroke(Stroke.Solid).SetWidth(2);

            ParagraphBuilder p = s.AddParagraph()
                .SetMargins(0, 20, 0, 10)
                .SetFont(DocumentFont);
            p.AddText(ReceiptText);
            p.AddUrl("0999999999 ");
            return s;
        }

        private static SectionBuilder AddReceiptTable(this SectionBuilder s)
        {
            s.AddTable()
                .SetHeaderRowStyleBorder(builder => builder.SetStroke(Stroke.None).SetWidth(.0f))
                .SetHeaderRowStyleFont(HiddenFont)
                .SetContentRowStyleBorder(builder => builder.SetStroke(Stroke.None).SetWidth(.0f))
                .SetContentRowStyleFont(ItalicFont)
                .SetDataSource(ReceiptData);

            return s;
        }

        private static SectionBuilder AddFooter(this SectionBuilder s)
        {
            RepeatingAreaBuilder footer = s.AddFooterToBothPages(160);

            footer
                .AddLine()
                .SetStroke(Stroke.Solid)
                .SetWidth(2);
            footer
                .AddParagraph()
                .SetMargins(0, 20, 0, 10)
                .AddText("SDA Chandauli, Inc")
                .SetFont(BoldFont);
            footer
                .AddParagraph()
                .SetMargins(0, 0, 0, 0)
                .SetFont(FooterFont)
                .AddTextToParagraph("CEAT Tyres agency")
                .AddTabSymbol()
                .AddTextToParagraph("[                                 ] ")
                .AddTabulation(280);
            footer
                .AddParagraph()
                .SetMargins(0, 0, 0, 0)
                .SetFont(FooterFont)
                .AddTextToParagraph("200 GT Road Chandauli, UP")
                .AddTabSymbol()
                .AddTextToParagraph("Signature / Proprieter")
                .AddTabulation(280);
            footer
                .AddParagraph()
                .SetMargins(0, 0, 0, 0)
                .SetFont(FooterFont)
                .AddTextToParagraph("GSTN : JKHHNMJYH53636373")
                .AddTabSymbol()
                .AddUrlToParagraph("")
                .AddTabulation(280);

            footer
                .AddParagraph()
                .SetMargins(0, 0, 0, 0)
                .SetFont(FooterFont)
                .AddText("*GST paid directly by SDA Chandauli, Inc., where applicable");
            footer
                .AddParagraph()
                .SetMargins(0, 0, 0, 0)
                .AddTextToParagraph("Contact: 0999999999 ")
                .AddTabSymbol()
                .SetFont(BoldFont)
                .AddUrlToParagraph("")
                .AddTabulation(280);
            return s;
        }
    }
}