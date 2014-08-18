using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CodeGenerate.Common;
using CodeGenerate.DataAccess;
using CodeGenerate.Model;


namespace CodeGenerate.Business
{
    /// <summary>
    /// 数据表详细字段业务类
    /// </summary>
    public class DataColumnBll
    {
        private static DataColumnBll _instance;

        public static DataColumnBll GetInstance()
        {
            return _instance ?? (_instance = new DataColumnBll());
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="db">数据库名称</param>
        /// <param name="table">表名</param>
        /// <returns></returns>
        public IList<DataColumnInfo> GetList(string db, string table)
        {
            return DataColumnDal.GetInstance().GetList(db, table);
        }
    }
}
