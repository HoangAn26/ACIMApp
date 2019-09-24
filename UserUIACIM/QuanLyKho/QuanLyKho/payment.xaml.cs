using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows.Navigation;
using QuanLyKho.Model;
using QuanLyKho.ViewModel;



namespace QuanLyKho
{
    /// <summary>
    /// Interaction logic for payment.xaml
    /// </summary>
    public partial class payment : Window
    {
        private bool stateofwin;
        ICommand close { get; set; }
        public payment()
        {
            InitializeComponent();

        }
 

      


        private void buttontoprint(object sender, RoutedEventArgs e)
        {

            string abc = RFIDcode.Password.ToString();

            var verify = DataProvider.Ins.DB.rfid_table.Where(x => x.rfid_code == abc).Count();
            UnitWindow Unit = new UnitWindow();
            var UnitVM = Unit.DataContext as UnitWindowVM;
            if (verify > 0)
            {
                var numprint = DataProvider.Ins.DB.rfid_table.Where(x => x.rfid_code == abc).Single().num_print;
                int num = Int32.Parse(numprint);
                if (num > 0)
                {

                if (UnitVM.formnumber == 1)
                {
                        UnitVM.CreateWordDocument(@"D:\StudyD\Apps\UserUIACIM\ĐẠI-HỌC-QUỐC-GIA-TP.docx", @"D:\StudyD\Apps\UserUIACIM\certificat.docx");

                        num = num - 1;
                        Numprint.Text = "Number of remaining times :\t" + num.ToString();
                        DataProvider.Ins.DB.rfid_table.Where(x => x.rfid_code == abc).Single().num_print = num.ToString();
                        DataProvider.Ins.DB.SaveChanges();
                        stateofwin = false;
                    }
                    if (UnitVM.formnumber == 2)
                    {
                        UnitVM.CreateWordDocument(@"D:\StudyD\Apps\UserUIACIM\ĐẠI-HỌC-QUỐC-GIA-TP.docx", @"D:\StudyD\Apps\UserUIACIM\certificat.docx");


                        num = num - 1;
                        Numprint.Text = num.ToString();
                        DataProvider.Ins.DB.rfid_table.Where(x => x.rfid_code == abc).Single().num_print = num.ToString();
                        DataProvider.Ins.DB.SaveChanges();
                        Numprint.Text = "Number of remaining times :\t" + num.ToString();
                        
                        stateofwin = false;
                    }
                }
                else
                {
                    MessageBox.Show(" Please add more number of printing times ");
                    stateofwin = false ;

                }
            }
        }




    }
}
