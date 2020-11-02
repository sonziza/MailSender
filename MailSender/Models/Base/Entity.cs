﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Models.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }
    public abstract class NamedEntity : Entity
    {
        public string Name { get; set; }
    }

    public abstract class Person : NamedEntity
    {
        public string Address { get; set; }
    }
}
