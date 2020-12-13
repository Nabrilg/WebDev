using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDev.Application.Models;

namespace WebDev.Application.Utils
{
    public class CacheManagement
    {
        // Class for Cache Memory changes management 

        public IMemoryCache _cache;

        public MemoryCacheEntryOptions cacheEntryOptions;
        
        public CacheManagement(IMemoryCache memoryCache)
        {
            cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            _cache = memoryCache;
        }
        public void FillConcepts(string key, List<Concept> concept)
        {
            _cache.Set(key, concept, cacheEntryOptions);
        }
        public void FillUsers(string key, List<User> user)
        {
            _cache.Set(key, user, cacheEntryOptions);
        }

        public void CreateCacheConcept(string key, Concept concept)
        {
            _cache.Set(key, concept, cacheEntryOptions);
        }

        public void CreateCacheUser(string key, User user)
        {
            _cache.Set(key, user, cacheEntryOptions);
        }

        public void UpdateCacheConcept(string key, Concept concept)
        {
            var fromCache = _cache.Get<List<Concept>>(key);
            fromCache[fromCache.FindIndex(ind => ind.Id.Equals(concept.Id))] = concept;
            _cache.Set(key, fromCache, cacheEntryOptions);
        }

        public void UpdateCacheUser(string key, User user)
        {
            var fromCache = _cache.Get<List<User>>(key);
            fromCache[fromCache.FindIndex(ind => ind.Id.Equals(user.Id))] = user;
            _cache.Set(key, fromCache, cacheEntryOptions);
        }

        public void DeleteCacheUser(string key, User user)
        {
            var fromCache = _cache.Get<List<User>>(key);
            fromCache.RemoveAt(fromCache.FindIndex(ind => ind.Id.Equals(user.Id)));
            _cache.Set(key, fromCache, cacheEntryOptions);
        }

        public void DeleteCacheConcept(string key, Concept concept)
        {
            var fromCache = _cache.Get<List<Concept>>(key);
            fromCache.RemoveAt(fromCache.FindIndex(ind => ind.Id.Equals(concept.Id)));
            _cache.Set(key, fromCache, cacheEntryOptions);
        }

        public void EmptyCache()
        {
            _cache.Remove(CacheKeys.Concepts);
            _cache.Remove(CacheKeys.Users);
        }
    }
}
