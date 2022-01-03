﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SoftEtherApi.Containers;

namespace SoftEtherApi.Model
{
    public class DhcpRouteCollection : IEnumerable<DhcpRoute>, ISoftEtherCollection
    {
        public List<DhcpRoute> Routes { get; set; } = new List<DhcpRoute>();
        
        public void Add(object val)
        {
            Routes.AddRange(DhcpRoute.FromCsv((string)val));
        }
        
        public void Add(DhcpRoute val)
        {
            Routes.Add(val);
        }
        
        public void Add(string ipNetwork, string subnet, string gateway)
        {
            Routes.Add(new DhcpRoute(ipNetwork, subnet, gateway));
        }

        public override string ToString()
        {
            return this.Select(m => m.ToString()).Aggregate((s, s1) => $"{s},{s1}");
        }
        
        public IEnumerator<DhcpRoute> GetEnumerator()
        {
            return Routes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}