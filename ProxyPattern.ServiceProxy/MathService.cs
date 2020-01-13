﻿using ProxyPattern.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.ServiceProxy
{
    public class MathService : IMathService
    {
        private IMathService _channel;

        public MathService()
        {
            Initialize();
        }

        public void Initialize()
        {
            var address = new EndpointAddress("http://localhost:53422/MathService.svc");
            var bind = new BasicHttpBinding();
            var factory = new ChannelFactory<IMathService>(bind, address);
            this._channel = factory.CreateChannel();
        }

        public double Add(double a, double b)
        {
            return _channel.Add(a, b);
        }
    }
}