using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_interlocking_system
{
    //轨道区段类
    class Track
    {
        /// <summary>
        /// 轨道区段名称，需要初始化的时候写入
        /// </summary>
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 本区段左边区段名称
        /// </summary>
        private string  _l_track;
        public string L_name
        {
            get { return _l_track; }
            set { _l_track = value; }
        }
        /// <summary>
        /// 本区段右边区段名称
        /// </summary>
        private string _r_track;
        public string R_name
        {
            get { return _r_track; }
            set { _r_track = value; }
        }
        /// <summary>
        /// 轨道区段继电器，TRUE代表正常，FALSE代表故障
        /// </summary>
        private bool _DGJ;
        public bool DGJ
        {
            get { return _DGJ; }
            set { _DGJ = value; }
        }
        private bool _locking;
        /// <summary>
        /// 进路锁闭状态指示，TRUE代表进路锁闭，FALSE代表进路空闲
        /// </summary>
        public bool Locking
        {
            get { return _locking; }
            set { _locking = value; }
        }
        /// <summary>
        /// 引导锁闭状态指示，TRUE代表引导锁闭，FALSE代表没有引导锁闭
        /// </summary>
        private bool _guiding;
        public bool Guiding
        {
            get { return _guiding; }
            set { _guiding = value; }
        }
        /// <summary>
        /// 进路类型指示，0代表接车进路，1代表发车进路，2代表调车进路
        /// </summary>
        private int _direction;
        public int Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        /// <summary>
        /// 构造函数,自动初始化DGJ Locking Guiding字段，手动初始化区段名称，左边/右边区段名称
        /// </summary>
        public Track(string name,string lname,string rname)
        {
            Name = name;
            L_name = lname;
            R_name = rname;
            this.DGJ = true;
            this._locking = false;
            this._guiding = false;
        }
        /// <summary>
        /// 轨道区段在进路当中的处理
        /// </summary>
        public void TrackOperation()
        {
            //正常进路处理过程
            //第一步检查进路状态
            if(DGJ==false)
            {
                MessageBox.Show("轨道区段" + this.Name + "存在故障，无法排列进路");
            }
            else
            {
                //第二步，选路设置，主要工作集中在道岔定反位操作，轨道区段不理睬
                //第三步，锁闭条件检查，同上
                //第四步,锁闭设置，根据进路类型对Locking Guiding字段操作（正常进路）
                Locking = true;
                Guiding = false;
                //第五步，开放信号检查，再次检查有无故障，有故障则转为引导进路(注意信号机灯光变换)
                if(true)//此处为指示进路当中是否有故障的全局变量
                {
                    //以下是正常建立进路

                }
                else
                {
                    Guiding = true;
                    //以下是建立引导进路

                }
                //第六步，手动模拟行车，注意信号机灯光变换
                //正常进路锁闭，区段被占用，出清，直接进入空闲状态，结束
                //引导进路锁闭，区段被占用，出清，进路处于仍然处于锁闭状态，需要总人解或区故解
            }
        }
    }
}
