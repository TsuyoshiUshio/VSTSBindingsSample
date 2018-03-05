﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VSTSBindings
{

    public class Rootobject
    {
        public int count { get; set; }
        public Value[] value { get; set; }
    }

    public class Value
    {
        public _Links _links { get; set; }
        public string quality { get; set; }
        public Authoredby authoredBy { get; set; }
        public object[] drafts { get; set; }
        public Queue queue { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string uri { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public string queueStatus { get; set; }
        public int revision { get; set; }
        public DateTime createdDate { get; set; }
        public Project project { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
        public Web web { get; set; }
        public Editor editor { get; set; }
    }

    public class Self
    {
        public object href { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
    }

    public class Editor
    {
        public string href { get; set; }
    }

    public class Authoredby
    {
        public string displayName { get; set; }
        public string url { get; set; }
        public string id { get; set; }
        public string uniqueName { get; set; }
        public string imageUrl { get; set; }
        public string descriptor { get; set; }
    }

    public class Queue
    {
        public _Links1 _links { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Pool pool { get; set; }
    }

    public class _Links1
    {
        public Self1 self { get; set; }
    }

    public class Self1
    {
        public string href { get; set; }
    }

    public class Pool
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isHosted { get; set; }
    }

    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string state { get; set; }
        public int revision { get; set; }
        public string visibility { get; set; }
    }

}
