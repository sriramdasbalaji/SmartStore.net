﻿using System.Collections.Generic;
using System.Web.Mvc;
using SmartStore.Web.Framework;
using SmartStore.Web.Framework.Mvc;

namespace SmartStore.Plugin.Shipping.ByTotal.Models
{
    public class ShippingByTotalListModel : ModelBase
    {
        public ShippingByTotalListModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
            AvailableShippingMethods = new List<SelectListItem>();
            Records = new List<ShippingByTotalModel>();
        }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.Country")]
        public int? AddCountryId { get; set; }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.StateProvince")]
        public int? AddStateProvinceId { get; set; }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.Zip")]
        public string AddZip { get; set; }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.ShippingMethod")]
        public int AddShippingMethodId { get; set; }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.From")]
        public decimal AddFrom { get; set; }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.To")]
        public decimal? AddTo { get; set; }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.UsePercentage")]
        public bool AddUsePercentage { get; set; }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.ShippingChargePercentage")]
        public decimal AddShippingChargePercentage { get; set; }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.ShippingChargeAmount")]
        public decimal AddShippingChargeAmount { get; set; }

        [SmartResourceDisplayName("Plugins.Shipping.ByTotal.Fields.LimitMethodsToCreated")]
        public bool LimitMethodsToCreated { get; set; }

        public string PrimaryStoreCurrencyCode { get; set; }

        public IList<SelectListItem> AvailableCountries { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }
        public IList<SelectListItem> AvailableShippingMethods { get; set; }
        public IList<ShippingByTotalModel> Records { get; set; }
    }
}