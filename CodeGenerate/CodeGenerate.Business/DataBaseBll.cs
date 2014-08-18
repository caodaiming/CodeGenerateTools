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
    /// 数据库业务类
    /// </summary>
    public class DataBaseBll
    {
        private static DataBaseBll _instance;

        public static DataBaseBll GetInstance()
        {
            return _instance ?? (_instance = new DataBaseBll());
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public IList<DataBaseInfo> GetList()
        {
            return DataBaseDal.GetInstance().GetList();
        }
    }
}
