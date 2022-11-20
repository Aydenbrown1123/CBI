using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_interlocking_system.Properties
{
    class Signal
    {
        // 信号机名称
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //信号机左边区段名称
        private string _l_name;
        public string L_name
        {
            get { return _l_name; }
            set { _l_name = value; }
        }
        //信号机右边区段名称
        private string _r_name;
        public string R_name
        {
            get { return _r_name; }
            set { _r_name = value; }
        }
        //1灯丝继电器
        private bool _DJ1;
        public bool DJ1
        {
            get { return _DJ1; }
            set { _DJ1 = value; }
        }
        //构造函数，信号机和两边的区段名称手动输入，其他自动给初始化
        public Signal(string name,string lname,string rname)
        {
            Name = name;
            L_name = lname;
            R_name = rname;
            DJ1 = true;
        }
    }
    class InboundSignal:Signal
    {
        //2灯丝继电器
        private bool _DJ2;
        public bool DJ2
        {
            get { return _DJ2; }
            set { _DJ2 = value; }
        }
        // 列车信号继电器
        private bool _LXJ;
        public bool LXJ
        {
            get { return _LXJ; }
            set { _LXJ = value; }
        }
        private bool _YXJ;
        public bool YXJ
        {
            get { return _YXJ; }
            set { _YXJ = value; }
        }
        private bool _ZXJ;
        public bool ZXJ
        {
            get { return _YXJ; }
            set { _ZXJ = value; }
        }
        private bool _TXJ;
        public bool TXJ
        {
            get { return _TXJ; }
            set { _TXJ = value; }
        }
        private bool _LUXJ;
        public bool LUXJ
        {
            get { return _LUXJ; }
            set { _LUXJ = value; }
        }
        public InboundSignal(string name, string lname, string rname) : base(name,lname,rname)
        {
            DJ2 = true;
            LXJ = false;
            YXJ = false;
            ZXJ = false;
            TXJ = false;
            LUXJ = false;
        }
    }
    //调车信号机
    class ShuntingSignal:Signal
    {
        //调车信号继电器
        private bool _DXJ;
        public bool DXJ
        {
            get { return _DXJ; }
            set { _DXJ = value; }
        }
        public ShuntingSignal(string name, string lname, string rname) :base(name,lname,rname)
        {
            DXJ = false;
        }
    }
    //接车兼调车信号机
    class ReceivingShuntingSignal:Signal
    {
        //列车信号继电器
        private bool _LXJ;
        public bool LXJ
        {
            get { return _LXJ; }
            set { _LXJ = value; }
        }
        //正线信号继电器
        private bool _ZXJ;
        public bool ZXJ
        {
            get { return _ZXJ; }
            set { _ZXJ = value; }
        }
        //调车信号继电器
        private bool _DXJ;
        public bool DXJ
        {
            get { return _DXJ; }
            set { _DXJ = value; }
        }
        public ReceivingShuntingSignal(string name, string lname, string rname) :base(name,lname,rname)
        {
            LXJ = false;
            ZXJ = false;
            DXJ = false;
        }
    }
}
