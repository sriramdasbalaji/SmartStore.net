﻿using SmartStore.Web.Framework;
using SmartStore.Web.Framework.Mvc;

namespace SmartStore.Admin.Models.Orders
{
    public class BestsellersReportLineModel : ModelBase
    {
        public int ProductVariantId { get; set; }
        [SmartResourceDisplayName("Admin.SalesReport.Bestsellers.Fields.Name")]
        public string ProductVariantFullName { get; set; }

        [SmartResourceDisplayName("Admin.SalesReport.Bestsellers.Fields.TotalAmount")]
        public string TotalAmount { get; set; }

        [SmartResourceDisplayName("Admin.SalesReport.Bestsellers.Fields.TotalQuantity")]
        public decimal TotalQuantity { get; set; }
    }
}