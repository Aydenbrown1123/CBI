using Computer_interlocking_system.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_interlocking_system
{
    //进路类
    public class Route
    {
        //进路成员
        public ArrayList RouteMember;
        //进路方向，0代表接车(向右)，1代表发车（向左），2代表向右调车，3代表向左调车
        public int RouteDirection;
        //进路状态，0代表正常锁闭，1代表引导锁闭，
        public int RouteState;
        //进路代号，0代表接车/发车/调车的禁止越过，1 正线通过 2 正线接车 3 侧线接车 5 允许调车 6 允许发车 10 信号机故障
        public int RouteType;
        //进路类的构造函数
        public Route(ArrayList arrayList,int routeDirection,int routeState,int routeType)
        {
            RouteMember = arrayList;
            RouteDirection = routeDirection;
            RouteState = routeState;
            RouteType = routeType;
        }

        //遍历检查是否需要引导总锁闭，进路中设备是否有故障/占用
        public bool CheckForFaultsOrOccupy(bool SwitchFault,bool TrackOrSignalFault)
        {
            for (int i = 0; i < RouteMember.Count; i++)
            {
                if (RouteMember[i] is Track track)
                {
                    if (track.IsTrackFree()==false)//轨道区段有故障或者占用
                    {
                        TrackOrSignalFault = true;
                        continue;
                    }
                }
                else if(RouteMember[i] is Signal signal)
                {
                    if(signal.State==10||signal.Occupy==true)//信号机故障或存在丢对进路
                    {
                        MessageBox.Show("信号机" + signal.Name + "存在故障或被占用，请使用引导进路");
                        TrackOrSignalFault = true;
                        continue;
                    }
                }
                else if(RouteMember[i] is Switch sw)
                {
                    if(sw.State==true||sw.Occupy==true)//道岔存在故障或者被占用，需要引导总锁闭
                    {
                        MessageBox.Show("道岔" + sw.Name + "存在故障，请使用引导总锁闭");
                        TrackOrSignalFault = true;
                        continue;
                    }
                }
            }
            return (TrackOrSignalFault & SwitchFault);
        }
        //正常进路 进路设置加锁闭(道岔转换，轨道区段锁闭，始端信号机开放（只开放始端信号机）)
        public void ArrangeNormalRoute(int RouteType)
        {
            for (int i = 0; i < RouteMember.Count; i++)
            {
                if (RouteMember[i] is InboundSignal inboundSignal)//进路设备是进站信号机
                {
                    if (RouteDirection == 0)//接车进路时改变继电器状态
                    {
                        switch (RouteType)
                        {
                            case 0://红灯，禁止越过
                                inboundSignal.LXJ = false;
                                inboundSignal.ZXJ = false;
                                inboundSignal.TXJ = false;
                                inboundSignal.YXJ = false;
                                inboundSignal.LUXJ = false;
                                inboundSignal.Occupy = true;
                                break;
                            case 1://绿灯，通过
                                inboundSignal.LXJ = true;
                                inboundSignal.ZXJ = true;
                                inboundSignal.TXJ = true;
                                inboundSignal.YXJ = false;
                                inboundSignal.LUXJ = false;
                                inboundSignal.Occupy = true;
                                break;
                            case 2://黄灯，正线接车
                                inboundSignal.LXJ = true;
                                inboundSignal.ZXJ = true;
                                inboundSignal.TXJ = false;
                                inboundSignal.YXJ = false;
                                inboundSignal.LUXJ = false;
                                inboundSignal.Occupy = true;
                                break;
                            case 3://双黄灯，侧线接车
                                inboundSignal.LXJ = true;
                                inboundSignal.ZXJ = false;
                                inboundSignal.TXJ = false;
                                inboundSignal.YXJ = false;
                                inboundSignal.LUXJ = false;
                                inboundSignal.Occupy = true;
                                break;
                            case 10:
                                inboundSignal.LXJ = false;
                                inboundSignal.ZXJ = false;
                                inboundSignal.TXJ = false;
                                inboundSignal.YXJ = false;
                                inboundSignal.LUXJ = false;
                                inboundSignal.Occupy = true;
                                break;
                        }
                        continue;
                    }
                }
                else if (RouteMember[i] is ReceivingShuntingSignal receivingShuntingSignal)//出站兼调车信号机
                {
                    if (RouteDirection == 1 || RouteDirection == 2)//发车进路或者向右的调车进路才改变继电器状态
                    {
                        switch (RouteType)
                        {
                            case 0://红灯，禁止越过
                                receivingShuntingSignal.LXJ = false;
                                receivingShuntingSignal.DXJ = false;
                                receivingShuntingSignal.ZXJ = false;
                                receivingShuntingSignal.Occupy = true;
                                break;
                            case 5://允许调车，无显示
                                receivingShuntingSignal.LXJ = false;
                                receivingShuntingSignal.DXJ = true;
                                receivingShuntingSignal.ZXJ = false;
                                receivingShuntingSignal.Occupy = true;
                                break;
                            case 6://允许发车，绿灯（不考虑一离去/二离去区段的占用情况，因为站场表示不出来，所以没有黄灯显示）
                                receivingShuntingSignal.LXJ = true;
                                receivingShuntingSignal.DXJ = false;
                                receivingShuntingSignal.ZXJ = true;
                                receivingShuntingSignal.Occupy = true;
                                break;
                        }
                        continue;
                    }
                    else if (RouteDirection == 3)//向左的调车进路方向，DCJ继电器吸起，但是信号机不显示灯光
                    {
                        receivingShuntingSignal.LXJ = false;
                        receivingShuntingSignal.DXJ = true;
                        receivingShuntingSignal.ZXJ = false;
                        receivingShuntingSignal.Occupy = true;
                        continue;
                    }
                }
                else if (RouteMember[i] is ShuntingSignal shuntingSignal)//调车信号机
                {
                    shuntingSignal.DJ1 = true;
                    shuntingSignal.Occupy = true;
                    continue;
                }
                else if(RouteMember[i] is Track track)//轨道区段锁闭
                {
                    track.Locking = true;
                    continue;
                }
                else if(RouteMember[i] is Switch sw)//道岔自动转换
                {
                    if(RouteDirection==0||RouteDirection==2)
                    {
                        if(RouteMember[i+1].Equals(sw.Rtrack))
                        {
                            sw.RelaySwitch(true);
                            continue;
                        }
                        else
                        {
                            sw.RelaySwitch(false);
                            continue;
                        }
                    }
                    else
                    {
                        if (RouteMember[i+1].Equals(sw.Ltrack))
                        {
                            sw.RelaySwitch(true);
                            continue;
                        }
                        else
                        {
                            sw.RelaySwitch(false);
                            continue;
                        }
                    }
                }
            }
        }
        //引导进路 进路设置加锁闭（轨道区段锁闭，始端信号机开放）
        public void ArrangeGuidingRoute()
        {
            for (int i = 0; i < RouteMember.Count; i++)
            {
                if (RouteMember[i] is InboundSignal inboundSignal)//进路设备是进站信号机
                {
                    if (RouteDirection == 0)//引导进路时改变继电器状态
                    {
                        switch (RouteType)
                        {
                            case 4://红白灯，引导接车
                                inboundSignal.LXJ = false;
                                inboundSignal.ZXJ = false;
                                inboundSignal.TXJ = false;
                                inboundSignal.YXJ = true;
                                inboundSignal.LUXJ = false;
                                inboundSignal.Occupy = true;
                                break;
                            case 10://信号机故障
                                inboundSignal.LXJ = false;
                                inboundSignal.ZXJ = false;
                                inboundSignal.TXJ = false;
                                inboundSignal.YXJ = false;
                                inboundSignal.LUXJ = false;
                                inboundSignal.Occupy = true;
                                break;
                        }
                        continue;
                    }
                }
                else if (RouteMember[i] is ReceivingShuntingSignal receivingShuntingSignal)//出站兼调车信号机只占用，不显示
                {
                    receivingShuntingSignal.Occupy = true;
                    continue;
                }
                else if (RouteMember[i] is ShuntingSignal shuntingSignal)//调车信号机只占用，不显示
                {
                    shuntingSignal.Occupy = true;
                    continue;
                }
                else if (RouteMember[i] is Track track)//轨道区段引导锁闭
                {
                    track.Locking = true;
                    track.Guiding = true;
                    continue;
                }
                else if (RouteMember[i] is Switch sw)//道岔只占用，不自动转换
                {
                    sw.Occupy = true;
                }
            }
        }
        //正常进路 模拟行车以及进路解锁
        public bool NormalSimulatingDriving()
        {
            bool MovementAuthority=false;
            for (int i = 0; i < RouteMember.Count; i++)
            {
                if(RouteMember[i] is InboundSignal inboundSignal&&RouteDirection==0)
                {

                }
            }
            return MovementAuthority;
        }

        //引导进路 模拟行车以及进路解锁
        public void GuidingSimulatingDriving()
        {
            for (int i = 0; i < RouteMember.Count; i++)
            {

            }
        }
    }
}
