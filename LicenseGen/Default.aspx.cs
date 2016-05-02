﻿using System;
using System.Web;
using System.Web.UI;

namespace InstaFollow.LicenseGen
{
	public partial class Default : Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
		}

	    protected void OnClickBtnGetLicense(object sender, EventArgs e)
	    {
	        if (!this.SaveUserData())
	        {
	            return;
	        }

	        if (!this.PerformPaypalPayment())
	        {
	            return;
	        }

	        var licenseCode = this.GetLicenseKey();
	        if (licenseCode == string.Empty)
	        {
	            return;
	        }

            this.tbLicense.Text = licenseCode;
	    }

	    private bool PerformPaypalPayment()
	    {
	        return true;
	    }

	    private string GetLicenseKey()
	    {
	        var machineKey = this.Request.QueryString["machinekey"];

	        if (machineKey == null)
	        {
	            return string.Empty;
	        }

	        var licenseServer = new LicenceServer();
	        return licenseServer.GenerateLicenceKey(machineKey.GetHashCode());
	    }

	    private bool SaveUserData()
	    {
            return true;
	    }
	}
}