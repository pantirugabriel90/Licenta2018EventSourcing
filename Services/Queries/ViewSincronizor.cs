using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using CQRSlite.Events;
using DataLayer;
using DataLayer.RavenDB;
using Domain.ContextEntities;
using Raven.Client.Documents;

namespace Services.Queries
{
    public interface IViewSincronizor
    {
        void Sincornize();
    }
    public  class ViewSincronizor : IViewSincronizor
    {
        private ApplicationContext _context;
        private IDocumentStore _store;
        private Stopwatch _stopWatch;
        private bool _sincronized;
        public ViewSincronizor(IDocumentStoreHolder documentStore)
        {
            _context = new ApplicationContext();
            _store = documentStore.Store;
        }

        public void Sincornize()
        {
            _stopWatch = Stopwatch.StartNew();

            while (!_sincronized)
            {
                if (_stopWatch.Elapsed.Seconds > 3)
                    throw new Exception("Unable to sincronize views with events");

                CheckSincronization();
            }
        }

        private void CheckSincronization()
        {
            using (var session = _store.OpenSession())
            {
               var  numberOfEvents = session.Query<Event>().Customize(x => x.WaitForNonStaleResults()).Count();

                var NumberOfProcessedEvent =
                    _context.Views.FirstOrDefault().NumberOfProcessedEvent;
                if (NumberOfProcessedEvent == numberOfEvents)
                {
                    _sincronized = true;
                }
            }
        }


    }
}
