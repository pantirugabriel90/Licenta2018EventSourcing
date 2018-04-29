using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using CQRSlite.Events;
using DataLayer;
using DataLayer.RavenDB;
using Domain.Views.Entities;
using Raven.Client.Documents;

namespace Services.Queries
{
    public interface IViewSincronizor
    {
        void Sincornize(string viewName);
    }
    public  class ViewSincronizor : IViewSincronizor
    {
        private ApplicationContext _context;
        private IDocumentStore _store;
        private Stopwatch _stopWatch;
        private System.Timers.Timer _timer;
        private string _viewName;
        private bool _sincronized;
        public ViewSincronizor(IDocumentStoreHolder documentStore)
        {

            //_timer = new System.Timers.Timer(100);
            //_timer.AutoReset = true;
            //_timer.Elapsed += new System.Timers.ElapsedEventHandler(CheckSincronization);
            _context = new ApplicationContext();
            _store = documentStore.Store;
        }

        public void Sincornize(string viewName)
        {
            _viewName = viewName;
            var frequency = 30;
            var timeCounter = 0;
            //_timer.Start();
            _stopWatch = Stopwatch.StartNew();

            while (!_sincronized)
            {
                if (_stopWatch.Elapsed.Milliseconds > timeCounter)
                {
                    CheckSincronization();
                }
                if (_sincronized)
                    timeCounter += frequency;

            }

        }

        private void CheckSincronization()
        {

            if (_stopWatch.Elapsed.Seconds > 2)
                throw new Exception("Unable to sincronize views with events");

            using (var session = _store.OpenSession())
            {
               var  numberOfEvents = session.Query<Event>().Count();

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
