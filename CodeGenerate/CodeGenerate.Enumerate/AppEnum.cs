using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CodeGenerate.Enumerate
{
    /// <summary>
    /// 是否自增长
    /// </summary>
    public enum IsIdentity
    {
        [Description("否")]
        No = 0,
        [Description("是")]
        Yes = 1
    }
    /// <summary>
    /// 是否主键
    /// </summary>
    public enum IsKey
    {
        [Description("×")]
        No = 0,
        [Description("√")]
        Yes = 1
    }
    /// <summary>
    /// 是否可空
    /// </summary>
    public enum IsNullable
    {
        [Description("×")]
        No = 0,
        [Description("√")]
        Yes = 1
    }
}
