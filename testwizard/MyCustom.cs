using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

//using System.Diagnostics;
//using System.Reflection;
//using System.Windows.Interop;



namespace eFAlarmSet
{
    public class MyWin32FromHwnd : System.Windows.Forms.IWin32Window
    {
        public MyWin32FromHwnd(IntPtr intHandle)
        {
            myHandle = intHandle;
        }

        IntPtr myHandle;
        public IntPtr Handle
        {
            get { return myHandle; }
        }
    }

    public class MyCustom
    {
        HMIInterface.CHMIInterface m_HMIInterface;
        View m_myForm;
        UserPropertyPage m_myProperty;

        IntPtr m_nOwner;
        MyWin32FromHwnd m_parentForm;
        int m_pHmi;

        int m_nTickCount;
        List<RowValue> m_Values=new List<RowValue> { };
        public MyCustom()
        {
            m_myForm = new View();
            m_myForm.Location = new Point(0, 0);
            m_pHmi = 0;
            m_nTickCount = DateTime.Now.Second;
        }

        /*~MyCustom()
        {
            
        }*/

        public IntPtr GetSurfaceBMP()
        {
            return Resource.subface.GetHbitmap();
        }
        public void SetParentHwnd(int pHmi, long Hwnd, string strFile)
        {
            if (0 != Hwnd)
            {
                m_nOwner = (IntPtr)Hwnd;
                if (null == m_parentForm)
                {
                    m_parentForm = new MyWin32FromHwnd(m_nOwner);
                }
            }
            else
            {
                m_pHmi = pHmi;
                m_HMIInterface = new HMIInterface.CHMIInterface();
                m_HMIInterface.Init((IntPtr)m_pHmi);
                //m_myForm.Init(m_HMIInterface.IsRunMode());

            }
        }
        public long GetCurWnd()
        {
            return m_myForm.Handle.ToInt32();
        }
        public void ReleaseAllClose()
        {
            //m_myForm.Hide();
            if (null != m_myForm)
            {
                m_myForm.Dispose();
            }

            if (m_myProperty != null)
            {
                m_myProperty.Dispose();
            }

            m_HMIInterface.Release();
        }
        public string OnCreate(short nSubNo)
        {
            m_myForm.Show();
            return "TRUE";
        }
        public void OnInit()
        {
            //foreach (string s in m_strTagName)
            //{
            //    if (string.IsNullOrEmpty(s))
            //    {
            //        continue;
            //    }
            //    m_HMIInterface.VarRegister(s);
            //}
            foreach (RowValue value in m_Values)
            {
                value.Regist();
            }
        }
        public void PreDestory()
        {

        }
        public string GetModName()
        {
            return "CustomTemplate3";
        }
        public void GetRect(ref int nLeft, ref int nTop, ref int nRight, ref int nBottom)
        {
            nLeft = m_myForm.Left;
            nTop = m_myForm.Top;
            nRight = m_myForm.Right;
            nBottom = m_myForm.Bottom;
        }
        public void SetRect(int x1, int y1, int x2, int y2)
        {
            m_myForm.Location = new Point(x1, y1);
            m_myForm.Size = new Size(x2 - x1, y2 - y1);
        }
        public string Serialize(int nType, object stringValue)
        { 
            //nType == 1 为存储状态
            string strValue = "";
            if (1 == nType)
            {
                //保存
                foreach (RowValue s in m_Values)
                {
                    strValue+=s.Name+ System.Environment.NewLine;
                }
            }
            else
            {
                //读取
                string s = (string)stringValue;
                if (!string.IsNullOrEmpty(s))
                {
                    string[] vs = s.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    m_Values = new List<RowValue> { };
                    foreach (string t in vs)
                    {
                        m_Values.Add(new RowValue(t, m_HMIInterface));
                    }
                }
            }
            return strValue;
        }
        public string OnProperty()
        {
            m_myProperty = new UserPropertyPage();
            m_myProperty.SetHMI(m_HMIInterface);
            m_HMIInterface.InitSheet();
            m_HMIInterface.AddPage((IntPtr)m_myProperty.Handle);
            m_myProperty.SetRows(m_Values);
            if (m_HMIInterface.DoModal() == 1)
            {
                if (m_myProperty.GetRows().Count>0)
                {
                    m_Values=m_myProperty.GetRows();
                }
            }
            return "TRUE";
        }
        public void OnTimer()
        {
            if (m_nTickCount != DateTime.Now.Second)
            {
                m_nTickCount = DateTime.Now.Second;
                //foreach (string s in m_strTagName)
                //{
                //    if (s != "")
                //    {
                //        double dValue;
                //        m_HMIInterface.VarDataGet(s, out dValue);
                //        m_myForm.AddPoint(dValue);
                //    }
                //}
                m_myForm.UpdateTableContent();
            }
        }
        public string OnWndMsg(int message, int wParam, int lParam)
        {
            return "TRUE";
        }
        public void DBReStart(int nDDeAcc)
        {
        }
        public string GetDataSource()
        {

            return "0";
        }
        public string DbRequest(ref short type, ref short p1, ref short p2, ref short p3, ref int len, ref byte[] pInfor)
        {

            return "TRUE";
        }
        public void DbResponde(short type, short p1, short p2, short p3, int len, byte[] pInfor)
        {
        }
        public void OnVarDataChange(string strName)
        {

        }
        public void OnNotifyVarChange(int[] ChangeValue, object vValue, int nCount)
        {

        }
        public void RegMethod_Prop()
        {
        }
        public string InvokeMethod(int nFunID, ref object tagResult, ref object[] pParams, int nParamCount)
        {
            return "TRUE";
        }
        public string InvokeProperty(int nPropertyID, int PropertyTpye, ref object tagParam)
        {
            return "TRUE";
        }
        public void OnRightMenu(long hMenuHandle)
        {
        }
        public void OnContextMenu(int nX, int nY)
        {
        }
        public void IssueFile(int nCount, ref object strWorkList, ref object strFileList)
        {

        }
        public string UserProperty(int id, ref string strNewValue, ref int pWnd)
        {
            return "TRUE";
        }
        public void OnBindStatueNotify(string strObject, int bReg)
        {

        }
        public string OnBindDataNotify(string strObject, int len, char[] pData)
        {
            return "TRUE";
        }
        public void GetTextList(ref object list, ref int nCount)
        {
        }
        public void GetVarList(ref object list, ref int nCount)
        {

        }
        public string ReplaceText(string cs0, string cs1)
        {
            return "TRUE";
        }
        public string ReplaceVar(string cs0, string cs1)
        {
            return "TRUE";
        }

    }

}
