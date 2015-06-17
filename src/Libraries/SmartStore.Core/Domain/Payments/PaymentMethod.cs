﻿using System.Runtime.Serialization;

namespace SmartStore.Core.Domain.Payments
{
	/// <summary>
	/// Represents a payment method
	/// </summary>
	[DataContract]
	public partial class PaymentMethod : BaseEntity
	{
		/// <summary>
		/// Gets or sets the payment method system name
		/// </summary>
		[DataMember]
		public string PaymentMethodSystemName { get; set; }

		/// <summary>
		/// Gets or sets identifiers of customer roles (comma separated) to be excluded in checkout
		/// </summary>
		[DataMember]
		public string ExcludedCustomerRoleIds { get; set; }

		/// <summary>
		/// Gets or sets identifiers of countries (comma separated) to be excluded in checkout
		/// </summary>
		[DataMember]
		public string ExcludedCountryIds { get; set; }

		/// <summary>
		/// Gets or sets shipping methods (comma separated) to be excluded in checkout
		/// </summary>
		[DataMember]
		public string ExcludedShippingMethodIds { get; set; }

		/// <summary>
		/// Gets or sets the context identifier for country exclusion
		/// </summary>
		[DataMember]
		public int CountryExclusionContextId { get; set; }

		/// <summary>
		/// Gets or sets the country exclusion context
		/// </summary>
		[DataMember]
		public CountryExclusionContextType CountryExclusionContext
		{
			get
			{
				return (CountryExclusionContextType)this.CountryExclusionContextId;
			}
			set
			{
				this.CountryExclusionContextId = (int)value;
			}
		}
	}
}