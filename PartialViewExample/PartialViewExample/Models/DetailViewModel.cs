using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartialViewExample.Models
{
    public class DetailViewModel
    {
        public MasterInfo Master { get; set; }
        public IEnumerable<DetailInfo> Details { get; set; }
    }

    public class DetailInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MasterInfo
    {
        public int Id { get; set; }
        public string No { get; set; }
    }

    public class PaginationInfo
    {
        /// <summary>
        /// 頁數
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 查詢條件等...
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 一頁顯示數量
        /// </summary>
        public int PageNum { get; set; }
    }
}