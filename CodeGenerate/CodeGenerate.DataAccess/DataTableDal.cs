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
    /// 数据表数据访问类
    /// </summary>
    public class DataTableDal
    {
        private static DataTableDal _instance;

        public static DataTableDal GetInstance()
        {

            return _instance ?? (_instance = new DataTableDal());
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="db">数据库名称</param>
        /// <returns></returns>
        public IList<DataTableInfo> GetList(string db)
        {
            var strSql = new StringBuilder(10);
            strSql.AppendFormat("use {0};", db);
            strSql.Append(" select sys.tables.NAME, ");
            strSql.Append(" (SELECT sys.extended_properties.VALUE FROM sys.extended_properties ");
            strSql.Append(" where minor_ID=0   ");
            strSql.Append(" and sys.extended_properties.Major_ID=sys.tables.Object_ID  ");
            strSql.Append(" and sys.extended_properties.name='MS_Description' ");
            strSql.Append(" ) AS description ");
            strSql.Append(" from sys.tables ");
            strSql.Append(" order by sys.tables.NAME; ");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnString, CommandType.Text, strSql.ToString());
            var list = new List<DataTableInfo>();
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
        private DataTableInfo DataRowToModel(DataRow row)
        {
            var model = new DataTableInfo();
            if (row != null)
            {
                if (!row["Name"].IsNullOrEmpty())
                {
                    model.Name = row["Name"].ToStringValue();
                }
                if (!row["Description"].IsNullOrEmpty())
                {
                    model.Description = row["Description"].ToStringValue();
                }
            }
            return model;
        }
    }
}
