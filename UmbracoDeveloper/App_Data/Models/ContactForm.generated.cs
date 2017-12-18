//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.7.99
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>ContactForm</summary>
	[PublishedContentModel("contactForm")]
	public partial class ContactForm : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "contactForm";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ContactForm(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ContactForm, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Address: address of company
		///</summary>
		[ImplementPropertyType("address")]
		public string Address
		{
			get { return this.GetPropertyValue<string>("address"); }
		}

		///<summary>
		/// companyName: Name of the company
		///</summary>
		[ImplementPropertyType("companyName")]
		public string CompanyName
		{
			get { return this.GetPropertyValue<string>("companyName"); }
		}

		///<summary>
		/// emailId: General email for correspondence
		///</summary>
		[ImplementPropertyType("emailId")]
		public string EmailId
		{
			get { return this.GetPropertyValue<string>("emailId"); }
		}

		///<summary>
		/// phoneNo
		///</summary>
		[ImplementPropertyType("phoneNo")]
		public string PhoneNo
		{
			get { return this.GetPropertyValue<string>("phoneNo"); }
		}
	}
}
