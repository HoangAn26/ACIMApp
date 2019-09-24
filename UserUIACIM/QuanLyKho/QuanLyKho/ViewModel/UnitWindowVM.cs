using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using LibUsbDotNet;
using LibUsbDotNet.Main;



namespace QuanLyKho.ViewModel
{
    public class UnitWindowVM : BaseViewModel
    {
        public string UserName;
        public ICommand PrintoutCommand { get; set; }
        public ICommand Clickin { get; set; }
        public ICommand Clickin1 { get; set; }
        public ICommand Clickform1 { get; set; }
        public ICommand Clickform2 { get; set; }
        public int formnumber;



        public UnitWindowVM()
        {
           
            //PrintoutCommand = new RelayCommand<object>((p) => { return true; }, (p) => { Window1 wd1 = new Window1(); wd1.ShowDialog(); });
            Clickform1 = new RelayCommand<object>((p) => { return true; }, (p) => { formnumber = 1; });
            Clickform2 = new RelayCommand<object>((p) => { return true; }, (p) => 
            { formnumber = 2; });
            Clickin = new RelayCommand<Window>((p) => { return true; }, (p) =>
            { p = new payment();
                p.ShowDialog();
                //if (formnumber == 1)
                //{
                //    CreateWordDocument(@"E:\test_doc\temp2.docx", @"E:\test\certificat.docx");
                //}
                //if (formnumber == 2)
                //{
                //    CreateWordDocument(@"E:\test_doc\temp.docx", @"E:\test\certificat2.docx");
                //}
                
            });
        }
        public void PrintOut(ref object Background, ref object Append, ref object Range, ref object OutputFileName,
    ref object From, ref object To, ref object Item, ref object Copies, ref object Pages, ref object PageType,
    ref object PrintToFile, ref object Collate, ref object ActivePrinterMacGX, ref object ManualDuplexPrint,
    ref object PrintZoomColumn, ref object PrintZoomRow, ref object PrintZoomPaperWidth, ref object PrintZoomPaperHeight)
        {

        }
        private void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        public void CreateWordDocument(object filename, object SaveAs)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                LoginWindow loginWindow = new LoginWindow();
                var loginVM = loginWindow.DataContext as LoginViewModel;// lay du lieu tu login window

                //find and replace
                
                var mssv = DataProvider.Ins.DB.Users.Where(x => x.UserName ==loginVM.UserName).Single().MSSV;
                var Displayname = DataProvider.Ins.DB.Users.Where(x => x.UserName == loginVM.UserName).Single().DisplayName;
                var khoa = DataProvider.Ins.DB.Users.Where(x => x.UserName == loginVM.UserName).Single().Khoa;
                var year = DataProvider.Ins.DB.Users.Where(x => x.UserName == loginVM.UserName).Single().Khóa;
                var place = DataProvider.Ins.DB.Users.Where(x => x.UserName == loginVM.UserName).Single().hộ_khẩu;
                var date = DataProvider.Ins.DB.Users.Where(x => x.UserName == loginVM.UserName).Single().borndate;
                this.FindAndReplace(wordApp, "<MSSV>", mssv);
                this.FindAndReplace(wordApp, "<Khoa>", khoa);
                this.FindAndReplace(wordApp, "<name>", Displayname);
                this.FindAndReplace(wordApp, "<place>", place);
                this.FindAndReplace(wordApp, "<borndate>", date);

            }
            else
            {
                MessageBox.Show("File not Found!");
            }

            //Save as
            myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);





            object printBackground = false;
            object copies = "1";
            object pages = "";
            object range = Word.WdPrintOutRange.wdPrintAllDocument;
            object items = Word.WdPrintOutItem.wdPrintDocumentContent;
            object pageType = Word.WdPrintOutPages.wdPrintAllPages;
            object oTrue = true;
            object oFalse = false;


            myWordDoc.PrintOut(ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing,
                ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
                ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing);
            myWordDoc.Close();
            wordApp.Quit();
         
            
           //int numprint = rfid.check_code_get_num()
            MessageBox.Show("In thành công");

        }

    }
}
