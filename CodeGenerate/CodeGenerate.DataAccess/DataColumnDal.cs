using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CodeGenerate.Common;
using CodeGenerate.Model;
using CodeGenerate.Enumerate;

namespace CodeGenerate.DataAccess
{
    /// <summary>
    /// 数据表详细字段数据访问类
    /// </summary>
    public class DataColumnDal
    {
        private static DataColumnDal _instance;

        public static DataColumnDal GetInstance()
        {
            return _instance ?? (_instance = new DataColumnDal());
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="db">数据库名称</param>
        /// <param name="table">表名</param>
        /// <returns></returns>
        public IList<DataColumnInfo> GetList(string db, string table)
        {
            var strSql = new StringBuilder(10);
            strSql.AppendFormat("use {0};", db);
            strSql.Append(" SELECT a.colorder AS 'Id',a.name AS 'Name', ");
            strSql.Append(" case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '1' else '0' END AS 'IsIdentity', ");
            strSql.Append(" case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then IDENT_SEED(d.name) else null END AS 'IdentSeed', ");
            strSql.Append(" case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then IDENT_INCR(d.name) else null END AS 'IdentIncr', ");
            strSql.Append(" case when exists(SELECT 1 FROM sysobjects where xtype='PK' and name in ( ");
            strSql.Append(" SELECT name FROM sysindexes WHERE indid in( ");
            strSql.Append(" SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid)))  ");
            strSql.Append(" then '1' else '0' END AS 'IsKey', ");
            strSql.Append(" b.name AS 'Type',a.length AS 'Bytes', ");
            strSql.Append(" COLUMNPROPERTY(a.id,a.name,'PRECISION') AS 'Length', ");
            strSql.Append(" isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0) AS 'Scale', ");
            strSql.Append(" case when a.isnullable=1 then '1' else '0' END AS 'IsNullable', ");
            strSql.Append(" isnull(e.text,'') AS 'DefaultValue',isnull(g.[value],'') AS 'Description' ");
            strSql.Append(" FROM syscolumns a ");
            strSql.Append(" left join systypes b on a.xtype=b.xusertype ");
            strSql.Append(" inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties' ");
            strSql.Append(" left join syscomments e on a.cdefault=e.id ");
            strSql.Append(" left join sys.extended_properties g on d.id=g.major_id and a.colid=g.minor_id  ");
            strSql.AppendFormat(" where d.name='{0}' ", table);
            strSql.Append(" order by a.id,a.colorder ");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnString, CommandType.Text, strSql.ToString());
            var list = new List<DataColumnInfo>();
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
        public DataColumnInfo DataRowToModel(DataRow row)
        {
            var model = new DataColumnInfo();
            if (row != null)
            {
                if (!row["Id"].IsNullOrEmpty())
                {
                    model.Id = row["Id"].ToInt32();
                }
                if (!row["Name"].IsNullOrEmpty())
                {
                    model.Name = row["Name"].ToStringValue();
                }
                if (!row["IsIdentity"].IsNullOrEmpty())
                {
                    model.IsIdentity = row["IsIdentity"].ToInt32();
                    model.IsIdentityDesc = EnumOperate.GetEnumDesc((IsIdentity) model.IsIdentity);
                }
                if (!row["IdentSeed"].IsNullOrEmpty())
                {
                    model.IdentSeed = row["IdentSeed"].ToInt32();
                }
                if (!row["IdentIncr"].IsNullOrEmpty())
                {
                    model.IdentIncr = row["IdentIncr"].ToInt32();
                }
                if (!row["IsKey"].IsNullOrEmpty())
                {
                    model.IsKey = row["IsKey"].ToInt32();
                    model.IsKeyDesc = EnumOperate.GetEnumDesc((IsKey)model.IsKey);
                }
                if (!row["Type"].IsNullOrEmpty())
                {
                    model.Type = row["Type"].ToStringValue();
                }
                if (!row["Bytes"].IsNullOrEmpty())
                {
                    model.Bytes = row["Bytes"].ToInt32();
                }
                if (!row["Length"].IsNullOrEmpty())
                {
                    model.Length = row["Length"].ToInt32();
                }
                if (!row["Scale"].IsNullOrEmpty())
                {
                    model.Scale = row["Scale"].ToInt32();
                }
                if (!row["IsNullable"].IsNullOrEmpty())
                {
                    model.IsNullable = row["IsNullable"].ToInt32();
                    model.IsNullableDesc = EnumOperate.GetEnumDesc((IsNullable)model.IsNullable);
                }
                if (!row["DefaultValue"].IsNullOrEmpty())
                {
                    model.DefaultValue = row["DefaultValue"].ToStringValue();
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
