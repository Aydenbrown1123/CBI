using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_interlocking_system
{
    //道岔类（单动）
    public class Switch
    {
        //道岔名称
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //道岔左边轨道区段（道岔的两边一定是轨道区段）
        public Track Ltrack;
        //道岔右边轨道区段
        public Track Rtrack;
        //道岔反位对应的轨道区段
        public Track Ftrack;
        //道岔反位有效的方向：0代表向左有效，1代表向右有效
        private int _EffectiveSign;
        public int EffectiveSign
        {
            get { return _EffectiveSign; }
            set { _EffectiveSign = value; }
        }
        //道岔定位的终端信号机
        //道岔左边
        public ArrayList D_LSignal;
        //道岔右边
        public ArrayList D_RSignal;
        //道岔反位的终端信号机
        //向左
        public ArrayList F_LSignal;
        //向右
        public ArrayList F_RSignal;
        //允许操作继电器
        private bool _YCJ;
        public bool YCJ
        {
            get { return _YCJ; }
            set { _YCJ = value; }
        }
        // 定位操作继电器
        private bool _DCJ;
        public bool DCJ
        {
            get { return _DCJ; }
            set { _DCJ = value; }
        }
        // 反位操作继电器
        private bool _FCJ;
        public bool FCJ
        {
            get { return _FCJ; }
            set { _FCJ = value; }
        }
        // 定位表示继电器
        private bool _DBJ;
        public bool DBJ
        {
            get { return _DBJ; }
            set { _DBJ = value; }
        }
        // 反位表示继电器
        private bool _FBJ;
        public bool FBJ
        {
            get { return _FBJ; }
            set { _FBJ = value; }
        }
        //状态标志位，false代表正常，true代表故障
        private bool _State;
        //占用标志位,false未占用，true已占用
        private bool _Occupy;
        public bool Occupy
        {
            get { return _Occupy; }
            set { _Occupy = value; }
        }
        public bool State
        {
            get { return _State; }
            set { _State = value; }
        }
        // 构造函数，道岔名称/防护方向，定位反位的终端信号机，全部都手动初始化，因为道岔是自动选排进路的关键设备
        public Switch(string name, int eff, Track ltrack, Track rtrack,Track ftrack)
        {
            Name = name;
            EffectiveSign = eff;
            Ltrack = ltrack;
            Rtrack = rtrack;
            Ftrack = ftrack;
            YCJ = true;
            DCJ = false;
            EffectiveSign = eff;
            RelaySwitch(DCJ);//道岔定反位转换时，只对DCJ这一个继电器进行赋值
        }
        // 继电器状态转换函数,只对定位操作继电器进行操作，其他继电器根据逻辑关系进行自动变换
        public void RelaySwitch(bool DGJ)
        {
            if (YCJ == true)//允许操作继电器吸起，道岔才可以转换
            {
                while (true)
                {
                    if (DCJ == true)
                    {
                        FCJ = false;
                    }
                    else
                    {
                        FCJ = true;
                    }
                    if (DCJ == true)
                    {
                        DBJ = true;
                    }
                    else
                    {
                        DBJ = false;
                    }
                    if (FCJ == true)
                    {
                        FBJ = true;
                    }
                    else
                    {
                        FBJ = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("当前不允许操纵道岔");
            }

        }
        //正常进路，根据进路方向选择道岔定反位,返回值为道岔定位表示继电器值
        //引导进路，无需这个操作，直接获取下一个轨道区段即可
        public bool SwitchPositionForNormalroute(int RouteDireciton, string TerminalSignal)
        {
            if ((RouteDireciton == 1 || RouteDireciton == 3) & EffectiveSign == 1)//向左的进路方向
            {
                if (D_LSignal.Contains(TerminalSignal))//发现了符合条件的终端信号机
                {
                    DCJ = true;
                    RelaySwitch(DCJ);// 对道岔定位操作，刷新道岔状态
                }
                else//定位时没有找到对应的终端信号机
                {
                    if (F_LSignal.Contains(TerminalSignal))//发现了符合条件的终端信号机
                    {
                        DCJ = false;
                        RelaySwitch(DCJ);// 对道岔反位操作，刷新道岔状态
                    }
                }
                return DBJ;
            }
            else if ((RouteDireciton == 0 || RouteDireciton == 2) & EffectiveSign == 1)//向右的进路方向
            {
                if (D_RSignal.Contains(TerminalSignal))//发现了符合条件的终端信号机
                {
                    DCJ = true;
                    RelaySwitch(DCJ);// 对道岔定位操作，刷新道岔状态
                }
                else//定位时没有找到对应的终端信号机
                {
                    if (F_RSignal.Contains(TerminalSignal))//发现了符合条件的终端信号机
                    {
                        DCJ = false;
                        RelaySwitch(DCJ);// 对道岔反位操作，刷新道岔状态
                    }
                }
                return DBJ;
            }
            else
            {
                return DBJ;
            }
        }
        //根据道岔定反位状态判断道岔后下一个轨道区段是谁
        //正常进路和引导进路都需要这一步
        public Track GetNextTrack(int RouteDirerction)
        {
            if (RouteDirerction == 0 || RouteDirerction == 2)//向右的进路方向
            {
                if (DBJ == false&&EffectiveSign==1)//道岔反位，且可以切换
                {
                    return Ftrack;
                }
                else
                {
                    return Rtrack;
                }
            }
            else
            {
                if (DBJ == false && EffectiveSign == 0)
                {
                    return Ftrack;
                }
                else
                {
                    return Ltrack;
                }
            }
        }

    }
    //双动道岔
    public class DoulbleActSwitch:Switch
    {
        //双动道岔另外一边的道岔
        public DoulbleActSwitch Aswitch;
        //双动道岔构造函数
        public DoulbleActSwitch(string name, int eff, Track ltrack, Track rtrack, Track ftrack,DoulbleActSwitch aswitch)
            : base(name, eff,ltrack, rtrack, ftrack)
        {
            Aswitch = aswitch;
        }
    }
}
