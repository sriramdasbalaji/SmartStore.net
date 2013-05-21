﻿using System.Web;
using System.Web.Routing;
using SmartStore.Core.Plugins;
using SmartStore.Plugin.Feed.Froogle.Data;
using SmartStore.Plugin.Feed.Froogle.Services;
using SmartStore.Services.Common;
using SmartStore.Services.Configuration;
using SmartStore.Services.Localization;

namespace SmartStore.Plugin.Feed.Froogle
{
    public class FroogleService : BasePlugin, IMiscPlugin
    {
        private readonly IGoogleService _googleService;
        private readonly ISettingService _settingService;
        private readonly GoogleProductObjectContext _objectContext;
		private readonly ILocalizationService _localizationService;	// codehint: sm-add

        public FroogleService(
			IGoogleService googleService,
            ISettingService settingService,
            GoogleProductObjectContext objectContext,
			ILocalizationService localizationService)
        {
            this._googleService = googleService;
            this._settingService = settingService;
            this._objectContext = objectContext;
			this._localizationService = localizationService;	// codehint: sm-add
        }

        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "FeedFroogle";
            routeValues = new RouteValueDictionary() { { "Namespaces", "SmartStore.Plugin.Feed.Froogle.Controllers" }, { "area", null } };
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            var settings = new FroogleSettings()
            {
                ProductPictureSize = 125,
				StaticFileName = "google_merchant_center_{0}.xml".FormatWith(HttpContext.Current.Request.Url.Authority.Prettify().ToLower()),
				CurrencyId = _googleService.Helper.CurrencyID,
				Condition = "new",
				OnlineOnly = true,
				AdditionalImages = true,
				SpecialPrice = true
			};
            _settingService.SaveSetting(settings);

            _objectContext.Install();

			_localizationService.ImportPluginResourcesFromXml(this.PluginDescriptor);

			// codehint: sm-edit (refactored)
			_googleService.Helper.ScheduleTaskInsert();

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            _settingService.DeleteSetting<FroogleSettings>();

            _objectContext.Uninstall();

			_localizationService.DeleteLocaleStringResources(this.PluginDescriptor.ResourceRootKey);

			// codehint: sm-edit (refactored)
			_googleService.Helper.ScheduleTaskDelete();

            base.Uninstall();
        }
    }
}