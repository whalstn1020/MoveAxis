using System;

using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;//숫자만 입력가능하게
using Microsoft.Win32;
using System.Windows.Media;
using System.Threading;
using System.Windows.Threading;
namespace MoveAxis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static MainWindow m_formMotion;

        public const uint ON = 1;
        public const uint OFF = 0;
        public const uint ENABLE = 1;
        public const uint DISABLE = 0;
        public const uint HIGH = 1;
        public const uint LOW = 0;

        public int m_lAxisCounts = 0;                          // 제어 가능한 축갯수 선언 및 초기화
        public static int m_lAxisNo = 1;                       // 제어할 축 번호 선언 및 초기화
        public uint m_uModuleID = 0;                           // 제어할 축의 모듈 I/O 선언 및 초기화 
        public int m_lBoardNo = 0, m_lModulePos = 0;           // 베이스보드 위치 값 / 모듈 위치 값

        private Thread[] m_hTestThread = new Thread[64];
        private bool[] m_bTestActive = new bool[64];


        public MainWindow()
        {
            InitializeComponent();
            InitOpen();                                        // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();
            NumOnly();
            m_formMotion = this;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(0.01);    //시간간격 설정
            timer.Tick += new EventHandler(TmDisplay_Tick);          //이벤트 추가
            timer.Start();//타이머 시작. 종료는 timer.Stop(); 으로 한다


        }

        public void NumOnly()
        {
            PosVal.PreviewTextInput += textBox_PreviewTextInput;
            VelVal.PreviewTextInput += textBox_PreviewTextInput;
            AccVal.PreviewTextInput += textBox_PreviewTextInput;
            DecVal.PreviewTextInput += textBox_PreviewTextInput;
        }

        public void InitOpen()
        {
            InitControl();
            String szFilePath = "C:\\Program Files\\EzSoftware RM\\EzSoftware\\MotionDefault.mot";///mot파일 불러오기
            if (CAXL.AxlOpen(7) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)//라이브러리 초기화 실패
            {
                MessageBox.Show("Initialize Fail..!!");
            }
            if (CAXM.AxmMotLoadParaAll(szFilePath) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)//mot파일 호출 실패
                MessageBox.Show("Mot File Not Found.");
        }

        public void InitControl()
        {
            // 초기값 설정
            PosVal.Text = "0.000";
            VelVal.Text = "100.000";
            AccVal.Text = "400.000";
            DecVal.Text = "400.000";
        }




        public void AddAxisInfo()//확인
        {
            String strAxis = "";

            //++ 유효한 전체 모션축수를 반환합니다.
            CAXM.AxmInfoGetAxisCount(ref m_lAxisCounts);
            m_lAxisNo = 0;
            //++ 지정한 축의 정보를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);
            for (int i = 0; i < m_lAxisCounts; i++)
            {
                switch (m_uModuleID)
                {
                    //++ 지정한 축의 정보를 반환합니다.
                    // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
                    case (uint)AXT_MODULE.AXT_SMC_4V04: strAxis = String.Format("{0:00}-[PCIB-QI4A]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_2V04: strAxis = String.Format("{0:00}-[PCIB-QI2A]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04: strAxis = String.Format("{0:00}-(RTEX-PM)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2Q: strAxis = String.Format("{0:00}-(RTEX-PM2Q)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2QE: strAxis = String.Format("{0:00}-(RTEX-PM2QE)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A4: strAxis = String.Format("{0:00}-[RTEX-A4N]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A5: strAxis = String.Format("{0:00}-[RTEX-A5N]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV: strAxis = String.Format("{0:00}-[MLII-SGDV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM: strAxis = String.Format("{0:00}-(MLII-PM)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICL: strAxis = String.Format("{0:00}-[MLII-CSDL]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICR: strAxis = String.Format("{0:00}-[MLII-CSDH]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV: strAxis = String.Format("{0:00}-[SIIIH-MRJ4]", i); break;
                    default: strAxis = String.Format("{0:00}-[Unknown]", i); break;
                }
                Axiscbo.Items.Add(strAxis);
            }
            InitControl();      // Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
        }

  
        private void ServoOn_Click(object sender, RoutedEventArgs e)//문제: 고정축만 onoff -> 누가 문제인가....
        {

            uint ServoOnOff=OFF;
            uint duRetCode = 0;
            duRetCode = CAXM.AxmSignalIsServoOn(m_lAxisNo, ref ServoOnOff);//해당 축의 Servo의 On/Off 상태확인
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("Servo is not exist ", duRetCode));


            if (ServoOnOff == OFF)//Off인 경우
            {
                ServoOn.Background = Brushes.Yellow;//Servo ON/OFF 상태 확인을 위한 색 변경

                ServoOnOff = ON;//On으로 변경
                CAXM.AxmSignalServoOn(m_lAxisNo, ServoOnOff);// Servo On 상태로 변경
            }
            else//On인 경우
            {
                ServoOn.Background = Brushes.LightGray;
                ServoOnOff = OFF;//Off으로 변경
                CAXM.AxmSignalServoOn(m_lAxisNo, ServoOnOff);// Servo Off 상태로 변경
            }
        }


        public void UpdateState()
        {
            Axiscbo.SelectedIndex = m_lAxisNo;


        }

        private void TmDisplay_Tick(object sender, EventArgs e)//확인
        {//타이머를 이용, 실시간 좌표 정보를 Position Monitor에 반환
            double dCmdPos = 0.0;
            double dCmdVel = 0.0;
            double dActPos = 0.0;

            //++ 지정한 축의 지령(Command)위치를 반환합니다.
            CAXM.AxmStatusGetCmdPos(m_lAxisNo, ref dCmdPos);
            //++ 지정한 축의 실제(Act)위치를 반환합니다.
            CAXM.AxmStatusGetActPos(m_lAxisNo, ref dActPos);
            //++ 지정한 축의 구동 속도를 반환합니다.
            CAXM.AxmStatusReadVel(m_lAxisNo, ref dCmdVel);

            ComPosVal.Text = string.Format("{0:0.000}", dCmdPos);
            ActPosVal.Text = string.Format("{0:0.000}", dActPos);
            ComVelVal.Text = string.Format("{0:0.000}", dCmdVel);
        }

        private void cboSelAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_lAxisNo = Axiscbo.SelectedIndex;
            //++ 지정한 축번호의 모듈ID를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);
            //UpdateState();      // 변경한 축의 상태와 Control들의 상태를 일치시킵니다.
        }

        private void JogPlus_MouseDown(object sender, RoutedEventArgs e)//확인
        {

            uint duRetCode = 0;
            double dVelocity = Math.Abs(Convert.ToDouble(VelVal.Text));
            double dAccel = Math.Abs(Convert.ToDouble(AccVal.Text));
            double dDecel = Math.Abs(Convert.ToDouble(DecVal.Text));

            //++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 구동
            duRetCode = CAXM.AxmMoveVel(m_lAxisNo, dVelocity, dAccel, dDecel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveVel return error[Code:{0:d}]", duRetCode));
        }

        private void JogPlus_MouseUp(object sender, MouseEventArgs e)//확인
        {
            //++ 지정한 축의 Jog구동(모션구동)을 종료 
            CAXM.AxmMoveSStop(m_lAxisNo);

        }

        private void JogMinus_MouseDown(object sender, RoutedEventArgs e)//확인 
        {
            uint duRetCode = 0;

            //입력된 속도/가속도/감속도 값을 수치로 변환하여 저장
            double dVelocity = Math.Abs(Convert.ToDouble(VelVal.Text));
            double dAccel = Math.Abs(Convert.ToDouble(AccVal.Text));
            double dDecel = Math.Abs(Convert.ToDouble(DecVal.Text));

            //++ 지정한 축을 (-)방향으로 지정한 속도/가속도/감속도로 구동
            duRetCode = CAXM.AxmMoveVel(m_lAxisNo, -dVelocity, dAccel, dDecel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveVel return error[Code:{0:d}]", duRetCode));
        }

        private void JogMinus_MouseUp(object sender, MouseEventArgs e)
        {
            //++ 지정한 축의 Jog구동(모션구동)을 종료 
            CAXM.AxmMoveSStop(m_lAxisNo);

        }

        private bool IsNumeric(string source)//숫자입력 함수
        {
            Regex regex = new Regex("[^0-9.-]+"); return !regex.IsMatch(source);
        }

        private void FileLoad_Click(object sender, RoutedEventArgs e)//mot 파일 불러오기
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            {
                ofdlg.InitialDirectory = @"C:\driver";   // 기본 폴더
                ofdlg.Filter = "Mot Files(*.mot)|*.mot|All files (*.*)|*.*";
                ofdlg.CheckFileExists = true;   // 파일 존재여부확인
                ofdlg.CheckPathExists = true;   // 폴더 존재여부확인
                // 파일 열기 (값의 유무 확인)
                if (ofdlg.ShowDialog().GetValueOrDefault())
                {
                    FilePath.Text = ofdlg.FileName;
                    String szFilePath = ofdlg.FileName;

                    if (CAXM.AxmMotLoadParaAll(szFilePath) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)//mot파일 호출 실패
                        MessageBox.Show("Mot File Not Found.");
                }
            }

        }

        private void HomeSearch_Click(object sender, RoutedEventArgs e)
        {
            MoveAxis.Window1 HomeSearch = new MoveAxis.Window1();
            HomeSearch.ShowDialog();
        }

        private void MoveStop_Click(object sender, RoutedEventArgs e)
        {
            //++ 지정한 축의 구동을 정지합니다.

            CAXM.AxmMoveSStop(MainWindow.m_lAxisNo);
        }

        private void Repeat_Click(object sender, RoutedEventArgs e)
        {
              if ((m_hTestThread[m_lAxisNo] == null) && (m_bTestActive[m_lAxisNo] == false))
                    {
                        // Thread Setting
                        m_hTestThread[m_lAxisNo] = new Thread(new ParameterizedThreadStart(RepeatThread));
                        m_hTestThread[m_lAxisNo].IsBackground = true;
                        m_hTestThread[m_lAxisNo].Start();
                        m_bTestActive[m_lAxisNo] = true;
                    }
                    else
                    {
                        MessageBox.Show("Already Moving");
                    }
     
      
        }
        


        private void RepeatThread(Object ObjData)
        {

           Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { 
          //메인 쓰레드가 객체를 가지고 있기 때문에 접근 불가 ->Dispatcher.invoke를 이용해 접근 
            uint uBusyStatus = 0;

            double dCurPos = 0.0;
            uint uMode = 0;
            int nAxis = m_lAxisNo;
            double dPosition = Convert.ToDouble(PosVal.Text);
            double dVelocity = Convert.ToDouble(VelVal.Text);
            double dAccel = Math.Abs(Convert.ToDouble(AccVal.Text));
            double dDecel = Math.Abs(Convert.ToDouble(DecVal.Text));
            
            CAXM.AxmStatusGetCmdPos(nAxis, ref dCurPos);
            CAXM.AxmMotGetAbsRelMode(nAxis, ref uMode);
            

            while (m_formMotion.m_bTestActive[nAxis] == true)
            {
                CAXM.AxmMoveStartPos(nAxis, dPosition, dVelocity, dAccel, dDecel);//지정축의 설정 위치까지 설정 속도/가속율로 구동
                do
                {
                    CAXM.AxmStatusReadInMotion(nAxis, ref uBusyStatus);
                    Thread.Sleep(1);
                } while ((m_formMotion.m_bTestActive[nAxis] == true) && (uBusyStatus != 0));

                if (m_formMotion.m_bTestActive[nAxis] == false) break;

                if (uMode == (uint)AXT_MOTION_ABSREL.POS_ABS_MODE)
                {
                    if (dCurPos == dPosition) break;
                    CAXM.AxmMoveStartPos(nAxis, dCurPos, dVelocity, dAccel, dDecel);
                }
                else
                {
                    if (0 == dPosition) break;
                    CAXM.AxmMoveStartPos(nAxis, -dPosition, dVelocity, dAccel, dDecel);
                }
                do
                {
                    CAXM.AxmStatusReadInMotion(nAxis, ref uBusyStatus);
                    Thread.Sleep(1);
                } while ((m_formMotion.m_bTestActive[nAxis] == true) && (uBusyStatus != 0));
            }
            m_formMotion.m_bTestActive[nAxis] = false;
            m_formMotion.m_hTestThread[nAxis] = null;
              
            }));
        }

    

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }

    }

}


