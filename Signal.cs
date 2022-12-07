using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_interlocking_system.Properties
{
    //信号机  基类
    public class Signal
    {
        // 信号机名称
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //信号机左边区段（信号机左右两边只能是轨道区段）
        public Track Ltrack;
        //信号机右边区段
        public Track Rtrack;
        //1灯丝继电器
        private bool _DJ1;
        public bool DJ1
        {
            get { return _DJ1; }
            set { _DJ1 = value; }
        }
        //状态标志位
        private int _State;
        public int State
        {
            get { return _State; }
            set { _State = value; }
        }
        //占用标志位,false未占用，true已占用
        private bool _Occupy;
        public bool Occupy
        {
            get { return _Occupy; }
            set { _Occupy = value; }
        }
        //构造函数，信号机和两边的区段名称手动输入，其他自动给初始化
        public Signal(string name,Track ltrack,Track rtrack)
        {
            Name = name;
            Ltrack = ltrack;
            Rtrack = rtrack;
            DJ1 = true;
            State = 0;
        }
    }
    //进站信号机
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
        //引导信号继电器
        private bool _YXJ;
        public bool YXJ
        {
            get { return _YXJ; }
            set { _YXJ = value; }
        }
        //正线信号继电器
        private bool _ZXJ;
        public bool ZXJ
        {
            get { return _YXJ; }
            set { _ZXJ = value; }
        }
        //通过信号继电器
        private bool _TXJ;
        public bool TXJ
        {
            get { return _TXJ; }
            set { _TXJ = value; }
        }
        //绿黄信号继电器
        private bool _LUXJ;
        public bool LUXJ
        {
            get { return _LUXJ; }
            set { _LUXJ = value; }
        }
        //进站信号机的构造函数，继承于父类的构造函数，没有额外的参数
        public InboundSignal(string name,Track ltrack, Track rtrack) : base(name,ltrack,rtrack)
        {
            DJ2 = true;
            LXJ = false;
            YXJ = false;
            ZXJ = false;
            TXJ = false;
            LUXJ = false;
        }
        //根据继电器状态判断信号显示
        public int InboundSignalLight()//返回一个数字，代表信号种类
        {
            if(DJ1==true)
            {
                if(LXJ==false)
                {
                    State = 0;
                    return 0;//数字0代表禁止越过，红灯
                }
                else if(LXJ==true&&ZXJ==true&&TXJ==true)
                {
                    State = 1;
                    return 1;//数字1代表正线通过，绿灯
                }
                else if(LXJ==true &&ZXJ==true )
                {
                    State = 2;
                    return 2;//数字2代表正线接车，黄灯
                }
                else if(LXJ==true&&ZXJ==false)
                {
                    if (DJ2==true)
                    {
                        State = 3;
                        return 3;//数字3代表侧线接车，双黄灯
                    }
                    else
                    {
                        State = 10;//数字10代表信号机故障
                        MessageBox.Show("第二黄灯断丝");
                        return 0;
                    }
                }
                else if(YXJ==true)
                {
                    if(DJ2==true)
                    {
                        State = 4;
                        return 4;//数字4代表引导接车，红白灯
                    }
                    else
                    {
                        State = 10;
                        MessageBox.Show("白灯断丝");
                        return 0;
                    }
                }
                else
                {
                    State = 0;
                    return 0;
                }
            }
            else
            {
                State = 10;
                MessageBox.Show("进站信号机"+this.Name+"灯丝断丝");
                return 0;
            }
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
        //调车信号机构造函数，继承于父类，没有更多的参数
        public ShuntingSignal(string name, Track ltrack,Track rtrack) : base(name,ltrack,rtrack)
        {
            DXJ = false;
        }
        //防护区段标志字，0代表防护的是左边的区段，1代表防护的是右边的区段,调车进路会用到
        private int _protecticveSign;
        public int ProtectiveSign
        {
            get { return _protecticveSign; }
            set { _protecticveSign = value; }
        }
        //根据继电器状态判断信号显示
        public int ShuntingSignalLight()//返回一个数字，代表信号种类
        {
            if(DJ1==true)
            {
                if (DXJ == true) 
                {
                    State = 5;
                    return 5; //数字5代表允许调车
                }
                else
                {
                    State = 0;
                    return 0;//数字0代表禁止越过
                }
            }
            else
            {
                State = 0;
                MessageBox.Show("调车信号机"+this.Name+"灯丝断丝");
                return 0;
            }
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
        //接车兼调车信号机，继承于父类，没有多余的参数
        public ReceivingShuntingSignal(string name, Track ltrack,Track rtrack) :base(name,ltrack,rtrack)
        {
            LXJ = false;
            ZXJ = false;
            DXJ = false;
        }
        //根据继电器状态判断信号显示
        public int RecvingShuntingSignalLight()
        {
            if(DJ1==true)
            {
                if(LXJ==false&&DXJ==false)
                {
                    State = 0;
                    return 0;//数字0代表禁止越过,红灯
                }
                else if(LXJ==true&&ZXJ==true)
                {
                    State = 6;
                    return 6;//主要方向发车，绿灯/黄灯（假设只有绿灯,因为只能看到一个离去区段）
                }//次要方向发车没有考虑，本站虽然有次要发车方向，但是出站兼调车信号机只有一个灯光
                else if(DXJ==true)
                {
                    State = 5;
                    return 5;//数字5代表允许调车
                }    
                else
                {
                    return 5;
                }
            }
            else
            {
                State = 0;
                MessageBox.Show("接车兼调车信号机"+this.Name+"灯丝断丝");
                return 0;
            }
        }
    }
}
