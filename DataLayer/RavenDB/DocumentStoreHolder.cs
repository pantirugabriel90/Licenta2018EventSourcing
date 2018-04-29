using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.RavenDB
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }

    }


    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        public IDocumentStore Store { get; }


        public DocumentStoreHolder(IOptions<RavenSettings> ravenSettings)
        {
            var settings = ravenSettings.Value;

            Store = new DocumentStore()
            {
                Urls = new[] { settings.Url },
                Database = settings.Database
            };

            Store.Initialize();

        }
        public DocumentStoreHolder(RavenSettings ravenSettings)
        {
            Store = new DocumentStore()
            {
                Urls = new[] { ravenSettings.Url },
                Database = ravenSettings.Database
            };

            Store.Initialize();

        }

    }
}
