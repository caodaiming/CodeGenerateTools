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
    /// 数据表业务类
    /// </summary>
    public class DataTableBll
    {
        private static DataTableBll _instance;

        public static DataTableBll GetInstance()
        {
            return _instance ?? (_instance = new DataTableBll());
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="db">数据库名称</param>
        /// <returns></returns>
        public IList<DataTableInfo> GetList(string db)
        {
            return DataTableDal.GetInstance().GetList(db);
        }
        public string GetMenu(string db)
        {
            var builder = new StringBuilder();
            builder.AppendLine("<div class=\"easyui-accordion\" fit=\"true\">");
            builder.AppendLine("<div title=\"努力工作，快乐生活！\">");
            string strTwo = GetTwoMenu(db);
            if (!strTwo.IsNullOrEmpty())
            {
                builder.AppendLine(strTwo);
            }
            builder.AppendLine("</div>");
            builder.AppendLine("</div>");
            return builder.ToString();
        }
        private string GetTwoMenu(string db)
        {
            var builder = new StringBuilder();
            var twoList = DataTableDal.GetInstance().GetList(db);
            if (twoList.Count > 0)
            {

                var strTwoMenu = new StringBuilder();
                foreach (var twoMenu in twoList)
                {
                    strTwoMenu.AppendFormat("<li><a link=\"DataColumn/?db={0}&table={1}\">{2}({1})</a></li>", db,
                                            twoMenu.Name, twoMenu.Description);
                }
                if (!strTwoMenu.IsNullOrEmpty())
                {
                    builder.AppendLine("<ul class=\"easyui-tree\">");
                    builder.AppendLine(strTwoMenu.ToString());
                    builder.AppendLine("</ul>");
                }
            }
            return builder.ToString();
        }
    }
}
