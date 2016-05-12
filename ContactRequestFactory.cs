﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithnet.GoogleApps
{
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using Api;
    using Google.Apis.Admin.Directory.directory_v1;
    using Google.Contacts;
    using Google.GData.Apps;
    using Google.GData.Contacts;
    using Google.GData.Client;
    using Google.GData.Extensions.Apps;
    using ManagedObjects;
    using Newtonsoft.Json;

    public static class ContactRequestFactory
    {
        public static void GetContacts(string domain,  BlockingCollection<object> importObjects)
        {
            foreach (ContactEntry entry in GetContacts(domain))
            {
                importObjects.Add(entry);
            }
        }

        public static IEnumerable<ContactEntry> GetContacts(string domain)
        {
            using (PoolItem<ContactsService> connection = ConnectionPools.ContactsServicePool.Take())
            {
                string uri = ContactsQuery.CreateContactsUri(domain);

                do
                {
                    ContactsQuery request = new ContactsQuery(uri)
                    {
                        NumberToRetrieve = 1000

                    };

                    ContactsFeed x = connection.Item.Query(request);

                    foreach (ContactEntry entry in x.Entries.OfType<ContactEntry>())
                    {
                        yield return entry;
                    }

                    uri = x.NextChunk;

                } while (uri != null);

            }
        }

        public static Contact GetContact(string id)
        {
            using (PoolItem<ContactsService> connection = ConnectionPools.ContactsServicePool.Take())
            {
                ContactsRequest cr = new ContactsRequest(new RequestSettings("Lithnet.GoogleApps"));
                cr.Service = connection.Item;

                return cr.Retrieve<Contact>(new Uri(id));
            }
        }

        public static void DeleteContact(string id)
        {
            using (PoolItem<ContactsService> connection = ConnectionPools.ContactsServicePool.Take())
            {
                ContactsRequest cr = new ContactsRequest(new RequestSettings("Lithnet.GoogleApps"));
                cr.Service = connection.Item;

                Contact c= cr.Retrieve<Contact>(new Uri(id));
                connection.Item.Delete(c.ContactEntry.EditUri.ToString());
            }
        }

        public static void DeleteContact(ContactEntry c)
        {
            using (PoolItem<ContactsService> connection = ConnectionPools.ContactsServicePool.Take())
            {
                connection.Item.Delete(c.EditUri.ToString());
            }
        }

        public static void DeleteContact(Contact c)
        {
            using (PoolItem<ContactsService> connection = ConnectionPools.ContactsServicePool.Take())
            {
                connection.Item.Delete(c.ContactEntry);
            }
        }


        public static Contact UpdateContact(Contact c)
        {
            using (PoolItem<ContactsService> connection = ConnectionPools.ContactsServicePool.Take())
            {
                ContactsRequest cr = new ContactsRequest(new RequestSettings("Lithnet.GoogleApps"));
                cr.Service = connection.Item;
                return cr.Update(c);
            }
        }

        public static Contact CreateContact(Contact c, string domain)
        {
            using (PoolItem<ContactsService> connection = ConnectionPools.ContactsServicePool.Take())
            {
                ContactsRequest cr = new ContactsRequest(new RequestSettings("Lithnet.GoogleApps"));
                cr.Service = connection.Item;
                
                return cr.Insert(new Uri($"https://www.google.com/m8/feeds/contacts/{domain}/full"), c);
            }
        }
    }
}
