using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        
        public bool Isloaded = false;
        public ICommand ClosewindowCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand linkMyBK { get; set; }
        // mọi thứ xử lý sẽ nằm trong này
        public MainViewModel()
        {
            
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.IsLogin)
                {
                    p.Show();

                }
                else
                {
                    p.Close();
                   
                }
            }
              );

            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UnitWindow wd = new UnitWindow(); wd.ShowDialog(); });
            linkMyBK = new RelayCommand<object>((p) => { return true; }, (p) => { System.Diagnostics.Process.Start("https://mybk.hcmut.edu.vn/my/index.action"); });/*nhan vao mau in*/
            ClosewindowCommand = new RelayCommand<Window>((w) => { return true; }, (w) => { w.Close(); });


        }
        
            

    }
}
