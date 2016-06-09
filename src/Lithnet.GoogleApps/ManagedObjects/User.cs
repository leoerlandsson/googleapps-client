﻿namespace Lithnet.GoogleApps.ManagedObjects
{
    using Google.Apis.Requests;
    using Google.Apis.Util;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Collections.ObjectModel;
    using System.Collections;

    public class User : IDirectResponseSchema, ISerializable
    {
        public List<Address> Addresses { get; set; }

        public bool? AgreedToTerms { get; private set; }

        public ReadOnlyCollection<string> Aliases
        {
            get
            {
                if (this.AliasesInternal == null)
                {
                    return null;
                }
                else
                {
                    return new ReadOnlyCollection<string>(this.AliasesInternal);
                }
            }
        }

        private List<string> AliasesInternal { get; set; }

        public bool? ChangePasswordAtNextLogin { get; set; }

        public DateTime? CreationTime
        {
            get
            {
                if (this.CreationTimeRaw == null)
                {
                    return null;
                }

                return DateTime.ParseExact(this.CreationTimeRaw, @"MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal);
            }
            private set
            {
                this.CreationTimeRaw = Utilities.GetStringFromDateTime(value);
            }
        }

        private string CreationTimeRaw { get; set; }

        public string CustomerId { get; set; }

        public IDictionary<string, IDictionary<string, object>> CustomSchemas { get; set; }

        public DateTime? DeletionTime
        {
            get
            {
                return Utilities.GetDateTimeFromString(this.DeletionTimeRaw);
            }
            private set
            {
                this.DeletionTimeRaw = Utilities.GetStringFromDateTime(value);
            }
        }

        public string DeletionTimeRaw { get; private set; }

        public List<Email> Emails { get; set; }

        public string ETag { get; set; }

        public List<ExternalID> ExternalIds { get; set; }

        public string HashFunction { get; set; }

        public string Id { get; set; }

        public List<IM> Ims { get; set; }

        public bool? IncludeInGlobalAddressList { get; set; }

        public bool? IpWhitelisted { get; set; }

        public bool? IsAdmin { get; private set; }

        public bool? IsDelegatedAdmin { get; private set; }

        public bool? IsMailboxSetup { get; private set; }

        private string Kind { get; set; }

        public DateTime? LastLoginTime
        {
            get
            {
                return Utilities.GetDateTimeFromString(this.LastLoginTimeRaw);
            }
            private set
            {
                this.LastLoginTimeRaw = Utilities.GetStringFromDateTime(value);
            }
        }

        private string LastLoginTimeRaw { get; set; }

        public UserName Name { get; set; }

        public ReadOnlyCollection<string> NonEditableAliases
        {
            get
            {
                if (this.NonEditableAliasesInternal == null)
                {
                    return null;
                }
                else
                {
                    return new ReadOnlyCollection<string>(this.NonEditableAliasesInternal);
                }
            }
        }

        private List<string> NonEditableAliasesInternal { get; set; }

        public Notes Notes { get; set; }

        public List<Organization> Organizations { get; set; }

        public string OrgUnitPath { get; set; }

        public string Password { get; set; }

        public List<Phone> Phones { get; set; }

        public string PrimaryEmail { get; set; }

        public List<Relation> Relations { get; set; }

        public bool? Suspended { get; set; }

        public string SuspensionReason { get; private set; }

        public string ThumbnailPhotoEtag { get; private set; }

        public string ThumbnailPhotoUrl { get; private set; }

        public List<Website> Websites { get; set; }

        internal bool Creating { get; }

        public User()
        {
            if (this.Name == null)
            {
                this.Name = new UserName();
            }
        }

        public User(bool creating)
            :this()
        {
            this.Creating = creating;
        }

        protected User(SerializationInfo info, StreamingContext context)
            :this()
        {
            foreach (SerializationEntry entry in info)
            {
                switch (entry.Name)
                {
                    case "primaryEmail":
                        this.PrimaryEmail = info.GetString(entry.Name);
                        break;

                    case "addresses":
                        this.Addresses = (List<Address>)info.GetValue(entry.Name, typeof(List<Address>));
                        break;

                    case "agreedToTerms":
                        this.AgreedToTerms = info.GetBoolean(entry.Name);
                        break;

                    case "aliases":
                        this.AliasesInternal = (List<string>)info.GetValue(entry.Name, typeof(List<string>));
                        break;

                    case "changePasswordAtNextLogin":
                        this.ChangePasswordAtNextLogin = info.GetBoolean(entry.Name);
                        break;

                    case "deletionTime":
                        this.DeletionTimeRaw = info.GetString(entry.Name);
                        break;

                    case "creationTime":
                        this.CreationTimeRaw = info.GetString(entry.Name);
                        break;

                    case "lastLoginTime":
                        this.LastLoginTimeRaw = info.GetString(entry.Name);
                        break;

                    case "customerId":
                        this.CustomerId = info.GetString(entry.Name);
                        break;

                    case "emails":
                        this.Emails = (List<Email>)info.GetValue(entry.Name, typeof(List<Email>));
                        break;

                    case "etag":
                        this.ETag = info.GetString(entry.Name);
                        break;

                    case "externalIds":
                        this.ExternalIds = (List<ExternalID>)info.GetValue(entry.Name, typeof(List<ExternalID>));
                        break;

                    case "id":
                        this.Id = info.GetString(entry.Name);
                        break;

                    case "ims":
                        this.Ims = (List<IM>)info.GetValue(entry.Name, typeof(List<IM>));
                        break;

                    case "includeInGlobalAddressList":
                        this.IncludeInGlobalAddressList = info.GetBoolean(entry.Name);
                        break;

                    case "ipWhitelisted":
                        this.IpWhitelisted = info.GetBoolean(entry.Name);
                        break;

                    case "isAdmin":
                        this.IsAdmin = info.GetBoolean(entry.Name);
                        break;

                    case "isDelegatedAdmin":
                        this.IsDelegatedAdmin = info.GetBoolean(entry.Name);
                        break;

                    case "isMailboxSetup":
                        this.IsMailboxSetup = info.GetBoolean(entry.Name);
                        break;

                    case "kind":
                        this.Kind = info.GetString(entry.Name);
                        break;

                    case "name":
                        this.Name = (UserName)info.GetValue(entry.Name, typeof(UserName));
                        break;

                    case "nonEditableAliases":
                        this.NonEditableAliasesInternal = (List<string>)info.GetValue(entry.Name, typeof(List<string>));
                        break;

                    case "notes":
                        this.Notes = (Notes)info.GetValue(entry.Name, typeof(Notes));
                        break;

                    case "organizations":
                        this.Organizations = (List<Organization>)info.GetValue(entry.Name, typeof(List<Organization>));
                        break;

                    case "orgUnitPath":
                        this.OrgUnitPath = info.GetString(entry.Name);
                        break;

                    case "phones":
                        this.Phones = (List<Phone>)info.GetValue(entry.Name, typeof(List<Phone>));
                        break;

                    case "websites":
                        this.Websites = (List<Website>)info.GetValue(entry.Name, typeof(List<Website>));
                        break;

                    case "relations":
                        this.Relations = (List<Relation>)info.GetValue(entry.Name, typeof(List<Relation>));
                        break;

                    case "suspended":
                        this.Suspended = info.GetBoolean(entry.Name);
                        break;

                    case "suspensionReason":
                        this.SuspensionReason = info.GetString(entry.Name);
                        break;

                    case "thumbnailPhotoEtag":
                        this.ThumbnailPhotoEtag = info.GetString(entry.Name);
                        break;

                    case "thumbnailPhotoUrl":
                        this.ThumbnailPhotoUrl = info.GetString(entry.Name);
                        break;

                    case "customSchemas":
                        this.CustomSchemas = (IDictionary<string, IDictionary<string, object>>)info.GetValue(entry.Name, typeof(IDictionary<string, IDictionary<string, object>>));
                        break;

                    default:
                        break;
                }
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (this.Suspended.HasValue)
            {
                info.AddValue("suspended", this.Suspended.Value);
            }

            if (this.ExternalIds != null)
            {
                info.AddValue("externalIds", this.ExternalIds);
            }

            if (this.Addresses != null)
            {
                    info.AddValue("addresses", this.Addresses);
            }

            if (this.CustomerId != null)
            {
                info.AddValue("customerId", this.CustomerId);
            }

            if (this.CustomSchemas != null)
            {
                info.AddValue("customSchemas", this.CustomSchemas);
            }

            if (this.Id != null)
            {
                info.AddValue("id", this.Id);
            }

            if (this.Ims != null)
            {
                info.AddValue("ims", this.Ims);
            }

            if (this.IncludeInGlobalAddressList != null)
            {
                info.AddValue("includeInGlobalAddressList", this.IncludeInGlobalAddressList.Value);
            }

            if (this.IpWhitelisted != null)
            {
                info.AddValue("ipWhitelisted", this.IpWhitelisted);
            }

            if (this.Kind != null)
            {
                info.AddValue("kind", this.Kind);
            }

            if (this.Name != null)
            {
                info.AddValue("name", this.Name);
            }

            if (this.Notes != null)
            {
                //if (this.Notes.Value != null)
                //{
                    info.AddValue("notes", this.Notes);
                //}
            }

            if (this.Organizations != null)
            {
                info.AddValue("organizations", this.Organizations);
            }

            if (this.OrgUnitPath != null)
            {
                info.AddValue("orgUnitPath", this.OrgUnitPath);
            }

            if (this.Password != null)
            {
                info.AddValue("password", this.Password);
            }

            if (this.Phones != null)
            {
                info.AddValue("phones", this.Phones);
            }

            if (this.PrimaryEmail != null)
            {
                info.AddValue("primaryEmail", this.PrimaryEmail);
            }

            if (this.Emails != null)
            {
                info.AddValue("emails", this.Emails);
            }

            if (this.Relations != null)
            {
                info.AddValue("relations", this.Relations);
            }

            if (this.Websites != null)
            {
                info.AddValue("websites", this.Websites);
            }
        }
    }
}