using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductService.Models
{
    public class InMemoryContext
    {
        private static InMemoryContext instance = null;
        public static InMemoryContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InMemoryContext();
                }
                return instance;
            }
        }

        public List<Team> Teams { get; set; }

        private InMemoryContext()
        {
            this.Reset();
            this.Initialize();
        }

        public void Reset()
        {
            this.Teams = new List<Team>();
        }
        public void Initialize()
        {
            this.Teams.AddRange(new List<Team> 
            {
                new Team{Id=1, Name="Uber"},
                new Team{Id=2, Name="Genesis"}
            });

        }
    }
}