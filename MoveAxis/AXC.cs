/****************************************************************************
*****************************************************************************
**
** File Name
** ----------
**
** AXC.CS
**
** COPYRIGHT (c) AJINEXTEK Co., LTD
**
*****************************************************************************
*****************************************************************************
**
** Description
** -----------
** Ajinextek Counter Library Header File
** 
**
*****************************************************************************
*****************************************************************************
**
** Source Change Indices
** ---------------------
** 
** (None)
**
**
*****************************************************************************
*****************************************************************************
**
** Website
** ---------------------
**
** http://www.ajinextek.com
**
*****************************************************************************
*****************************************************************************
*/

using System;
using System.Runtime.InteropServices;

public class CAXC
{
//========== ���� �� ��� ���� 
    // CNT ����� �ִ��� Ȯ��
    [DllImport("AXL.dll")] public static extern uint AxcInfoIsCNTModule(ref uint upStatus);
    
    // CNT ��� No Ȯ��
    [DllImport("AXL.dll")] public static extern uint AxcInfoGetModuleNo(int lBoardNo, int lModulePos, ref int lpModuleNo);
    
    // CNT ����� ����� ���� Ȯ��
    [DllImport("AXL.dll")] public static extern uint AxcInfoGetModuleCount(ref int lpModuleCount);

    // ������ ����� ī���� �Է� ä�� ���� Ȯ��
    [DllImport("AXL.dll")] public static extern uint AxcInfoGetChannelCount(int lModuleNo, ref int lpCount);
    
    // �ý��ۿ� ������ ī������ �� ä�� ���� Ȯ��
    [DllImport("AXL.dll")] public static extern uint AxcInfoGetTotalChannelCount(ref int lpChannelCount);    

    // ������ ��� ��ȣ�� ���̽� ���� ��ȣ, ��� ��ġ, ��� ID Ȯ��
    [DllImport("AXL.dll")] public static extern uint AxcInfoGetModule(int lModuleNo, ref int lpBoardNo, ref int lpModulePos, ref uint upModuleID);

    // �ش� ����� ��� ������ �������� ��ȯ�Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcInfoGetModuleStatus(int lModuleNo);

    [DllImport("AXL.dll")] public static extern uint AxcInfoGetFirstChannelNoOfModuleNo(int lModuleNo, ref int lpChannelNo);

    // ī���� ����� Encoder �Է� ����� ���� �մϴ�.
    // dwMethod --> 0x00 : Sign and pulse, x1 multiplication
    // dwMethod --> 0x01 : Phase-A and phase-B pulses, x1 multiplication
    // dwMethod --> 0x02 : Phase-A and phase-B pulses, x2 multiplication
    // dwMethod --> 0x03 : Phase-A and phase-B pulses, x4 multiplication
    // dwMethod --> 0x08 : Sign and pulse, x2 multiplication
    // dwMethod --> 0x09 : Increment and decrement pulses, x1 multiplication
    // dwMethod --> 0x0A : Increment and decrement pulses, x2 multiplication
    // SIO-CN2CH�� ���
    // dwMethod --> 0x00 : Up/Down ���, A phase : �޽�, B phase : ����
    // dwMethod --> 0x01 : Phase-A and phase-B pulses, x1 multiplication
    // dwMethod --> 0x02 : Phase-A and phase-B pulses, x2 multiplication
    // dwMethod --> 0x03 : Phase-A and phase-B pulses, x4 multiplication
    [DllImport("AXL.dll")] public static extern uint AxcSignalSetEncInputMethod(int lChannelNo, uint dwMethod);

    // ī���� ����� Encoder �Է� ����� ���� �մϴ�.
    // *dwpUpMethod --> 0x00 : Sign and pulse, x1 multiplication
    // *dwpUpMethod --> 0x01 : Phase-A and phase-B pulses, x1 multiplication
    // *dwpUpMethod --> 0x02 : Phase-A and phase-B pulses, x2 multiplication
    // *dwpUpMethod --> 0x03 : Phase-A and phase-B pulses, x4 multiplication
    // *dwpUpMethod --> 0x08 : Sign and pulse, x2 multiplication
    // *dwpUpMethod --> 0x09 : Increment and decrement pulses, x1 multiplication
    // *dwpUpMethod --> 0x0A : Increment and decrement pulses, x2 multiplication
    // SIO-CN2CH�� ���
    // dwMethod --> 0x00 : Up/Down ���, A phase : �޽�, B phase : ����
    // dwMethod --> 0x01 : Phase-A and phase-B pulses, x1 multiplication
    // dwMethod --> 0x02 : Phase-A and phase-B pulses, x2 multiplication
    // dwMethod --> 0x03 : Phase-A and phase-B pulses, x4 multiplication
    [DllImport("AXL.dll")] public static extern uint AxcSignalGetEncInputMethod(int lChannelNo, ref uint dwpUpMethod);

    // ī���� ����� Ʈ���Ÿ� ���� �մϴ�.
    // dwMode -->  0x00 : Latch
    // dwMode -->  0x01 : State
    // dwMode -->  0x02 : Special State    --> SIO-CN2CH ����
    // SIO-CN2CH�� ���
    // dwMode -->  0x00 : ���� ��ġ Ʈ���� �Ǵ� �ֱ� ��ġ Ʈ����.
    // ���� : ��ǰ���� ����� ���� �ٸ��� ������ �����Ͽ� ��� �ʿ�.
    // dwMode -->  0x01 : �ð� �ֱ� Ʈ����(AxcTriggerSetFreq�� ����)
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetFunction(int lChannelNo, uint dwMode);

    // ī���� ����� Ʈ���� ������ Ȯ�� �մϴ�.
    // *dwMode -->  0x00 : Latch
    // *dwMode -->  0x01 : State
    // *dwMode -->  0x02 : Special State
    // dwMode -->  0x00 : ���� ��ġ Ʈ���� �Ǵ� �ֱ� ��ġ Ʈ����.
    // ���� : ��ǰ���� ����� ���� �ٸ��� ������ �����Ͽ� ��� �ʿ�.
    // dwMode -->  0x01 : �ð� �ֱ� Ʈ����(AxcTriggerSetFreq�� ����)
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetFunction(int lChannelNo, ref uint dwpMode);

    // dwUsage --> 0x00 : Trigger Not use
    // dwUsage --> 0x01 : Trigger use
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetNotchEnable(int lChannelNo, uint dwUsage);

    // *dwUsage --> 0x00 : Trigger Not use
    // *dwUsage --> 0x01 : Trigger use
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetNotchEnable(int lChannelNo, ref uint dwpUsage);
    

    // ī���� ����� Captuer �ؼ��� ���� �մϴ�.(External latch input polarity)
    // dwCapturePol --> 0x00 : Signal OFF -> ON
    // dwCapturePol --> 0x01 : Signal ON -> OFF
    [DllImport("AXL.dll")] public static extern uint AxcSignalSetCaptureFunction(int lChannelNo, uint dwCapturePol);

    // ī���� ����� Captuer �ؼ� ������ Ȯ�� �մϴ�.(External latch input polarity)
    // *dwCapturePol --> 0x00 : Signal OFF -> ON
    // *dwCapturePol --> 0x01 : Signal ON -> OFF
    [DllImport("AXL.dll")] public static extern uint AxcSignalGetCaptureFunction(int lChannelNo, ref uint dwpCapturePol);

    // ī���� ����� Captuer ��ġ�� Ȯ�� �մϴ�.(External latch)
    // *dbpCapturePos --> Capture position ��ġ
    [DllImport("AXL.dll")] public static extern uint AxcSignalGetCapturePos(int lChannelNo, ref double dbpCapturePos);

    // ī���� ����� ī���� ���� Ȯ�� �մϴ�.
    // *dbpActPos --> ī���� ��
    [DllImport("AXL.dll")] public static extern uint AxcStatusGetActPos(int lChannelNo, ref double dbpActPos);

    // ī���� ����� ī���� ���� dbActPos ������ ���� �մϴ�.
    [DllImport("AXL.dll")] public static extern uint AxcStatusSetActPos(int lChannelNo, double dbActPos);

    // ī���� ����� Ʈ���� ��ġ�� �����մϴ�.
    // ī���� ����� Ʈ���� ��ġ�� 2�������� ���� �� �� �ֽ��ϴ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetNotchPos(int lChannelNo, double dbLowerPos, double dbUpperPos);

    // ī���� ����� ������ Ʈ���� ��ġ�� Ȯ�� �մϴ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetNotchPos(int lChannelNo, ref double dbpLowerPos, ref double dbpUpperPos);

    // ī���� ����� Ʈ���� ����� ������ �մϴ�.
    // dwOutVal --> 0x00 : Ʈ���� ��� '0'
    // dwOutVal --> 0x01 : Ʈ���� ��� '1'
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetOutput(int lChannelNo, uint dwOutVal);

    // ī���� ����� ���¸� Ȯ���մϴ�.
    // Bit '0' : Carry (ī���� ����ġ�� ���� �޽��� ���� ī���� ����ġ�� �Ѿ� 0�� �ٲ���� �� 1��ĵ�� ON���� �մϴ�.)
    // Bit '1' : Borrow (ī���� ����ġ�� ���� �޽��� ���� 0�� �Ѿ� ī���� ����ġ�� �ٲ���� �� 1��ĵ�� ON���� �մϴ�.)
    // Bit '2' : Trigger output status
    // Bit '3' : Latch input status
    [DllImport("AXL.dll")] public static extern uint AxcStatusGetChannel(int lChannelNo, ref uint dwpChannelStatus);


    // SIO-CN2CH ���� �Լ���
    //
    // ī���� ����� ��ġ ������ �����Ѵ�.
    // ���� ��ġ �̵����� ���� �޽� ������ �����ϴµ�,
    // ex) 1mm �̵��� 1000�� �ʿ��ϴٸ�dMoveUnitPerPulse = 0.001�� �Է��ϰ�,
    //     ���� ��� �Լ��� ��ġ�� ���õ� ���� mm ������ �����ϸ� �ȴ�.
    [DllImport("AXL.dll")] public static extern uint AxcMotSetMoveUnitPerPulse(int lChannelNo, double dMoveUnitPerPulse);

    // ī���� ����� ��ġ ������ Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcMotGetMoveUnitPerPulse(int lChannelNo, ref double dpMoveUnitPerPuls);

    // ī���� ����� ���ڴ� �Է� ī���͸� ���� ����� �����Ѵ�.
    // dwReverse --> 0x00 : �������� ����.
    // dwReverse --> 0x01 : ����.
    [DllImport("AXL.dll")] public static extern uint AxcSignalSetEncReverse(int lChannelNo, uint dwReverse);

    // ī���� ����� ���ڴ� �Է� ī���͸� ���� ����� ������ Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcSignalGetEncReverse(int lChannelNo, ref uint dwpReverse);

    // ī���� ����� Encoder �Է� ��ȣ�� �����Ѵ�.
    // dwSource -->  0x00 : 2(A/B)-Phase ��ȣ.
    // dwSource -->  0x01 : Z-Phase ��ȣ.(���⼺ ����.)
    [DllImport("AXL.dll")] public static extern uint AxcSignalSetEncSource(int lChannelNo, uint dwSource);

    // ī���� ����� Encoder �Է� ��ȣ ���� ������ Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcSignalGetEncSource(int lChannelNo, ref uint dwpSource);

    // ī���� ����� Ʈ���� ��� ���� �� ���� ���� �����Ѵ�.
    // ��ġ �ֱ� Ʈ���� ��ǰ�� ��� ��ġ �ֱ�� Ʈ���� ����� �߻���ų ���� �� ���� ���� �����Ѵ�.
    // ���� ��ġ Ʈ���� ��ǰ�� ��� Ram ���� ������ Ʈ���� ������ ���� ���� ��ġ�� �����Ѵ�.
    // ���� : AxcMotSetMoveUnitPerPulse�� ������ ����.
    // Note : ���Ѱ��� ���Ѱ����� �������� �����Ͽ��� �մϴ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetBlockLowerPos(int lChannelNo, double dLowerPosition);

    // ī���� ����� Ʈ���� ��� ���� �� ���� ���� Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetBlockLowerPos(int lChannelNo, ref double dpLowerPosition);

    // ī���� ����� Ʈ���� ��� ���� �� ���� ���� �����Ѵ�.
    // ��ġ �ֱ� Ʈ���� ��ǰ�� ��� ��ġ �ֱ�� Ʈ���� ����� �߻���ų ���� �� ���� ���� �����Ѵ�.
    // ���� ��ġ Ʈ���� ��ǰ�� ��� Ʈ���� ������ ������ Ram �� ������ ������ Ʈ���� ������ ����Ǵ� ��ġ�� ���ȴ�.
    // ���� : AxcMotSetMoveUnitPerPulse�� ������ ����.
    // Note : ���Ѱ��� ���Ѱ����� ū���� �����Ͽ��� �մϴ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetBlockUpperPos(int lChannelNo, double dUpperPosition);
    // ī���� ����� Ʈ���� ��� ���� �� ���� ���� �����Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetBlockUpperPos(int lChannelNo, ref double dpUpperrPosition);

    // ī���� ����� ��ġ �ֱ� ��� Ʈ���ſ� ���Ǵ� ��ġ �ֱ⸦ �����Ѵ�.
    // ���� : AxcMotSetMoveUnitPerPulse�� ������ ����.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetPosPeriod(int lChannelNo, double dPeriod);

    // ī���� ����� ��ġ �ֱ� ��� Ʈ���ſ� ���Ǵ� ��ġ �ֱ⸦ Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetPosPeriod(int lChannelNo, ref double dpPeriod);

    // ī���� ����� ��ġ �ֱ� ��� Ʈ���� ���� ��ġ ������ ���� ��ȿ����� �����Ѵ�.
    // dwDirection -->  0x00 : ī������ ��/���� ���Ͽ� Ʈ���� �ֱ� ���� ���.
    // dwDirection -->  0x01 : ī���Ͱ� ���� �Ҷ��� Ʈ���� �ֱ� ���� ���.
    // dwDirection -->  0x01 : ī���Ͱ� ���� �Ҷ��� Ʈ���� �ֱ� ���� ���.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetDirectionCheck(int lChannelNo, uint dwDirection);
    // ī���� ����� ��ġ �ֱ� ��� Ʈ���� ���� ��ġ ������ ���� ��ȿ��� ������ Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetDirectionCheck(int lChannelNo, ref uint dwpDirection);

    // ī���� ����� ��ġ �ֱ� ��� Ʈ���� ����� ����, ��ġ �ֱ⸦ �ѹ��� �����Ѵ�.
    // ��ġ ���� ���� :  AxcMotSetMoveUnitPerPulse�� ������ ����.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetBlock(int lChannelNo, double dLower, double dUpper, double dABSod);

    // ī���� ����� ��ġ �ֱ� ��� Ʈ���� ����� ����, ��ġ �ֱ⸦ ������ �ѹ��� Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetBlock(int lChannelNo, ref double dpLower, ref double dpUpper, ref double dpABSod);

    // ī���� ����� Ʈ���� ��� �޽� ���� �����Ѵ�.
    // ���� : uSec
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetTime(int lChannelNo, double dTrigTime);

    // ī���� ����� Ʈ���� ��� �޽� �� ������ Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetTime(int lChannelNo, ref double dpTrigTime);

    // ī���� ����� Ʈ���� ��� �޽��� ��� ������ �����Ѵ�.
    // dwLevel -->  0x00 : Ʈ���� ��½� 'Low' ���� ���.
    // dwLevel -->  0x00 : Ʈ���� ��½� 'High' ���� ���.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetLevel(int lChannelNo, uint dwLevel);
    // ī���� ����� Ʈ���� ��� �޽��� ��� ���� ������ Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetLevel(int lChannelNo, ref uint dwpLevel);

    // ī���� ����� ���ļ� Ʈ���� ��� ��ɿ� �ʿ��� ���ļ��� �����Ѵ�.
    // ���� : Hz, ���� : 1Hz ~ 500 kHz
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetFreq(int lChannelNo, uint dwFreqency);
    // ī���� ����� ���ļ� Ʈ���� ��� ��ɿ� �ʿ��� ���ļ��� ������ Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetFreq(int lChannelNo, ref uint dwpFreqency);	

    // ī���� ����� ���� ä�ο� ���� ���� ��� ���� �����Ѵ�.
    // dwOutput ���� : 0x00 ~ 0x0F, �� ä�δ� 4���� ���� ���
    [DllImport("AXL.dll")] public static extern uint AxcSignalWriteOutput(int lChannelNo, uint dwOutput);

    // ī���� ����� ���� ä�ο� ���� ���� ��� ���� Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcSignalReadOutput(int lChannelNo, ref uint dwpOutput);

    // ī���� ����� ���� ä�ο� ���� ���� ��� ���� ��Ʈ ���� �����Ѵ�.
    // lBitNo ���� : 0 ~ 3, �� ä�δ� 4���� ���� ���
    [DllImport("AXL.dll")] public static extern uint AxcSignalWriteOutputBit(int lChannelNo, int lBitNo, uint uOnOff);
    // ī���� ����� ���� ä�ο� ���� ���� ��� ���� ��Ʈ ���� Ȯ�� �Ѵ�.
    // lBitNo ���� : 0 ~ 3
    [DllImport("AXL.dll")] public static extern uint AxcSignalReadOutputBit(int lChannelNo, int lBitNo, ref uint upOnOff);

    // ī���� ����� ���� ä�ο� ���� ���� �Է� ���� Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcSignalReadInput(int lChannelNo, ref uint dwpInput);

    // ī���� ����� ���� ä�ο� ���� ���� �Է� ���� ��Ʈ ���� Ȯ�� �Ѵ�.
    // lBitNo ���� : 0 ~ 3
    [DllImport("AXL.dll")] public static extern uint AxcSignalReadInputBit(int lChannelNo, int lBitNo, ref uint upOnOff);

    // ī���� ����� Ʈ���� ����� Ȱ��ȭ �Ѵ�.
    // ���� ������ ��ɿ� ���� Ʈ���� ����� ���������� ����� ������ �����Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetEnable(int lChannelNo, uint dwUsage);

    // ī���� ����� Ʈ���� ��� Ȱ��ȭ ���� ������ Ȯ���ϴ�.
    [DllImport("AXL.dll")] public static extern uint AxcTriggerGetEnable(int lChannelNo, ref uint dwpUsage);

    // ī���� ����� ������ġ Ʈ���� ����� ���� ������ RAM ������ Ȯ���Ѵ�.
    // dwAddr ���� : 0x0000 ~ 0x1FFFF;
    [DllImport("AXL.dll")] public static extern uint AxcTriggerReadAbsRamData(int lChannelNo, uint dwAddr, ref uint dwpData);

    // ī���� ����� ������ġ Ʈ���� ����� ���� �ʿ��� RAM ������ �����Ѵ�.
    // dwAddr ���� : 0x0000 ~ 0x1FFFF;
    [DllImport("AXL.dll")] public static extern uint AxcTriggerWriteAbsRamData(int lChannelNo, uint dwAddr, uint dwData);

	// ���� CNT ä���� ���� ��ġ Ʈ���� ����� ���� DWORD�� ��ġ ������ �����Ѵ�.
	//----------------------------------------------------------------------------------------------------------------------------------
	// 1. AXT_SIO_CN2CH�� ���
	// dwTrigNum	--> 131072(=0x20000) ������ ���� ����
	// dwTrigPos	--> DWORD�� Data �Է� ����
	// dwDirection	--> 0x0(default) : dwTrigPos[0], dwTrigPos[1] ..., dwTrigPos[dwTrigNum - 1] ������ Data�� Write �Ѵ�.
	//					0x1			 : dwTrigPos[dwTrigNum - 1], dwTrigPos[dwTrigNum - 2], ..., dwTrigPos[0] ������ Data�� Write �Ѵ�.
	// *����* 1) dwDirection: Data Write ������ �ٸ� �� ��ɻ��� ���� ����
	//		  2) AXC Manual�� AxcTriggerSetAbs - Description�� �����Ͽ� data�� ���� �� ����ؾ� ��
	//----------------------------------------------------------------------------------------------------------------------------------
	// 2. AXT_SIO_HPC4�� ���
	// dwTrigNum	--> 500 ������ ���� ����
	// dwTrigPos	--> DWORD�� Data �Է� ����
	// dwDirection	--> 0x0(default) : ������ �ʴ� ������, �Է����� �ʾƵ� �ȴ�.
	//----------------------------------------------------------------------------------------------------------------------------------
	// 3. AXT_SIO_RCNT2RTEX, AXT_SIO_RCNT2MLIII, AXT_SIO_RCNT2SIIIH, AXT_SIO_RCNT2SIIIH_R�� ���
	// dwTrigNum	--> 0x200(=512) ������ ���� ����
	// dwTrigPos	--> DWORD�� data �Է� ����
	// dwDirection	--> 0x0(default) : ������ �ʴ� ������, �Է����� �ʾƵ� �ȴ�.
	//----------------------------------------------------------------------------------------------------------------------------------
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetAbs(int lChannelNo, uint dwTrigNum, ref uint dwTrigPos, uint dwDirection = 0);

	// ���� CNT ä���� ���� ��ġ Ʈ���� ����� ���� double�� ��ġ ������ �����Ѵ�.
	//----------------------------------------------------------------------------------------------------------------------------------
	// 1. AXT_SIO_CN2CH�� ���
	// dwTrigNum	--> 4194304(=0x20000*32) ������ ���� ����
	// dTrigPos		--> double�� data �Է� ����
	// dwDirection	--> 0x0(default) : dTrigPos[0], dTrigPos[1] ..., dTrigPos[dwTrigNum - 1] ������ Data�� Write �Ѵ�.
	//					0x1			 : dTrigPos[dwTrigNum - 1], dTrigPos[dwTrigNum - 2], ..., dTrigPos[0] ������ Data�� Write �Ѵ�.
	// *����* 1) dwDirection: Data Write ������ �ٸ� �� ��ɻ��� ���� ����
	//----------------------------------------------------------------------------------------------------------------------------------
	// 2. AXT_SIO_RCNT2RTEX, AXT_SIO_RCNT2MLIII, AXT_SIO_RCNT2SIIIH_R�� ���
	// dwTrigNum	--> 0x200(=512) ������ ���� ����
	// dTrigPos		--> double�� data �Է� ����
	// dwDirection	--> 0x0(default) : ������ �ʴ� ������, �Է����� �ʾƵ� �ȴ�.
	//----------------------------------------------------------------------------------------------------------------------------------
    [DllImport("AXL.dll")] public static extern uint AxcTriggerSetAbsDouble(int lChannelNo, uint dwTrigNum, ref double dTrigPos, uint dwDirection = 0);


	////////////////// LCM4_10_Version/////////////////////////////////////////////////////////////
	// ī���� ����� PWM ����� Ȱ��ȭ�Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTriggerSetPwmEnable(int lChannelNo, bool bEnable);
	// ī���� ����� PWM ��� Ȱ��ȭ ���¸� Ȯ���Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTriggerGetPwmEnable(int lChannelNo, ref bool bEnable);
	// ī���� ����� PWM ��¸�带 �����Ѵ�.
	// dwMode : PWM ��¸��
	// [0] : Manual (Manual�� ������ PWM Data)
	// [1] : Auto (�ӵ� Table)
	[DllImport("AXL.dll")] public static extern uint AxcTriggerSetPwmOutMode(int lChannelNo, uint dwMode); 
	// ī���� ����� PWM ��¸�带 Ȯ���Ѵ�.
	// dwMode : PWM ��¸��
	// [0] : Manual (Manual�� ������ PWM Data)
	// [1] : Auto (�ӵ� Table)
	[DllImport("AXL.dll")] public static extern uint AxcTriggerGetPwmOutMode(int lChannelNo, ref uint dwpMode);	
	// ī���� ����� PWM ��� ������ �ִ� �ӵ��� �����Ѵ�.
	// dMaxVel : PWM ��� �ִ�ӵ��� �����Ѵ�. 5000 table base �� ��쿡 ��ȿ�ϸ� ������ dMaxvel �������� �ӵ������� ����������. 
	// ������ : 
	// �ӵ������� 5000���� ������ ���� dMaxVel �� 5000�� ��������� �����Ǿ�� �Ѵ�. (5000 ~ 100000) ���� ���� �����ϴ�.
	[DllImport("AXL.dll")] public static extern uint AxcTriggerSetPwmMaxVel(int lChannelNo, double dMaxVel);
	// ī���� ����� PWM ��� ������ �ִ� �ӵ��� Ȯ���Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTriggerGetPwmMaxVel(int lChannelNo, ref uint dpMaxVel);
	// ī���� ����� �� ���̺� 2-D ����ӵ����� PWM ��ȣ�� ����ϱ� ���� �ʿ��� ������ �����Ѵ�.
	// pwm ��¸�尡 Manual �� ��쿡�� ��ȿ�ϴ�.
	[DllImport("AXL.dll")] public static extern uint AxcTriggerSetPwmManualData(int lChannelNo,uint dwFrequency, double dDutyRatio);
	// ī���� ����� �� ���̺� 2-D ����ӵ����� PWM ��ȣ�� ����ϱ� ���� �ʿ��� ������ Ȯ���Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTriggerGetPwmManualData(int lChannelNo,ref uint dwpFrequency, ref double dpDutyRatio);
	// ī���� ����� �ӵ� Table mode �� �����Ѵ�.
	// dwOperationMode : �ӵ� Table mode
	// [0] == 5000 table mode
	// [1] == 1000 table mode
	[DllImport("AXL.dll")] public static extern uint AxcTriggerSetPwmOperationMode(int lChannelNo, uint dwOperationMode);
	// ī���� ����� �ӵ� Table mode �� Ȯ���Ѵ�.
	// dwpOperationMode : �ӵ� Table mode
	// [0] == 5000 table mode
	// [1] == 1000 table mode
	[DllImport("AXL.dll")] public static extern uint AxcTriggerGetPwmOperationMode(int lChannelNo, ref uint dwpOperationMode);
	// ī���� ����� �� ���̺� 2-D ����ӵ����� PWM ��ȣ�� ����ϱ� ���� �ʿ��� ������ �����Ѵ�.
	// lDataCnt : ���� �� Ʈ���� ������ ��ü ����
	// dpVel : dpVel[0],dpVel[1]....dpVel[DataCnt-2] ������ �Է� ����
	// dwpFrequency : dwpFrequency[0],dwpFrequency[1]....dwpFrequency[DataCnt-2] ������ �Է� ����
	// dwpDutyRatio : dwpDutyRatio[0],dwpDutyRatio[1]....dwpDutyRatio[DataCnt-2] ������ �Է� ����
	// ������ : 
	//    1) dpVel, dwpFrequency, dwpDutyRatio �� �迭 ������ �����Ͽ� ����ؾ��Ѵ�. ���ο��� ���Ǵ� ���� ���� ���� �迭�� �����ϸ� �޸� ���� ������ �߻� �� �� ����.
	//    2) dpVel �� ���� �ӵ� Table �� �ش��ϴ� ������ �����Ѵ�.
	//		- �ӵ� Table mode �� 1000 table base �� ���� LCM4 velocity table ������ �����Ѵ�.
	//		- �ӵ� Table mode �� 5000 table base �� ���� (MaxVelocity /5000) ���� ���Ǿ� 5000���� �ӵ� ������ ������. ������ �´� �ӵ����� �Է��ؾ��Ѵ�.
	//		- �ӵ��� 0�� ���������� PWM ����� �Ұ��ϴ�.
	//    3) PWM Enable ���¿����� ����� �� ����.
	[DllImport("AXL.dll")] public static extern uint AxcTriggerSetPwmPatternData(int lChannelNo, int lDataCnt,  ref double[] dpVel, ref uint[] dwpFrequency, ref double[] dpDutyRatio);
	// ī���� ����� �� ���̺� 2-D ����ӵ����� PWM ��ȣ�� ����ϱ� ���� �ʿ��� ������ �����Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTriggerSetPwmData(int lChannelNo, double dVel, uint dwFrequency, double dDutyRatio);
	// ī���� ����� �� ���̺� 2-D ����ӵ����� PWM ��ȣ�� ����ϱ� ���� �ʿ��� ������ Ȯ���Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTriggerGetPwmData(int lChannelNo, double dVel, ref uint dwpFrequency, ref double dpDutyRatio);
	// ī���� ����� �ӵ� ���� Ȯ�� �մϴ�.
	[DllImport("AXL.dll")] public static extern uint AxcStatusReadActVel(int lChannelNo, ref double dpActVel);
	// ī���� ����� 2D �ӵ� ���� Ȯ�� �մϴ�.
	[DllImport("AXL.dll")] public static extern uint AxcStatusRead2DActVel(int lChannelNo, ref double dpActVel);
	// ī���� ����� Position ���� �ʱ�ȭ �Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcStatusSetActPosClear(int lChannelNo);
    ////////////////// HPC4_30_Version
	// ī���� ����� �� ���̺� �Ҵ�� Ʈ���� ����� ������ �����Ѵ�.
	// uLevel : Ʈ���� ��� ��ȣ�� Active Level
	//   [0]  : Ʈ���� ��½� 'Low' ���� ���.
	//   [1]  : Ʈ���� ��½� 'High' ���� ���.
    [DllImport("AXL.dll")] public static extern uint AxcTableSetTriggerLevel(int lModuleNo, int lTablePos, uint uLevel);
	// ī���� ����� �� ���̺� ������ Ʈ���� ����� ���� �������� Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTableGetTriggerLevel(int lModuleNo, int lTablePos, ref uint upLevel);

	// ī���� ����� �� ���̺� �Ҵ�� Ʈ���� ����� �޽� ���� �����Ѵ�.
	// dTriggerTimeUSec : [Default 500ms], us������ ����
	[DllImport("AXL.dll")] public static extern uint AxcTableSetTriggerTime(int lModuleNo, int lTablePos, double dTriggerTimeUSec);
	// ī���� ����� �� ���̺� ������ Ʈ���� ����� �޽� �� �������� Ȯ���Ѵ�.
    [DllImport("AXL.dll")] public static extern uint AxcTableGetTriggerTime(int lModuleNo, int lTablePos, ref double dpTriggerTimeUSec);

	// ī���� ����� �� ���̺� �Ҵ� �� 2���� ���ڴ� �Է� ��ȣ�� �����Ѵ�.
	// uEncoderInput1 [0-3]: ī���� ��⿡ �ԷµǴ� 4���� ���ڴ� ��ȣ�� �ϳ�
	// uEncoderInput2 [0-3]: ī���� ��⿡ �ԷµǴ� 4���� ���ڴ� ��ȣ�� �ϳ�
	[DllImport("AXL.dll")] public static extern uint AxcTableSetEncoderInput(int lModuleNo, int lTablePos, uint uEncoderInput1, uint uEncoderInput2);
	// ī���� ����� �� ���̺� �Ҵ� �� 2���� ���ڴ� �Է� ��ȣ�� Ȯ���Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTableGetEncoderInput(int lModuleNo, int lTablePos, ref uint upEncoderInput1, ref uint upEncoderInput2);

	// ī���� ����� �� ���̺� �Ҵ� �� Ʈ���� ��� ��Ʈ�� �����Ѵ�.
	// uTriggerOutport [0x0-0xF]: Bit0: Ʈ���� ��� 0, Bit1: Ʈ���� ��� 1, Bit2: Ʈ���� ��� 2, Bit3: Ʈ���� ��� 3 
	// Ex) 0x3(3)   : ��� 0, 1�� Ʈ���� ��ȣ�� ����ϴ� ���
	//     0xF(255) : ��� 0, 1, 2, 3�� Ʈ���� ��ȣ�� ����ϴ� ���
	[DllImport("AXL.dll")] public static extern uint AxcTableSetTriggerOutport(int lModuleNo, int lTablePos, uint uTriggerOutport);
	// ī���� ����� �� ���̺� �Ҵ� �� Ʈ���� ��� ��Ʈ�� Ȯ���Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTableGetTriggerOutport(int lModuleNo, int lTablePos, ref uint upTriggerOutport);

	// ī���� ����� �� ���̺� ������ Ʈ���� ��ġ�� ���� ��� ���� ������ �����Ѵ�.
	// dErrorRange  : ���� ���� Unit������ Ʈ���� ��ġ�� ���� ��� ���� ������ ����
	[DllImport("AXL.dll")] public static extern uint AxcTableSetErrorRange(int lModuleNo, int lTablePos, double dErrorRange);
	// ī���� ����� �� ���̺� ������ Ʈ���� ��ġ�� ���� ��� ���� ������ Ȯ���Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTableGetErrorRange(int lModuleNo, int lTablePos, ref double dpErrorRange);

	// ī���� ����� �� ���̺� ������ ������(Ʈ���� ��� Port, Ʈ���� �޽� ��) Ʈ���Ÿ� 1�� �߻���Ų��.
	// �� ���� : 1) Ʈ���Ű� Disable�Ǿ� ������ �� �Լ��� �ڵ����� Enable���� Ʈ���Ÿ� �߻���Ŵ 
	//           2) Trigger Mode�� HPC4_PATTERN_TRIGGER ����� ��� �� �Լ��� �ڵ����� Ʈ���� ��带 HPC4_RANGE_TRIGGER�� ���� ��(�ϳ��� Ʈ���Ÿ� �߻���Ű�� ����)
	[DllImport("AXL.dll")] public static extern uint AxcTableTriggerOneShot(int lModuleNo, int lTablePos);

	// ī���� ����� �� ���̺� ������ ������(Ʈ���� ��� Port, Ʈ���� �޽� ��), ������ ������ŭ ������ ���ļ��� Ʈ���Ÿ� �߻���Ų��.
    // lTriggerCount     : ������ ���ļ��� �����ϸ� �߻���ų Ʈ���� ��� ����
	// uTriggerFrequency : Ʈ���Ÿ� �߻���ų ���ļ�	
	// �� ���� : 1) Ʈ���Ű� Disable�Ǿ� ������ �� �Լ��� �ڵ����� Enable���� ������ ���� Ʈ���Ÿ� �߻���Ŵ 
	//           2) Trigger Mode�� HPC4_PATTERN_TRIGGER ��尡 �ƴ� ��� �� �Լ��� �ڵ����� Ʈ���� ��带 HPC4_PATTERN_TRIGGER�� ���� ��
	[DllImport("AXL.dll")] public static extern uint AxcTableTriggerPatternShot(int lModuleNo, int lTablePos, int lTriggerCount, uint uTriggerFrequency);
	// ī���� ����� �� ���̺� ������ ���� Ʈ���� ���� ������(���ļ�, ī����) Ȯ���Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTableGetPatternShotData(int lModuleNo, int lTablePos, ref int lpTriggerCount, ref uint upTriggerFrequency);

	// ī���� ����� �� ���̺� Ʈ���Ÿ� ����ϴ� ����� �����Ѵ�.
	// uTrigMode : Ʈ���Ÿ� ����ϴ� ����� �����Ѵ�.
	//   [0] HPC4_RANGE_TRIGGER   : ������ Ʈ���� ��ġ�� ������ ��� �����ȿ� ��ġ�� �� Ʈ���Ÿ� ����ϴ� ���
	//   [1] HPC4_VECTOR_TRIGGER  : ���� Ʈ���� ��ġ�� ������ ��� ������ ���� ������ ��ġ�� �� Ʈ���Ÿ� ����ϴ� ���
	//   [3] HPC4_PATTERN_TRIGGER : ��ġ�� �����ϰ� ������ ������ŭ ������ ���ļ��� Ʈ���Ÿ� ����ϴ� ���
	[DllImport("AXL.dll")] public static extern uint AxcTableSetTriggerMode(int lModuleNo, int lTablePos, uint uTrigMode);
	// ī���� ����� �� ���̺� ������ Ʈ���Ÿ� ����ϴ� ����� Ȯ���Ѵ�
	[DllImport("AXL.dll")] public static extern uint AxcTableGetTriggerMode(int lModuleNo, int lTablePos, ref uint upTrigMode);		
	// ī���� ����� �� ���̺� ���� ��µ� ���� Ʈ���� ������ �ʱ�ȭ �Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTableSetTriggerCountClear(int lModuleNo, int lTablePos);

	// ī���� ����� �� ���̺� 2-D ������ġ���� Ʈ���� ��ȣ�� ����ϱ� ���� �ʿ��� ������ �����Ѵ�.
	// lTriggerDataCount : ���� �� Ʈ���� ������ ��ü ����
    //   [-1, 0]         : ��ϵ� Ʈ���� ���� ����Ÿ �ʱ�ȭ
	// dpTriggerData     : 2-D ������ġ Ʈ���� ����(�ش� �迭�� ������ lTriggerDataCount * 2�� �Ǿ�ߵ�)
	//   *[0, 1]         : X[0], Y[0] 
	// lpTriggerCount    : �Է��� 2-D ���� Ʈ���� ��ġ���� Ʈ���� ���� ���� �� �߻���ų Ʈ���� ������ �迭�� ����(�ش� �迭�� ������ lTriggerDataCount)
	// dpTriggerInterval : TriggerCount ��ŭ �����ؼ� Ʈ���Ÿ� �߻���ų�� ���� �� ������ ���ļ� ������ ����(�ش� �迭�� ������ lTriggerDataCount)
	// ������ : 
	//    1) �� ���������� �迭 ������ �����Ͽ� ����ؾߵ˴ϴ�. ���ο��� ���Ǵ� ���� ���� ���� �迭�� �����ϸ� �޸� ���� ������ �߻� �� �� ����.
	//    2) Trigger Mode�� HPC4_RANGE_TRIGGER�� �ڵ� �����
	//    3) �Լ� ���ο��� Trigger�� Disable�� �� ��� ������ �����ϸ� �Ϸ� �� �ٽ� Enable ��Ŵ
	[DllImport("AXL.dll")] public static extern uint AxcTableSetTriggerData(int lModuleNo, int lTablePos, int lTriggerDataCount, double[] dpTriggerData, int[] lpTriggerCount, double[] dpTriggerInterval);
	// ī���� ����� �� ���̺� Ʈ���� ��ȣ�� ����ϱ� ���� ������ Ʈ���� ���� ������ Ȯ���Ѵ�.
	// �� ���� : �� ���̺� ��ϵ� �ִ� Ʈ���� ����Ÿ ������ �� ���� �Ʒ��� ���� Ʈ���� ����Ÿ ������ �̸� �ľ��� �� ����Ͻʽÿ�.
	// Ex)      1) AxcTableGetTriggerData(lModuleNo, lTablePos, &lTriggerDataCount, NULL, NULL, NULL);
	//          2) dpTriggerData     = new double[lTriggerDataCount * 2];
	//          3) lpTriggerCount    = new int[lTriggerDataCount];
	//          4) dpTriggerInterval = new double[lTriggerDataCount];  
    [DllImport("AXL.dll")] public static extern uint AxcTableGetTriggerData(int lModuleNo, int lTablePos, ref int lpTriggerDataCount, ref double[] dpTriggerData, ref int[] lpTriggerCount, ref double[] dpTriggerInterval);
	
	// ī���� ����� �� ���̺� 2-D ������ġ���� Ʈ���� ��ȣ�� ����ϱ� ���� �ʿ��� ������ AxcTableSetTriggerData�Լ��� �ٸ� ������� �����Ѵ�.
	// lTriggerDataCount : ���� �� Ʈ���� ������ ��ü ����
	// uOption : dpTriggerData �迭�� ����Ÿ �Է� ����� ���� 
	//   [0]   : dpTriggerData �迭�� X Pos[0], Y Pos[0], X Pos[1], Y Pos[1] ������ �Է�
	//   [1]   : dpTriggerData �迭�� X Pos[0], Y Pos[0], Count, Inteval, X Pos[1], Y Pos[1], Count, Inteval ������ �Է�
	// ������ : 
	//    1) dpTriggerData�� �迭 ������ �����Ͽ� ����ؾߵ˴ϴ�. ���ο��� ���Ǵ� ���� ���� ���� �迭�� �����ϸ� �޸� ���� ������ �߻� �� �� ����.
	//    2) Trigger Mode�� HPC4_RANGE_TRIGGER�� �ڵ� �����
	//    3) �Լ� ���ο��� Trigger�� Disable�� �� ��� ������ �����ϸ� �Ϸ� �� �ٽ� Enable ��Ŵ
    [DllImport("AXL.dll")] public static extern uint AxcTableSetTriggerDataEx(int lModuleNo, int lTablePos, int lTriggerDataCount, uint uOption, ref double dpTriggerData);
	// ī���� ����� �� ���̺� Ʈ���� ��ȣ�� ����ϱ� ���� ������ Ʈ���� ���� ������ Ȯ���Ѵ�.
	// �� ���� : �� ���̺� ��ϵ� �ִ� Ʈ���� ����Ÿ ������ �� ���� �Ʒ��� ���� Ʈ���� ����Ÿ ������ �̸� �ľ��� �� ���.
	// Ex)      1) AxcTableGetTriggerDataEx(lModuleNo, lTablePos, &lTriggerDataCount, &uOption, NULL);
	//          2) if(uOption == 0) : dpTriggerData     = new double[lTriggerDataCount * 2];
	//          3) if(uOption == 1) : dpTriggerData     = new double[lTriggerDataCount * 4];
	//          4) dpTriggerInterval = new double[lTriggerDataCount];  
    [DllImport("AXL.dll")] public static extern uint AxcTableGetTriggerDataEx(int lModuleNo, int lTablePos, ref int lpTriggerDataCount,  ref uint upOption, ref double dpTriggerData);
  
	// ī���� ����� ������ ���̺� ������ ��� Ʈ���� ����Ÿ�� H/W FIFO�� ����Ÿ�� ��� �����Ѵ�.
	[DllImport("AXL.dll")] public static extern uint AxcTableSetTriggerDataClear(int lModuleNo, int lTablePos);

	// ī���� ����� ������ ���̺��� Ʈ���� ��� ����� ���۽�Ŵ.
	// uEnable : Ʈ���Ÿ� ��� ����� ��뿩�θ� ����
	// �� ���� : 1) Ʈ���� ��� �� DISABLE�ϸ� ����� �ٷ� ����
	//           2) AxcTableTriggerOneShot, AxcTableGetPatternShotData,AxcTableSetTriggerData, AxcTableGetTriggerDataEx �Լ� ȣ��� �ڵ����� ENABLE��
	[DllImport("AXL.dll")] public static extern uint AxcTableSetEnable(int lModuleNo, int lTablePos, uint uEnable);
	// ī���� ����� ������ ���̺��� Ʈ���� ��� ����� ���� ���θ� Ȯ����.
	[DllImport("AXL.dll")] public static extern uint AxcTableGetEnable(int lModuleNo, int lTablePos, ref uint upEnable);		

	// ī���� ����� ������ ���̺��� �̿��� �߻��� Ʈ���� ������ Ȯ��.
	// lpTriggerCount : ������� ��µ� Ʈ���� ��� ������ ��ȯ, AxcTableSetTriggerCountClear �Լ��� �ʱ�ȭ
	[DllImport("AXL.dll")] public static extern uint AxcTableReadTriggerCount(int lModuleNo, int lTablePos, ref int lpTriggerCount);	

	// ī���� ����� ������ ���̺� �Ҵ�� H/W Ʈ���� ����Ÿ FIFO�� ���¸� Ȯ��.
	// lpCount1[0~500] : 2D Ʈ���� ��ġ ����Ÿ �� ù��°(X) ��ġ�� �����ϰ� �ִ� H/W FIFO�� �Էµ� ����Ÿ ����
	// upStatus1 : 2D Ʈ���� ��ġ ����Ÿ �� ù��°(X) ��ġ�� �����ϰ� �ִ� H/W FIFO�� ����
	//   [Bit 0] : Data Empty
	//   [Bit 1] : Data Full
	//   [Bit 2] : Data Valid
	// lpCount2[0~500] : 2D Ʈ���� ��ġ ����Ÿ �� �ι�°(Y) ��ġ�� �����ϰ� �ִ� H/W FIFO�� �Էµ� ����Ÿ ����
	// upStatus2 : 2D Ʈ���� ��ġ ����Ÿ �� �ι�°(Y) ��ġ�� �����ϰ� �ִ� H/W FIFO�� ����
	//   [Bit 0] : Data Empty
	//   [Bit 1] : Data Full
	//   [Bit 2] : Data Valid
	[DllImport("AXL.dll")] public static extern uint AxcTableReadFifoStatus(int lModuleNo, int lTablePos, ref int lpCount1, ref uint upStatus1, ref int lpCount2, ref uint upStatus2);

	// ī���� ����� ������ ���̺� �Ҵ�� H/W Ʈ���� ����Ÿ FIFO�� ���� ��ġ ����Ÿ���� Ȯ��.
	// dpTopData1 : 2D H/W Ʈ���� ����Ÿ FIFO�� ���� ����Ÿ �� ù��°(X) ��ġ ����Ÿ�� Ȯ�� �� 
	// dpTopData1 : 2D H/W Ʈ���� ����Ÿ FIFO�� ���� ����Ÿ �� �ι�°(Y) ��ġ ����Ÿ�� Ȯ�� �� 
	[DllImport("AXL.dll")] public static extern uint AxcTableReadFifoData(int lModuleNo, int lTablePos, ref double dpTopData1, ref double dpTopData2);
}

