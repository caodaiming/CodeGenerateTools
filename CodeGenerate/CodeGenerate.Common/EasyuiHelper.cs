using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerate.Common
{
    public class datagrid
    {
        public datagrid(int total, dynamic rows)
        {
            this.total = total;
            this.rows = rows;
        }
        public datagrid(int total, dynamic cols, dynamic rows)
        {
            this.total = total;
            this.cols = cols;
            this.rows = rows;
        }
        /// <summary>
        /// 总数
        /// </summary>
        public int total;
        /// <summary>
        /// 列数据集
        /// </summary>
        public dynamic cols;
        /// <summary>
        /// 行数据集
        /// </summary>
        public dynamic rows;
    }
    public class cols
    {
        public cols(string field, string title, string align, int width)
        {
            this.field = field;
            this.title = title;
            this.align = align;
            this.width = width;
        }
        public string field;
        public string title;
        public string align;
        public int width;
    }
    public class treegrid
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string id;
        /// <summary>
        /// 显示内容
        /// </summary>
        public string text;
        /// <summary>
        /// 图标
        /// </summary>
        public string iconCls;
        /// <summary>
        /// 当前是展开还是收缩的状态
        /// </summary>
        public string state;
        public string Remark;
        /// <summary>
        /// 子节点集合
        /// </summary>
        public List<treegrid> children = new List<treegrid>();
    }
    public class Tree
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string id;
        /// <summary>
        /// 显示内容
        /// </summary>
        public string text;
        /// <summary>
        /// 图标
        /// </summary>
        public string iconCls;
        /// <summary>
        /// 是否被选中，checked为C#关键字，所以前面加@
        /// </summary>
        public bool @checked = false;
        /// <summary>
        /// 当前是展开还是收缩的状态
        /// </summary>
        public string state;
        /// <summary>
        /// 子节点集合
        /// </summary>
        public List<Tree> children = new List<Tree>();
        public string attributes { get; set; }
    }
    public class combobox
    {
        public string id { set; get; }
        public string text { set; get; }
        public bool selected { set; get; }
    }
    public class charts
    {
        public charts(string label, string value)
        {
            this.label = label;
            this.value = value;
        }
        public string label;
        public string value;
    }
    public class linecharts
    {
        public linecharts(string label, string value)
        {
            this.label = label;
            this.value = value;
        }
        public string label;
        public string value;
    }
}
