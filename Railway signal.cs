using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_interlocking_system.Properties
{
    class Railway_signal
    {
        /// <summary>
        /// 信号机名称
        /// </summary>
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 信号机左边关联设备名称
        /// </summary>
        private string _l_name;
        public string l_name
        {
            get { return _l_name; }
            set { _l_name = value; }
        }
        /// <summary>
        /// 信号机右边关联设备名称
        /// </summary>
        private string _r_name;
        public string r_name
        {
            get { return _r_name; }
            set { _r_name = value; }
        }
        /// <summary>
        /// 接近区段名称
        /// </summary>
        private string _J_name;
        public string J_name
        {
            get { return _J_name; }
            set { _J_name = value; }
        }
        /// <summary>
        /// 防护内方第一个道岔名称
        /// </summary>
        private string _D_name;
        public string D_name
        {
            get { return _D_name; }
            set { _D_name = value; }
        }
        /// <summary>
        /// 防护内方第一个区段名称
        /// </summary>
        private string _Q_name;
        public string q_name
        {
            get { return _Q_name; }
            set { _Q_name = value; }
        }
        /// <summary>
        /// 在信号机类当中定义布尔类型的LXJ变量
        /// </summary>
        private bool _LXJ;//字段
        public bool LXJ//属性
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
        private bool _1DJ;
        public bool DJ1
        {
            get { return _1DJ; }
            set { _1DJ = value; }
        }
        private bool _2DJ;
        public bool DJ2
        {
            get { return _2DJ; }
            set { _2DJ = value; }
        }
        public void Railway_signal_F()
        {

        }
    }
}
