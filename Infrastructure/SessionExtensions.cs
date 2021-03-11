using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Infrastructure
{
    public static class SessionExtensions
    {
        //is a tool to convert our Cart object to a Json (string) file, and then back (because we can't store carts in a session)
        public static void SetJson (this ISession session, string key, object value)
        {
            //sets a string equal to the key that we pass in and the value
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        //gets a session passed in (the information regarding the session), then we need the key to pull the value out of the session
        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            //if the sessionData is null, pass back the key, other wise, use the json serializer to deserialize, of the type T, the sesion data that was passed in
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
