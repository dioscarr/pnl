using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using pnl.Data;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace pnl.Models
{
    public class ReportData
    {        
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;
        public ReportData(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _env = env;
            taxtForm = new TaxForm();
            dependent = new List<Dependent>();
            filingStatus = new FilingStatus();
            taxFormAddress = new TaxFormAddress();
            taxFormCriteria = new TaxFormCriteria();
            taxFormAddress = new TaxFormAddress();
            CareProvider = new DependentCareProviders();
        }
        public ReportData(ApplicationDbContext db)
        {
            _db = db;
         
         
            taxtForm = new TaxForm();
            dependent = new List<Dependent>();
            filingStatus = new FilingStatus();
            taxFormAddress = new TaxFormAddress();
            taxFormCriteria = new TaxFormCriteria();
            taxFormAddress = new TaxFormAddress();
            CareProvider = new DependentCareProviders();
        }
        public ReportData()
        {
           
            taxtForm = new TaxForm();
            dependent = new List<Dependent>();
            filingStatus = new FilingStatus();
            taxFormAddress = new TaxFormAddress();
            taxFormCriteria = new TaxFormCriteria();
            taxFormAddress = new TaxFormAddress();
            CareProvider = new DependentCareProviders();
        }                
        public TaxForm taxtForm{ get; set; }
        public List<Dependent> dependent { get; set; }
        public FilingStatus filingStatus { get; set; }
        public TaxFormAddress taxFormAddress { get; set; }
        public TaxFormCriteria taxFormCriteria { get; set; }
        public TaxFormPerson taxFormPerson { get; set; }
        public DependentCareProviders CareProvider { get; set; }     

        #region Declaration
        int _maxColumn = 3;
        Document _document;
        iTextSharp.text.Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        MemoryStream _memoryStream = new MemoryStream();
        PdfPCell _pdfCell;
        #endregion

        public byte[] GetPdfReport(int taxFormId)
        {
            #region doc setup
            _document = new Document();
            _document.SetPageSize(PageSize.Letter);
            _document.SetMargins(5f, 5f, 5f, 5f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Thomas", 8f, 1);
            PdfWriter docWriter = PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            float[] sizes = new float[_maxColumn];
            for (var i = 0; i < _maxColumn; i++)
            {
                if (i == 0) sizes[i] = 20;
                else sizes[i] = 100;
            }
            _pdfTable.SetTotalWidth(sizes);
            var t = _db.TaxForms.Find(taxFormId);
            #endregion
            this.ReportHeader(t.TaxYear, t.FilingStatus);
            this.EmptyRow(2);
            this.ReportBody(t);

            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();
        }
           
        public ReportData GetReport(int taxFormId)
        {
            ReportData report = new ReportData();
            if (taxFormId > 0)
            {
                report.taxtForm = _db.TaxForms.Find(taxFormId);
                //report.dependent = _db.Dependent.Where(c => c.TaxFormID == taxFormId).ToList();
                //report.filingStatus = report.taxtForm.Filingstatus;
                //report.taxtForm.            }
            }
            return report;
        }
        private void ReportHeader(int taxYear, string fStatus)
        {
            _pdfCell = new PdfPCell(this.SetPageTitle(taxYear, fStatus));
            _pdfCell.Colspan = _maxColumn ;
            _pdfCell.Border = 0;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
            
            _pdfCell = new PdfPCell(this.AddLogo());
            _pdfCell.Colspan = 3;
            _pdfCell.Border = 0;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
        }
        private PdfPTable SetPageTitle(int taxYear, string fStatus)
        {
            int maxColumn =2;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            PdfPCell _pdfCell = new PdfPCell(new Phrase($"Tax Year {taxYear}",_fontStyle));
            _pdfCell.Colspan = maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.Border = 0;
            pdfPTable.AddCell(_pdfCell);
            pdfPTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"1 of 2", _fontStyle));
            _pdfCell.Colspan = maxColumn;
            _pdfCell.Rowspan = 2;
            _pdfCell.VerticalAlignment = Element.ALIGN_TOP;
            _pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfCell.Border = 0;
            pdfPTable.AddCell(_pdfCell);
            pdfPTable.CompleteRow();

            return pdfPTable;
        }
        private void ReportBody(TaxForm t)
        {
            var fontStyleBold = FontFactory.GetFont("Tahoma)", 9f, 1);
            _fontStyle = FontFactory.GetFont("Tahoma)", 9f, 0);
            #region Detail Table Header
            _pdfCell = new PdfPCell(new Phrase("Tax Year", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
            #endregion
            #region Detail table body
            #region Main Applicant information
            #region Main Constituent
            _pdfCell = new PdfPCell(new Phrase($"{t.Person.FirstName} {t.Person.LastName}", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Colspan = 3;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Phone}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Birthday}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Email}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Occupation}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
            #endregion
            #region Spouse
            _pdfCell = new PdfPCell(new Phrase($"{t.Person.FirstName} {t.Person.LastName}", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Colspan = 3;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Phone}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Birthday}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Email}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Occupation}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
            #endregion
            #region Address
            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Address.Address1}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Address.Address2}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Address.City}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Address.State}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _pdfCell = new PdfPCell(new Phrase($"{t.Person.Address.Zip}", _fontStyle));
            _pdfCell.Colspan = 3;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.White;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
            #endregion
            #region
            foreach (var item in t.TaxFormCriterias)
            {
                _pdfCell = new PdfPCell(new Phrase($"{item.Name}", _fontStyle));
                _pdfCell.Colspan = 3;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();
            }
            #endregion
            #endregion
            #endregion
        }
        private PdfPTable AddLogo()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);
            string path = _env.WebRootPath + "/img";
            
            string imgCombine = Path.Combine(path, "LOgo.png");
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imgCombine);

            _pdfCell = new PdfPCell(img);
            _pdfCell.Colspan = maxColumn+2;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 2;
            pdfPTable.AddCell(_pdfCell);

            pdfPTable.CompleteRow();
            return pdfPTable;            
        }
        private void EmptyRow(int nCount)
        {
            for (int i = 0; i < nCount; i++)
            {
                _pdfCell = new PdfPCell(new Phrase("", _fontStyle));
                _pdfCell.Colspan = _maxColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 10;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();
            }
        }      
    }
}

