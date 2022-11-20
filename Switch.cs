using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_interlocking_system
{
    //道岔类
    class Switch
    {
        //道岔名称
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //双动道岔另一边的名称
        private string _a_name;
        public string A_name
        {
            get { return _a_name; }
            set { _a_name = value; }
        }
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
        /// 反位表示继电器
        private bool _FBJ;
        public bool FBJ
        {
            get { return _FBJ; }
            set { _FBJ = value; }
        }
        /// <summary>
        /// 构造函数，道岔名称手动初始化，其他变量全部自动给初始化
        /// </summary>
        public Switch(string name,string aname)
        {
            Name = name;
            A_name = aname;
            YCJ = true;
            DCJ = false;
            RelaySwitch(DCJ);//道岔定反位转换时，只对DCJ这一个继电器进行赋值
        }
        public Switch(string name)
        {
            Name = name;
            YCJ = true;
            DCJ = false;
            RelaySwitch(DCJ);//道岔定反位转换时，只对DCJ这一个继电器进行赋值
        }
        /// <summary>
        /// 继电器状态转换函数
        /// </summary>
        public void RelaySwitch(bool J)
        {
            if(YCJ==true)//允许操作继电器吸起，道岔才可以转换
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
    }
}
