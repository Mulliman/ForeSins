using Blazor.IndexedDB.WebAssembly;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App.Database
{
    public class ContextDb : IndexedDb
    {
        public ContextDb(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }

        public IndexedSet<Round> Rounds { get; set; }
    }
}
