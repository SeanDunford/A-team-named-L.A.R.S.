﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Web.Security;
using System.Text;


namespace BayHelper.Com.Models
{

    public class WebProfile
    {

        private System.Web.Profile.ProfileBase _profileBase;

        public WebProfile()
        {
            this._profileBase = new System.Web.Profile.ProfileBase();
        }

        public WebProfile(System.Web.Profile.ProfileBase profileBase)
        {
            this._profileBase = profileBase;
        }

        public virtual int UserId
        {
            get
            {
                return ((int)(this.GetPropertyValue("UserId")));
            }
            set
            {
                this.SetPropertyValue("UserId", value);
            }
        }

        public static WebProfile Current
        {
            get
            {
                return new WebProfile(System.Web.HttpContext.Current.Profile);
            }
        }

        public virtual System.Web.Profile.ProfileBase ProfileBase
        {
            get
            {
                return this._profileBase;
            }
        }

        public virtual object this[string propertyName]
        {
            get
            {
                return this._profileBase[propertyName];
            }
            set
            {
                this._profileBase[propertyName] = value;
            }
        }

        public virtual string UserName
        {
            get
            {
                return this._profileBase.UserName;
            }
        }

        public virtual bool IsAnonymous
        {
            get
            {
                return this._profileBase.IsAnonymous;
            }
        }

        public virtual bool IsDirty
        {
            get
            {
                return this._profileBase.IsDirty;
            }
        }

        public virtual System.DateTime LastActivityDate
        {
            get
            {
                return this._profileBase.LastActivityDate;
            }
        }

        public virtual System.DateTime LastUpdatedDate
        {
            get
            {
                return this._profileBase.LastUpdatedDate;
            }
        }

        public virtual System.Configuration.SettingsProviderCollection Providers
        {
            get
            {
                return this._profileBase.Providers;
            }
        }

        public virtual System.Configuration.SettingsPropertyValueCollection PropertyValues
        {
            get
            {
                return this._profileBase.PropertyValues;
            }
        }

        public virtual System.Configuration.SettingsContext Context
        {
            get
            {
                return this._profileBase.Context;
            }
        }

        public virtual bool IsSynchronized
        {
            get
            {
                return this._profileBase.IsSynchronized;
            }
        }

        public static System.Configuration.SettingsPropertyCollection Properties
        {
            get
            {
                return System.Web.Profile.ProfileBase.Properties;
            }
        }

        public static WebProfile GetProfile(string username)
        {
            return new WebProfile(System.Web.Profile.ProfileBase.Create(username));
        }

        public static WebProfile GetProfile(string username, bool authenticated)
        {
            return new WebProfile(System.Web.Profile.ProfileBase.Create(username, authenticated));
        }

        public virtual object GetPropertyValue(string propertyName)
        {
            return this._profileBase.GetPropertyValue(propertyName);
        }

        public virtual void SetPropertyValue(string propertyName, object propertyValue)
        {
            this._profileBase.SetPropertyValue(propertyName, propertyValue);
        }

        public virtual System.Web.Profile.ProfileGroupBase GetProfileGroup(string groupName)
        {
            return this._profileBase.GetProfileGroup(groupName);
        }

        public virtual void Initialize(string username, bool isAuthenticated)
        {
            this._profileBase.Initialize(username, isAuthenticated);
        }

        public virtual void Save()
        {
            this._profileBase.Save();
        }

        public virtual void Initialize(System.Configuration.SettingsContext context, System.Configuration.SettingsPropertyCollection properties, System.Configuration.SettingsProviderCollection providers)
        {
            this._profileBase.Initialize(context, properties, providers);
        }

        public static System.Configuration.SettingsBase Synchronized(System.Configuration.SettingsBase settingsBase)
        {
            return System.Web.Profile.ProfileBase.Synchronized(settingsBase);
        }

        public static System.Web.Profile.ProfileBase Create(string userName)
        {
            return System.Web.Profile.ProfileBase.Create(userName);
        }

        public static System.Web.Profile.ProfileBase Create(string userName, bool isAuthenticated)
        {
            return System.Web.Profile.ProfileBase.Create(userName, isAuthenticated);
        }
    }
}