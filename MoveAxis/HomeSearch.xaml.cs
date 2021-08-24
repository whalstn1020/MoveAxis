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
using System.Text.RegularExpressions;
namespace MoveAxis
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            NumOnly();
        }








        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }
        private bool IsNumeric(string source)//숫자입력 함수
        {
            Regex regex = new Regex("[^0-9.-]+"); return !regex.IsMatch(source);
        }
        public void NumOnly()
        {
            FVVal.PreviewTextInput += textBox_PreviewTextInput;
            SVVal.PreviewTextInput += textBox_PreviewTextInput;
            TVVal.PreviewTextInput += textBox_PreviewTextInput;
            LVVal.PreviewTextInput += textBox_PreviewTextInput;
            FAcc.PreviewTextInput += textBox_PreviewTextInput;
            SAcc.PreviewTextInput += textBox_PreviewTextInput;
        }

        private void HomeSearch_Click(object sender, RoutedEventArgs e)
        {

            uint duRetCode = 0;
            //++ 지정한 축에 원점검색을 진행합니다.
            duRetCode = CAXM.AxmHomeSetStart(MainWindow.m_lAxisNo);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmHomeSetStart return error[Code:{0:d}]", duRetCode));

        }
        private void MoveStop_Click(object sender, EventArgs e)
        { 
                    //++ 지정한 축의 구동을 정지합니다.
                   
                    CAXM.AxmMoveSStop(MainWindow.m_lAxisNo);
        }
    }
}
