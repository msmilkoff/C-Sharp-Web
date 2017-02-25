namespace PizzaMore.Utility
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CookieCollection : ICookieCollection
    {
        private IDictionary<string, Cookie> cookies;

        public CookieCollection()
        {
            this.cookies = new Dictionary<string, Cookie>();
        }

        public Cookie this[string key]
        {
            get
            {
                if (!this.cookies.ContainsKey(key))
                {
                    string message = string.Format(Constants.CookieNotFound, key);
                    throw new KeyNotFoundException(message);
                }

                return this.cookies[key];
            }

            set
            {
                this.cookies[key] = value;
            }
        }

        public IDictionary<string, Cookie> Cookies => this.cookies;

        public int Count => this.cookies.Count;


        public void AddCookie(Cookie cookie)
        {
            if (!this.cookies.ContainsKey(cookie.Name))
            {
                this.cookies.Add(cookie.Name, cookie);
            }
            else
            {
                throw new ArgumentException(string.Format(Constants.CookieAlreadyExists, cookie.Name));
            }
        }

        public bool ContainsKey(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public void RemoveCookie(string cookieName)
        {
            this.cookies.Remove(cookieName);
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<Cookie> IEnumerable<Cookie>.GetEnumerator()
        {
            return this.cookies.Values.GetEnumerator();
        }
    }
}
