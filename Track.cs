using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_interlocking_system
{
    //轨道区段（不区分有岔无岔，主要/次要方向的选择由道岔来完成）
    public class Track
    {
        // 轨道区段名称，需要初始化的时候写入
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        // 本区段左边设备名称(轨道两边可能是道岔/信号机)
        private string _l_name;
        public string L_name
        {
            get { return _l_name; }
            set { _l_name = value; }
        }
        // 本区段右边设备名称
        private string _r_name;
        public string R_name
        {
            get { return _r_name; }
            set { _r_name = value; }
        }
        // 轨道区段继电器，TRUE代表占用，FALSE代表空闲
        private bool _DGJ;
        public bool DGJ
        {
            get { return _DGJ; }
            set { _DGJ = value; }
        }
        private bool _locking;
        // 进路锁闭状态指示，TRUE代表进路锁闭
        public bool Locking
        {
            get { return _locking; }
            set { _locking = value; }
        }
        // 引导锁闭状态指示，TRUE代表引导锁闭
        private bool _guiding;
        public bool Guiding
        {
            get { return _guiding; }
            set { _guiding = value; }
        }

        // 构造函数,自动初始化DGJ Locking Guiding字段，手动初始化区段名称，左边/右边区段名称
        public Track(string name,string lname,string rname)
        {
            Name = name;
            L_name = lname;
            R_name = rname;
            this.DGJ = true;
            this._locking = false;
            this._guiding = false;
        }
        // 检查轨道区段是否空闲
        public bool IsTrackFree()
        {
            if(DGJ==false&&Locking==false&&Guiding==false)
            {
                return true;
            }
            else
            {
                MessageBox.Show("轨道区段" + this.Name + "存在故障或已经锁闭");
                return false;
            }
        }
        //将该轨道区段锁闭（正常进路）
        public bool LockNormalRoute()
        {
            this.Locking = true;
            this.Guiding = false;
            
            return true;
        }
        //将该轨道区段锁闭（引导进路）
        public bool LockGuideRoute()
        {
            Locking = true;
            Guiding = false;

            return true;
        }
        //将该区段从正常进路解锁
        public bool UnlockNormalrelease()
        {
            if(DGJ==true)
            {
                Locking = false;
                Guiding = false;
                DGJ = false;
                return true;
            }
            else
            {
                MessageBox.Show("轨道区段" + this.Name + "存在故障或已建立引导进路，无法解锁");
                return false;
            }
        }
        //将该区段从引导进路解锁
        public bool UnlockGuideRelease()
        {
            if(DGJ==true)
            {
                this.Locking = false;
                this.Guiding = false;
                DGJ = false;
                return true;
            }
            else
            {
                MessageBox.Show("轨道区段"+this.Name+"存在故障或无需引导解锁");
                return false;
            }  
        }
        //故障/列车占用设置
        public void SetFaultOrOccupy()
        {
            DGJ = false;
        }
        //自动返回列车进路下一个轨道区段名称
        //RouteDirection:进路方向，0代表接车进路，1代表发车进路，2代表向右调车，3代表向左调车
        public string GetNextTrack(int RouteDirection)
        {
            if(RouteDirection == 0||RouteDirection==2)
            {
                return this.R_name;
            }
            else
            {
                return this.L_name;
            }
        }
    }
}
