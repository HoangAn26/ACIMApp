using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System.IO;
using System.Reflection;
using System.Windows;
using ACIMApp.Module.BusinessObjects;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.FileAttachments.Win;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit.API.Native;

using DevExpress.XtraPrinting.Native;
using System.Windows.Forms;
using DevExpress.Xpo;
using Document = DevExpress.XtraRichEdit.API.Native.Document;

namespace ACIMApp.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class PrintCer : ViewController
    {
        public PrintCer()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            //TargetViewType = ViewType.ListView;
            //TargetObjectType = typeof(ACIMApp.Module.BusinessObjects.MauIn);
                       
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }


        private void simpleAction1_Execute_1(object sender, SimpleActionExecuteEventArgs e)
        {
            MauIn mauIn = (MauIn)View.CurrentObject;
            NguoiDung nguoiDung = mauIn.Session.GetObjectByKey<NguoiDung>(SecuritySystem.CurrentUserId);
            
            //Name of files
            FileData chungNhan = mauIn.fileMau;
            string fileName = chungNhan.FileName;
            string fileNameTemp = @"TempFile\" + fileName;
            string fileNameSave = @"SaveFile\" + fileName;

            //Names of fields in files
            //if (nguoiDung.thanhVien.TenNguoiDung != null) ;
            string tenNguoiDung = nguoiDung.thanhVien.TenNguoiDung!=null? nguoiDung.thanhVien.TenNguoiDung:"";
            DateTime _ngaySinh = (DateTime)nguoiDung.thanhVien.ngaySinh;
            string ngaySinh = _ngaySinh.ToString("dd-MM-yyyy") != null ? _ngaySinh.ToString("dd-MM-yyyy") : "";//Edit format of DateTime
            string gioiTinh = nguoiDung.thanhVien.ToString() != null ? nguoiDung.thanhVien.ToString() : "";
            string MSSV = nguoiDung.thanhVien.MSSV != null ? nguoiDung.thanhVien.MSSV : "";
            string khoa = nguoiDung.thanhVien.khoaString != null ? nguoiDung.thanhVien.khoaString : "";
            string SDT = nguoiDung.thanhVien.SDT != null ? nguoiDung.thanhVien.SDT : "";
            string email = nguoiDung.thanhVien.email != null ? nguoiDung.thanhVien.email : "";
            string diaChi = nguoiDung.thanhVien.diaChi != null ? nguoiDung.thanhVien.diaChi : "";

            //int soLanIn = nguoiDung.soLanIn;


            using (RichEditDocumentServer srv = new RichEditDocumentServer())
            {
                if (srv.LoadDocument(fileNameTemp, DocumentFormat.OpenXml))
                {
                    Document doc = srv.Document;
                    //tenNguoiDung
                    DocumentRange[] ranges = doc.FindAll("<tenNguoiDung>", SearchOptions.None);
                    for (int i = 0; i < ranges.Length; i++) doc.Replace(ranges[i], tenNguoiDung);
                    //ngaySinh
                    DocumentRange[] range1s = doc.FindAll("<ngaySinh>", SearchOptions.None);
                    for (int i = 0; i < range1s.Length; i++) doc.Replace(range1s[i], ngaySinh);
                    //gioiTinh
                    DocumentRange[] range2s = doc.FindAll("<gioiTinh>", SearchOptions.None);
                    for (int i = 0; i < range2s.Length; i++) doc.Replace(range2s[i], gioiTinh);
                    //MSSV
                    DocumentRange[] range3s = doc.FindAll("<MSSV>", SearchOptions.None);
                    for (int i = 0; i < range3s.Length; i++) doc.Replace(range3s[i], MSSV);
                    //khoa
                    DocumentRange[] range4s = doc.FindAll("<khoa>", SearchOptions.None);
                    for (int i = 0; i < range4s.Length; i++) doc.Replace(range4s[i], khoa);
                    //SDT
                    DocumentRange[] range5s = doc.FindAll("<SDT>", SearchOptions.None);
                    for (int i = 0; i < range5s.Length; i++) doc.Replace(range5s[i], SDT);
                    //email
                    DocumentRange[] range6s = doc.FindAll("<email>", SearchOptions.None);
                    for (int i = 0; i < range6s.Length; i++) doc.Replace(range6s[i], email);
                    //diaChi
                    DocumentRange[] range7s = doc.FindAll("<diaChi>", SearchOptions.None);
                    for (int i = 0; i < range7s.Length; i++) doc.Replace(range7s[i], diaChi);
                }
                srv.SaveDocument(fileNameSave, DocumentFormat.OpenXml);
                //srv.Document.Sections[0].Page.Landscape = true;

                //DevExpress.XtraPrinting.PrintableComponentLink link = new DevExpress.XtraPrinting.PrintableComponentLink(new DevExpress.XtraPrinting.PrintingSystem());

                if (nguoiDung.soLanIn>0)
                { 
                    srv.Print();
                    nguoiDung.soLanIn--;
                    MessageBox.Show("You have "+ nguoiDung.soLanIn.ToString()+" more time(s) to PRINT");
                    nguoiDung.Save();// lưu lại giá trị
                }
                else { MessageBox.Show("Your print time has run out!"); }
                

                //FileStream fsOut = File.Open("FileOut.pdf", FileMode.Create);
                //srv.ExportToPdf(fsOut);
                //fsOut.Close();
            }
            //RichEditDocumentServer srv1 = new RichEditDocumentServer();
            //srv1.LoadDocument(fileNameTemp, DocumentFormat.OpenXml);
            //DevExpress.XtraPrinting.PdfExportOptions options = new DevExpress.XtraPrinting.PdfExportOptions();
            //options.Compressed = false;
            //options.ImageQuality = DevExpress.XtraPrinting.PdfJpegImageQuality.Highest;
            //FileStream pdfFileStream = new FileStream("Document_PDF.pdf", FileMode.Create);
            //srv1.ExportToPdf(pdfFileStream, options);

            //System.Diagnostics.Process.Start("Document_PDF.pdf");

            //System.Diagnostics.Process.Start(fileNameSave);
            //FileAttachmentsWindowsFormsModule.GetFileDataManager(Application).Open(chungNhan);//Open FileData
            //PreviewPrint previewPrintWindow = new PreviewPrint();
            //previewPrintWindow.ShowDialog();
        }
    }
}
