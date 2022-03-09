using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFAlarmSet
{
    public class RowValue
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public double PV { get; set; }
        public bool ALMENAB { get; set; }
        public double LO { get; set; }
        public double LL { get; set; }
        public double HI { get; set; }
        public double HH { get; set; }

        private double dALMENAB { get; set; }

        private string tag_name;
        private string tag_desc;
        private string tag_pv;
        private string tag_almenab;
        private string tag_lo;
        private string tag_ll;
        private string tag_hi;
        private string tag_hh;
        private bool first_update = true;
        private HMIInterface.CHMIInterface m_HMIInterface;

        public RowValue(string tag, HMIInterface.CHMIInterface cHMIInterface)
        {
            m_HMIInterface = cHMIInterface;
            tag_name=tag;
            Name=tag_name;
            tag_desc =tag+".DESC";
            tag_pv=tag+".PV";
            tag_almenab=tag+".ALMENAB";
            tag_lo= tag+".LO";
            tag_ll=tag+ ".LL";
            tag_hi=tag+".HI";
            tag_hh=tag+".HH";
        }

        public void Regist()
        {
            m_HMIInterface.VarRegister(tag_desc);
            m_HMIInterface.VarRegister(tag_pv);
            m_HMIInterface.VarRegister(tag_almenab);
            m_HMIInterface.VarRegister(tag_lo);
            m_HMIInterface.VarRegister(tag_ll);
            m_HMIInterface.VarRegister(tag_hi);
            m_HMIInterface.VarRegister(tag_hh);

        }
        public bool Update()
        {
            try
            {
                if (m_HMIInterface!=null)
                {
                    double var = 0;
                    m_HMIInterface.VarDataGet(tag_pv, out var);
                    PV=var;
                    m_HMIInterface.VarDataGet(tag_almenab, out var);
                    ALMENAB=var>0.0 ? true : false;
                    m_HMIInterface.VarDataGet(tag_lo, out var);
                    LO=var;
                    m_HMIInterface.VarDataGet(tag_ll, out var);
                    LL=var;
                    m_HMIInterface.VarDataGet(tag_hi, out var);
                    HI=var;
                    m_HMIInterface.VarDataGet(tag_hh, out var);
                    HH=var;
                    if (!first_update)
                    {
                        string svar = "";
                        m_HMIInterface.VarDataGet(tag_desc, out svar);
                        Desc=svar;
                    }
                    first_update=false;
                    return true;
                }
                return false;
            }
            catch 
            {
                return false;
            }
        }

        public bool Write()
        {
            try
            {
                if (m_HMIInterface!=null)
                {    
                    m_HMIInterface.VarDataSet(tag_almenab, ALMENAB?1.0:0.0);
                    m_HMIInterface.VarDataSet(tag_lo, LO);
                    m_HMIInterface.VarDataSet(tag_ll, LL);
                    m_HMIInterface.VarDataSet(tag_hi, HI);
                    m_HMIInterface.VarDataSet(tag_hh, HH);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
