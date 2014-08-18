using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerate.Model
{
    /// <summary>
    /// 数据表详细字段实体类
    /// </summary>
    public class DataColumnInfo
    {
        /// <summary>
        /// 字段序号
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 字段名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 自增长
        /// </summary>
        public int IsIdentity { set; get; }
        public string IsIdentityDesc { set; get; }
        /// <summary>
        /// 标识种子
        /// </summary>
        public int IdentSeed { set; get; }
        /// <summary>
        /// 递增量
        /// </summary>
        public int IdentIncr { set; get; }
        /// <summary>
        /// 是否为主键
        /// </summary>
        public int IsKey { set; get; }
        public string IsKeyDesc { set; get; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string Type { set; get; }
        /// <summary>
        /// 占用字节数
        /// </summary>
        public int Bytes { set; get; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { set; get; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int Scale { set; get; }
        /// <summary>
        /// 允许空
        /// </summary>
        public int IsNullable { set; get; }
        public string IsNullableDesc { set; get; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { set; get; }
        /// <summary>
        /// 字段说明
        /// </summary>
        public string Description { set; get; }
    }
}
