using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CodeGenerate.Common;
using CodeGenerate.Model;

namespace CodeGenerate.DataAccess
{
    /// <summary>
    /// 数据库数据访问类
    /// </summary>
    public class DataBaseDal
    {
        private static DataBaseDal _instance;

        public static DataBaseDal GetInstance()
        {
            return _instance ?? (_instance = new DataBaseDal());
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public IList<DataBaseInfo> GetList()
        {
            var strSql = new StringBuilder(10);
            strSql.Append("use master;");
            strSql.Append("SELECT Name FROM sys.databases where Name not in ('master','msdb','tempdb','model') ORDER BY Name;");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnString, CommandType.Text, strSql.ToString());
            var list = new List<DataBaseInfo>();
            if (Utils.HasMoreRow(ds))
            {
                list.AddRange(from DataRow dr in ds.Tables[0].Rows select DataRowToModel(dr));
            }
            return list;
        }
        /// <summary>
        /// 转换实体
        /// </summary>
        /// <param name="row">数据行</param>
        /// <returns></returns>
        private DataBaseInfo DataRowToModel(DataRow row)
        {
            var model = new DataBaseInfo();
            if (row != null)
            {
                if (!row["Name"].IsNullOrEmpty())
                {
                    model.Name = row["Name"].ToStringValue();
                }
            }
            return model;
        }
    }
}
