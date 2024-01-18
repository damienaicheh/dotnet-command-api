using System;
using System.Collections.Generic;
using CommandAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CommandAPI.Data
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        private readonly IMemoryCache _cache;

        public MockCommandAPIRepo(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _cache.Set(cmd.Id, cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _cache.Remove(cmd.Id);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            // store list of commands in cache memory
            if (!_cache.TryGetValue("myKey", out List<Command> commands))
            {
                return commands;
            }
            else
            {
                commands = new List<Command>();
                _cache.Set("myKey", commands);
                return commands;
            }
        }

        public Command GetCommandById(int id)
        {
            return _cache.Get<Command>(id);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateCommand(Command cmd)
        {
            _cache.Set(cmd.Id, cmd);
        }
    }
}