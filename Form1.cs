using Computer_interlocking_system.Properties;
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_interlocking_system
{
    public partial class CBI : Form
    {
        public bool flag = false;//标签显示的标志位
        public CBI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 联锁程序主体
        /// </summary>
        public void Shilihua()
        {
            //实例化信号设备

            //轨道区段
            Track T_3JG = new Track("3JG", "NULL", "X");
            Track T_3DG_1 = new Track("3DG_1", "X", "C3");
            Track T_3DG_2 = new Track("3DG_2", "C3", "D5");
            Track T_5DG_1 = new Track("5DG_1", "D5", "C5");
            Track T_5DG_2 = new Track("5DG_2", "C5", "D7");
            Track T_9DG_1 = new Track("9DG_1", "D7", "C9");
            Track T_9DG_2 = new Track("9DG_2", "C9", "SI");
            Track T_9DG_3 = new Track("9DG_3", "C9", "S3");
            Track T_IG = new Track("IG", "SI", "NULL");
            Track T_3G = new Track("3G", "S3", "NULL");
            Track T_1LQ = new Track("1LQ", "NULL", "XF");
            Track T_IIAG = new Track("IIAG", "XF", "D_1");
            Track T_1DG_1 = new Track("1DG_1", "D1", "C1");
            Track T_1DG_2 = new Track("1DG_2", "C1", "D3");
            Track T_7DG_1 = new Track("7DG_1", "D3", "C7");
            Track T_7DG_2 = new Track("7DG_2", "C7", "D9");
            Track T_11DG_1 = new Track("11DG_1", "D9", "C11");
            Track T_11DG_2 = new Track("11DG_2", "C11", "SII");
            Track T_11DG_3 = new Track("11_DG_3", "C_11", "S4");
            Track T_IIG = new Track("IIG", "SII", "NULL");
            Track T_4G = new Track("4G", "S4", "NULL");
            Track T_1_3DG = new Track("1-3DG", "C1", "C3");
            Track T_5_7DG = new Track("5-7DG", "C5", "C7");
            ArrayList TrackList = new ArrayList
            {
                T_3JG,
                T_3DG_1,
                T_3DG_2,
                T_5DG_1,
                T_5DG_2,
                T_9DG_1,
                T_9DG_2,
                T_9DG_3,
                T_IG,
                T_3G,
                T_1LQ,
                T_IIAG,
                T_1DG_1,
                T_1DG_2,
                T_7DG_1,
                T_7DG_2,
                T_11DG_1,
                T_11DG_2,
                T_11DG_3,
                T_IIG,
                T_4G,
                T_1_3DG,
                T_5_7DG
            };



            //信号机
            InboundSignal X = new InboundSignal("X", T_3JG, T_3DG_1);
            InboundSignal XF = new InboundSignal("XF", T_1LQ, T_IIAG);
            ReceivingShuntingSignal SI = new ReceivingShuntingSignal("SI", T_9DG_2, T_IG);
            ReceivingShuntingSignal SII = new ReceivingShuntingSignal("SII", T_11DG_2, T_IIG);
            ReceivingShuntingSignal S3 = new ReceivingShuntingSignal("S3", T_9DG_3, T_3G);
            ReceivingShuntingSignal S4 = new ReceivingShuntingSignal("S4", T_11DG_3, T_4G);
            ShuntingSignal D1 = new ShuntingSignal("D1", T_IIAG, T_1DG_1);
            ShuntingSignal D3 = new ShuntingSignal("D3", T_1DG_2, T_7DG_1);
            ShuntingSignal D5 = new ShuntingSignal("D5", T_3DG_2, T_5DG_1);
            ShuntingSignal D7 = new ShuntingSignal("D7", T_5DG_2, T_9DG_1);
            ShuntingSignal D9 = new ShuntingSignal("D9", T_7DG_2, T_11DG_1);
            ArrayList SignalList = new ArrayList
            {
                X,
                XF,
                SI,
                SII,
                S3,
                S4,
                D1,
                D3,
                D5,
                D7,
                D9
            };


            //道岔
            Switch C1 = new Switch("C1", 1, T_1DG_1, T_1DG_2, T_1_3DG);
            //{ "XF" },{"SII","S4"},{ "XF"},{ "SI","SII","S3","S4"}
            C1.D_LSignal.Add(XF);
            C1.D_RSignal.Add(SII);
            C1.D_RSignal.Add(S4);
            C1.F_LSignal.Add(XF);
            C1.F_RSignal.Add(SI);
            C1.F_RSignal.Add(SII);
            C1.F_RSignal.Add(S3);
            C1.F_RSignal.Add(S4);
            Switch C3 = new Switch("C3", 0, T_3DG_1, T_3DG_2, T_1_3DG);
            C3.D_LSignal.Add(X);
            C3.D_RSignal.Add(SI);
            C3.D_RSignal.Add(SII);
            C3.D_RSignal.Add(S3);
            C3.D_RSignal.Add(S4);
            C3.F_LSignal.Add(XF);
            C3.F_RSignal.Add(SI);
            C3.F_RSignal.Add(SII);
            C3.F_RSignal.Add(S3);
            C3.F_RSignal.Add(S4);
            Switch C5 = new Switch("C5", 1, T_5DG_1, T_5DG_2, T_5_7DG);
            C5.D_LSignal.Add(X);
            C5.D_LSignal.Add(XF);
            C5.D_RSignal.Add(SI);
            C5.D_RSignal.Add(S3);
            C5.F_LSignal.Add(X);
            C5.F_LSignal.Add(XF);
            C5.F_RSignal.Add(SII);
            C5.F_RSignal.Add(S4);
            Switch C7 = new Switch("C7", 0, T_7DG_1, T_7DG_2, T_5_7DG);
            C7.D_LSignal.Add(X);
            C7.D_LSignal.Add(XF);
            C7.D_RSignal.Add(SII);
            C7.D_RSignal.Add(S4);
            C7.F_LSignal.Add(X);
            C7.F_LSignal.Add(XF);
            C7.F_RSignal.Add(SII);
            C7.F_RSignal.Add(S4);
            Switch C9 = new Switch("C9", 1, T_9DG_1, T_9DG_2, T_9DG_3);
            C9.D_LSignal.Add(X);
            C9.D_LSignal.Add(XF);
            C9.D_RSignal.Add(SI);
            C9.F_LSignal.Add(X);
            C9.F_LSignal.Add(XF);
            C9.F_RSignal.Add(S3);
            Switch C11 = new Switch("C11", 1, T_11DG_1, T_11DG_2, T_11DG_3);
            C11.D_LSignal.Add(X);
            C11.D_LSignal.Add(XF);
            C11.D_RSignal.Add(S3);
            C11.F_LSignal.Add(X);
            C11.F_LSignal.Add(XF);
            C11.F_RSignal.Add(S4);
            ArrayList SwitchList = new ArrayList
            {
                C1,
                C3,
                C5,
                C7,
                C9,
                C11
            };




            //联锁表
            //接车
            //X至IG
            ArrayList J_X_SI = new ArrayList
            {
                X,
                T_3DG_1,
                C3,
                T_3DG_2,
                D5,
                T_5DG_1,
                C5,
                T_5DG_2,
                D7,
                T_9DG_1,
                C9,
                T_9DG_2,
                SI,
                T_IG
            };
            //X至3G
            ArrayList J_X_S3 = new ArrayList
            {
                X,
                T_3DG_1,
                C3,
                T_3DG_2,
                D5,
                T_5DG_1,
                C5,
                T_5DG_2,
                D7,
                T_9DG_1,
                C9,
                T_9DG_3,
                SI,
                T_3G
            };
            //X至IIG
            ArrayList J_X_SII = new ArrayList
            {
                X,
                T_3DG_1,
                C3,
                T_3DG_2,
                D5,
                T_5DG_1,
                C5,
                T_5_7DG,
                C7,
                T_7DG_2,
                D9,
                T_11DG_1,
                C11,
                T_11DG_2,
                SII,
                T_IIG
            };
            //X至4G
            ArrayList J_X_S4 = new ArrayList
            {
                X,
                T_3DG_1,
                C3,
                T_3DG_2,
                D5,
                T_5DG_1,
                C5,
                T_5_7DG,
                C7,
                T_7DG_2,
                D9,
                T_11DG_1,
                C11,
                T_11DG_3,
                S4,
                T_4G
            };
            //XF至IIG
            ArrayList J_XF_SII = new ArrayList
            {
                XF,
                T_IIAG,
                D1,
                T_1DG_1,
                C1,
                T_1DG_2,
                D3,
                T_7DG_1,
                C7,
                T_7DG_2,
                D9,
                T_11DG_1,
                C11,
                T_11DG_2,
                SII,
                T_IIG
            };
            //XF至4G
            ArrayList J_XF_S4 = new ArrayList
            {
                XF,
                T_IIAG,
                D1,
                T_1DG_1,
                C1,
                T_1DG_2,
                D3,
                T_7DG_1,
                C7,
                T_7DG_2,
                D9,
                T_11DG_1,
                C11,
                T_11DG_3,
                S4,
                T_4G
            };
            //XF至IG
            ArrayList J_XF_SI = new ArrayList
            {
                XF,
                T_IIAG,
                D1,
                T_1DG_1,
                C1,
                T_1_3DG,
                C3,
                T_3DG_2,
                D5,
                T_5DG_1,
                C5,
                T_5DG_2,
                D7,
                T_9DG_1,
                C9,
                T_9DG_2,
                SI,
                T_IG
            };
            //XF至3G
            ArrayList J_XF_S3 = new ArrayList
            {
                XF,
                T_IIAG,
                D1,
                T_1DG_1,
                C1,
                T_1_3DG,
                C3,
                T_3DG_2,
                D5,
                T_5DG_1,
                C5,
                T_5DG_2,
                D7,
                T_9DG_1,
                C9,
                T_9DG_3,
                S3,
                T_3G
            };

            //发车
            //IG至X
            ArrayList F_SI_X = new ArrayList
            {
                T_IG,
                SI,
                T_9DG_2,
                C9,
                T_9DG_1,
                D7,
                T_5DG_2,
                C5,
                T_5DG_1,
                D5,
                T_3DG_2,
                C3,
                T_3DG_1,
                X
            };
            //IG至XF
            ArrayList F_SI_XF = new ArrayList
            {
                T_IG,
                SI,
                T_9DG_2,
                C9,
                T_9DG_1,
                D7,
                T_5DG_2,
                C5,
                T_5DG_1,
                D5,
                T_3DG_2,
                C3,
                T_1_3DG,
                C1,
                T_1DG_1,
                D1,
                T_IIAG,
                XF
            };
            //3G至X
            ArrayList F_S3_X = new ArrayList
            {
                T_3G,
                S3,
                T_9DG_3,
                C9,
                T_9DG_1,
                D7,
                T_5DG_2,
                C5,
                T_5DG_1,
                D5,
                T_3DG_2,
                C3,
                T_3DG_1,
                X
            };
            //3G至XF
            ArrayList F_S3_XF = new ArrayList
            {
                T_3G,
                S3,
                T_9DG_3,
                C9,
                T_9DG_1,
                D7,
                T_5DG_2,
                C5,
                T_5DG_1,
                D5,
                T_3DG_2,
                C3,
                T_1_3DG,
                C1,
                T_1DG_1,
                D1,
                T_IIAG,
                XF
            };
            //IIG至XF
            ArrayList F_SII_XF = new ArrayList
            {
                T_IIG,
                SII,
                T_11DG_2,
                C11,
                T_11DG_1,
                D9,
                T_7DG_2,
                C7,
                T_7DG_1,
                D3,
                T_1DG_2,
                C1,
                T_1DG_1,
                D1,
                T_IIAG,
                XF
            };
            //IIG至X
            ArrayList F_SII_X = new ArrayList
            {
                T_IIG,
                SII,
                T_11DG_2,
                C11,
                T_11DG_1,
                D9,
                T_7DG_2,
                C7,
                T_5_7DG,
                C5,
                T_5DG_1,
                D5,
                T_3DG_2,
                C3,
                T_3DG_2,
                X
            };
            //4G至XF
            ArrayList F_SI4_XF = new ArrayList
            {
                T_4G,
                S4,
                T_11DG_3,
                C11,
                T_11DG_1,
                D9,
                T_7DG_2,
                C7,
                T_7DG_1,
                D3,
                T_1DG_2,
                C1,
                T_1DG_1,
                D1,
                T_IIAG,
                XF
            };
            //IIG至X
            ArrayList F_S4_X = new ArrayList
            {
                T_4G,
                S4,
                T_11DG_3,
                C11,
                T_11DG_1,
                D9,
                T_7DG_2,
                C7,
                T_5_7DG,
                C5,
                T_5DG_1,
                D5,
                T_3DG_2,
                C3,
                T_3DG_2,
                X
            };

            //调车进路要不就先不做了？

            //站场显示刷新
            //后续显示变化也使用这个函数
            for (int i = 0; i < TrackList.Count; i++)
            {
                RefreshTrackDisplay((Track)TrackList[i]);
            }
            for (int i = 0; i < SignalList.Count; i++)
            {
                RefreshSignalDisplay((Signal)SignalList[i]);
            }
            for (int i = 0; i < SwitchList.Count; i++)
            {
                RefreshSwitchDisplay();
            }
            

        }
        // X引导总锁闭按钮-悬停提示信息
        private void Yzbto_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                // 创建the ToolTip 
                ToolTip toolTip1 = new ToolTip();
                flag = true;
                // 设置显示样式
                toolTip1.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip1.ReshowDelay = 0;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
                toolTip1.ShowAlways = true;//是否显示提示框

                //  设置伴随的对象.
                toolTip1.SetToolTip(this.yzbto, "下行方向引导总锁闭\n" +
                "\n" +
                "接车进路上出现道岔故障而失去位置信息时使用\n" +
                "\n" +
                "1.单独操纵道岔到进路规定的位置\n" +
                "2.输入口令确认\n");//设置提示按钮和提示内容
            }
            flag = false;
        }
        // 总取消按钮悬-浮提示信息
        private void Zqbto_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                ToolTip toolTip2 = new ToolTip();
                flag = true;
                toolTip2.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip2.ReshowDelay = 0;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
                toolTip2.ShowAlways = true;//是否显示提示框
                                           //  设置伴随的对象.
                toolTip2.SetToolTip(this.zqbto, "总取消\n" +
                    "\n" +
                    "列车未进入短进路，且未进入接近区段时使用\n" +
                    "\n" +
                    "1.点击始端信号机按钮\n" +
                    "2.检查接近区段和进路内都无列车进入，自动关闭始端信号\n" +
                    "3.确认信号关闭后进路自动解锁");//设置提示按钮和提示内容
            }
            flag = false;
        }
        // 总人解按钮-悬浮提示信息
        private void Zrbto_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                ToolTip toolTip3 = new ToolTip();
                flag = true;
                toolTip3.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip3.ReshowDelay = 0;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
                toolTip3.ShowAlways = true;//是否显示提示框
                                           //  设置伴随的对象.
                toolTip3.SetToolTip(this.zrbto, "总人解\n" +
                    "\n" +
                    "列车未进入短进路，但已经进入接近区段时使用\n" +
                    "\n" +
                    "1.点击始端信号机按钮\n" +
                    "2.检查接近区段和进路内都无列车进入，自动关闭始端信号\n" +
                    "3.确认信号关闭后进路延时\n" +
                    "  (接车、正线发车进路-3min,侧线发车、调车进路-30s）\n" +
                    "4.延时结束，检查列车或者调车车列没有冒入，进路自动解锁");//设置提示按钮和提示内容
            }
            flag = false;
        }
        // 区段故障解锁按钮-悬浮提示信息
        private void Qgbto_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                ToolTip toolTip4 = new ToolTip();
                flag = true;
                toolTip4.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip4.ReshowDelay = 0;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
                toolTip4.ShowAlways = true;//是否显示提示框
                                           //  设置伴随的对象.
                toolTip4.SetToolTip(this.qgbto, "区段故障解锁\n" +
                    "\n" +
                    "进路内部分信号设备出现故障，轨道区段不能解锁时使用\n" +
                    "每次只能解锁一个区段\n" +
                    "\n" +
                    "1.值班员办理区段故障解锁手续\n" +
                    "2.检查区段故障解锁条件\n" +
                    "  区段必须空闲（DGJ吸起），区段不在进路前方……\n" +
                    "3.确认条件满足，进行解锁");//设置提示按钮和提示内容
            }
            flag = false;
        }
        // 道岔总定位按钮-悬浮提示信息
        private void Zdbot_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                ToolTip toolTip5 = new ToolTip();
                flag = true;
                toolTip5.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip5.ShowAlways = true;//是否显示提示框
                                           //  设置伴随的对象.
                toolTip5.SetToolTip(this.zdbot, "道岔总定位\n" +
                    "\n" +
                    "操纵道岔到定位");//设置提示按钮和提示内容
            }
            flag = false;
        }
        // 道岔总反位按钮-悬浮提示信息
        private void Zfbto_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                ToolTip toolTip6 = new ToolTip();
                flag = true;
                toolTip6.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip6.ShowAlways = true;//是否显示提示框
                                           //  设置伴随的对象.
                toolTip6.SetToolTip(this.zfbto, "道岔总反位\n" +
                    "\n" +
                    "操纵道岔到反位");//设置提示按钮和提示内容
            }
            flag = false;
        }
        // 道岔单锁按钮-悬浮提示信息
        private void Dsbto_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                ToolTip toolTip7 = new ToolTip();
                flag = true;
                toolTip7.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip7.ShowAlways = true;//是否显示提示框
                                           //  设置伴随的对象.
                toolTip7.SetToolTip(this.dsbto, "道岔单锁\n" +
                    "\n" +
                    "引导接车时本咽喉所有道岔都要锁闭\n" +
                    "锁闭后道岔不能操作，但可以参与排列进路");//设置提示按钮和提示内容
            }
            flag = false;
        }
        // 道岔单解按钮-悬浮提示信息
        private void Djbto_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                ToolTip toolTip8 = new ToolTip();
                flag = true;
                toolTip8.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip8.ShowAlways = true;//是否显示提示框
                                           //  设置伴随的对象.
                toolTip8.SetToolTip(this.djbto, "道岔单解\n" +
                    "\n" +
                    "道岔解除单锁");//设置提示按钮和提示内容
            }
            flag = false;
        }
        // 道岔封锁按钮-悬浮提示信息
        private void Dfbto_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                ToolTip toolTip9 = new ToolTip();
                flag = true;
                toolTip9.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip9.ShowAlways = true;//是否显示提示框
                                           //  设置伴随的对象.
                toolTip9.SetToolTip(this.dfbto, "道岔封锁\n" +
                    "\n" +
                    "道岔禁止操作，禁止使用");//设置提示按钮和提示内容
            }
            flag = false;
        }
        // 道岔解封按钮-悬浮提示信息
        private void Djbtom_MouseHover(object sender, EventArgs e)
        {
            if (!flag)
            {
                ToolTip toolTip10 = new ToolTip();
                flag = true;
                toolTip10.InitialDelay = 1000;//事件触发多久后出现提示
                toolTip10.ShowAlways = true;//是否显示提示框
                                            //  设置伴随的对象.
                toolTip10.SetToolTip(this.djbtom, "道岔解封\n" +
                    "\n" +
                    "解除道岔封锁");//设置提示按钮和提示内容
            }
            flag = false;
        }




        //道岔的操作在此处包装为函数，使用时结合条件判定，直接调用实现进行图形的变换
        //道岔的定位
        //道岔1定位显示
        public void C1_D()
        {
            line_C1_D.BorderColor = Color.Lime;
            line_C1_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C1_F.BorderColor = Color.Yellow;
            line_C1_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C1.ForeColor = Color.Green;
            line_C3_D.BorderColor = Color.Lime;
            line_C3_F.BorderColor = Color.Yellow;
            line_C3_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C3_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C3.ForeColor = Color.Green;
        }
        public void C3_D()
        {
            line_C1_D.BorderColor = Color.Lime;
            line_C1_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C1_F.BorderColor = Color.Yellow;
            line_C1_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C1.ForeColor = Color.Green;
            line_C3_D.BorderColor = Color.Lime;
            line_C3_F.BorderColor = Color.Yellow;
            line_C3_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C3_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C3.ForeColor = Color.Green;
        }
        public void C5_D()
        {
            line_C5_D.BorderColor = Color.Lime;
            line_C5_F.BorderColor = Color.Yellow;
            line_C5_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C5_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C5.ForeColor = Color.Green;
            line_C7_D.BorderColor = Color.Lime;
            line_C7_F.BorderColor = Color.Yellow;
            line_C7_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C7_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C7.ForeColor = Color.Green;
        }
        public void C7_D()
        {
            line_C5_D.BorderColor = Color.Lime;
            line_C5_F.BorderColor = Color.Yellow;
            line_C5_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C5_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C5.ForeColor = Color.Green;
            line_C7_D.BorderColor = Color.Lime;
            line_C7_F.BorderColor = Color.Yellow;
            line_C7_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C7_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C7.ForeColor = Color.Green;
        }
        public void C9_D()
        {
            line_C9_D.BorderColor = Color.Lime;
            line_C9_F.BorderColor = Color.Yellow;
            line_C9_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C9_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C9.ForeColor = Color.Green;
        }
        public void C11_D()
        {
            line_C11_D.BorderColor = Color.Lime;
            line_C11_F.BorderColor = Color.Yellow;
            line_C11_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            line_C11_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C11.ForeColor = Color.Green;
        }

        //道岔反位
        //道岔1反位操作
        public void C1_F()
        {
            line_C1_D.BorderColor = Color.Lime;
            line_C1_F.BorderColor = Color.Yellow;
            line_C1_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C1_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C1.ForeColor = Color.Yellow;
            line_C3_D.BorderColor = Color.Lime;
            line_C3_F.BorderColor = Color.Yellow;
            line_C3_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C3_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C3.ForeColor = Color.Yellow;
        }
        public void C3_F()
        {
            line_C1_D.BorderColor = Color.Lime;
            line_C1_F.BorderColor = Color.Yellow;
            line_C1_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C1_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C1.ForeColor = Color.Yellow;
            line_C3_D.BorderColor = Color.Lime;
            line_C3_F.BorderColor = Color.Yellow;
            line_C3_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C3_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C3.ForeColor = Color.Yellow;
        }

        public void C5_F()
        {
            line_C5_D.BorderColor = Color.Lime;
            line_C5_F.BorderColor = Color.Yellow;
            line_C5_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C5_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C5.ForeColor = Color.Yellow;
            line_C7_D.BorderColor = Color.Lime;
            line_C7_F.BorderColor = Color.Yellow;
            line_C7_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C7_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C7.ForeColor = Color.Yellow;
        }
        public void C7_F()
        {
            line_C5_D.BorderColor = Color.Lime;
            line_C5_F.BorderColor = Color.Yellow;
            line_C5_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C5_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C5.ForeColor = Color.Yellow;
            line_C7_D.BorderColor = Color.Lime;
            line_C7_F.BorderColor = Color.Yellow;
            line_C7_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C7_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C7.ForeColor = Color.Yellow;
        }
        public void C9_F()
        {
            line_C9_D.BorderColor = Color.Lime;
            line_C9_F.BorderColor = Color.Yellow;
            line_C9_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C9_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C9.ForeColor = Color.Yellow;
        }
        public void C11_F()
        {
            line_C11_D.BorderColor = Color.Lime;
            line_C11_F.BorderColor = Color.Yellow;
            line_C11_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C11_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            label_C11.ForeColor = Color.Yellow;
        }
        //道岔失去表示
        public void C1_S()
        {
            line_C1_D.BorderColor = Color.Lime;
            line_C1_F.BorderColor = Color.Yellow;
            line_C1_D.BorderColor = Color.Green;
            line_C1_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C1_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C1.ForeColor = Color.Red;
        }
        public void C3_S()
        {
            line_C3_D.BorderColor = Color.Lime;
            line_C3_F.BorderColor = Color.Yellow;
            line_C3_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C3_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C3.ForeColor = Color.Red;
        }
        public void C5_S()
        {
            line_C5_D.BorderColor = Color.Lime;
            line_C5_F.BorderColor = Color.Yellow;
            line_C5_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C5_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C5.ForeColor = Color.Red;
        }
        public void C7_S()
        {
            line_C7_D.BorderColor = Color.Lime;
            line_C7_F.BorderColor = Color.Yellow;
            line_C7_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C7_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C7.ForeColor = Color.Red;
        }
        public void C9_S()
        {
            line_C9_D.BorderColor = Color.Lime;
            line_C9_F.BorderColor = Color.Yellow;
            line_C9_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C9_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C9.ForeColor = Color.Red;
        }
        public void C11_S()
        {
            line_C11_D.BorderColor = Color.Lime;
            line_C11_F.BorderColor = Color.Yellow;
            line_C11_D.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            line_C11_F.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            label_C11.ForeColor = Color.Red;
        }
        //清除故障
        public void C1_Q()
        {
            C1_D();
        }
        public void C3_Q()
        {
            C3_D();
        }
        public void C5_Q()
        {
            C5_D();
        }
        public void C7_Q()
        {
            C7_D();
        }
        public void C9_Q()
        {
            C9_D();
        }
        public void C11_Q()
        {
            C11_D();
        }
        //挤岔
        //道岔1挤岔
        public void C1_J()
        {

        }
        public void C3_J()
        {

        }
        public void C5_J()
        {

        }
        public void C7_J()
        {

        }
        public void C9_J()
        {

        }
        public void C11_J()
        {

        }

        //道岔右键菜单
        //道岔右键菜单-定位
        public void Dc_Functions_D(object sender, EventArgs e)
        {
            if (Con_Name.Equals("line_C1_D") || Con_Name.Equals("line_C1_F") || Con_Name.Equals("label_C1"))
            {
                C1_D();
            }
            else if (Con_Name.Equals("line_C3_D") || Con_Name.Equals("line_C3_F") || Con_Name.Equals("label_C3"))
            {
                C3_D();
            }
            else if (Con_Name.Equals("line_C5_D") || Con_Name.Equals("line_C5_F") || Con_Name.Equals("label_C5"))
            {
                C5_D();
            }
            else if (Con_Name.Equals("line_C7_D") || Con_Name.Equals("line_C7_F") || Con_Name.Equals("label_C7"))
            {
                C7_D();
            }
            else if (Con_Name.Equals("line_C9_D") || Con_Name.Equals("line_C9_F") || Con_Name.Equals("label_C9"))
            {
                C9_D();
            }
            else if (Con_Name.Equals("line_C11_D") || Con_Name.Equals("line_C11_F") || Con_Name.Equals("label_C11"))
            {
                C11_D();
            }
        }
        //道岔右键菜单-反位
        public void Dc_Funcitons_F(object sender, EventArgs e)
        {
            if (Con_Name.Equals("line_C1_D") || Con_Name.Equals("line_C1_F") || Con_Name.Equals("label_C1"))
            {
                C1_F();
            }
            else if (Con_Name.Equals("line_C3_D") || Con_Name.Equals("line_C3_F") || Con_Name.Equals("label_C3"))
            {
                C3_F();
            }
            else if (Con_Name.Equals("line_C5_D") || Con_Name.Equals("line_C5_F") || Con_Name.Equals("label_C5"))
            {
                C5_F();
            }
            else if (Con_Name.Equals("line_C7_D") || Con_Name.Equals("line_C7_F") || Con_Name.Equals("label_C7"))
            {
                C7_F();
            }
            else if (Con_Name.Equals("line_C9_D") || Con_Name.Equals("line_C9_F") || Con_Name.Equals("label_C9"))
            {
                C9_F();
            }
            else if (Con_Name.Equals("line_C11_D") || Con_Name.Equals("line_C11_F") || Con_Name.Equals("label_C11"))
            {
                C11_F();
            }


        }
        //道岔右键菜单-故障设置-失去表示
        public void Dc_Functions_S(object sender, EventArgs e)
        {
            if (Con_Name.Equals("line_C1_D") || Con_Name.Equals("line_C1_F") || Con_Name.Equals("label_C1"))
            {
                C1_S();
            }
            else if (Con_Name.Equals("line_C3_D") || Con_Name.Equals("line_C3_F") || Con_Name.Equals("label_C3"))
            {
                C3_S();
            }
            else if (Con_Name.Equals("line_C5_D") || Con_Name.Equals("line_C5_F") || Con_Name.Equals("label_C5"))
            {
                C5_S();
            }
            else if (Con_Name.Equals("line_C7_D") || Con_Name.Equals("line_C7_F") || Con_Name.Equals("label_C7"))
            {
                C7_S();
            }
            else if (Con_Name.Equals("line_C9_D") || Con_Name.Equals("line_C9_F") || Con_Name.Equals("label_C9"))
            {
                C9_S();
            }
            else if (Con_Name.Equals("line_C11_D") || Con_Name.Equals("line_C11_F") || Con_Name.Equals("label_C11"))
            {
                C11_S();
            }
        }
        //道岔右键菜单-清除故障
        public void Dc_Functions_Q(object sender, EventArgs e)
        {
            if (Con_Name.Equals("line_C1_D") || Con_Name.Equals("line_C1_F") || Con_Name.Equals("label_C1"))
            {
                C1_Q();
            }
            else if (Con_Name.Equals("line_C3_D") || Con_Name.Equals("line_C3_F") || Con_Name.Equals("label_C3"))
            {
                C3_Q();
            }
            else if (Con_Name.Equals("line_C5_D") || Con_Name.Equals("line_C5_F") || Con_Name.Equals("label_C5"))
            {
                C5_Q();
            }
            else if (Con_Name.Equals("line_C7_D") || Con_Name.Equals("line_C7_F") || Con_Name.Equals("label_C7"))
            {
                C7_Q();
            }
            else if (Con_Name.Equals("line_C9_D") || Con_Name.Equals("line_C9_F") || Con_Name.Equals("label_C9"))
            {
                C9_Q();
            }
            else if (Con_Name.Equals("line_C11_D") || Con_Name.Equals("line_C11_F") || Con_Name.Equals("label_C11"))
            {
                C11_Q();
            }
        }
        //道岔右键菜单-设置故障-挤岔
        public void Dc_J(object sender, EventArgs e)
        {
            Point Positon = (Point)this.PointToClient(Control.MousePosition);
            int PositionX = (int)Positon.X;
            MessageBox.Show("positionX:" + PositionX);
            if (PositionX < 540)
            {
                C1_J();
            }
            else if (PositionX > 380 && PositionX < 450)
            {
                C3_J();
            }
            else if (PositionX > 450 && PositionX < 520)
            {
                C5_J();
            }
            else if (PositionX > 520 && PositionX < 650)
            {
                C7_J();
            }
            else if (PositionX > 650 && PositionX < 720)
            {
                C9_J();
            }
            else if (PositionX > 720 && PositionX < 790)
            {
                C11_J();
            }
        }


        //信号机灯光显示
        //X信号机灯光显示
        //正线通过——绿灯
        public void X_L()
        {
            X_D1.BorderColor = Color.Green;
            X_D2.BorderColor = Color.Black;
        }
        //正线接车，侧线发车——黄灯
        public void X_U()
        {
            X_D1.BorderColor = Color.Yellow;
            X_D2.BorderColor = Color.Black;
        }
        //侧线接车——2个黄灯
        public void X_2U()
        {
            X_D1.BorderColor = Color.Yellow;
            X_D2.BorderColor = Color.Yellow;
        }
        //禁止越过信号机——红灯
        public void X_H()
        {
            X_D1.BorderColor = Color.Red;
            X_D2.BorderColor = Color.Black;
        }
        //引导接车——红白灯
        public void X_HB()
        {
            X_D1.BorderColor = Color.White;
            X_D2.BorderColor = Color.Red;
        }


        //XF信号机灯光表示
        //正线通过——绿灯
        public void XF_L()
        {
            XF_D1.BorderColor = Color.Green;
            XF_D2.BorderColor = Color.Black;
        }
        //正线接车，侧线发车——黄灯
        public void XF_U()
        {
            XF_D1.BorderColor = Color.Yellow;
            XF_D2.BorderColor = Color.Black;
        }
        //侧线接车——2个黄灯
        public void XF_2U()
        {
            XF_D1.BorderColor = Color.Yellow;
            XF_D2.BorderColor = Color.Yellow;
        }
        //禁止越过信号机——红灯
        public void XF_H()
        {
            XF_D1.BorderColor = Color.Red;
            XF_D2.BorderColor = Color.Black;
        }
        //引导接车——红白灯
        public void XF_HB()
        {
            XF_D1.BorderColor = Color.White;
            XF_D2.BorderColor = Color.Red;
        }
        //SI信号机灯光表示
        //禁止越过信号机
        public void SI_H()
        {
            SI_D.BorderColor = Color.Red;
        }
        //前方一个区段空闲
        public void SI_U()
        {
            SI_D.BorderColor = Color.Yellow;
        }
        //前方两个区段空闲
        public void SI_L()
        {
            SI_D.BorderColor = Color.Green;
        }


        //SII信号机灯光表示
        //禁止越过信号机
        public void SII_H()
        {
            SII_D.BorderColor = Color.Red;
        }
        //前方一个区段空闲
        public void SII_U()
        {
            SII_D.BorderColor = Color.Yellow;
        }
        //前方两个区段空闲
        public void SII_L()
        {
            SII_D.BorderColor = Color.Green;
        }


        //S3信号机灯光表示
        //禁止越过信号机
        public void S3_H()
        {
            S3_D.BorderColor = Color.Red;
        }
        //前方一个区段空闲
        public void S3_U()
        {
            S3_D.BorderColor = Color.Yellow;
        }
        //前方两个区段空闲
        public void S3_L()
        {
            S3_D.BorderColor = Color.Green;
        }


        //S4信号机灯光表示
        //禁止越过信号机-红灯
        public void S4_H()
        {
            S4_D.BorderColor = Color.Red;
        }
        //前方一个区段空闲-黄灯
        public void S4_U()
        {
            S4_D.BorderColor = Color.Yellow;
        }
        //前方两个区段空闲
        public void S4_L()
        {
            S4_D.BorderColor = Color.Green;
        }


        //D1信号机灯光显示
        //禁止调车-蓝灯
        public void D1_L()
        {
            D1.BorderColor = Color.Blue;
        }
        //允许调车-白灯
        public void D1_B()
        {
            D1.BorderColor = Color.White;
        }


        //D3信号机灯光显示
        //禁止调车-蓝灯
        public void D3_L()
        {
            D3.BorderColor = Color.Blue;
        }
        //允许调车-白灯
        public void D3_B()
        {
            D3.BorderColor = Color.White;
        }


        //D5信号机灯光显示
        //禁止调车-蓝灯
        public void D5_L()
        {
            D5.BorderColor = Color.Blue;
        }
        //允许调车-白灯
        public void D5_B()
        {
            D5.BorderColor = Color.White;
        }


        //D7信号机灯光显示
        //禁止调车-蓝灯
        public void D7_L()
        {
            D7.BorderColor = Color.Blue;
        }
        //允许调车-白灯
        public void D7_B()
        {
            D7.BorderColor = Color.White;
        }


        //D9信号机灯光显示
        //禁止调车-蓝灯
        public void D9_L()
        {
            D9.BorderColor = Color.Blue;
        }
        //允许调车-白灯
        public void D9_B()
        {
            D9.BorderColor = Color.White;
        }


        //轨道区段显示
        //3JG区段状态
        //空闲状态
        public void K_3JG()
        {
            Track_3JG.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_3JG()
        {
            Track_3JG.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_3JG()
        {
            Track_3JG.BorderColor = Color.White;
        }


        //3DG_1区段状态
        //空闲状态
        public void K_3DG_1()
        {
            Track_3DG_1.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_3DG_1()
        {
            Track_3DG_1.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_3DG_1()
        {
            Track_3DG_1.BorderColor = Color.White;
        }
        //3DG_2区段状态
        //空闲状态
        public void K_3DG_2()
        {
            Track_3DG_2.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_3DG_2()
        {
            Track_3DG_2.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_3DG_2()
        {
            Track_3DG_2.BorderColor = Color.White;
        }


        //5DG_1区段状态
        //空闲状态
        public void K_5DG_1()
        {
            Track_5DG_1.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_5DG_1()
        {
            Track_5DG_1.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_5DG_1()
        {
            Track_5DG_1.BorderColor = Color.White;
        }
        //5DG_2区段状态
        //空闲状态
        public void K_5DG_2()
        {
            Track_5DG_2.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_5DG_2()
        {
            Track_5DG_2.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_5DG_2()
        {
            Track_5DG_2.BorderColor = Color.White;
        }


        //9DG_1区段状态
        //空闲状态
        public void K_9DG_1()
        {
            Track_9DG_1.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_9DG_1()
        {
            Track_9DG_1.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_9DG_1()
        {
            Track_9DG_1.BorderColor = Color.White;
        }
        //9DG_2区段状态
        //空闲状态
        public void K_9DG_2()
        {
            Track_9DG_2.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_9DG_2()
        {

            Track_9DG_2.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_9DG_2()
        {
            Track_9DG_2.BorderColor = Color.White;
        }
        //9DG_3区段状态
        //空闲状态
        public void K_9DG_3()
        {
            Track_9DG_3.BorderColor = Color.FromArgb(82, 120, 182);
            Track_9DG_4.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_9DG_3()
        {
            Track_9DG_3.BorderColor = Color.Red;
            Track_9DG_4.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_9DG_3()
        {
            Track_9DG_3.BorderColor = Color.White;
            Track_9DG_4.BorderColor = Color.White;
        }


        //1LQ区段状态
        //空闲状态
        public void K_1LQ()
        {
            Track_1LQ.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_1LQ()
        {
            Track_1LQ.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_1LQ()
        {
            Track_1LQ.BorderColor = Color.White;
        }


        //IIAG区段状态
        //空闲状态
        public void K_IIAG()
        {
            Track_IIAG.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_IIAG()
        {
            Track_IIAG.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_IIAG()
        {
            Track_IIAG.BorderColor = Color.White;
        }


        //1DG_1区段状态
        //空闲状态
        public void K_1DG_1()
        {
            Track_1DG_1.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_1DG_1()
        {
            Track_1DG_1.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_1DG_1()
        {
            Track_1DG_1.BorderColor = Color.White;
        }
        //1DG_2区段状态
        //空闲状态
        public void K_1DG_2()
        {
            Track_1DG_2.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_1DG_2()
        {
            Track_1DG_2.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_1DG_2()
        {
            Track_1DG_2.BorderColor = Color.White;
        }


        //7DG_1区段状态
        //空闲状态
        public void K_7DG_1()
        {
            Track_7DG_1.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_7DG_1()
        {
            Track_7DG_1.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_7DG_1()
        {
            Track_7DG_1.BorderColor = Color.White;
        }
        //7DG_2区段状态
        //空闲状态
        public void K_7DG_2()
        {
            Track_7DG_2.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_7DG_2()
        {
            Track_7DG_2.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_7DG_2()
        {
            Track_7DG_2.BorderColor = Color.White;
        }


        //11DG_1区段状态
        //空闲状态
        public void K_11DG_1()
        {
            Track_11DG_1.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_11DG_1()
        {
            Track_11DG_1.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_11DG_1()
        {
            Track_11DG_1.BorderColor = Color.White;
        }
        //11DG_2区段状态
        //空闲状态
        public void K_11DG_2()
        {

            Track_11DG_2.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_11DG_2()
        {
            Track_11DG_2.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_11DG_2()
        {
            Track_11DG_2.BorderColor = Color.White;
        }
        //11DG_3区段状态
        //空闲状态
        public void K_11DG_3()
        {
            Track_11DG_3.BorderColor = Color.FromArgb(82, 120, 182);
            Track_11DG_4.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_11DG_3()
        {
            Track_11DG_3.BorderColor = Color.Red;
            Track_11DG_4.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_11DG_3()
        {
            Track_11DG_3.BorderColor = Color.White;
            Track_11DG_4.BorderColor = Color.White;
        }


        //IG区段状态
        //空闲状态
        public void K_IG()
        {
            Track_IG.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_IG()
        {
            Track_IG.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_IG()
        {
            Track_IG.BorderColor = Color.White;
        }


        //IIG区段状态
        //空闲状态
        public void K_IIG()
        {
            Track_IIG.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_IIG()
        {
            Track_IIG.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_IIG()
        {
            Track_IIG.BorderColor = Color.White;
        }


        //3G区段状态1
        //空闲状态
        public void K_3G()
        {
            Track_3G.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_3G()
        {
            Track_3G.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_3G()
        {
            Track_3G.BorderColor = Color.White;
        }


        //4G区段状态
        //空闲状态
        public void K_4G()
        {
            Track_4G.BorderColor = Color.FromArgb(82, 120, 182);
        }
        //占用状态
        public void Z_4G()
        {
            Track_4G.BorderColor = Color.Red;
        }
        //锁闭状态
        public void S_4G()
        {
            Track_4G.BorderColor = Color.White;
        }


        //全局变量，传输控件名称
        //全局变量，接受正在单击的lineshape控件（轨道，道岔）
        public Microsoft.VisualBasic.PowerPacks.LineShape nnn = null;

        //全局变量，接受正在单击的label控件
        public Label kkk = null;
        //全局变量，接受正在单击的控件名称
        public string Con_Name = "";

        //获取轨道区段/道岔名称的函数
        public void Trans_name_G(object sender, EventArgs e)
        {
            Con_Name = nnn.Name;
        }
        //全局变量，接受正在单击的Rectangleshape控件（信号机）
        public Microsoft.VisualBasic.PowerPacks.RectangleShape mmm = null;
        //获取信号机按钮名称的函数
        public void Trans_name_X(object sender, EventArgs e)
        {
            Con_Name = mmm.Name;
        }
        //获取label名称的函数
        public void Trans_name_L(object sender, EventArgs e)
        {
            Con_Name = kkk.Name;
        }
        //轨道区段占用显示
        public void Gd_Functions_Z(object sender, EventArgs e)
        {
            //3JG
            if (Con_Name.Equals("line_3JG") || Con_Name.Equals("label_3JG"))
            {
                Z_3JG();
            }
            //3DG
            else if (Con_Name.Equals("line_3DG_1") || Con_Name.Equals("line_3DG_2") || Con_Name.Equals("label_3DG"))
            {
                Z_3DG_1();
                Z_3DG_2();
            }
            //5DG
            else if (Con_Name.Equals("line_5DG_1") || Con_Name.Equals("line_5DG_2") || Con_Name.Equals("label_5DG"))
            {
                Z_5DG_1();
                Z_5DG_2();
            }
            //9DG
            else if (Con_Name.Equals("line_9DG_1") || Con_Name.Equals("line_9DG_2") || Con_Name.Equals("label_9DG"))
            {
                Z_9DG_1();
                Z_9DG_2();
                Z_9DG_3();
            }
            //1LQ
            else if (Con_Name.Equals("line_1LQ") || Con_Name.Equals("label_1LQ"))
            {
                Z_1LQ();
            }
            //IIAG
            else if (Con_Name.Equals("line_IIAG") || Con_Name.Equals("label_IIAG"))
            {
                Z_IIAG();
            }
            //1DG
            else if (Con_Name.Equals("line_1DG_1") || Con_Name.Equals("line_1DG_2") || Con_Name.Equals("label_1DG"))
            {
                Z_1DG_1();
                Z_1DG_2();
            }
            //7DG
            else if (Con_Name.Equals("line_7DG_1") || Con_Name.Equals("line_7DG_2") || Con_Name.Equals("label_7DG"))
            {
                Z_7DG_1();
                Z_7DG_2();
            }
            //11Dg
            else if (Con_Name.Equals("line_11DG_1") || Con_Name.Equals("line_11DG_2") || Con_Name.Equals("label_11DG"))
            {
                Z_11DG_1();
                Z_11DG_2();
                Z_11DG_3();
            }
            //IG
            else if (Con_Name.Equals("line_IG") || Con_Name.Equals("label_IG"))
            {
                Z_IG();
            }
            //IIG
            else if (Con_Name.Equals("line_IIG") || Con_Name.Equals("label_IIG"))
            {
                Z_IIG();
            }
            //3G
            else if (Con_Name.Equals("line_3G") || Con_Name.Equals("label_3G"))
            {
                Z_3G();
            }
            //4G
            else if (Con_Name.Equals("line_4G") || Con_Name.Equals("label_4G"))
            {
                Z_4G();
            }
        }
        //轨道区段空闲显示
        public void Gd_Functions_C(object sender, EventArgs e)
        {
            //3JG
            if (Con_Name.Equals("Track_3JG") || Con_Name.Equals("label_3JG"))
            {
                K_3JG();
            }
            //3DG
            else if (Con_Name.Equals("Track_3DG_1") || Con_Name.Equals("Track_3DG_2") || Con_Name.Equals("label_3DG"))
            {
                K_3DG_1();
                K_3DG_2();
            }
            //5DG
            else if (Con_Name.Equals("Track_5DG_1") || Con_Name.Equals("Track_5DG_2") || Con_Name.Equals("label_5DG"))
            {
                K_5DG_1();
                K_5DG_2();
            }
            //9DG
            else if (Con_Name.Equals("Track_9DG_1") || Con_Name.Equals("Track_9DG_2") || Con_Name.Equals("label_9DG"))
            {
                K_9DG_1();
                K_9DG_2();
                K_9DG_3();
            }
            //1LQ
            else if (Con_Name.Equals("Track_1LQ") || Con_Name.Equals("label_1LQ"))
            {
                K_1LQ();
            }
            //IIAG
            else if (Con_Name.Equals("Track_IIAG") || Con_Name.Equals("label_IIAG"))
            {
                K_IIAG();
            }
            //1DG
            else if (Con_Name.Equals("Track_1DG_1") || Con_Name.Equals("Track_1DG_2") || Con_Name.Equals("label_1DG"))
            {
                K_1DG_1();
                K_1DG_2();
            }
            //7DG
            else if (Con_Name.Equals("Track_7DG_1") || Con_Name.Equals("Track_7DG_2") || Con_Name.Equals("label_7DG"))
            {
                K_7DG_1();
                K_7DG_2();
            }
            //11Dg
            else if (Con_Name.Equals("Track_11DG_1") || Con_Name.Equals("Track_11DG_2") || Con_Name.Equals("label_11DG"))
            {
                K_11DG_1();
                K_11DG_2();
                K_11DG_3();
            }
            //IG
            else if (Con_Name.Equals("Track_IG") || Con_Name.Equals("label_IG"))
            {
                K_IG();
            }
            //IIG
            else if (Con_Name.Equals("Track_IIG") || Con_Name.Equals("label_IIG"))
            {
                K_IIG();
            }
            //3G
            else if (Con_Name.Equals("Track_3G") || Con_Name.Equals("label_3G"))
            {
                K_3G();
            }
            //4G
            else if (Con_Name.Equals("Track_4G") || Con_Name.Equals("label_4G"))
            {
                K_4G();
            }
        }
        //轨道区段锁闭显示
        public void Gd_Functions_S(object sender, EventArgs e)
        {
            //3JG
            if (Con_Name.Equals("Track_3JG") || Con_Name.Equals("label_3JG"))
            {
                S_3JG();
            }
            //3DG
            else if (Con_Name.Equals("Track_3DG_1") || Con_Name.Equals("Track_3DG_2") || Con_Name.Equals("label_3DG"))
            {
                S_3DG_1();
                S_3DG_2();
            }
            //5DG
            else if (Con_Name.Equals("Track_5DG_1") || Con_Name.Equals("Track_5DG_2") || Con_Name.Equals("label_5DG"))
            {
                S_5DG_1();
                S_5DG_2();
            }
            //9DG
            else if (Con_Name.Equals("Track_9DG_1") || Con_Name.Equals("Track_9DG_2") || Con_Name.Equals("label_9DG"))
            {
                S_9DG_1();
                S_9DG_2();
                K_9DG_3();
            }
            //1LQ
            else if (Con_Name.Equals("Track_1LQ") || Con_Name.Equals("label_1LQ"))
            {
                S_1LQ();
            }
            //IIAG
            else if (Con_Name.Equals("Track_IIAG") || Con_Name.Equals("label_IIAG"))
            {
                S_IIAG();
            }
            //1DG
            else if (Con_Name.Equals("Track_1DG_1") || Con_Name.Equals("Track_1DG_2") || Con_Name.Equals("label_1DG"))
            {
                S_1DG_1();
                S_1DG_2();
            }
            //7DG
            else if (Con_Name.Equals("Track_7DG_1") || Con_Name.Equals("Track_7DG_2") || Con_Name.Equals("label_7DG"))
            {
                S_7DG_1();
                S_7DG_2();
            }
            //11Dg
            else if (Con_Name.Equals("Track_11DG_1") || Con_Name.Equals("Track_11DG_2") || Con_Name.Equals("label_11DG"))
            {
                S_11DG_1();
                S_11DG_2();
                S_11DG_3();
            }
            //IG
            else if (Con_Name.Equals("Track_IG") || Con_Name.Equals("label_IG"))
            {
                S_IG();
            }
            //IIG
            else if (Con_Name.Equals("Track_IIG") || Con_Name.Equals("label_IIG"))
            {
                S_IIG();
            }
            //3G
            else if (Con_Name.Equals("Track_3G") || Con_Name.Equals("label_3G"))
            {
                S_3G();
            }
            //4G
            else if (Con_Name.Equals("Track_4G") || Con_Name.Equals("label_4G"))
            {
                S_4G();
            }
        }
        //信号机故障设置：灯丝断丝
        public void X_Functions_D(object sender, EventArgs e)
        {
            X_D1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            X_D2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
            X_1DJ.BackColor = Color.Red;
        }
        //信号机清除故障：灯丝完好
        public void X_Functions_Q(object sender, EventArgs e)
        {
            X_D1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            X_D2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            X_1DJ.BackColor = Color.Lime;
        }
        
        //信号机灯光显示
        //红灯
        public void RedLight(Signal signal)
        {

        }

        public void CBI_Load(object sender, EventArgs e)
        {

        }
        //站场显示刷新
        //轨道区段
        public void RefreshTrackDisplay(Track track)
        {
            track.Name = Con_Name;
            if (track.DGJ == true && track.Locking == false&&track.Guiding==false)
            {
                Gd_Functions_C(track,null);
            }
            else if (track.DGJ == true && track.Locking == true )
            {
                Gd_Functions_S(track, null);
            }
            else if(track.DGJ==true&&track.Guiding==true)
            {
                Gd_Functions_S(track, null);
            }
            else if (track.DGJ==false)
            {
                Gd_Functions_Z(track, null);
            }
        }
        //信号机
        public void RefreshSignalDisplay(Signal signal)
        {
            if(signal is InboundSignal)//进站信号机
            {
                if(signal.State==0)//0代表禁止越过，红灯
                {
                    
                }
                else if(signal.State==1)//1代表正线通过，绿灯（本次程序当中用不到）
                {

                }
                else if (signal.State == 2)//2代表正线接车，黄灯
                {

                }
                else if (signal.State == 3)//3代表侧线接车，双黄灯
                {

                }
                else if (signal.State == 4)//4代表引导接车，红白灯
                {

                }
                else
                {

                }
            }
            else if(signal is ShuntingSignal)//调车信号机
            {
                if(signal.State==0)//禁止越过（接发车进路当中不检查调车信号机）
                {

                }
                else if(signal.State==5)//允许调车
                {

                }
                else
                {

                }
            }
            else
            {
                if(signal.State==0)//禁止越过
                {

                }
                else if(signal.State==5)//允许调车
                {

                }
                else if(signal.State==6)//发车
                {

                }
            }
        }

        //道岔
        public void RefreshSwitchDisplay()
        {

        }
    }
}
