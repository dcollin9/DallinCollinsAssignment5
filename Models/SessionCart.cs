﻿using DallinCollinsAssignment5.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models
{
    //subclasses the Cart class and overrides the AddItem, RemoveLine, and Clear methods so that they call the base implementations and then store the updated state in the sesson
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Project proj, int qty)
        {
            base.AddItem(proj, qty);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Project proj)
        {
            base.RemoveLine(proj);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}